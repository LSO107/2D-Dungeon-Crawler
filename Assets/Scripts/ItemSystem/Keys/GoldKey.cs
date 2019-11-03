// Lee (1720076)
using ItemSystem.Definitions;

namespace ItemSystem.Keys
{
    internal sealed class GoldKey : KeyItem
    {
        private const string IconPath = "ItemIcons/Keys/GoldKey";
        private const string ItemName = "Gold Key";

        public GoldKey()
            : base(ItemName,
                   IconPath)
        { }
    }
}
