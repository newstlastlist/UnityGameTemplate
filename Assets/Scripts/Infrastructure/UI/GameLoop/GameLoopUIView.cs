using System.Collections.Generic;
using Infrastructure.UI.MenuButtons;
using Infrastructure.UI.Menus;
using UniRx;
using UnityEngine;
using Zenject;

namespace Infrastructure.UI.GameLoop
{
    public class GameLoopUIView : MonoBehaviour
    {
        [SerializeField] private Transform _menuBtnsParent;
        [SerializeField] private List<MenuButtonView> _menuBtns;
        [SerializeField] private List<MenuView> _menus;

        [Inject]
        private IGameLoopUIPresenter _presenter;
        
        private void Start()
        {
            _presenter.OnLoadingStateChanged
                .Subscribe(isActive => SetUIActiveState(!isActive))
                .AddTo(this);
            
            foreach (var btn in _menuBtns)
            {
                btn.OnClickAsObservable()
                    .Subscribe(_ => _presenter.OnMenuButtonClicked(btn.MenuType))
                    .AddTo(this);
            }
            
            _presenter.OnMenuChanged
                .Subscribe(OpenMenu)
                .AddTo(this);
        }
        private void OpenMenu(MenuType type)
        {
            if (type == MenuType.None)
            {
                _menuBtnsParent.gameObject.SetActive(true);
                foreach (var menu in _menus)
                {
                    menu.Close();
                }
                return;
            }
            foreach (var menu in _menus)
            {
                if (menu.MenuType == type)
                {
                    _menuBtnsParent.gameObject.SetActive(false);
                    menu.Open();
                }
                else
                {
                    menu.Close();
                }
            }
        }
        
        private void SetUIActiveState(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
    
    public enum MenuType
    {
        Settings,
        None
       
    }
}