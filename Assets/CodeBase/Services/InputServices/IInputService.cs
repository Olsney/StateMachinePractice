using UnityEngine;

namespace CodeBase.Services.InputServices
{
    public interface IInputService
    {
        Vector3 Direction { get; }
        bool IsJumping { get; }
        public bool IsAttacking { get; }
    }
}