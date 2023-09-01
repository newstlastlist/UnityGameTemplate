using Infrastructure.UI.Services.Windows;
using StaticData.Windows;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        WindowConfig ForWindow(WindowId id);
    }
}