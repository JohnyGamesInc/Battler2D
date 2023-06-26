using UnityEngine;


namespace _Rewards._Main
{
    
    internal sealed class MainController : MonoBehaviour
    {
        
        [SerializeField] private RewardView rewardView;
        [SerializeField] private CurrencyView _currencyView;

        
        private RewardController _rewardController;


        private void Awake() =>
            _rewardController = new RewardController(rewardView, _currencyView);


        private void Start()
        {
            _rewardController.Init();
        }
            
        
        private void OnDestroy() =>
            _rewardController.Deinit();
        
        
    }
}