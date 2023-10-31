using Services.Input;
using Zenject;

namespace SceneContext
{
    public class InputServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InputServiceInstall();
        }

        private void InputServiceInstall()
        {
            var inputService = new InputService(Container.Resolve<VariableJoystick>());
            
            Container
                .Bind<IInputService>()
                .FromInstance(inputService)
                .AsSingle();
        }
    }
}