using Helpers.Services;
using Infrastructure.Factory;
using Logic;
using UnityEngine;
using Zenject;

namespace Loot.Money
{
    public class MoneySpawner : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private IRandomizerService _randomizerService;
        
        private int _minValue;
        private int _maxValue;
        
        [Inject]
        public void Construct(IGameFactory factory, IRandomizerService randomService)
        {
            _gameFactory = factory;
            _randomizerService = randomService;
        }
        
        public void SetMoneyValue(int min, int max)
        {
            _minValue = min;
            _maxValue = max;
        }
        
        private void SpawnMoney(Vector3 at)
        {
            MoneyEntity moneyEntity = _gameFactory.CreateMoneyEntity();
            moneyEntity.transform.position = at;
            moneyEntity.GetComponent<UniqueId>().GenerateId();

            Money money = GenerateMoney();
      
            moneyEntity.Initialize(money);
        }
        
        private Money GenerateMoney()
        {
            Money money = new Money()
            {
                Value = _randomizerService.Next(_minValue, _maxValue)
            };
            return money;
        }
    }
}