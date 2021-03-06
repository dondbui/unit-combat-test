﻿/*** ---------------------------------------------------------------------------
/// MetadataLoader.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 14th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.data.vo;
using UnityEngine;

namespace core.data
{
    /// <summary>
    /// Static class to handle the loading and parsing of the metadata.
    /// </summary>
    public class MetadataLoader
    {
        private const string METADATA_LOC = "JSON/Metadata/";

        public static MetadataMap LoadMetaDataFile(string jsonFileName)
        {
            TextAsset textAsset = Resources.Load<TextAsset>(METADATA_LOC + jsonFileName);

            MetadataMap dataMap = JsonUtility.FromJson<MetadataMap>(textAsset.text);

            // Debug out all the units parsed in.
            for (int i = 0, count = dataMap.Equipment.Count; i < count; i++)
            {
                EquipmentVO vo = dataMap.Equipment[i];

                //Debug.Log("EQ: " + vo.uid);
            }

            dataMap.Process();

            return dataMap;
        }
    }
}