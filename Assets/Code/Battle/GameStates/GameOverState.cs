using Common;
using Patterns.Behaviour.Command;
using Patterns.Decoupling.ServiceLocator;
using System;

namespace Battle.GameStates
{
    class GameOverState : GameState
    {
        private readonly Command _stopBattleCommand;

        public GameOverState(Command stopBattleCommand)
        {
            _stopBattleCommand = stopBattleCommand;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            ServiceLocator.Instance.GetService<CommandQueue>()
                          .AddCommand(_stopBattleCommand);
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {
        }
    }
}