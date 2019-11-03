// Lee (1720076)
using ItemSystem.Definitions;

namespace ItemSystem.Keys
{
    internal sealed class SilverKey : KeyItem
    {
        private const string IconPath = "ItemIcons/Keys/SilverKey";
        private const string ItemName = "Silver Key";

        public SilverKey()
            : base(ItemName,
                   IconPath)
        { }
    }
}
