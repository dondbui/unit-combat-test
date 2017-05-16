/*** ---------------------------------------------------------------------------
/// CombatController.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 15th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.units;
using UnityEngine;

namespace core.combat
{
    /// <summary>
    /// Static class that handles the combat calculations
    /// </summary>
    public class CombatUtils
    {
        public static void HandleAttack(ref Unit attacker, int equipmentSlot, ref Unit defender)
        {
            Equipment equipment = attacker.equipment[equipmentSlot];

            Debug.Log("Start attack : " + attacker.vo.uid + " uses " + equipment.vo.uid +" on " + defender.vo.uid);

            if (equipment.remainingAmmo == 0)
            {
                Debug.Log(attacker.vo.uid + " NO AMMO!!");
                return;
            }

            // calculate the damage
            int damage = equipment.vo.basedamage;

            // apply the damage
            defender.hp -= damage;

            // prevent it from going negative.
            if (defender.hp <= 0)
            {
                defender.hp = 0;

                Debug.Log(defender.vo.uid + " DESTROYED!!");
            }

            // expend some ammo
            int ammoUsed = 1;
            equipment.remainingAmmo -= ammoUsed;
        }


    }
}