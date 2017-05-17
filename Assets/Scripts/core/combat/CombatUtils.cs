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
        public static void HandleAttack(ref Unit attacker, int atkEqpSlot, ref Unit defender, int defEqpSlot)
        {
            Equipment attackerEquipment = attacker.equipment[atkEqpSlot];

            Debug.Log("Start attack : " + attacker.vo.uid + " uses " + 
                attackerEquipment.vo.uid +" on " + defender.vo.uid);

            if (attackerEquipment.remainingAmmo == 0)
            {
                Debug.Log(attacker.vo.uid + " NO AMMO!!");
                return;
            }

            // calculate the damage
            int damage = attackerEquipment.vo.basedamage;

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
            attackerEquipment.remainingAmmo -= ammoUsed;

            Equipment defenderEquipment = defender.equipment[defEqpSlot];

            if (defenderEquipment.remainingAmmo == 0)
            {
                Debug.Log(defender.vo.uid + " NO AMMO!!");
                return;
            }

            // now it's the defender's turn to fire back
            Debug.Log("Counter-Attack : " + defender.vo.uid + " uses " +
                defenderEquipment.vo.uid + " on " + attacker.vo.uid);

            int counterDamage = defenderEquipment.vo.basedamage;

            attacker.hp -= counterDamage;
            // prevent it from going negative.
            if (attacker.hp <= 0)
            {
                attacker.hp = 0;

                Debug.Log(attacker.vo.uid + " DESTROYED!!");
            }
            defenderEquipment.remainingAmmo -= ammoUsed;
        }
    }
}