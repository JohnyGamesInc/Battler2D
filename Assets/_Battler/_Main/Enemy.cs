﻿using UnityEngine;


namespace _Battler._Main
{
    
    internal interface IEnemy
    {
        void Update(PlayerData playerData);
    }

    
    
    internal class Enemy : IEnemy
    {
        private const float KMoney = 5f;
        private const float KPower = 1.5f;
        private const float MaxHealthPlayer = 20;
        private const float KCriminal = 3.0f;

        private readonly string _name;

        private int _moneyPlayer;
        private int _healthPlayer;
        private int _powerPlayer;
        private int _criminalPlayer;


        public Enemy(string name) =>
            _name = name;


        public void Update(PlayerData playerData)
        {
            switch (playerData.DataType)
            {
                case DataType.Money:
                    _moneyPlayer = playerData.Value;
                    break;

                case DataType.Health:
                    _healthPlayer = playerData.Value;
                    break;

                case DataType.Power:
                    _powerPlayer = playerData.Value;
                    break;
                
                case DataType.Criminal:
                    _criminalPlayer = playerData.Value;
                    break;
            }

            Debug.Log($"Notified {_name} change to {playerData.DataType:F}");
        }

        
        public int CalcPower()
        {
            int kHealth = CalcKHealth();
            float moneyRatio = _moneyPlayer / KMoney;
            float powerRatio = _powerPlayer / KPower;
            float criminalRation = _criminalPlayer / KCriminal;

            return (int)(moneyRatio + kHealth + powerRatio + criminalRation);
        }


        private int CalcKHealth() =>
            _healthPlayer > MaxHealthPlayer ? 100 : 5;
        
    }
}