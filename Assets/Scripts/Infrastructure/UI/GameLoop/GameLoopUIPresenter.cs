using System;

namespace Infrastructure.UI.GameLoop
{
    public interface IGameLoopUIPresenter
    {
        void OnMenuButtonClicked(MenuType type);
        
        IObservable<MenuType> OnMenuChanged { get; }
        IObservable<bool> OnLoadingStateChanged { get; }
    }

    public class GameLoopUIPresenter : IGameLoopUIPresenter
    {
        private readonly IGameLoopUIUsecase _usecase;

        public GameLoopUIPresenter(IGameLoopUIUsecase usecase)
        {
            _usecase = usecase;
        }
        public void OnMenuButtonClicked(MenuType type)
        {
            _usecase.SetMenu(type);
        }
        
        public IObservable<bool> OnLoadingStateChanged => _usecase.OnLoadingStateChanged;
        public IObservable<MenuType> OnMenuChanged => _usecase.OnMenuChanged;
    }
}