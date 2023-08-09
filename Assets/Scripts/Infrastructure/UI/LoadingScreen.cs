using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private Slider _loadingProgressBar;
        [SerializeField] private TextMeshProUGUI _loadingText;
        
        public float CurrentProgress => _loadingProgressBar.value;

        private void Awake()
        {
            Hide();
        }

        public void UpdateProgress(float progress)
        {
            _loadingProgressBar.value = progress;
            _loadingText.text = String.Format(ConstString.LOADING, (int)(progress * 100f));
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
