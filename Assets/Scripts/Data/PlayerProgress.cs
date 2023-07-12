using System;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public Currency Currency;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            Currency = new Currency();
        }
    }
}