using Infrastructure;
using Infrastructure.AssetManagement;
using Infrastructure.AudioManagement;
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
    [SerializeField] private AudioService _audioService;
    public override void InstallBindings()
    {
        SceneLoaderInstall();

        FactoriesInstall();
        
        SaveSystemInstall();

        GameStateMachineInstall();

        GameInstall();
        
        AssetsServiecesInstall();
        
        AudioServiceInstall();
    }

    private void AssetsServiecesInstall()
    {
        Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }

    private void GameInstall()
    {
        Container.Bind<Game>().AsSingle();
    }

    private void SceneLoaderInstall()
    {
        Container.Bind<SceneLoader>().AsSingle();
        Container.Bind<LoadingScreen>().FromInstance(_loadingScreen).AsSingle();
    }

    private void FactoriesInstall()
    {
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
    }

    private void SaveSystemInstall()
    {
        Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
        Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }

    private void GameStateMachineInstall()
    {
        Container.Bind<GameStateMachine>().AsSingle();
        Container.Bind<LoadLevelState>().AsTransient();
        Container.Bind<BootstrapState>().AsTransient();
        Container.Bind<GameLoopState>().AsTransient();
        Container.Bind<LoadProgressState>().AsTransient();
    }

    private void AudioServiceInstall()
    {
        Container.Bind<AudioService>().FromInstance(_audioService).AsSingle();
    }
}