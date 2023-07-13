using Zenject;

public class DebugClassAInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DebugClassA>()
            .AsSingle();

    }
}