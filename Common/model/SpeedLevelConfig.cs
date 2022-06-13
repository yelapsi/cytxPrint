using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common.model
{
   public class SpeedLevelConfig
    {
       public SpeedLevelConfig()
		{}

       /// <summary>
       /// 
       /// </summary>
       public string speedLevel
       {
           set;
           get;
       }
       /// <summary>
       /// 
       /// </summary>
       public Int64 ticketInterval
       {
           set;
           get;
       }
       /// <summary>
       /// 
       /// </summary>
       public Int64 digitalInterval
       {
           set;
           get;
       }
       /// <summary>
       /// 
       /// </summary>
       public Int64 enterInterval
       {
           set;
           get;
       }
       /// <summary>
       /// 
       /// </summary>
       public Int64 dynamicIntervalMin
       {
           set;
           get;
       }
       /// <summary>
       /// 
       /// </summary>
       public Int64 dynamicIntervalMax
       {
           set;
           get;
       }
       /// <summary>
       /// 
       /// </summary>
       public Int64 state
       {
           set;
           get;
       }
    }
}
