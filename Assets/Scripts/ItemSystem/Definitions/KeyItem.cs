// Lee (1720076)
namespace ItemSystem.Definitions
{
    /// <summary>
    /// Represents an important <see cref="Item"/> which can't be
    /// dropped, destroyed or sold to a shop
    /// </summary>
    internal abstract class KeyItem : Item
    {
        protected KeyItem(string itemName,
                          string iconPath)
            : base(itemName,
                   iconPath)
        {}
    }
}
