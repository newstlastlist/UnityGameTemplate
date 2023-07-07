using Infrastructure;
using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.SceneManagement;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.States;
using Infrastructure.UI;
using UnityEngine;
using Zenject;

public class DependenciesInstaller : MonoInstaller
{
    [SerializeField] private LoadingScreen _loadingScreen;
    public override void InstallBindings()
    {
        Container.Bind<SceneLoader>().AsSingle();
        Container.Bind<LoadingScreen>().FromInstance(_loadingScreen).AsSingle();
        
        //factories
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        
        //save system
        Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
        Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        
        //states
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<LoadLevelState>().AsTransient();
        Container.Bind<BootstrapState>().AsTransient();
        Container.Bind<GameLoopState>().AsTransient();
        Container.Bind<LoadProgressState>().AsTransient();
        
        //game
        Container.Bind<Game>().AsSingle();
        
        //assets
        Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }
}