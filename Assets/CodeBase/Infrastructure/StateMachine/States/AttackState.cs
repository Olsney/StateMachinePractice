using CodeBase.Hero;
using CodeBase.Infrastructure.StateMachine.Interfaces;
using CodeBase.Services.InputServices;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine.States
{
    public class AttackState : IExitable
    {
        private readonly HeroStateMachine _heroStateMachine;
        private readonly IInputService _inputService;
        private readonly HeroMover _heroMover;
        private readonly HeroAnimator _heroAnimator;
        private readonly HeroAttack _heroAttack;
        public bool CanUpdate { get; private set; }


        public AttackState(HeroStateMachine heroStateMachine, IInputService inputService, HeroMover heroMover,
            HeroAnimator heroAnimator, HeroAttack heroAttack)
        {
            _heroStateMachine = heroStateMachine;
            _inputService = inputService;
            _heroMover = heroMover;
            _heroAnimator = heroAnimator;
            _heroAttack = heroAttack;
        }

        public void Enter()
        {
            CanUpdate = true;
            
            Debug.Log("Attack state entered");

            _heroAnimator.PlayAttack();
            _heroAttack.Attack();
        }

        public void Exit()
        {
            CanUpdate = false;
            
            Debug.Log("Attack state EXITED");
        }

        public void Update()
        {
            if (_inputService.IsAttacking == false)
            {
                // _heroAnimator.StopPlayingAttack();
                _heroStateMachine.Enter<IdleState>();
            }
        }
    }
}