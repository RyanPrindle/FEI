using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning_Scheduler_Interface.Classes
{
    class ColumnRequest
    {
        private String mPartnumber { get; set; }
        private String mContact { get; set; }
        private bool mHot { get; set; }
        private DateTime mRequestedDate { get; set; }
        private DateTime mStartedDate { get; set; }
        private DateTime mFinishedDate { get; set; }
        private bool mUltrasonic { get; set; }
        private bool mCrest10 { get; set; }
        private bool mCrest20 { get; set; }
        private bool mCrestLong { get; set; }
        private bool mDecon { get; set; }
        private bool mDishWasher { get; set; }
        private bool mWaterPik { get; set; }

    }
}
