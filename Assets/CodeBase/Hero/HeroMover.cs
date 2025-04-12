using CodeBase.Services.InputServices;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMover : MonoBehaviour
    {
        [field: SerializeField] private float Speed;
        
        private IInputService _inputService;
        private CharacterController _characterController;

        public void Construct(IInputService inputService, CharacterController characterController)
        {
            _inputService = inputService;
            _characterController = characterController;
        }

        public void Move()
        {
            _characterController.SimpleMove(_inputService.Direction * (Speed * Time.deltaTime));
        }
    }
}