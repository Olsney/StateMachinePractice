using CodeBase.Hero;
using CodeBase.Infrastructure.StateMachine.Interfaces;
using CodeBase.Services.InputServices;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class JumpState : IExitable
    {
        private readonly HeroStateMachine _heroStateMachine;
        private readonly IInputService _inputService;
        private readonly HeroMover _heroMover;
        private readonly HeroAnimator _heroAnimator;

        public bool CanUpdate { get; private set; }
        
        public JumpState(HeroStateMachine heroStateMachine, IInputService inputService, HeroMover heroMover, HeroAnimator heroAnimator)
        {
            _heroStateMachine = heroStateMachine;
            _inputService = inputService;
            _heroMover = heroMover;
            _heroAnimator = heroAnimator;
        }

        public void Enter()
        {
            CanUpdate = true;
            
            Debug.Log("Jump state entered");

            _heroAnimator.PlayJump();
        }

        public void Exit()
        {
            CanUpdate = false;
            
            _heroAnimator.StopJump();
            
            Debug.Log("Jump state EXITED");
        }

        public void Update()
        {
            
            if (_inputService.IsJumping)
                return;
            
            if (_inputService.Direction == Vector3.zero)
                _heroStateMachine.Enter<IdleState>();
            
            if (_inputService.Direction != Vector3.zero)
                _heroStateMachine.Enter<MoveState>();
        }
    }
}