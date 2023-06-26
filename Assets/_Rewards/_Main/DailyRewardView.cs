using System;

namespace _Rewards._Main
{
    internal sealed class DailyRewardView : RewardView
    {
        
        private const string CurrentDailyActiveSlotKey = nameof(CurrentDailyActiveSlotKey);
        private const string GetDailyRewardTimeKey = nameof(GetDailyRewardTimeKey);


        private void Awake()
        {
            _currentActiveSlotKey = CurrentDailyActiveSlotKey;
            _getRewardTimeKey = GetDailyRewardTimeKey;
        }
        
    }
}