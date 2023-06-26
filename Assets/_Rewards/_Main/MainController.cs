using UnityEngine;


namespace _Rewards._Main
{
    
    internal sealed class MainController : MonoBehaviour
    {
        
        [SerializeField] private DailyRewardView _dailyRewardView;
        [SerializeField] private WeeklyRewardView _weeklyRewardView;
        [SerializeField] private CurrencyView _currencyView;

        
        private RewardController _dailyRewardController;
        private RewardController _weeklyRewardController;


        private void Awake()
        { 
            _dailyRewardController = new RewardController(_dailyRewardView, _currencyView);
            _weeklyRewardController = new RewardController(_weeklyRewardView, _currencyView);
        }
        

        private void Start()
        {
            _dailyRewardController.Init();
            _weeklyRewardController.Init();
        }
            
        
        private void OnDestroy()
        { 
            _dailyRewardController.DeInit();
            _weeklyRewardController.DeInit();
        }
            
        
        
    }
}