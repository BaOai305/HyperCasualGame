using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Script.Core.Character;

namespace Assets.Script.Core.Library
{
    internal class AnimatedLibrary
    {
        public static void SetParameter(CharacterState characterState, Animator animator)
        {
            switch (characterState)
            {
                case CharacterState.InGround:
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IN_GROUND, true);
                    break;
                case CharacterState.Idle:
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IDLE, true);

                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_WALKING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_RUNNING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_JUMPING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING, false);
                    break;
                case CharacterState.Walking:
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_WALKING, true);

                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_RUNNING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IDLE, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING, false);
                    break;

                case CharacterState.Running:
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_RUNNING, true);

                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_WALKING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IDLE, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING, false);
                    break;

                case CharacterState.Jumping:
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_JUMPING, true);

                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IDLE, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING, false);
                    break;

                case CharacterState.Falling:
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_FALLING, true);

                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_RUNNING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_WALKING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_JUMPING, false);
                    animator.SetBool(CONST.ANIMATOR_CONTROLLER_PARAMETER_IS_IDLE, false);
                    break;
            }
        }
    }
}
