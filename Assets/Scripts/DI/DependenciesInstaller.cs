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
    [SerializeField] private CoroutineRunner _coroutineRunner;
    [SerializeField] private AudioService _audioService;
    
    private IGameFactory _gameFactory;

    public override void InstallBindings()
    {
        LoadingScreenInstall();
        
        AssetsServiecesInstall();

        FactoriesInstall();

        BindCoroutineRunner();

        SaveSystemInstall();

        SceneLoaderInstall();

        GameStateMachineInstall();

        GameInstall();

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

    private void BindCoroutineRunner()
    {
        Container.Bind<ICoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();
    }

    private void SceneLoaderInstall()
    {
        Container.Bind<SceneLoader>().AsSingle();
    }

    private void FactoriesInstall()
    {
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        _gameFactory = Container.Resolve<IGameFactory>();
    }

    private void SaveSystemInstall()
    {
        Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
        Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
    }

    private void GameStateMachineInstall()
    {
        Container.Bind<GameStateMachine>().AsSingle();
    }

    private void AudioServiceInstall()
    {
        Container.Bind<AudioService>().FromInstance(_audioService).AsSingle();
    }
    private void LoadingScreenInstall()
    {
        Container.Bind<LoadingScreen>().FromInstance(_loadingScreen).AsSingle();
    }
}