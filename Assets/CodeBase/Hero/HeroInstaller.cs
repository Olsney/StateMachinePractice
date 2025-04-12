using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.Services.InputServices;
using UnityEngine;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(HeroMover))]
    [RequireComponent(typeof(HeroAttack))]
    [RequireComponent(typeof(HeroAnimator))]
    public class HeroInstaller : MonoBehaviour
    {
        private CharacterController _characterController;
        private HeroMover _heroMover;
        private HeroAttack _heroAttack;
        private HeroAnimator _animator;
        private IInputService _inputService;
        private HeroStateMachine _stateMachine;

        public void Construct()
        {
            _characterController = GetComponent<CharacterController>();
            _inputService = new StandaloneInputService();
            
            _heroMover = GetComponent<HeroMover>();
            _heroMover.Construct(_inputService, _characterController);

            _heroAttack = GetComponent<HeroAttack>();
            
            _animator = GetComponent<HeroAnimator>();
            
            _stateMachine = new HeroStateMachine(_inputService, _heroMover, _animator, _heroAttack);

            _stateMachine.Enter<IdleState>();
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}