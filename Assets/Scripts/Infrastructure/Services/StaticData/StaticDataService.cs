using System.Collections.Generic;
using System.Linq;
using Infrastructure.UI.Services.Windows;
using StaticData.Windows;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowId, WindowConfig> _windowConfigs;

        public void LoadUI()
        {
            _windowConfigs = Resources
                .Load<WindowStaticData>(ConstString.StaticDataWindowsPath)
                .WindowConfigs
                .ToDictionary(x => x.WindowId, x => x);
        }

        public WindowConfig ForWindow(WindowId id) =>
            _windowConfigs.TryGetValue(id, out WindowConfig windowConfig)
                ? windowConfig
                : null;
    }
}