using System;
using Core;
using Patterns.Decoupling.ServiceLocator;
using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class GameFacadeImpl : MonoBehaviour, GameFacade
    {
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;

        public void StartBattle()
        {
            ServiceLocator.Instance.GetService<GameStateController>().Reset();
            ServiceLocator.Instance.GetService<ScoreView>().Reset();
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            ServiceLocator.Instance.GetService<LoadingScreen>().Hide();
        }

        public void StopBattle()
        {
            ServiceLocator.Instance.GetService<LoadingScreen>().Show();
            _enemySpawner.StopAndReset();
        }
    }
}