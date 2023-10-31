using Helpers;
using UnityEngine;
using Zenject;

namespace Services.Input
{
    public class InputService : IInputService
    {
        public Vector2 Axis => JoysticAxis();

        private VariableJoystick _joystick;

        [Inject]
        public InputService(VariableJoystick joystick)
        {
            _joystick = joystick;
        }
        
        public Vector2 JoysticAxis()
        {
            return new Vector2(_joystick.Horizontal, _joystick.Vertical);
        }
    }
}