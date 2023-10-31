using System;
using Infrastructure.UI.GameLoop;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.UI.MenuButtons
{
    public class MenuButtonView : MonoBehaviour
    {
        [SerializeField] private MenuType _menuType;

        public MenuType MenuType => _menuType;
        
        public IObservable<Unit> OnClickAsObservable()
        {
            return GetComponent<Button>().OnClickAsObservable();
        }
    }
}