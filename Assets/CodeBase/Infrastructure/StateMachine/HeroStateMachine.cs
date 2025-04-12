using System;
using System.Collections.Generic;
using CodeBase.Hero;
using CodeBase.Infrastructure.StateMachine.Interfaces;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.Services.InputServices;
using UnityEngine;

namespace CodeBase.Infrastructure.StateMachine
{
    public class HeroStateMachine
    {
        private readonly HeroMover _heroMover;
        private readonly HeroAnimator _heroAnimator;
        private readonly HeroAttack _heroAttack;
        private readonly IInputService _inputService;
        private IExitable _activeState;
        private IExitable _defaultState;
        private Dictionary<Type, IExitable> _states;

        public HeroStateMachine(IInputService inputService, HeroMover heroMover, HeroAnimator heroAnimator,
            HeroAttack heroAttack)
        {
            _inputService = inputService;
            _heroMover = heroMover;
            _heroAnimator = heroAnimator;
            _heroAttack = heroAttack;

            _states = new Dictionary<Type, IExitable>()
            {
                [typeof(IdleState)] = new IdleState(this, _inputService, _heroMover, _heroAnimator),
                [typeof(MoveState)] = new MoveState(this, _inputService, _heroMover, _heroAnimator),
                [typeof(JumpState)] = new JumpState(this, _inputService, _heroMover, _heroAnimator),
                [typeof(AttackState)] = new AttackState(this, _inputService, _heroMover, _heroAnimator, _heroAttack)
            };

            _defaultState = _states[typeof(IdleState)];
            
            
            if (_heroAnimator == null)
                Debug.Log("Animator null");
        }

        public void Enter<TState>() where TState : class, IExitable
        {
            if (_states.TryGetValue(typeof(TState), out IExitable nextState) == false)
                return;

            if (_activeState == null)
                _activeState = _defaultState;

            _activeState?.Exit();
            _activeState = nextState;
            _activeState.Enter();
        }

        public void Update()
        {
            // if (_activeState.CanUpdate)
            //     _activeState?.Update();
            
            _activeState?.Update();
        }
    }
}