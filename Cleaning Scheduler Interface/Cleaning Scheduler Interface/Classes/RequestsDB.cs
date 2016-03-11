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
        private static string COLUMNTABLE = "ColumnTable";

        public RequestsDB()
        {
            requestDB = new DB(cleaningRequestsDBFullPath);
        }
        public DataTable GetRequestsTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = //"SELECT * FROM " + REQUESTTABLE;
            "SELECT RequestTable.RequestID, RequestTable.Requestor, RequestTable.RequestedOn, " +
            "RequestTable.StartedOn, RequestTable.FinishedOn, RequestTable.PartNumber, RequestTable.Type1, " +
            "RequestTable.Type2, RequestTable.Type3, RequestTable.Type4, ContactTable.Email, " +
            "RequestTable.SerialNumber, RequestTable.PO, RequestTable.Hot FROM ContactTable " +
            "INNER JOIN RequestTable ON ContactTable.ContactId = RequestTable.Contact";
            return requestDB.GetDataTable(cmd);
        }

        public DataTable GetQueuedRequests()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + REQUESTTABLE + " WHERE StartedOn = dbNull";
            return requestDB.GetDataTable(cmd);
        }

#region Contact

        public DataTable GetContactTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + CONTACTTABLE + " ORDER BY ContactId";
            return requestDB.GetDataTable(cmd);
        }

        public int IsContact(String email)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + CONTACTTABLE + " WHERE Email = @Email";
            cmd.Parameters.AddWithValue("@Email", email.ToLower());
            return requestDB.GetID(cmd, "ContactId");
        }

        public int AddIfNewContact(String email)
        {
            int iD = 0;
            iD = IsContact(email);
            if (iD == 0)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "INSERT INTO " + CONTACTTABLE + " ([EMail]) VALUES (@email)";
                cmd.Parameters.AddWithValue("@email", email.ToLower());
                iD = requestDB.AddReturnID(cmd);
            }
            return iD;
        }

#endregion
#region Column

        public DataTable GetColumnsTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + COLUMNTABLE + " ORDER BY Type";
            return requestDB.GetDataTable(cmd);
        }

        public int AddColumnRequest(ColumnRequest request)
        {
            {
                String now = DateTime.Now.ToShortDateString();
                OleDbCommand cmd = new OleDbCommand();
                if (request.mContactId < 1)
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Requestor], [RequestedOn], [PartNumber], [Comment], [SerialNumber], [Hot]) " +
                                      "VALUES (@requestor, @requestedOn, @type, @comment, @serial, @hot)";                   
                }
                else
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Contact], [Requestor], [RequestedOn], [PartNumber], [Comment], [SerialNumber], [Hot]) " +
                                      "VALUES (@contact, @requestor, @requestedOn, @type, @comment,  @serial, @hot)";
                    cmd.Parameters.AddWithValue("@contact", request.mContactId);
                }
                    cmd.Parameters.AddWithValue("@requestor", request.mRequestor);
                    cmd.Parameters.AddWithValue("@requestedOn", now);
                    cmd.Parameters.AddWithValue("@type", request.mType);
                    cmd.Parameters.AddWithValue("@comment", request.mComment);
                    cmd.Parameters.AddWithValue("@serial", request.mSerial);
                    cmd.Parameters.AddWithValue("@hot", request.mHot);                    
                return requestDB.AddReturnID(cmd);
            }
        }

#endregion

    }
}
