using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning_Scheduler_Interface
{
    class PartRequest
    {
        public String mRequestor { get; set; }
        public String mPart { get; set; }
        public int mContactId { get; set; }
        public String mComment { get; set; }
        public String mSerial { get; set; }
        public String mSite { get; set; }
        public String mPO { get; set; }
        public bool mHot { get; set; }
        public String mStockLocation { get; set; }
        public bool mCleanroomReady { get; set; }
        public bool mCage { get; set; }
        public bool mBulk { get; set; }
        public DateTime mRequestedDate { get; set; }
        public DateTime mStartedDate { get; set; }
        public DateTime mFinishedDate { get; set; }
        public bool mUltrasonic { get; set; }
        public bool mCrest10 { get; set; }
        public bool mCrest20 { get; set; }
        public bool mCrestLong { get; set; }
        public bool mDecon { get; set; }
        public bool mDishWasher { get; set; }
        public bool mWaterPik { get; set; }
    }
}
