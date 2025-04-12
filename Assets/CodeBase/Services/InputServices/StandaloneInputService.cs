
using UnityEngine;

namespace CodeBase.Services.InputServices
{
    public class StandaloneInputService : IInputService
    {
        private const string Horizontal = nameof(Horizontal);
        private const KeyCode Jump = KeyCode.Space;
        private const string Vertical = "Vertical";

        public Vector3 Direction => new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
        public bool IsJumping => Input.GetKeyDown(Jump);
        public bool IsAttacking => Input.GetMouseButtonDown(0);
    }
}