using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning_Scheduler_Interface
{
    class CleanProcedure
    {
        public int mReqID { get; set; }
        public bool mUltrasonic { get; set; }
        public bool mCrest10 { get; set; }
        public bool mCrest20 { get; set; }
        public bool mCrestLong { get; set; }
        public bool mDecon { get; set; }
        public bool mDishWasher { get; set; }
        public bool mWaterPik { get; set; }
    }
}
