using System.Collections.Generic;
using CodeBase.Infrastructure.AssetManagement;
using Infrastructure.AssetManagement;
using Infrastructure.Services.PersistentProgress;
using Loot;
using Loot.Money;
using UnityEngine;
using Zenject;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IPersistentProgressService _persistentProgressService;
        
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        [Inject]
        public GameFactory(IAssetProvider assets, IPersistentProgressService progressService)
        {
            _assets = assets;
            _persistentProgressService = progressService;
        }

        // public GameObject CreateHero(GameObject at)
        // {
        //     InstantiateRegistered(AssetPath.HeroPath, at.transform.position);
        // }

        public MoneyEntity CreateMoneyEntity()
        {
            MoneyEntity moneyEntity = InstantiateRegistered(AssetPath.Money)
                .GetComponent<MoneyEntity>();
            
            moneyEntity.Construnct(_persistentProgressService.Progress.CurrencyData);

            return moneyEntity;
        }
       
        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        protected GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath, at: at);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        } 
        protected GameObject InstantiateRegistered(GameObject prefab, Vector3 at)
        {
            GameObject gameObject = GameObject.Instantiate(prefab, at, Quaternion.identity);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        } 
    
        protected GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(path: prefabPath);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        }
        protected GameObject InstantiateRegistered(GameObject prefab)
        {
            GameObject gameObject = GameObject.Instantiate(prefab);

            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(progressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if(progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
      
            ProgressReaders.Add(progressReader);
        }

        
    }
}