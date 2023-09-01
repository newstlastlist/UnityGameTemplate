using UnityEngine;

namespace Helpers.Services
{
    public class RandomizerService : IRandomizerService
    {
        public int Next(int min, int max) =>
            Random.Range(min, max);
    }
}