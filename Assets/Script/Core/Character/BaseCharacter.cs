using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Core.Character
{
    public class BaseCharacter : IBaseCharacter
    {
        public BaseCharacter() { }
        private string id;
        private string nameDisplay;

        private float maxHealth;
        private float currentHealth;

        private float maxMana;
        private float currentMana;

        private float moveSpeed;
        private float jumpHeight;

        private float attackDamage;
        private float attackSpeed;
        private float attackRange;

        private CharacterState characterState;
        private bool isInGround;
        private bool isAccelerating;


        // getter and setter
        public string Id { get => id; set => id = value; }
        public string NameDisplay { get => nameDisplay; set => nameDisplay = value; }
        public float MaxHealth { get => maxHealth; set => maxHealth = value; }
        public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
        public float MaxMana { get => maxMana; set => maxMana = value; }
        public float CurrentMana { get => currentMana; set => currentMana = value; }
        public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
        public float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
        public float AttackDamage { get => attackDamage; set => attackDamage = value; }
        public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
        public float AttackRange { get => attackRange; set => attackRange = value; }
        public CharacterState CharacterState { get => characterState; set => characterState = value; }
        public bool IsInGround { get => isInGround; set => isInGround = value; }
        public bool IsAccelerating { get => isAccelerating; set => isAccelerating = value; }
    }
}
