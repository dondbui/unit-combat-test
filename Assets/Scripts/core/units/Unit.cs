﻿/*** ---------------------------------------------------------------------------
/// Unit.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 15th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.data.vo;
using System.Collections.Generic;

namespace core.units
{
    /// <summary>
    /// Represents the unit's state and has reference to the original metadata
    /// </summary>
    public class Unit
    {
        public UnitVO vo;

        /// <summary>
        /// The unit's current remaining HP
        /// </summary>
        public int hp;

        /// <summary>
        /// The unit's remaining ammo
        /// </summary>
        public int ammo;

        /// <summary>
        /// The unit's remaining fuel
        /// </summary>
        public int fuel;

        public List<Equipment> equipment;

        public Unit (UnitVO vo, List<Equipment> equipment)
        {
            this.vo = vo;

            // Initialize the unit with max supplies
            hp = vo.hp;
            ammo = vo.ammo;
            fuel = vo.fuel;

            this.equipment = equipment;
        }
    }
}