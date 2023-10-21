using Battle.GameStates;
using Common;
using Common.Commands;
using Patterns.Decoupling.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Battle
{

    public class GameStateController : MonoBehaviour
    {
        public enum GameStates
        {
            Playing,
            GameOver,
            Victory
        }
        
        private GameState _currentState;

        private Dictionary<GameStates, GameState> _idToState;

        private void Start()
        {
            var stopBattleCommand = new StopBattleCommand();
            _idToState = new Dictionary<GameStates, GameState>
                            {
                                { GameStates.Playing, new PlayingState() },
                                { GameStates.GameOver, new GameOverState(stopBattleCommand) },
                                { GameStates.Victory, new VictoryState(stopBattleCommand) }
                            };

            _currentState = GetState(GameStates.Playing);
            _currentState.Start(OnStateEnded);
        }

        private async void OnStateEnded(GameStates nextState)
        {
            await Task.Yield();
            _currentState.Stop();
            _currentState =  GetState(nextState);
            _currentState.Start(OnStateEnded);

        }

        public void Reset()
        {
            OnStateEnded(GameStates.Playing);
        }

        private GameState GetState(GameStates gameState)
        {
            return _idToState[gameState];
        }
    }
}