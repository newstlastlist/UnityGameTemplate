using Infrastructure.Services;

namespace Helpers.Services
{
    public interface IRandomizerService : IService
    {
        int Next(int minValue, int maxValue);
    }
}