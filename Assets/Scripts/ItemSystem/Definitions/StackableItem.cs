// Lee (1720076)

namespace ItemSystem.Definitions
{
    /// <summary>Inherits from base class, adding stackability
    /// to the <see cref="Item"/> class
    /// </summary> 
    public abstract class StackableItem : Item
    {
        /// <summary>
        /// The maximum amount of an <see cref="Item"/>
        /// that can be contained in a "stack"
        /// </summary>
        public int MaxStackAmount;

        protected StackableItem(string name,
                                string iconPath,
                                int maxStackAmount)
            : base(name, iconPath)
        {
            MaxStackAmount = maxStackAmount;
        }
    }
}
