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
        public int mQty { get; set; }
        public String mDescription { get; set; }
        public String mInstructions { get; set; }
        public String mSerial { get; set; }
        public String mPO { get; set; }
        public bool mHot { get; set; }
        public String mStockLocation { get; set; }
        public bool mCleanroomReady { get; set; }
        public bool mCage { get; set; }
        public bool mBulk { get; set; }
        public DateTime mRequestedDate { get; set; }

        public PartRequest()
        {
            mCage = false;
            mBulk = false;
            mHot = false;
            mCleanroomReady = false;
        }
    }
}
