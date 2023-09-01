using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Loot.Money;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        // GameObject CreateHero(GameObject at);
        // void CreateHud();
        MoneyEntity CreateMoneyEntity();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}