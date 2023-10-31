using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Infrastructure.UI.Menus.Settings
{
    public class SettingsMenuView : MenuView
    {
        [Inject]
        private ISettingsMenuPresenter _presenter;
        
        [SerializeField] private Button _closeBtn;
        [SerializeField] private List<SettingsToggleView> _settingsToggles;
        
        private void Start()
        {
            _closeBtn
                .OnClickAsObservable()
                .Subscribe(_ =>_presenter.CloseMenu())
                .AddTo(this);
            
            foreach (var toggle in _settingsToggles)
            {
                toggle.OnToggleValueChanged
                    .Subscribe(tuple => _presenter.OnToggleChanged(tuple.Item1, tuple.Item2))
                    .AddTo(this);
            }
        }
    }

    public enum SettingsToggleType
    {
        Sound
    }
}