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
            cmd.CommandText = "SELECT * FROM " + REQUESTTABLE;
            return requestDB.GetDataTable(cmd);
        }

        public int StartCleaning(int reqId)
        {
            String now = DateTime.Now.ToString();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE " + REQUESTTABLE + " SET [StartedOn] = @date WHERE [RequestID] = @reqID";
            cmd.Parameters.AddWithValue("@date", now);
            cmd.Parameters.AddWithValue("@reqID", reqId);
            return requestDB.Update(cmd);
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

        public int FinishClean(CleanProcedure reqCleanProcedures)
        {
            String now = DateTime.Now.ToString();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE " + REQUESTTABLE + " SET [FinishedOn] = @date, [Decon] = @decon, [Dishwasher] = @dishwasher, " + 
            "[WaterPik] = @waterpik, [Ultrasound] = @ultrasound, [Crest10] = @crest10, [Crest20] = @crest20, [CrestLong] = @crestlong WHERE [RequestID] = @reqID";
            cmd.Parameters.AddWithValue("@date", now);
            cmd.Parameters.AddWithValue("@decon", reqCleanProcedures.mDecon);
            cmd.Parameters.AddWithValue("@dishwasher", reqCleanProcedures.mDishWasher);
            cmd.Parameters.AddWithValue("@waterpik", reqCleanProcedures.mWaterPik);
            cmd.Parameters.AddWithValue("@ultrasound", reqCleanProcedures.mUltrasonic);
            cmd.Parameters.AddWithValue("@crest10", reqCleanProcedures.mCrest10);
            cmd.Parameters.AddWithValue("@crest20", reqCleanProcedures.mCrest20);
            cmd.Parameters.AddWithValue("@crestlong", reqCleanProcedures.mCrestLong);

            cmd.Parameters.AddWithValue("@reqID", reqCleanProcedures.mReqID);
            return requestDB.Update(cmd);
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
                String now = DateTime.Now.ToString();
                OleDbCommand cmd = new OleDbCommand();
                if (request.mContactId < 1)
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Requestor], [RequestedOn], [PartNumber], [Comment], [SerialNumber], [Hot], [Quantity]) " +
                                      "VALUES (@requestor, @requestedOn, @type, @comment, @serial, @hot, @qty)";                   
                }
                else
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Contact], [Requestor], [RequestedOn], [PartNumber], [Comment], [SerialNumber], [Hot], [Quantity]) " +
                                      "VALUES (@contact, @requestor, @requestedOn, @type, @comment,  @serial, @hot, @qty)";
                    cmd.Parameters.AddWithValue("@contact", request.mContactId);
                }
                    cmd.Parameters.AddWithValue("@requestor", request.mRequestor);
                    cmd.Parameters.AddWithValue("@requestedOn", now);
                    cmd.Parameters.AddWithValue("@type", request.mType);
                    cmd.Parameters.AddWithValue("@comment", request.mComment);
                    cmd.Parameters.AddWithValue("@serial", request.mSerial);
                    cmd.Parameters.AddWithValue("@hot", request.mHot);
                    cmd.Parameters.AddWithValue("@qty", request.mQty);                   
                return requestDB.AddReturnID(cmd);
            }
        }

#endregion
#region Part
        public int AddPartRequest(PartRequest request)
        {
            {
                String now = DateTime.Now.ToString();
                OleDbCommand cmd = new OleDbCommand();
                if (request.mContactId < 1)
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Requestor], [RequestedOn], [PartNumber], [Comment], [PO], [SerialNumber], " +
                                      "[Quantity], [Hot], [Site], [CleanRoomReady], [Cage], [Bulk]) " +
                                      "VALUES (@requestor, @requestedOn, @type, @comment, @serial, @hot)";
                }
                else
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Contact], [Requestor], [RequestedOn], [PartNumber], [Comment], [PO], [SerialNumber], " +
                                      "[Quantity], [Hot], [Site], [CleanRoomReady], [Cage], [Bulk]) " +
                                      "VALUES (@contact, @requestor, @requestedOn, @part, @comment, @po,  @serial, @qty, @hot, @site, @cr, @cage, @bulk)";
                    cmd.Parameters.AddWithValue("@contact", request.mContactId);
                }
                cmd.Parameters.AddWithValue("@requestor", request.mRequestor);
                cmd.Parameters.AddWithValue("@requestedOn", now);
                cmd.Parameters.AddWithValue("@part", request.mPart);
                cmd.Parameters.AddWithValue("@comment", request.mComment);
                cmd.Parameters.AddWithValue("@po", request.mPO);
                cmd.Parameters.AddWithValue("@serial", request.mSerial);
                cmd.Parameters.AddWithValue("@qty", request.mQty);
                cmd.Parameters.AddWithValue("@hot", request.mHot);
                cmd.Parameters.AddWithValue("@site", request.mSite);
                cmd.Parameters.AddWithValue("@cr", request.mCleanroomReady);
                cmd.Parameters.AddWithValue("@cage", request.mCage);
                cmd.Parameters.AddWithValue("@bulk", request.mBulk);
                return requestDB.AddReturnID(cmd);
            }
        }
#endregion
    }
}
