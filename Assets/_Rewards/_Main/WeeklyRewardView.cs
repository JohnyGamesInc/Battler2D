namespace _Rewards._Main
{
    
    internal sealed class WeeklyRewardView : RewardView
    {
        
        private const string CurrenWeeklyActiveSlotKey = nameof(CurrenWeeklyActiveSlotKey);
        private const string GetWeeklyRewardTimeKey = nameof(GetWeeklyRewardTimeKey);


        private void Awake()
        {
            Init(CurrenWeeklyActiveSlotKey, GetWeeklyRewardTimeKey);
        }

        
        protected override void Init(string currentActiveSlotKey, string getRewardTimeKey)
        {
            _currentActiveSlotKey = currentActiveSlotKey;
            _getRewardTimeKey = getRewardTimeKey;
        }
        
        
    }
}