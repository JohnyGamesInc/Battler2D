using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace _Rewards._Main
{
    
    internal sealed class RewardController
    {
        
        private readonly RewardView _rewardView;
        private readonly CurrencyView _currencyView;

        private List<RewardSlotView> _slots;
        private Coroutine _coroutine;

        private bool _isRewardReady;
        private bool _isInitialized;
        
        
        public RewardController(RewardView rewardView, CurrencyView currencyView)
        { 
            _rewardView = rewardView;
            _currencyView = currencyView;
        }
            
        
        public void Init()
        {
            if (_isInitialized)
                return;

            InitSlots();
            RefreshUi();
            StartRewardsUpdating();
            SubscribeButtons();

            _isInitialized = true;
        }
        
        
        public void Deinit()
        {
            if (!_isInitialized)
                return;

            DeinitSlots();
            StopRewardsUpdating();
            UnsubscribeButtons();

            _isInitialized = false;
        }
        
        
        private void InitSlots()
        {
            _slots = new List<RewardSlotView>();

            for (int i = 0; i < _rewardView.Rewards.Count; i++)
            {
                RewardSlotView instanceSlot = CreateRewardSlotView();
                _slots.Add(instanceSlot);
            }
        }
        
        
        private RewardSlotView CreateRewardSlotView() =>
            Object.Instantiate
            (
                _rewardView.RewardSlotPrefab,
                _rewardView.RewardSlotsContainer,
                false
            );
        
        
        private void DeinitSlots()
        {
            foreach (RewardSlotView slot in _slots)
            {
                if (slot) Object.Destroy(slot.gameObject);
            }
            
            _slots.Clear();
        }
        
        
        private void StartRewardsUpdating() =>
            _coroutine = _rewardView.StartCoroutine(RewardsStateUpdater());
        
        
        private void StopRewardsUpdating()
        {
            if (_coroutine == null)
                return;

            if (_rewardView != null) _rewardView.StopCoroutine(_coroutine);
            _coroutine = null;
        }
        
        
        private IEnumerator RewardsStateUpdater()
        {
            WaitForSeconds waitForSecond = new WaitForSeconds(1);

            while (true)
            {
                RefreshRewardsState();
                RefreshUi();
                yield return waitForSecond;
            }
        }
        
        
        private void SubscribeButtons()
        {
            _rewardView.GetRewardButton.onClick.AddListener(ClaimReward);
            _rewardView.ResetButton.onClick.AddListener(ResetRewardsState);
        }

        
        private void UnsubscribeButtons()
        {
            _rewardView.GetRewardButton.onClick.RemoveListener(ClaimReward);
            _rewardView.ResetButton.onClick.RemoveListener(ResetRewardsState);
        }
        
        
        private void ClaimReward()
        {
            if (!_isRewardReady)
                return;

            Reward reward = _rewardView.Rewards[_rewardView.CurrentActiveSlot];

            switch (reward.RewardType)
            {
                case RewardType.Wood:
                    _currencyView.AddWood(reward.CountCurrency);
                    break;
                
                case RewardType.Crystal:
                    _currencyView.AddCrystal(reward.CountCurrency);
                    break;
            }

            _rewardView.TimeGetReward = DateTime.UtcNow;
            _rewardView.CurrentActiveSlot++;

            RefreshRewardsState();
        }
        
        
        private void RefreshRewardsState()
        {
            bool gotRewardEarlier = _rewardView.TimeGetReward.HasValue;
            if (!gotRewardEarlier)
            {
                _isRewardReady = true;
                return;
            }

            TimeSpan timeFromLastRewardGetting = DateTime.UtcNow - _rewardView.TimeGetReward.Value;

            bool isDeadlineElapsed = timeFromLastRewardGetting.TotalSeconds >= _rewardView.TimeDeadline;

            bool isTimeToGetNewReward = timeFromLastRewardGetting.TotalSeconds >= _rewardView.TimeCooldown;

            if (isDeadlineElapsed) 
                ResetRewardsState();

            _isRewardReady = isTimeToGetNewReward;
        }

        
        private void ResetRewardsState()
        {
            _rewardView.TimeGetReward = null;
            _rewardView.CurrentActiveSlot = 0;
        }


        private void RefreshUi()
        {
            _rewardView.GetRewardButton.interactable = _isRewardReady;
            _rewardView.TimerNewReward.text = GetTimerNewRewardText();
            RefreshSlots();
        }

        
        private string GetTimerNewRewardText()
        {
            if (_isRewardReady)
                return "The reward is ready to be received!";

            if (_rewardView.TimeGetReward.HasValue)
            {
                DateTime nextClaimTime = _rewardView.TimeGetReward.Value.AddSeconds(_rewardView.TimeCooldown);
                TimeSpan currentClaimCooldown = nextClaimTime - DateTime.UtcNow;

                string timeGetReward =
                    $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:" +
                    $"{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                return $"Time to get the next reward: {timeGetReward}";
            }

            return string.Empty;
        }

        
        private void RefreshSlots()
        {
            for (int i = 0; i < _slots.Count; i++)
            {
                Reward reward = _rewardView.Rewards[i];
                int countDay = i + 1;
                bool isSelected = i == _rewardView.CurrentActiveSlot;

                _slots[i].SetData(reward, countDay, isSelected);
            }
        }
        
        
    }
}