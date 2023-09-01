using Data;
using Infrastructure.Services.PersistentProgress;
using Logic;
using UnityEngine;

namespace Loot.Money
{
    public class MoneyEntity : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private GameObject _pickupVfxPrefab;

        private Money _money;
        private bool _pickedUp;
        private CurrencyData _currencyData;
        private string _id;

        public void Construnct(CurrencyData currencyData) 
            => _currencyData = currencyData;

        public void Initialize(Money money)
            => _money = money;
        
        private void Start() => 
            _id = GetComponent<UniqueId>().Id;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!_pickedUp)
            {
                _pickedUp = true;
                Pickup();
            }
        }
        
        private void Pickup()
        {
            PlayPickupFx();
            UpdateCollectedMoneyAmount();

            Destroy(gameObject);
        }
        private void UpdateCollectedMoneyAmount() =>
            _currencyData.Collect(_money);

        private void PlayPickupFx()
        {
            if (_pickupVfxPrefab == null)
                return;
            
            Instantiate(_pickupVfxPrefab, transform.position, Quaternion.identity);
        }

        public void LoadProgress(PlayerProgress progress)
        {
        }

        public void UpdateProgress(PlayerProgress progress)
        {
        }
    }
}