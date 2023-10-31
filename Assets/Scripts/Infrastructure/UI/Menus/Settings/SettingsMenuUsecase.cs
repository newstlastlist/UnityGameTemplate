using Infrastructure.UI.GameLoop;
using UnityEngine;
using Zenject;

namespace Infrastructure.UI.Menus.Settings
{
    public interface ISettingsMenuUsecase : IMenuUsecase
    {
        void HandleToggleChange(SettingsToggleType type, bool state);
    }
    public class SettingsMenuUsecase : ISettingsMenuUsecase
    {
        private readonly IGameLoopUIUsecase _gameLoopUIUsecase;

        public SettingsMenuUsecase(IGameLoopUIUsecase gameLoopUIUsecase)
        {
            _gameLoopUIUsecase = gameLoopUIUsecase;
        }
        
        public void HandleToggleChange(SettingsToggleType type, bool state)
        {
            switch (type)
            {
                case SettingsToggleType.Sound:
                    ToggleSound(state);
                    break;
            }
        }
        
        private void ToggleSound(bool state)
        {
            AudioListener.pause = !state;
            Debug.Log("Soun disabled: " + AudioListener.pause);
        }
        
        public void CloseMenu()
        {
            _gameLoopUIUsecase.SetMenu(MenuType.None);
        }
    }
}