using System;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public CurrencyData CurrencyData;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            CurrencyData = new CurrencyData();
        }
    }
}