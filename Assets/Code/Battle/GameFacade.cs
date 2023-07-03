﻿using System;
using Ships;
using Ships.Enemies;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private ScreenFade _screenFade;
        [SerializeField] private ShipInstaller _shipInstaller;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private ScoreView _scoreView;

        public void StartBattle()
        {
            _scoreView.Reset();
            _enemySpawner.StartSpawn();
            _shipInstaller.SpawnUserShip();
            _screenFade.Hide();
        }

        public void StopBattle()
        {
            _screenFade.Show();
            _enemySpawner.StopAndReset();
            _shipInstaller.DestroyUserShip();
        }
    }
}