using System;
using Infrastructure.UI.Services.Windows;
using Infrastructure.UI.Windows;

namespace StaticData.Windows
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId WindowId;
        public WindowBase Prefab;
    }
}