using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleaning_Request_Interface
{
    class GunRequest
    {
        public String mRequestor { get; set; }
        public String mType { get; set; }
        public int mContactId { get; set; }
        public int mQty { get; set; }
        public String mInstructions { get; set; }
        public String mSerial { get; set; }
        public bool mHot { get; set; } 
        public DateTime mRequestedDate { get; set; }
        public String mDescription { get; set; }
    }
}
