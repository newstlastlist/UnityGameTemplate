using Infrastructure.Services;

namespace Infrastructure.UI.Services.Windows
{
    public interface IWindowService : IService
    {
        void Open(WindowId id);
    }
}