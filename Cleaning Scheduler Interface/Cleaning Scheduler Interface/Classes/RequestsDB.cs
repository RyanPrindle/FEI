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
        private static string GUNTABLE = "GunTable";
        private static string GUNPARTTABLE = "GunPartTable";
        private static string HISTORY = "HistoryQuery";
        private static string REQUEST = "RequestQuery";

        public RequestsDB()
        {
            requestDB = new DB(cleaningRequestsDBFullPath);
        }
        public DataTable GetRequestsTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + REQUEST;
            return requestDB.GetDataTable(cmd);
        }

        public DataTable GetRequestHistoryTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + HISTORY;
            return requestDB.GetDataTable(cmd);
        }

        public DataTable GetRequest(int reqID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + REQUEST + " WHERE [RequestID] = @reqID";
            cmd.Parameters.AddWithValue("@reqID", reqID);
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

        public int DeleteRequest(int reqId)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE FROM " + REQUESTTABLE + "  WHERE [RequestID] = @reqID";
            cmd.Parameters.AddWithValue("@reqID", reqId);
            return requestDB.Update(cmd);
        }

        public int BackUpRequest(int reqId)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE " + REQUESTTABLE + " SET [StartedOn] = @null WHERE [RequestID] = @reqID";
            cmd.Parameters.AddWithValue("@null", DBNull.Value);
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
            "[WaterPik] = @waterpik, [Ultrasonic] = @ultrasonic, [Crest10] = @crest10, [Crest20] = @crest20, [CrestLong] = @crestlong WHERE [RequestID] = @reqID";
            cmd.Parameters.AddWithValue("@date", now);
            cmd.Parameters.AddWithValue("@decon", reqCleanProcedures.mDecon);
            cmd.Parameters.AddWithValue("@dishwasher", reqCleanProcedures.mDishWasher);
            cmd.Parameters.AddWithValue("@waterpik", reqCleanProcedures.mWaterPik);
            cmd.Parameters.AddWithValue("@ultrasonic", reqCleanProcedures.mUltrasonic);
            cmd.Parameters.AddWithValue("@crest10", reqCleanProcedures.mCrest10);
            cmd.Parameters.AddWithValue("@crest20", reqCleanProcedures.mCrest20);
            cmd.Parameters.AddWithValue("@crestlong", reqCleanProcedures.mCrestLong);
            cmd.Parameters.AddWithValue("@reqID", reqCleanProcedures.mReqID);
            return requestDB.Update(cmd);
        }

#endregion
#region Gun

        public DataTable GetGunTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + GUNTABLE + " ORDER BY Type";
            return requestDB.GetDataTable(cmd);
        }

        public int AddGunRequest(GunRequest request)
        {
            {
                String now = DateTime.Now.ToString();
                OleDbCommand cmd = new OleDbCommand();
                if (request.mContactId < 1)
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Requestor], [RequestedOn], [PartNumber], [Instructions], [SerialNumber], [Hot], [Quantity], [Description]) " +
                                      "VALUES (@requestor, @requestedOn, @type, @instructions, @serial, @hot, @qty, @desc)";                   
                }
                else
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Contact], [Requestor], [RequestedOn], [PartNumber], [Instructions], [SerialNumber], [Hot], [Quantity], [Description]) " +
                                      "VALUES (@contact, @requestor, @requestedOn, @type, @instructions,  @serial, @hot, @qty, @desc)";
                    cmd.Parameters.AddWithValue("@contact", request.mContactId);
                }
                cmd.Parameters.AddWithValue("@requestor", request.mRequestor);
                cmd.Parameters.AddWithValue("@requestedOn", now);
                cmd.Parameters.AddWithValue("@type", request.mType);
                cmd.Parameters.AddWithValue("@instructions", request.mInstructions);
                cmd.Parameters.AddWithValue("@serial", request.mSerial);
                cmd.Parameters.AddWithValue("@hot", request.mHot);
                cmd.Parameters.AddWithValue("@qty", request.mQty);
                cmd.Parameters.AddWithValue("@desc", request.mDescription);
                return requestDB.AddReturnID(cmd);
            }
        }

        public DataTable GetGunParts(String gun)
        {
            string query;
            switch(gun)
            {
                case "Tomahawk Column":
                    query = "TomahawkQuery";
                    break;
                case "Sidewinder Column":
                    query = "SidewinderQuery";
                    break;
                case "KLA Gun":
                    query = "KLAQuery";
                    break;
                case "UC Gun":
                    query = "UCQuery";
                    break;
                case "NGSEM Gun":
                    query = "NGSEMQuery";
                    break;
                case "Magnum Column":
                    query = "MagnumQuery";
                    break;
                case "Chamber Kit":
                    query = "ChamberKitQuery";
                    break;
                case "ELEC Module":
                    query = "SidewinderQuery";
                    break;
                case "Pheonix Column":
                    query = "PheonixQuery";
                    break;
                case "Phi Evans Column":
                    query = "PhiEvansQuery";
                    break;
                case "Plasma Column":
                    query = "PlasmaQuery";
                    break;
                case "Vectra Column":
                    query = "VectraQuery";
                    break;
                case "VisionaryColumn":
                    query = "Visionary Query";
                    break;
                default:
                    query = GUNPARTTABLE;
                    break;
            }
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + query;
            return requestDB.GetDataTable(cmd);
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
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Requestor], [RequestedOn], [PartNumber], [Instructions], [PO], [SerialNumber], " +
                                      "[Quantity], [Hot], [Site], [CR Ready], [Cage], [Bulk], [Description]) " +
                                      "VALUES (@requestor, @requestedOn, @part, @instructions, @po,  @serial, @qty, @hot, @site, @cr, @cage, @bulk, @desc)";
                }
                else
                {
                    cmd.CommandText = "INSERT INTO " + REQUESTTABLE + " ([Contact], [Requestor], [RequestedOn], [PartNumber], [Instructions], [PO], [SerialNumber], " +
                                      "[Quantity], [Hot], [Site], [CR Ready], [Cage], [Bulk], [Description]) " +
                                      "VALUES (@contact, @requestor, @requestedOn, @part, @instructions, @po,  @serial, @qty, @hot, @site, @cr, @cage, @bulk, @desc)";
                    cmd.Parameters.AddWithValue("@contact", request.mContactId);
                }
                cmd.Parameters.AddWithValue("@requestor", request.mRequestor);
                cmd.Parameters.AddWithValue("@requestedOn", now);
                cmd.Parameters.AddWithValue("@part", request.mPart);
                cmd.Parameters.AddWithValue("@instructions", request.mInstructions);
                cmd.Parameters.AddWithValue("@po", request.mPO);
                cmd.Parameters.AddWithValue("@serial", request.mSerial);
                cmd.Parameters.AddWithValue("@qty", request.mQty);
                cmd.Parameters.AddWithValue("@hot", request.mHot);
                cmd.Parameters.AddWithValue("@site", request.mSite);
                cmd.Parameters.AddWithValue("@cr", request.mCleanroomReady);
                cmd.Parameters.AddWithValue("@cage", request.mCage);
                cmd.Parameters.AddWithValue("@bulk", request.mBulk);
                cmd.Parameters.AddWithValue("@desc", request.mDescription);
                return requestDB.AddReturnID(cmd);
            }
        }
#endregion
    }
}
