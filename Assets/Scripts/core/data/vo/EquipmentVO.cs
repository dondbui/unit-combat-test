using System;

namespace core.data.vo
{
    /// <summary>
    /// Items that can be equiped onto Units to modify attributes
    /// </summary>
    [Serializable]
    public class EquipmentVO : BaseVO
    {
        /// <summary>
        /// The amount of base damage this unit can do
        /// </summary>
        public int basedamage;

        /// <summary>
        /// The type of equipment this is
        /// </summary>
        public string type;

        /// <summary>
        /// The amount of ammo capacity for this type of equipment.
        /// </summary>
        public int ammocapacity;

        /// <summary>
        /// The amount of additional damage this equipment adds
        /// </summary>
        public int damagebonus;

        /// <summary>
        /// How much additional health this unit can receive
        /// </summary>
        public int healthbonus;

        /// <summary>
        /// How much damage this piece of equipment helps with
        /// </summary>
        public int damagereduction;

        /// <summary>
        /// The range of the attack
        /// </summary>
        public int range;
    }
}