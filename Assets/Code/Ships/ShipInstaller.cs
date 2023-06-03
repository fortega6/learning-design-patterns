using Input;
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
       [SerializeField] private Ship _ship;

       private void Awake()
       {
            _ship.Configure(GetInput(), GetCheckLimitsStrategy());
       }

        private ICheckLimits GetCheckLimitsStrategy()
        {
            if (_useAI)
            {
                return new InitialPositionCheckLimits(_ship.transform, 10f);
            }

            return new ViewportCheckLimits(_ship.transform, Camera.main);
        }

        private Input GetInput()
       {
            if (_useAI)
            {
                return new AIInputAdapter(_ship);
            }
            if (_useJoystick)
            {
                return new JoystickInputAdapter(_joystick, _joyButton);
            }

            Destroy(_joystick.gameObject);
            Destroy(_joyButton.gameObject);
            return new UnityInputAdapter();
       }
   }
}
