namespace Infrastructure.UI.Menus.Settings
{
    public interface ISettingsMenuPresenter
    {
        void OnToggleChanged(SettingsToggleType type, bool state);
        void CloseMenu();
    }

    public class SettingsMenuPresenter : ISettingsMenuPresenter
    {
        private ISettingsMenuUsecase _useCase;

        public SettingsMenuPresenter(ISettingsMenuUsecase useCase)
        {
            _useCase = useCase;
        }

        public void OnToggleChanged(SettingsToggleType type, bool state)
        {
            _useCase.HandleToggleChange(type, state);
        }

        public void CloseMenu()
        {
            _useCase.CloseMenu();
        }
    }
}