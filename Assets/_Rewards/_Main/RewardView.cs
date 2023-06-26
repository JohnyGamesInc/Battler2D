using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace _Rewards._Main
{
    
    internal abstract class RewardView : MonoBehaviour
    {
        
        protected string _currentActiveSlotKey;
        protected string _getRewardTimeKey;

        protected abstract void Init(string currentActiveSlotKey, string getRewardTimeKey);
        

        [field: Header("Settings Time Get Reward")]
        [field: SerializeField] public float TimeCooldown { get; private set; } = 86400;
        [field: SerializeField] public float TimeDeadline { get; private set; } = 172800;

        [field: Header("Settings Rewards")]
        [field: SerializeField] public List<Reward> Rewards { get; private set; }

        [field: Header("Ui Elements")]
        [field: SerializeField] public TMP_Text TimerNewReward { get; private set; }
        [field: SerializeField] public Transform RewardSlotsContainer { get; private set; }
        [field: SerializeField] public RewardSlotView RewardSlotPrefab { get; private set; }
        [field: SerializeField] public Button GetRewardButton { get; private set; }
        [field: SerializeField] public Button ResetButton { get; private set; }
        
        
        public int CurrentActiveSlot
        {
            get => PlayerPrefs.GetInt(_currentActiveSlotKey);
            set => PlayerPrefs.SetInt(_currentActiveSlotKey, value);
        }

        
        public DateTime? TimeGetReward
        {
            get
            {
                string data = PlayerPrefs.GetString(_getRewardTimeKey);
                return !string.IsNullOrEmpty(data) ? DateTime.Parse(data) : null;
            }
            set
            {
                if (value != null)
                    PlayerPrefs.SetString(_getRewardTimeKey, value.ToString());
                else
                    PlayerPrefs.DeleteKey(_getRewardTimeKey);
            }
        }
        
        
        
    }
}