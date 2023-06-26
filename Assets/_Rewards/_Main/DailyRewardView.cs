using System;


namespace _Rewards._Main
{
    
    internal sealed class DailyRewardView : RewardView
    {
        
        private const string CurrentDailyActiveSlotKey = nameof(CurrentDailyActiveSlotKey);
        private const string GetDailyRewardTimeKey = nameof(GetDailyRewardTimeKey);


        private void Awake()
        {
            Init(CurrentDailyActiveSlotKey, GetDailyRewardTimeKey);
        }

        
        protected override void Init(string currentActiveSlotKey, string getRewardTimeKey)
        {
            _currentActiveSlotKey = currentActiveSlotKey;
            _getRewardTimeKey = getRewardTimeKey;
        }
        
        
    }
}