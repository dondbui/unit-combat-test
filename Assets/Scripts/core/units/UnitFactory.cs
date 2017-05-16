/*** ---------------------------------------------------------------------------
/// UnitFactory.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 15th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.data;
using core.data.vo;
using System.Collections.Generic;

namespace core.units
{
    /// <summary>
    /// The factory that creates new units given a UID
    /// </summary>
    public class UnitFactory
    {
        private static UnitFactory instance;

        private MetadataMap metadataMap;

        private UnitFactory()
        {

        }

        public static UnitFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new UnitFactory();
            }

            return instance;
        }

        public void SetMetadata(MetadataMap metadataMap)
        {
            this.metadataMap = metadataMap;
        }

        public Unit CreateNewUnit(string uid)
        {
            UnitVO vo = metadataMap.GetVO<UnitVO>(uid);

            List<Equipment> defaultEquipment = new List<Equipment>();

            if (!string.IsNullOrEmpty(vo.equipment1))
            {
                EquipmentVO eq1VO = metadataMap.GetVO<EquipmentVO>(vo.equipment1);



                defaultEquipment.Add(new Equipment(eq1VO));
            }

            if (!string.IsNullOrEmpty(vo.equipment2))
            {
                EquipmentVO eq2VO = metadataMap.GetVO<EquipmentVO>(vo.equipment2);
                defaultEquipment.Add(new Equipment(eq2VO));
            }

            Unit unit = new Unit(vo, defaultEquipment);
            return unit;
        }
    }
}