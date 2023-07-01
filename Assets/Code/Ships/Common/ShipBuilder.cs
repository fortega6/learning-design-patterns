using Input;
using Ships.CheckLimits;
using Ships.Enemies;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Ships.Common
{
    public class ShipBuilder
    {
        public enum InputMode
        {
            Unity,
            Joystick,
            Ai
        }
        public enum CheckLimitTypes
        {
            InitialPosition,
            Viewport
        }

        private ShipMediator _prefab;
        private Vector3 _position;
        private Quaternion _rotation = Quaternion.identity;
        private Input.Input _input;
        private ICheckLimits _checkLimits;
        private ShipToSpawnConfiguration _shipConfiguration;
        private InputMode _inputMode;
        private Joystick _joystick;
        private JoyButton _joyButton;
        private CheckLimitTypes _checkLimitsType;
        private Teams _team;

        public ShipBuilder FromPrebab(ShipMediator prebab)
        {
            _prefab = prebab;
            return this;
        }
        public ShipBuilder WithTeam(Teams team)
        {
            _team = team;
            return this;
        }
        public ShipBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public ShipBuilder WithRotation(Quaternion rotation)
        {
            _rotation = rotation;
            return this;
        }
        public ShipBuilder WithInput(Input.Input input)
        {
            _input = input;
            return this;
        }
        public ShipBuilder WithCheckLimits(ICheckLimits checkLimits)
        {
            _checkLimits = checkLimits;
            return this;
        }
        public ShipBuilder WithConfiguration(ShipToSpawnConfiguration shipConfiguration)
        {
            _shipConfiguration = shipConfiguration;
            return this;
        }
        public ShipBuilder WithJoysticks(Joystick joystick, JoyButton joyButton)
        {
            _joystick = joystick;
            _joyButton = joyButton;
            return this;
        }
        public ShipBuilder WithInputMode(InputMode inputMode)
        {
            _inputMode = inputMode;
            return this;
        }
        public ShipBuilder WithCheckLimitType(CheckLimitTypes checkLimitType)
        {
            _checkLimitsType = checkLimitType;
            return this;
        }
        public ShipMediator Build()
        {
            var ship = GameObject.Instantiate(_prefab, _position, _rotation);
            var shipConfiguration = new ShipConfiguration(GetInput(ship),
                                                          GetCheckLimits(ship),
                                                          _shipConfiguration.Speed,
                                                          _shipConfiguration.Health,
                                                          _shipConfiguration.FireRate,
                                                          _shipConfiguration.DefaultProjectileId,
                                                          _team);
            ship.Configure(shipConfiguration);
            return ship;
        }

        private ICheckLimits GetCheckLimits(ShipMediator ship)
        {
            if (_checkLimits != null)
            {
                return _checkLimits;
            }

            switch (_checkLimitsType)
            {
                case CheckLimitTypes.InitialPosition:
                    return new InitialPositionCheckLimits(ship.transform, 10);
                case CheckLimitTypes.Viewport:
                    return new ViewportCheckLimits(Camera.main);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private Input.Input GetInput(ShipMediator shipMediator)
        {
            if (_input != null)
            {
                return _input;
            }

            switch (_inputMode)
            {
                case InputMode.Unity:
                    return new UnityInputAdapter();
                case InputMode.Joystick:
                    Assert.IsNotNull(_joystick);
                    Assert.IsNotNull(_joyButton);
                    return new JoystickInputAdapter(_joystick, _joyButton);
                case InputMode.Ai:
                    return new AIInputAdapter(shipMediator);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
