using System;
using Data;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Infrastructure.UI.Windows
{
    public class WindowBase : MonoBehaviour
    {
        [SerializeField] private Button _closeBtn;

        public Button CloseBtn => _closeBtn;
        protected IPersistentProgressService ProgressService;
        protected PlayerProgress PlayerProgress => ProgressService.Progress;
        

        [Inject]
        public void Construct(IPersistentProgressService progressService)
        {
            ProgressService = progressService;
        }

        private void Awake() 
            => OnAwake();

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() 
            => CleanUp();

        protected virtual void OnAwake() 
            => _closeBtn.onClick.AddListener(() => Destroy(gameObject));

        protected virtual void Initialize() { }

        protected virtual void SubscribeUpdates() { }

        protected virtual void CleanUp() { }
    }
    
    //example
    // public class SomeWindow : WindowBase
    // {
    //     [SerializeField] private TextMeshProUGUI _someTextInfo;
    //
    //     protected override void Initialize()
    //         => RefreshMoneyText();
    //
    //     protected override void SubscribeUpdates()
    //         => PlayerProgress.CurrencyData.Changed += RefreshMoneyText;
    //
    //     protected override void CleanUp()
    //     {
    //         base.CleanUp();
    //         PlayerProgress.CurrencyData.Changed -= RefreshMoneyText;
    //     }
    //
    //     private void RefreshMoneyText()
    //         => _someTextInfo.text = PlayerProgress.CurrencyData.CollectedMoney.ToString();
    // }
}