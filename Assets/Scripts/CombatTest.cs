/*** ---------------------------------------------------------------------------
/// CombatTest.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 14th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.data;
using UnityEngine;

/// <summary>
/// Contains all the test specific code and logic. 
/// </summary>
public class CombatTest : MonoBehaviour
{
    private const string METADATA_FILE = "metadata";

    void Start ()
    {
        Debug.Log("Start");

        // Attempt to load the JSON file. 

        MetadataMap map = MetadataLoader.LoadMetaDataFile(METADATA_FILE);

        Debug.Log("End");
    }
    
    // Update is called once per frame
    void Update ()
    {
    
    }
}
