using Infrastructure.UI.Services.Factory;
using Zenject;

namespace Infrastructure.UI.Services.Windows
{
    public class WindowService : IWindowService
    {
        private readonly IUIFactory _uiFactory;

        [Inject]
        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Open(WindowId id)
        {
            switch (id)
            {
                case WindowId.Unknown:
                    break;
            }
        }
    }
}