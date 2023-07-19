using Common;
using Patterns.Decoupling.ServiceLocator;
using System;

namespace Battle.GameStates
{
    class GameOverState : GameState
    {
        private readonly GameFacade _gameFacade;

        public GameOverState(GameFacade gameFacade)
        {
            _gameFacade = gameFacade;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            _gameFacade.StopBattle();
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {
        }
    }
}