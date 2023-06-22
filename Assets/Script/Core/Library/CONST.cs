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
        public static readonly string ANIMATOR_CONTROLLER_PATH = "AnimatorControllers/Gun2New";
        public static readonly string PREFAB_ANIMATED_PATH = "Prefabs/Sakura";


        // Virtual Camera
        public static readonly string VIRTUAL_CAMERA_NAME = "CM vcam1";
        // Player Input Actionss
        public static readonly string PLAYER_INPUT_ACTIONS_PATH = "InputActionAssets/PlayerInputActions";
        public static readonly string ACTIONMAP_PLAYER = "Player";
        public static readonly string ACTIONMAP_UI = "UI";
        public static readonly string ACTION_MOVE = "Move";
        public static readonly string ACTION_JUMP = "Jump";
        public static readonly string ACTION_RUN = "Run";
        public static readonly string ACTION_FIRE = "Fire";


        // Animator Controller Parameter
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_IN_GROUND = "isInGround";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_ACCELERATING = "isAccelerating";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_IDLE = "isIdle";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_WALKING = "isWalking";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_RUNNING = "isRunning";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_JUMPING = "isJumping";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING = "isFalling";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_ATTACKING = "isAttacking";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_DEAD = "isDead";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_TAKING_DAMAGE = "isTakingDamage";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_CASTING = "isCasting";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_STUNNED = "isStunned";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_KNOCKED_BACK = "isKnockedBack";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_KNOCKED_DOWN = "isKnockedDown";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_FROZEN = "isFrozen";
        public static readonly string ANIMATOR_CONTROLLER_PARAMETER_IS_BURNING = "isBurning";

        // game object tag
        public static readonly string TAG_PLAYER = "Player";
        public static readonly string TAG_ENEMY = "Enemy";
        public static readonly string TAG_PROJECTILE = "Projectile";
        public static readonly string TAG_FLOOR = "Floor";
    }
}
