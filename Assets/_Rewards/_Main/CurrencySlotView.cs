using TMPro;
using UnityEngine;


namespace _Rewards._Main
{
    
    internal sealed class CurrencySlotView : MonoBehaviour
    {
        
        [SerializeField] private TMP_Text _count;


        public void SetData(int count) =>
            _count.text = count.ToString();
        
        
    }
}