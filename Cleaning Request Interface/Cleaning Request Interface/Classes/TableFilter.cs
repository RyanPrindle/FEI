using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning_Request_Interface
{
    class TableFilter
    {
        public DataTable mDTable { get; set; }
        public String mPart { get; set; }
        public String mRequestor { get; set; }
        public int mCRR { get; set; }
        public int mHot { get; set; }
        public DateTime mReqStart { get; set; }
        public DateTime mReqStop { get; set; }
        public DateTime mInProcStart { get; set; }
        public DateTime mInProcStop { get; set; }
        public DateTime mFinStart { get; set; }
        public DateTime mFinStop { get; set; }

        public TableFilter(DataTable dT)
        {
            mDTable = dT;
            mPart = "";
            mRequestor = "";
            mCRR = 0;
            mHot = 0;
        }
    }
}
