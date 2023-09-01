using System;
using Loot;
using Loot.Money;

namespace Data
{
    [Serializable]
    public class CurrencyData
    {
        public int CollectedMoney;

        public Action Changed;

        public void Collect(Money money)
        {
            CollectedMoney += money.Value;
            Changed?.Invoke();
        }
    }
}