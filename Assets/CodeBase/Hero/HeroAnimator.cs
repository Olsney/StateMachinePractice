﻿using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class HeroAnimator : MonoBehaviour
    {
        private static readonly int Idle = Animator.StringToHash("Idle"); 
        private static readonly int Jumping = Animator.StringToHash("Jumping");
        private static readonly int Attacking = Animator.StringToHash("Attacking");
        private static readonly int Moving = Animator.StringToHash("Moving");

        private readonly int _isJumping = Animator.StringToHash("IsJumping");
        private readonly int _isWalking = Animator.StringToHash("IsWalking");
        private readonly int _isAttacking = Animator.StringToHash("IsAttacking");
        private readonly int _speed = Animator.StringToHash("Speed");

        private Animator _animator;
        private CharacterController _characterController;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            _animator.SetFloat(_speed, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }

        public void PlayJump() => 
            _animator.SetBool(_isJumping, true);

        public void StopJump() => 
            _animator.SetBool(_isJumping, false);

        public void PlayAttack() => 
            _animator.SetTrigger(_isAttacking);

        public bool IsAttackAnimationPlaying()
        {
            for (int i = 0; i < _animator.layerCount; i++)
            {
                if (_animator.GetCurrentAnimatorStateInfo(i).IsName("Attacking"))
                    return true;
            }

            return false;
        }

        public void PlayMove() => 
            _animator.SetBool(_isWalking, true);

        public void Move(float speed)
        {
            _animator.SetBool(_isWalking, true);
            _animator.SetFloat(_speed, speed);
        }
    }
}