/*** ---------------------------------------------------------------------------
/// CombatTest.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 14th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.combat;
using core.data;
using core.units;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains all the test specific code and logic. 
/// </summary>
public class CombatTest : MonoBehaviour
{
    private const string METADATA_FILE = "metadata";

    private const string UNIT_SCOUT = "scout";

    private const string UNIT_DSCOUT = "deimos_scout";

    private const string CHAR_SHERMAN = "sherman";
    private const string CHAR_DEFAULT = "defaultEnemy";

    void Start ()
    {
        Debug.Log("Start");

        // Attempt to load the JSON file. 

        MetadataMap map = MetadataLoader.LoadMetaDataFile(METADATA_FILE);

        UnitFactory uf = UnitFactory.GetInstance();

        uf.SetMetadata(map);

        List<Unit> playerUnits = new List<Unit>();
        List<Unit> enemyUnits = new List<Unit>();
        List<Unit> neutralUnits = new List<Unit>();

        Unit scout = uf.CreateNewUnit(UNIT_SCOUT, CHAR_SHERMAN, CombatantFactionEnum.Player);
        playerUnits.Add(scout);

        for (int i = 0; i < 3; i++)
        {
            Unit deimosScout = uf.CreateNewUnit(UNIT_DSCOUT, CHAR_DEFAULT, CombatantFactionEnum.Enemy);
            enemyUnits.Add(deimosScout);
        }

        CombatEncounterController cec = CombatEncounterController.GetInstance();
        cec.StartEncounter(playerUnits, enemyUnits, neutralUnits);

        // While the encounter is still going on try to force the units to attack the first one
        // in the enemy list
        while (!cec.IsEncounterOver())
        {
            List<Unit> pendingUnits = cec.CurrentEncounter.UnitsPendingAction;
            if (cec.CurrentFaction == CombatantFactionEnum.Player)
            {

                List<Unit> enemyEncounterUnits = cec.CurrentEncounter.EnemyUnits;

                TryAttacking(pendingUnits, enemyEncounterUnits);
            }
            else if (cec.CurrentFaction == CombatantFactionEnum.Enemy)
            {
                List<Unit> playerEncounterUnits = cec.CurrentEncounter.PlayerUnits;

                TryAttacking(pendingUnits, playerEncounterUnits);
            }
            else
            {
                cec.GoToNextStep();
            }
        }

        Debug.Log("End");
    }

    private void TryAttacking(List<Unit> pendingUnits, List<Unit> targetUnits)
    {
        // If we don't have any more units waiting then we can't do anything
        if (pendingUnits.Count == 0)
        {
            return;
        }
        // Get the next pending unit
        Unit attacker = pendingUnits[0];

        // Out of targets then we don't care and should bounce out
        if (targetUnits.Count == 0)
        {
            return;
        }

        Unit defender = targetUnits[0];
        CombatEncounterController cec = CombatEncounterController.GetInstance();

        // Attack it using the first weapon slot
        cec.AttackUnit(attacker, 0, defender);
    }
    
    // Update is called once per frame
    void Update ()
    {
    
    }
}
