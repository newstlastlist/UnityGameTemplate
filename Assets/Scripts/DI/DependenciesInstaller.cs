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
    [SerializeField] private CoroutineRunner _coroutineRunner;
    public override void InstallBindings()
    {
        AssetsServiecesInstall();
        
        FactoriesInstall();
        
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

    private void SceneLoaderInstall()
    {
        GameObject coroutineRunner = Container.InstantiatePrefab(_coroutineRunner);
        ICoroutineRunner coroutineRunnerComponent = coroutineRunner.GetComponent<CoroutineRunner>();
        
        Container.Bind<ICoroutineRunner>().FromInstance(coroutineRunnerComponent).AsSingle();
        Container.Bind<SceneLoader>().AsSingle().WithArguments(coroutineRunnerComponent, _loadingScreen);
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
    }

    private void AudioServiceInstall()
    {
        Container.Bind<AudioService>().FromInstance(_audioService).AsSingle();
    }
}