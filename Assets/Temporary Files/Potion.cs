// Lee (1720076)
using UnityEngine;

namespace Temporary_Files
{
    [CreateAssetMenu(fileName = "New Potion", menuName = "Potion")]
    public class Potion : ScriptableObject
    {
        public string Name;
        public string Description;
        public Sprite Sprite1;
        public Sprite Sprite2;
        public int StatEffect;
        public int BuyPrice;
        public int SellPrice;

        public void Print()
        {
            Debug.Log("Name:" + Name+"." +
                      "Description:" + Description + "." +
                      "Stat Effect:" + StatEffect + "." +
                      "Buy Price:" + BuyPrice + "." +
                      "Sell Price:" + SellPrice + ".");
        }
    }
}