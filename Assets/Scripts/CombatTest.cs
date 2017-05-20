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

                if (pendingUnits.Count > 0)
                {
                    // Get the next pending unit
                    Unit playerUnit = pendingUnits[0];

                    if (enemyEncounterUnits.Count > 0)
                    {
                        Unit enemyUnit = enemyEncounterUnits[0];

                        cec.AttackUnit(playerUnit, 0, enemyUnit);
                    }
                }
            }
            else if (cec.CurrentFaction == CombatantFactionEnum.Enemy)
            {
                List<Unit> playerEncounterUnits = cec.CurrentEncounter.PlayerUnits;

                if (pendingUnits.Count > 0)
                {
                    // Get the next pending unit
                    Unit enemyUnit = pendingUnits[0];

                    if (playerEncounterUnits.Count > 0)
                    {
                        Unit playerUnit = playerEncounterUnits[0];

                        cec.AttackUnit(enemyUnit, 0, playerUnit);
                    }
                }
            }
            else
            {
                cec.GoToNextStep();
            }
        }

        Debug.Log("End");
    }
    
    // Update is called once per frame
    void Update ()
    {
    
    }
}
