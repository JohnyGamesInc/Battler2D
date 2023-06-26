using System;
using UnityEngine;


namespace _Rewards._Main
{
    
    [Serializable]
    internal sealed class Reward
    {
        
        [field: SerializeField] public RewardType RewardType { get; private set; }
        
        [field: SerializeField] public RewardTimeType RewardTimeType { get; private set; }
        [field: SerializeField] public Sprite IconCurrency { get; private set; }
        [field: SerializeField] public int CountCurrency { get; private set; }
        
    }
}