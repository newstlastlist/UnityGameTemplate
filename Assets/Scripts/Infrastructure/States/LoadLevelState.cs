using Infrastructure.Factory;
using Infrastructure.SceneManagement;
using Infrastructure.UI;
using Zenject;

namespace Infrastructure.States
{
  public class LoadLevelState : IPayloadedState<string>
  {
    private const string InitialPointTag = "InitialPoint";

    private GameStateMachine _stateMachine;
    private SceneLoader _sceneLoader;
    private LoadingScreen _loadingScreen;
    private IGameFactory _gameFactory;

    [Inject]
    public void Construct(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingScreen loadingScreen, IGameFactory gameFactory)
    {
      _stateMachine = gameStateMachine;
      _sceneLoader = sceneLoader;
      _loadingScreen = loadingScreen;
      _gameFactory = gameFactory;
    }

    public void Enter(string sceneName)
    {
      // _loadingCurtain.Show();
      _sceneLoader.Load(sceneName, OnLoaded);
    }

    public void Exit()
    {
        // _loadingCurtain.Hide();
    }

    private void OnLoaded()
    {
      _stateMachine.Enter<GameLoopState>();
    }

   
  }
}