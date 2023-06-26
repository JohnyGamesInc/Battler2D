using UnityEngine;


namespace _Rewards._Main
{
    
    internal sealed class CurrencyView : MonoBehaviour
    {
        
        private const string WoodKey = nameof(WoodKey);
        private const string CrystalKey = nameof(CrystalKey);

        [SerializeField] private CurrencySlotView _woodCurrency;
        [SerializeField] private CurrencySlotView _crystalCurrency;

        
        private int Wood
        {
            get => PlayerPrefs.GetInt(WoodKey);
            set => PlayerPrefs.SetInt(WoodKey, value);
        }

        
        private int Diamond
        {
            get => PlayerPrefs.GetInt(CrystalKey);
            set => PlayerPrefs.SetInt(CrystalKey, value);
        }
        

        private void Start()
        {
            _woodCurrency.SetData(Wood);
            _crystalCurrency.SetData(Diamond);
        }


        public void AddWood(int value)
        {
            Wood += value;
            _woodCurrency.SetData(Wood);
        }

        
        public void AddCrystal(int value)
        {
            Diamond += value;
            _crystalCurrency.SetData(Diamond);
        }
        
    }
}