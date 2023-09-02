using System;
using Loot.Money;
using UniRx;

namespace Data
{
    [Serializable]
    public class CurrencyData
    {
        private readonly ReactiveProperty<int> _collectedMoney = new ReactiveProperty<int>(0);

        public IReadOnlyReactiveProperty<int> CollectedMoney => _collectedMoney;

        public void Collect(Money money)
        {
            _collectedMoney.Value += money.Value;
        }
    }
}