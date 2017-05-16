/*** ---------------------------------------------------------------------------
/// BaseVO.cs
/// 
/// <author>Don Duy Bui</author>
/// <date>May 15th, 2017</date>
/// ------------------------------------------------------------------------***/

using System;

namespace core.data.vo
{
    /// <summary>
    /// Base class for all VO
    /// </summary>
    [Serializable]
    public class BaseVO
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        public string uid;

    }
}