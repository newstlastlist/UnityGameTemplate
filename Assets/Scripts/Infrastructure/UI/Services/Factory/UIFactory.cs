using Infrastructure.Services.StaticData;
using Infrastructure.UI.Services.Windows;
using Infrastructure.UI.Windows;
using UnityEngine;
using Zenject;

namespace Infrastructure.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private IStaticDataService _staticData;
        private Transform _uiRoot;

        [Inject]
        public UIFactory(IStaticDataService staticData, Transform uiRoot)
        {
            _staticData = staticData;
            _uiRoot = uiRoot;
        }

        //how to use
        public void CreateSomeUIElement()
        {
            var config = _staticData.ForWindow(WindowId.Unknown);
            WindowBase someUiElement = Object.Instantiate(config.Prefab, _uiRoot);
        }
    }
}