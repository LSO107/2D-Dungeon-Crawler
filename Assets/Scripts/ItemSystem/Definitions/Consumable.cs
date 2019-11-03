// Lee (1720076)

namespace ItemSystem.Definitions
{
    /// <summary>
    /// An <see cref="Item"/> which is to be consumed
    /// and apply some effect to an object
    /// </summary>
    public abstract class Consumable : StackableItem
    {
        protected Consumable(string name,
                             string iconPath,
                             int maxStackAmount)
            : base(name,
                   iconPath,
                   maxStackAmount)
        {}

        /// <summary>
        /// Defines the behaviour of the <see cref="Item"/> when it is consumed
        /// </summary>
        public abstract void Use();
    }
}
