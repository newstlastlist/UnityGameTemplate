using System;
using UniRx;

namespace Infrastructure.UI.GameLoop
{
    public interface IGameLoopUIUsecase
    {
        void SetMenu(MenuType type);
        void SetLoadingState(bool isLoading);
        IObservable<MenuType> OnMenuChanged { get; }
        IObservable<bool> OnLoadingStateChanged { get; }
    }

    public class GameLoopUIUsecase : IGameLoopUIUsecase
    {
        private Subject<MenuType> _onMenuChanged = new Subject<MenuType>();
        private Subject<bool> _onLoadingStateChanged = new Subject<bool>();

        public void SetMenu(MenuType type)
        {
            _onMenuChanged.OnNext(type);
        }
        
        public void SetLoadingState(bool isLoading)
        {
            _onLoadingStateChanged.OnNext(isLoading);
        }

        public IObservable<MenuType> OnMenuChanged => _onMenuChanged;
        public IObservable<bool> OnLoadingStateChanged => _onLoadingStateChanged;
    }
}