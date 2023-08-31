using System.Collections.Generic;
using UnityEngine;

namespace StaticData.Windows
{
    [CreateAssetMenu(menuName = "Static Data/Window Static Data", fileName = "WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> WindowConfigs;
    }
}