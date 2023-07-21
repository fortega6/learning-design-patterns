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
        public void StopBattle()
        {
            ServiceLocator.Instance.GetService<EnemySpawner>().StopAndReset();
        }
    }
}