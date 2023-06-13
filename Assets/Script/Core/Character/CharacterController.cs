using Assets.Script.Core.Character;
using Assets.Script.Core.Library;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private BaseCharacter character = new BaseCharacter();
    private new CapsuleCollider2D collider;
    private CapsuleCollider2D triggerCollider;
    private new Rigidbody2D rigidbody;
    public GameObject prefab;
    private PlayerInput playerInput;

    private Animator animator;

    private Vector2 previousVelocity;

    void Start()
    {

        collider = gameObject.AddComponent<CapsuleCollider2D>();
        rigidbody = gameObject.AddComponent<Rigidbody2D>();

        // add trigger collider
        triggerCollider = gameObject.AddComponent<CapsuleCollider2D>();
        triggerCollider.isTrigger = true;
        triggerCollider.size = new Vector2(0.5f, 1.5f);


        // resize capsule collider to fit sprite size
        collider.size = new Vector2(0.5f, 1.5f);
        // create an instance of prefab and add it to child of this gameobject
        GameObject instanceAnimated = Instantiate(prefab, transform.position, Quaternion.identity);

        instanceAnimated.transform.position =
            new Vector3(transform.position.x,
            transform.position.y + CONST.INSTANCED_PREFAB_ANIMATION_POSITION.Y,
            transform.position.z);
        instanceAnimated.transform.parent = transform;

        playerInput = gameObject.AddComponent<PlayerInput>();
        playerInput.notificationBehavior = PlayerNotifications.InvokeUnityEvents;
        // get input action asset from resources
        InputActionAsset inputActionAsset = Resources.Load<InputActionAsset>(CONST.PLAYER_INPUT_ACTIONS_PATH);
        inputActionAsset.FindActionMap(CONST.ACTIONMAP_PLAYER).FindAction(CONST.ACTION_MOVE).performed += Move;
        inputActionAsset.FindActionMap(CONST.ACTIONMAP_PLAYER).FindAction(CONST.ACTION_JUMP).performed += Jump;

        playerInput.actions = inputActionAsset;
        playerInput.actions.Enable();


        // load animator controller from resources
        AnimatorController animatorController = Resources.Load<AnimatorController>(CONST.ANIMATOR_CONTROLLER_PATH);

        animator = instanceAnimated.GetComponent<Animator>();
        // set animator controller to animator
        animator.runtimeAnimatorController = animatorController;

        // play idle animation
        animator.Play("idle", 0, 0f);
        character.CharacterState = CharacterState.Idle;
        AnimatedLibrary.SetParameter(character.CharacterState, animator);

        previousVelocity = rigidbody.velocity;
    }

    // event enter trigger collider 2d 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == CONST.TAG_FLOOR)
        //{
        // log to console with delta time
        Debug.Log("OnTriggerEnter2D: " + Time.deltaTime);
        animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING, false);
        character.IsInGround = true;
        animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IN_GROUND, true);

        //}
    }

    // event exit trigger collider 2d
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == CONST.TAG_FLOOR)
        //{
        // log to console with delta time
        Debug.Log("OnTriggerExit2D: " + Time.deltaTime);
        if (rigidbody.velocity.y > 0.01)
        {
            character.CharacterState = CharacterState.Jumping;
            character.IsInGround = false;
            animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IN_GROUND, false);
            AnimatedLibrary.SetParameter(character.CharacterState, animator);
        }
        //}
    }

    private void onSetPlayerInput()
    {
        playerInput = gameObject.AddComponent<PlayerInput>();
        playerInput.notificationBehavior = PlayerNotifications.InvokeUnityEvents;
        // get input action asset from resources
        InputActionAsset inputActionAsset = Resources.Load<InputActionAsset>(CONST.PLAYER_INPUT_ACTIONS_PATH);
        inputActionAsset.FindActionMap(CONST.ACTIONMAP_PLAYER).FindAction(CONST.ACTION_MOVE).performed += Move;
        inputActionAsset.FindActionMap(CONST.ACTIONMAP_PLAYER).FindAction(CONST.ACTION_JUMP).performed += Jump;

        playerInput.actions = inputActionAsset;
        playerInput.actions.Enable();
    }

    void Update()
    {
        // lock rotation
        transform.rotation = Quaternion.identity;
        onFaceSide();

        // log to console state of character
        Debug.Log("Character State: " + character.CharacterState);
    }

    private void FixedUpdate()
    {
        Vector2 accelebration = rigidbody.velocity - previousVelocity;

        if (accelebration.magnitude > 0.1f)
        {
            character.IsAccelerating = true;
            animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_ACCELERATING, true);
        }
        else if (accelebration.magnitude < 0.1f)
        {
            character.IsAccelerating = false;
            animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_ACCELERATING, false);
        }

        // check gameobject is falling or not
        if (rigidbody.velocity.y < -0.5 && !character.IsInGround)
        {
            character.CharacterState = CharacterState.Falling;
            AnimatedLibrary.SetParameter(character.CharacterState, animator);
        }

        if (character.IsInGround && !character.IsAccelerating)
        {
            character.CharacterState = CharacterState.Idle;
            AnimatedLibrary.SetParameter(CharacterState.Idle, animator);
        }
        // if in ground, is accelerating, set state to walking or running
        else if (character.IsInGround && character.IsAccelerating && character.CharacterState != CharacterState.Running)
        {
            character.CharacterState = CharacterState.Walking;
            AnimatedLibrary.SetParameter(CharacterState.Walking, animator);
        } else if (character.IsInGround && character.IsAccelerating && character.CharacterState != CharacterState.Walking)
        {
            character.CharacterState = CharacterState.Running;
            AnimatedLibrary.SetParameter(CharacterState.Running, animator);
        }
    }



    void onFaceSide()
    {
        if (rigidbody.velocity.x < 0)
        {
            // flip sprite to left
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rigidbody.velocity.x > 0)
        {
            // flip sprite to right
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void Move(InputAction.CallbackContext ctx)
    {
        if (character.IsInGround)
        {
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                character.CharacterState = CharacterState.Running;
                rigidbody.velocity = ctx.ReadValue<Vector2>() * 20f;
            }
            else
            {
                character.CharacterState = CharacterState.Walking;
                rigidbody.velocity = ctx.ReadValue<Vector2>() * 10f;
            }
            AnimatedLibrary.SetParameter(character.CharacterState, animator);
        }
        else if (!character.IsInGround)
        {
            if (Keyboard.current.leftShiftKey.isPressed)
            {
                rigidbody.velocity = ctx.ReadValue<Vector2>() * 20f;
            }
            else
            {
                rigidbody.velocity = ctx.ReadValue<Vector2>() * 10f;
            }
        }
    }

    void Jump(InputAction.CallbackContext ctx)
    {
        // check if character is in ground, if yes, set state to jumping
        if (character.IsInGround)
        {
            character.CharacterState = CharacterState.Jumping;
            AnimatedLibrary.SetParameter(character.CharacterState, animator);
            rigidbody.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
            character.IsInGround = false;
            animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IN_GROUND, false);
        }
    }

}
