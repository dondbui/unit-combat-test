/*** ---------------------------------------------------------------------------
/// CombatController.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 15th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.data.vo;
using core.units;
using UnityEngine;

namespace core.combat
{
    /// <summary>
    /// Static class that handles the combat calculations
    /// </summary>
    public class CombatUtils
    {
        /// <summary>
        /// Handle the attack between 2 combatants
        /// </summary>
        public static void HandleAttack(ref Unit attacker, int atkEqpSlot, ref Unit defender, int defEqpSlot)
        {
            Equipment attackerEquipment = attacker.equipment[atkEqpSlot];
            ApplyDamage(ref attacker, ref attackerEquipment, ref defender);


            // Unit is dead so no counter attack.
            if (defender.hp <= 0)
            {
                return;
            }

            Equipment defenderEquipment = defender.equipment[atkEqpSlot];
            ApplyDamage(ref defender, ref defenderEquipment, ref attacker);
        }

        /// <summary>
        /// Applies damage to the defender
        /// </summary>
        private static void ApplyDamage(ref Unit attacker, ref Equipment equipment, ref Unit defender)
        {
            EquipmentVO equipmentVO = equipment.vo;

            Debug.Log(attacker.vo.uid + " uses " +
                equipmentVO.uid + " on " + defender.vo.uid);

            if (equipment.remainingAmmo == 0)
            {
                Debug.Log(attacker.vo.uid + " NO AMMO!!");
                return;
            }

            // calculate the damage
            int baseShotDamage = equipmentVO.basedamage;
            int numShots = equipmentVO.numshotsperattack;
            double hitChance = equipmentVO.hitchance;

            // do the num shots
            for (int i = 0; i < numShots; i++)
            {
                // TODO: apply dodge reduction
                if (!DoesShotHit(hitChance, 0))
                {
                    Debug.Log("MISS!!!");
                    continue;
                }

                // apply the damage
                defender.hp -= baseShotDamage;

                Debug.Log("DAMAGE: " + baseShotDamage);

                // prevent it from going negative.
                if (defender.hp <= 0)
                {
                    defender.hp = 0;

                    Debug.Log(defender.vo.uid + " DESTROYED!!");
                    break;
                }

                // expend some ammo
                int ammoUsed = 1;
                equipment.remainingAmmo -= ammoUsed;
                if (equipment.remainingAmmo <= 0)
                {
                    Debug.Log(equipmentVO.uid + " Out of AMMO!!");
                    break;
                }
            }
        }

        /// <summary>
        /// Does the shot hit given the attacker's hit chance and the defender's dodge chance
        /// </summary>
        private static bool DoesShotHit(double hitChance, double dodgeChange)
        {
            // Roll for chance to hit
            float roll = Random.Range(0, 1.0f);

            // If we roll under the threshold then we're good
            return roll <= hitChance - dodgeChange;
        }

    }
}