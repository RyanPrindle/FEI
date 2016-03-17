using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning_Scheduler_Interface
{
    class ColumnRequest
    {
        public String mRequestor { get; set; }
        public String mType { get; set; }
        public int mContactId { get; set; }
        public int mQty { get; set; }
        public String mComment { get; set; }
        public String mSerial { get; set; }
        public bool mHot { get; set; } 
        public DateTime mRequestedDate { get; set; }
    }
}
