using CodeBase.Hero;
using UnityEngine;

namespace CodeBase
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private HeroInstaller _heroInstaller;
        private void Awake()
        {
            _heroInstaller.Construct();
        }
    }
}