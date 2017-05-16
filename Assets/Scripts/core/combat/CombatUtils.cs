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
        public static void HandleAttack(ref Unit attacker, ref Unit defender)
        {
            Debug.Log("Start attack : " + attacker.vo.uid + " vs " + defender.vo.uid);

            if (attacker.ammo == 0)
            {
                Debug.Log(attacker.vo.uid + " NO AMMO!!");
                return;
            }

            // calculate the damage
            int damage = attacker.vo.basedamage;

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
            attacker.ammo -= ammoUsed;
        }


    }
}