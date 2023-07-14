using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider _loadingProgressBar;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
