using Infrastructure.UI.GameLoop;
using Infrastructure.UI.Menus.Settings;
using Zenject;

namespace Infrastructure.UI.Installers
{
    public class GameLoopUIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGemeLoopUI();

            InstallSettingsMenuUI();
        }

        private void InstallGemeLoopUI()
        {
            var gameLoopUIUsecase = new GameLoopUIUsecase();

            var gameLoopUIPresenter = new GameLoopUIPresenter(gameLoopUIUsecase);

            Container
                .Bind<IGameLoopUIUsecase>()
                .FromInstance(gameLoopUIUsecase)
                .AsSingle();
            
            Container
                .Bind<IGameLoopUIPresenter>()
                .FromInstance(gameLoopUIPresenter)
                .AsSingle();
        }

        private void InstallSettingsMenuUI()
        {
            var settingsMenuUsecase = new SettingsMenuUsecase(Container.Resolve<IGameLoopUIUsecase>());

            var settingsMenuPresenter = new SettingsMenuPresenter(settingsMenuUsecase);
            
            Container
                .Bind<ISettingsMenuUsecase>()
                .FromInstance(settingsMenuUsecase)
                .AsSingle();
            
            Container
                .Bind<ISettingsMenuPresenter>()
                .FromInstance(settingsMenuPresenter)
                .AsSingle();
        }
    }
}