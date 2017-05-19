/*** ---------------------------------------------------------------------------
/// UnitVO.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 14th, 2017</date>
/// ------------------------------------------------------------------------***/

using System;
using System.Collections.Generic;

namespace core.data.vo
{
    /// <summary>
    /// The value object data for a unit.
    /// </summary>
    [Serializable]
    public class UnitVO : BaseVO
    {
        /// <summary>
        /// The raw type string. Should enum this later.
        /// </summary>
        public string type;

        /// <summary>
        /// How much base health this unit starts with
        /// </summary>
        public int hp;

        /// <summary>
        /// The amount of base damage this unit can do
        /// </summary>
        public int baseDamage;

        /// <summary>
        /// How much ammunition this unit can carry
        /// </summary>
        public int ammo;

        /// <summary>
        /// The movement speed is how many tiles this unit can move in one turn
        /// </summary>
        public int speed;

        /// <summary>
        /// How many tiles a unit can move before running out of fuel
        /// </summary>
        public int fuel;

        /// <summary>
        /// Space deliminated list of default equipment for this unit
        /// </summary>
        public string equipmentList;

        public string[] equipmentUIDs;

        public override void Process()
        {
            // Only if we have something for the equipmentList do we need to add anything;
            if (!string.IsNullOrEmpty(equipmentList))
            {
                // Split it on the space
                equipmentUIDs = equipmentList.Split(' ');
            }

            base.Process();
        }
    }
}