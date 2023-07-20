using Battle;
using Patterns.Decoupling.ServiceLocator;
using System;
using UnityEngine;

namespace Core
{
    public class GameFacadeInstaller : Installer
    {
        [SerializeField] private GameFacadeImpl _gameFacade;
        public override void Install(ServiceLocator serviceLocator)
        {
            Debug.Log("GameFacadeInstaller");
            serviceLocator.RegisterService<GameFacade>(_gameFacade);
        }
        private void OnDestroy()
        {
            ServiceLocator.Instance.UnregisterService<GameFacade>();
        }
    }
}
