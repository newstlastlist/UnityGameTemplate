using Helpers.Services;
using Infrastructure;
using Infrastructure.AssetManagement;
using Infrastructure.AudioManagement;
using Infrastructure.Factory;
using Infrastructure.SceneManagement;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticData;
using Infrastructure.States;
using Infrastructure.UI.LoadingScreen;
using Infrastructure.UI.Services.Factory;
using Infrastructure.UI.Services.Windows;
using UnityEngine;
using Zenject;

public class DependenciesInstaller : MonoInstaller
{
    #region UI
    [SerializeField] private LoadingScreen _loadingScreen;
    [SerializeField] private Transform _uiRoot;
    #endregion
    
    #region Services
    [SerializeField] private AudioService _audioService;
    #endregion

    #region Misc
    [SerializeField] private CoroutineRunner _coroutineRunner;
    #endregion


    public override void InstallBindings()
    {
        LoadingScreenInstall();

        RandomizerServiceInstaller();

        StaticDataServiceInstall();
        
        AssetsServiecesInstall();

        SaveSystemInstall();
        
        FactoriesInstall();

        BindCoroutineRunner();

        SceneLoaderInstall();

        GameStateMachineInstall();

        GameInstall();

        AudioServiceInstall();

        WindowServiceInstall();
    }

    private void AssetsServiecesInstall()
    {
        Container
            .Bind<IAssetProvider>()
            .To<AssetProvider>()
            .AsSingle();
    }

    private void StaticDataServiceInstall()
    {
        IStaticDataService staticDataService = new StaticDataService();
        staticDataService.Load();
        
        Container
            .Bind<IStaticDataService>()
            .FromInstance(staticDataService)
            .AsSingle();
    }

    private void GameInstall()
    {
        Container
            .Bind<Game>()
            .AsSingle();
    }

    private void BindCoroutineRunner()
    {
        Container
            .Bind<ICoroutineRunner>()
            .FromInstance(_coroutineRunner)
            .AsSingle();
    }

    private void SceneLoaderInstall()
    {
        Container
            .Bind<SceneLoader>()
            .AsSingle();
    }

    private void FactoriesInstall()
    {
        Container
            .Bind<IGameFactory>()
            .To<GameFactory>()
            .AsSingle();

        Container
            .Bind<IUIFactory>()
            .To<UIFactory>()
            .AsSingle()
            .WithArguments(_uiRoot);
    }

    private void WindowServiceInstall()
    {
        Container
            .Bind<IWindowService>()
            .To<WindowService>()
            .AsSingle();
    }
    private void SaveSystemInstall()
    {
        Container
            .Bind<IPersistentProgressService>()
            .To<PersistentProgressService>()
            .AsSingle();
        
        Container
            .Bind<ISaveLoadService>()
            .To<SaveLoadService>()
            .AsSingle();
    }

    private void GameStateMachineInstall()
    {
        Container
            .Bind<GameStateMachine>()
            .AsSingle();
    }

    private void AudioServiceInstall()
    {
        Container
            .Bind<AudioService>()
            .FromInstance(_audioService)
            .AsSingle();
    }

    private void RandomizerServiceInstaller()
    {
        Container
            .Bind<IRandomizerService>()
            .To<RandomizerService>()
            .AsSingle();
    }

    private void LoadingScreenInstall()
    {
        Container
            .Bind<LoadingScreen>()
            .FromInstance(_loadingScreen)
            .AsSingle();
    }
}