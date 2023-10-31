using Settings;
using Tayx.Graphy;
using UnityEngine;
using Zenject;

namespace Infrastructure.Misc
{
    public class GraphySettings : MonoBehaviour
    {
        [Inject] private DeveloperSettings _settings;
        private GraphyManager _graphyManager;
        private void Awake()
        {
            _graphyManager = GetComponent<GraphyManager>();
            
            if (!_settings.ShowGraphyPerformanceAsset)
            {
                gameObject.SetActive(false);
            }
            
        }
    }
}