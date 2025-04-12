using CodeBase.Hero;
using CodeBase.Infrastructure.StateMachine.Interfaces;
using CodeBase.Services.InputServices;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class MoveState : IExitable
    {
        private readonly HeroStateMachine _heroStateMachine;
        private readonly IInputService _inputService;
        private readonly HeroMover _heroMover;
        private readonly HeroAnimator _heroAnimator;
        
        public bool CanUpdate { get; private set; }

        public MoveState(HeroStateMachine heroStateMachine, IInputService inputService, HeroMover heroMover, HeroAnimator heroAnimator)
        {
            _heroStateMachine = heroStateMachine;
            _inputService = inputService;
            _heroMover = heroMover;
            _heroAnimator = heroAnimator;
        }

        public void Enter()
        {
            CanUpdate = true;
            
            Debug.Log("Move state entered");

            _heroAnimator.PlayMove();
        }

        public void Exit()
        {
            CanUpdate = false;
            
            Debug.Log("Move state EXITED");
        }

        public void Update()
        {
            _heroMover.Move();
            
            if(_inputService.IsJumping)
                _heroStateMachine.Enter<JumpState>();
            
            if(_inputService.Direction == Vector3.zero)
                _heroStateMachine.Enter<IdleState>();
            
            if(_inputService.IsAttacking)
                _heroStateMachine.Enter<AttackState>();
        }
    }
}