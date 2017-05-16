/*** ---------------------------------------------------------------------------
/// CombatTest.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 14th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.data;
using core.units;
using UnityEngine;

/// <summary>
/// Contains all the test specific code and logic. 
/// </summary>
public class CombatTest : MonoBehaviour
{
    private const string METADATA_FILE = "metadata";

    private const string SCOUT = "scout";

    private const string D_SCOUT = "deimos_scout";

    void Start ()
    {
        Debug.Log("Start");

        // Attempt to load the JSON file. 

        MetadataMap map = MetadataLoader.LoadMetaDataFile(METADATA_FILE);

        UnitFactory uf = UnitFactory.GetInstance();

        uf.SetMetadata(map);

        Unit scout = uf.CreateNewUnit(SCOUT);
        Unit deimosScout = uf.CreateNewUnit(D_SCOUT);

        Debug.Log("End");
    }
    
    // Update is called once per frame
    void Update ()
    {
    
    }
}
