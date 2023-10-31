using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.UI.Menus.Settings
{
    public class SettingsToggleView : MonoBehaviour
    {
        [SerializeField] private SettingsToggleType _settingsToggleType;
        
        private Subject<(SettingsToggleType, bool)> _onToggleValueChanged = new Subject<(SettingsToggleType, bool)>();

        private void Start()
        {
            Toggle toggle = GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(isOn => _onToggleValueChanged.OnNext((_settingsToggleType, isOn)));
        }
        
        public IObservable<(SettingsToggleType, bool)> OnToggleValueChanged => _onToggleValueChanged;
    }
}