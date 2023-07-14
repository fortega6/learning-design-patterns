using Battle.GameStates;
using Common;
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

        [SerializeField] private GameFacade _gameFacade;

        
        private GameState _currentState;

        private Dictionary<GameStates, GameState> _idToState;

        private void Awake()
        {
            _idToState = new Dictionary<GameStates, GameState>
                            {
                                { GameStates.Playing, new PlayingState() },
                                { GameStates.GameOver, new GameOverState(_gameFacade) },
                                { GameStates.Victory, new VictoryState(_gameFacade) }
                            };
        }

        private void Start()
        {
            _currentState = GetState(GameStates.Playing);
            _currentState.Start(OnStateEnded);
        }

        private async void OnStateEnded(GameStates nextState)
        {
            await Task.Yield();
            _currentState.Stop();
            _currentState = GetState(nextState);
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