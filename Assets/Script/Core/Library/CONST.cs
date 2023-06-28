using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Core.Library
{
    public class CONST
    {
        // Instanced Prefab Animation
        public static readonly Vector3 INSTANCED_PREFAB_ANIMATION_POSITION = new Vector3(1, -0.7f, 1);

        // Path to Assets Folder Resources
        public static readonly string 
            ANIMATOR_CONTROLLER_PATH = "AnimatorControllers/Gun2New"
            , PREFAB_ANIMATED_PATH = "Prefabs/Sakura"
            , PREFAB_GAMEPLAY_UI = "Prefabs/CanvasGamePlay";

        // Events
        public static readonly string 
            PATH_EVENT_FIRE = "Events/FireEvent"
            , PATH_EVENT_SWITCH_WEAPON = "Events/SwitchWeaponEvent";

        // Config File JSON
        public static readonly string FILE_WEAPON_CONFIG = "WeaponConfig";

        // UI Component Name
        public static readonly string 
            UI_COMPONENT_NAME_BTN_FIRE = "btnFire"
            , UI_COMPONENT_NAME_BTN_SWITCH_WEP_PRE = "btnSwitchWepPre"
            , UI_COMPONENT_NAME_BTN_SWITCH_WEP_NEXT = "btnSwitchWepNext";

        // Virtual Camera
        public static readonly string VIRTUAL_CAMERA_NAME = "CM vcam1";
        // Player Input Actionss
        public static readonly string 
            PLAYER_INPUT_ACTIONS_PATH = "InputActionAssets/PlayerInputActions"
            , ACTIONMAP_PLAYER = "Player"
            , ACTIONMAP_UI = "UI"
            , ACTION_MOVE = "Move"
            , ACTION_JUMP = "Jump"
            , ACTION_RUN = "Run"
            , ACTION_FIRE = "Fire"
            , ACTION_SWITCH_WEAPON = "SwitchWeapon";


        // Animator Controller Parameter
        public static readonly string 
            ANIMATOR_CONTROLLER_PARAMETER_IS_IN_GROUND = "isInGround"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_ACCELERATING = "isAccelerating"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_IDLE = "isIdle"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_WALKING = "isWalking"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_RUNNING = "isRunning"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_JUMPING = "isJumping"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING = "isFalling"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_ATTACKING = "isAttacking"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_DEAD = "isDead"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_TAKING_DAMAGE = "isTakingDamage"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_CASTING = "isCasting"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_STUNNED = "isStunned"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_KNOCKED_BACK = "isKnockedBack"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_KNOCKED_DOWN = "isKnockedDown"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_FROZEN = "isFrozen"
            , ANIMATOR_CONTROLLER_PARAMETER_IS_BURNING = "isBurning";

        // Animator UP Trigger Parameter
        public static readonly string 
            ANIMATOR_TRIGGER_BLANK = "UP_blank"
            , ANIMATOR_TRIGGER_AIM = "UP_aim"
            , ANIMATOR_TRIGGER_RELOAD1 = "UP_reload1"
            , ANIMATOR_TRIGGER_RELOAD2 = "UP_reload2"
            , ANIMATOR_TRIGGER_FIRE_SINGLE = "UP_fire light"
            , ANIMATOR_TRIGGER_FIRE_AUTO = "UP_fire light loop"
            , ANIMATOR_TRIGGER_FIRE_CHARGE = "UP_fire heavy";

        // game object tag
        public static readonly string 
            TAG_PLAYER = "Player"
            , TAG_ENEMY = "Enemy"
            , TAG_PROJECTILE = "Projectile"
            , TAG_FLOOR = "Floor";

        // scene name
        public static readonly string 
            SCENE_MAIN_MENU = "MainMenuScene"
            , SCENE_GAMEPLAY = "Gameplay"
            , SCENE_TEST = "TestScene";
    }
}
