using System;
using Infrastructure.UI.GameLoop;
using UnityEngine;

namespace Infrastructure.UI.Menus
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private MenuType _menuType;

        public MenuType MenuType => _menuType;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}