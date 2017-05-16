/*** ---------------------------------------------------------------------------
/// UnitFactory.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 15th, 2017</date>
/// ------------------------------------------------------------------------***/

using core.data;
using core.data.vo;

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

            Unit unit = new Unit(vo);
            return unit;
        }
    }
}