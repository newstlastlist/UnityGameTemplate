using System;
using UnityEngine;
using Zenject;

namespace Settings
{
    [CreateAssetMenu(fileName = "Settings", menuName = "Installers/Settings")]
    public class Settings : ScriptableObjectInstaller<Settings>
    {
        [SerializeField] private DeveloperSettings _developerSettings;
        [SerializeField] private ApplicationSettings _applicationSettings;    
        
        public override void InstallBindings()
        {
            Container
                .Bind<DeveloperSettings>()
                .FromInstance(_developerSettings)
                .AsSingle();
            
            Container
                .Bind<ApplicationSettings>()
                .FromInstance(_applicationSettings)
                .AsSingle();
        }
    }
    [Serializable]
    public class DeveloperSettings
    {
        public bool FakeTimeLoadScene = true;
        public bool ShowGraphyPerformanceAsset = true;
    }
    [Serializable]
    public class ApplicationSettings
    {
        public int TargetFrameRate = 60;
    }
}