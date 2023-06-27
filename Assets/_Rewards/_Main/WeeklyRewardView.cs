using UnityEngine;


namespace _Rewards._Main
{
    
    internal sealed class WeeklyRewardView : RewardView
    {
        
        private const string CurrenWeeklyActiveSlotKey = nameof(CurrenWeeklyActiveSlotKey);
        private const string GetWeeklyRewardTimeKey = nameof(GetWeeklyRewardTimeKey);
        
        [field: Header("Settings Time Get Reward")]
        [SerializeField] private float _timeCooldown = 604800;
        [SerializeField] public float _timeDeadline = 1209600;
        
        
        private void Awake()
        {
            Init(CurrenWeeklyActiveSlotKey, GetWeeklyRewardTimeKey);
        }

        
        protected override void Init(string currentActiveSlotKey, string getRewardTimeKey)
        {
            _currentActiveSlotKey = currentActiveSlotKey;
            _getRewardTimeKey = getRewardTimeKey;
            TimeCooldown = _timeCooldown;
            TimeDeadline = _timeDeadline;
        }
        
        
    }
}