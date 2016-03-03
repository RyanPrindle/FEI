using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace Cleaning_Scheduler_Interface
{
    class RequestsDB
    {
        private static String cleaningRequestsDBFullPath = @"\\hlsql01\Beamtech\\Cleaning Team\Cleaning Scheduler\CleaningRequestsDB.accdb";
        private DB requestDB;
        private static string REQUESTTABLE = "RequestTable";
        private static string CONTACTTABLE = "ContactTable";

        public RequestsDB()
        {
            requestDB = new DB(cleaningRequestsDBFullPath);
        }
        public DataTable GetRequestsTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + REQUESTTABLE;
            return requestDB.GetDataTable(cmd);
        }

        public DataTable GetQueuedRequests()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + REQUESTTABLE + " WHERE StartedOn = dbNull";
            return requestDB.GetDataTable(cmd);
        }

        public DataTable GetContactTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + CONTACTTABLE;
            return requestDB.GetDataTable(cmd);
        }

        public int IsContact(String email)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + CONTACTTABLE + " WHERE Email = @Email";
            cmd.Parameters.AddWithValue("@Email", email.ToLower());
            return requestDB.GetID(cmd, "ContactID");
        }

        public int AddIfNewContact(String email)
        {
            int iD = 0;
            iD = IsContact(email);
            if (iD == 0)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "Insert into " + CONTACTTABLE + " ([EMail]) values (@email)";
                cmd.Parameters.AddWithValue("@email", email.ToLower());
                iD = requestDB.AddReturnID(cmd);
            }
            return iD;
        }
    }
}
