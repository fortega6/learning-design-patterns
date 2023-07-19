using UI;
using UnityEngine;

namespace Core
{
    public class LoadingScreenInstaller : Installer
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        public override void Install(Patterns.Decoupling.ServiceLocator.ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_loadingScreen.gameObject);
            serviceLocator.RegisterService(_loadingScreen);
        }
    }
}
