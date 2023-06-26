using System;
using UnityEngine;


namespace _Rewards._Main
{
    
    internal sealed class DailyRewardView : RewardView
    {
        
        private const string CurrentDailyActiveSlotKey = nameof(CurrentDailyActiveSlotKey);
        private const string GetDailyRewardTimeKey = nameof(GetDailyRewardTimeKey);
        
        
        [field: Header("Settings Time Get Reward")]
        [SerializeField] private float _timeCooldown = 86400;
        [SerializeField] public float _timeDeadline = 172800;


        private void Awake()
        {
            Init(CurrentDailyActiveSlotKey, GetDailyRewardTimeKey);
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