using System.Collections.Generic;
using Infrastructure.AudioManagement;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.UI;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        // GameObject CreateHero(GameObject at);
        // void CreateHud();
        AudioService CreateAudioService();
        CoroutineRunner CreateCoroutineRunner();
        LoadingScreen CreateLoadingScreen();
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}