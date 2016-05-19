using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacuum_Furnace_Scheduler_v1._0
{
    class JobRequest
    {
        private int mQuantity;
        private String mPartNumber;
        private String mCustomer;
        private int mCustomerId;
        private String mContact;
        private int mContactId;
        private String mLocation;
        private bool mHot;
        private List<String> mSerialNumberList;
        
        public JobRequest()
        {
            mQuantity = 0;
            mPartNumber = "";
            mCustomer = "";
            mCustomerId = 0;
            mContact = "";
            mContactId = 1;
            mLocation = "";
            mHot = false;
            mSerialNumberList = new List<String>();
        }

        public void SetQuantity(int qty)
        {
            mQuantity = qty;
        }
        public int GetQuantity()
        {
            return mQuantity;
        }

        public void SetPartNumber(String part)
        {
            mPartNumber = part;
        }
        public String GetPartNumber()
        {
            return mPartNumber;
        }

        public void SetCustomer(String cust)
        {
            mCustomer = cust;
        }
        public String GetCustomer()
        {
            return mCustomer;
        }

        public void SetCustomerId(int custId)
        {
            mCustomerId = custId;
        }
        public int GetCustomerId()
        {
            return mCustomerId;
        }

        public void SetContact(String contact)
        {
            mContact = contact;
        }
        public String GetContact()
        {
            return mContact;
        }

        public void SetContactId(int contactId)
        {
            mContactId = contactId;
        }
        public int GetContactId()
        {
            return mContactId;
        }

        public void SetLocation(String loc)
        {
            mLocation = loc;
        }
        public String GetLocation()
        {
            return mLocation;
        }

        public void SetHot(bool hot)
        {
            mHot = hot;
        }
        public bool GetHot()
        {
            return mHot;
        }

        public void SetSerialNumber(String serial)
        {
            mSerialNumberList.Add(serial);
        }
        public List<String> GetSerialNumbers()
        {
            return mSerialNumberList;
        }
    }
}
