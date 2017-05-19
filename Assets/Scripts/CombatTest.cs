/*** ---------------------------------------------------------------------------
/// CombatTest.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 14th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.combat;
using core.data;
using core.units;
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

        Unit scout = uf.CreateNewUnit(UNIT_SCOUT, CHAR_SHERMAN);
        Unit deimosScout = uf.CreateNewUnit(UNIT_DSCOUT, CHAR_DEFAULT);

        Debug.Log(scout.ToString());
        Debug.Log(deimosScout.ToString());

        CombatUtils.HandleAttack(ref scout, 0, ref deimosScout, 0);

        Debug.Log(scout.ToString());
        Debug.Log(deimosScout.ToString());

        Debug.Log("End");
    }
    
    // Update is called once per frame
    void Update ()
    {
    
    }
}
