﻿using Input;
using Ships.CheckLimits;
using Ships.Common;
using Ships.Enemies;
using System;
using UnityEngine;

namespace Ships
{
    public class ShipInstaller : MonoBehaviour
   {
        [SerializeField] private bool _useAI;
        [SerializeField] private bool _useJoystick;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private JoyButton _joyButton;
        [SerializeField] private ShipMediator _ship;

        [SerializeField] private ShipToSpawnConfiguration _shipConfiguration;
        [SerializeField] private ShipsConfiguration _shipsConfiguration;

        private void Awake()
        {
            var shipFactory = new ShipFactory(Instantiate(_shipsConfiguration));
            var shipBuilder = shipFactory.Create(_shipConfiguration.ShipId.Value)
                                            .WithConfiguration(_shipConfiguration);

            SetInput(shipBuilder);
            SetCheckLimitsStrategy(shipBuilder);
            shipBuilder.Build();
        }

        private void SetCheckLimitsStrategy(ShipBuilder shipBuilder)
        {
            if (_useAI)
            {
                shipBuilder.WithCheckLimitType(ShipBuilder.CheckLimitTypes.InitialPosition);
                return;
            }

            shipBuilder.WithCheckLimitType(ShipBuilder.CheckLimitTypes.Viewport);
        }

        private void SetInput(ShipBuilder shipBuilder)
       {
            if (_useAI)
            {
                shipBuilder.WithInputMode(ShipBuilder.InputMode.Ai);
                return;
            }
            if (_useJoystick)
            {
                shipBuilder.WithInputMode(ShipBuilder.InputMode.Joystick);
                shipBuilder.WithJoysticks(_joystick, _joyButton);
                return;
            }

            shipBuilder.WithInputMode(ShipBuilder.InputMode.Unity);

            Destroy(_joystick.gameObject);
            Destroy(_joyButton.gameObject);
       }
   }
}
