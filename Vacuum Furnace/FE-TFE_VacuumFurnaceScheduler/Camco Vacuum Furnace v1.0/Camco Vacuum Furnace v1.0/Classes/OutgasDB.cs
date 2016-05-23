using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Vacuum_Furnace_Scheduler_v1._0
{
    class OutgasDB 
    {
        private static string OUTGASDBCONNSTRING = @"Provider=Microsoft Office 12.0 Access Database Engine OLE DB Provider;Data Source= " +
            // @"D:\Desktop\Camco Vacuum Furnace\BE\Outgas_be.accdb";
                                      //@"C:\Users\rprindle\Desktop\TFE_VacuumFurnaceScheduler\BE-TFE_VacuumFurnaceScheduler\Outgas_be.accdb";
                                        @"C:\dev\TFE_Projects\TFE_VacuumFurnaceScheduler\BE-TFE_VacuumFurnaceScheduler\Outgas_be.accdb";
        private static String CONTACTTABLE = "Contact";
        private static String CUSTOMERTABLE = "Customer";
        private static String LOCATIONTABLE = "Location";
        private static String PARTTABLE = "PartNumbers";
        private static String SERIALTABLE = "SerialNumber";
        private static String JOBSTABLE = "Jobs";
        private static String OPERATORTABLE = "Operators";
        private static String BATCHTABLE = "OutgasBatch";
        private static String TEMPTABLE = "TemperatureCycles";
        private static String MATTABLE = "Material";
        private static String CYCLETABLE = "TemperatureCycles";
        private static String AREATABLE = "Area";

        private static String BATCHQUERY = "BatchQuery";
        private static String COMPLETEDBATCHQUERY = "CompletedBatchQuery";
        private static String EDITBATCHQUERY = "EditBatchQuery";
        private static String HISTORYQUERY = "HistoryQuery";
        private static String STARTBATCHQUERY = "StartBatchQuery";
        private static String INPROCESSOVEN1BATCHQUERY = "InProcessOven1BatchQuery";
        private static String INPROCESSOVEN2BATCHQUERY = "InProcessOven2BatchQuery";
        private static String JOBQUERY = "JobQuery";
        private static String JOBQUEUEQUERY = "JobQueueQuery";
        private static String RECEIVEDJOBSQUERY = "ReceivedJobsQuery";
        private static String EDITTFEJOBSQUERY = "EditTFEJobsQuery";
        private static String EDITOTHERJOBSQUERY = "EditOtherJobsQuery";
        private static String EDITALLJOBSQUERY = "EditAllJobsQuery";
        private static String CLOSEDFINISHEDJOBSQUERY = "ClosedFinishedJobsQuery";
        private static String PARTJOBBATCHINFOQUERY = "PartJobBatchInfoQuery";
        private static String ALLJOBSQUERY = "AllJobsQuery";
        private static String OPENJOBBATCHQUERY = "OpenJobBatchQuery";
        private static String BATCHCONTACTQUERY = "BatchContactEmailQuery";


        private OleDbConnection outgasDBConnection { get; set; }
        private OleDbCommand outgasDBOleDbCmd{ get; set; }

        public bool Error { get; set; }
        public bool Test()
        {
            if (openOutgasDB())
            {
                closeOutgasDB();
                return true;
            }
            return false;
        }

        //Open -  Close ****************************************************************************************************
        #region Open/Close

        private bool openOutgasDB()
        {
            outgasDBConnection = new OleDbConnection(OUTGASDBCONNSTRING);
            outgasDBOleDbCmd = new OleDbCommand();
            outgasDBOleDbCmd.Connection = outgasDBConnection;
            try
            {
                if (outgasDBConnection.State != ConnectionState.Open)
                    outgasDBConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
                return false;
            }
            return true;
        }
        private bool closeOutgasDB()
        {
            try
            {
                if (outgasDBConnection.State == ConnectionState.Open)
                    outgasDBConnection.Close();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
                return false;
            }
            return true;
        }

        #endregion

        //Is ***************************************************************************************************************
        #region Is?

        public bool IsPartSerialized(String partNumber)
        {
            DataTable serializedPartTable = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + PARTTABLE + " WHERE Serialized = TRUE";
            serializedPartTable = GetDataTable(cmd);
            foreach (DataRow row in serializedPartTable.Rows)
            {
                if (partNumber.Equals(row["PartNumber"]))
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsOperator(String userName)
        {
            DataTable tempTable = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = outgasDBConnection;
            cmd.CommandText = "SELECT * FROM" + OPERATORTABLE + " WHERE UserName = @username";
            cmd.Parameters.AddWithValue("@username", userName);
            tempTable = GetDataTable(cmd);
            if (tempTable.Rows.Count > 0)
                return true;
            return false;
        }
        public int IsContact(String email)
        {
            int iD = 0;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "SELECT * FROM " + CONTACTTABLE + " WHERE Email = @Email";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@Email", email.ToLower());
                    OleDbDataReader outgasDBReader;
                    outgasDBReader = outgasDBOleDbCmd.ExecuteReader();
                    if (outgasDBReader.Read())
                    {
                        iD = (int)outgasDBReader["ContactId"];
                        outgasDBReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return iD;
        }
        public bool IsOvenEmpty(string oven)
        {
            bool empty = true;
            DataTable batchTable = new DataTable();
            if (oven.Equals("Oven 1(EGUN)"))
                batchTable = GetInProcessBatchesOven1();
            else
                batchTable = GetInProcessBatchesOven2();
            if (batchTable.Rows.Count > 0)
                        empty = false;            
            return empty;
        }

        #endregion

        //Create - Start ***********************************************************************************************************
        #region Creat/Start

        public int CreateBatch(int operatorID)
        {
            int iD = 0;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "INSERT into " + BATCHTABLE + " ([Operator],[DateCreated]) values (@operatorID, Now())";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@operatorID", operatorID);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        outgasDBOleDbCmd.CommandText = "Select @@Identity";
                        iD = (int)outgasDBOleDbCmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return iD;
        }
        public bool StartBatch(int batchID,string ovenChoice)
        {
            bool success = false;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "UPDATE " + BATCHTABLE + " SET [DateStarted] = (Now()), [Oven] = @oven WHERE [BatchID] = @batch";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@oven", ovenChoice); 
                    outgasDBOleDbCmd.Parameters.AddWithValue("@batch", batchID);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        closeOutgasDB();
                        if (openOutgasDB())
                        {
                            outgasDBOleDbCmd.Connection = outgasDBConnection;
                            outgasDBOleDbCmd.CommandText = "UPDATE " + JOBSTABLE + " SET [Status] = @status, [Location] = @location WHERE [BatchID] = @batch";
                            outgasDBOleDbCmd.Parameters.AddWithValue("@status", "In Process");
                            outgasDBOleDbCmd.Parameters.AddWithValue("@location", ovenChoice);
                            outgasDBOleDbCmd.Parameters.AddWithValue("@batch", batchID);
                            if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                                success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return success;
        }

        #endregion

        //Add **************************************************************************************************************
        #region Add

        public bool AddToBatch(int batchID, int jobID)
        {
            bool success = false;
            if (UpdateJobStatus(jobID, "Queued"))
            {
                try
                {
                    if (openOutgasDB())
                    {
                        outgasDBOleDbCmd.Connection = outgasDBConnection;
                        outgasDBOleDbCmd.CommandText = "UPDATE " + JOBSTABLE + " SET [BatchID] = @batchID WHERE [jobId] = @jobID";
                        outgasDBOleDbCmd.Parameters.AddWithValue("@batchID", batchID);
                        outgasDBOleDbCmd.Parameters.AddWithValue("@jobID", jobID);
                        if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                            success = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Error = true;
                }
            }
            closeOutgasDB();
            UpdateLineItemNumbers(batchID);
            return success;
        }
        public int AddIfNewContact(String email)
        {
            int iD = 0;
            try
            {
                if (IsContact(email) == 0)
                {
                    if (openOutgasDB())
                    {
                        outgasDBOleDbCmd.Connection = outgasDBConnection;
                        outgasDBOleDbCmd.CommandText = "Insert into " + CONTACTTABLE + " ([EMail]) values (@email)";
                        outgasDBOleDbCmd.Parameters.AddWithValue("@email", email.ToLower());
                        if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                        {
                            outgasDBOleDbCmd.CommandText = "Select @@Identity";
                            iD = (int)outgasDBOleDbCmd.ExecuteScalar();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return iD;
        }
        public int AddNewCustomer(String username)
        {
            int iD = 0;
            String email = username + "@FEI.com";
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "Insert into " + CUSTOMERTABLE + " ([Email], [UserName]) values (@email, @userName)";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@email", email);
                    outgasDBOleDbCmd.Parameters.AddWithValue("@userName", username);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        outgasDBOleDbCmd.CommandText = "Select @@Identity";
                        iD = (int)outgasDBOleDbCmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return iD;
        }
        public bool AddNewPart(String partNumber, String description, String cycle, String area, String material)
        {
            bool success = false;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "Insert into " + PARTTABLE + " ( [PartNumber], [Description], [CycleID], [Area], [Material]) values (@part, @desc, @cycle, @area, @mat)";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@part", partNumber);
                    outgasDBOleDbCmd.Parameters.AddWithValue("@desc", description);
                    outgasDBOleDbCmd.Parameters.AddWithValue("@cycle", cycle);
                    outgasDBOleDbCmd.Parameters.AddWithValue("@area", area);
                    outgasDBOleDbCmd.Parameters.AddWithValue("@mat", material);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return success;
        }
        public bool AddNewSerial(String serial, int jobId)
        {
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "Insert into " + SERIALTABLE + " ( [SerialNumber], [JobID]) values (@serial, @jobId)";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@serial", serial);
                    outgasDBOleDbCmd.Parameters.AddWithValue("@jobId", jobId);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() == 0)
                    {
                        closeOutgasDB();
                        return false;
                    }
                }
                else
                {
                    closeOutgasDB();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return true;
        }
        public int AddJobRequest(JobRequest jR)
        {
            int jId = 0;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "Insert into " + JOBSTABLE
                                                  + " ([CustomerId], [PartNumber], [Qty], [Status], [Location], [ContactId], [DateReceived])"
                                                  + " values ( @custId, @part, @qty, @sta, @loc, @con, Now())";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@custId", jR.GetCustomerId());
                    outgasDBOleDbCmd.Parameters.AddWithValue("@part", jR.GetPartNumber());
                    outgasDBOleDbCmd.Parameters.AddWithValue("@qty", jR.GetQuantity());
                    outgasDBOleDbCmd.Parameters.AddWithValue("@sta", "Received");
                    outgasDBOleDbCmd.Parameters.AddWithValue("@loc", jR.GetLocation());
                    outgasDBOleDbCmd.Parameters.AddWithValue("@con", jR.GetContactId());
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        outgasDBOleDbCmd.CommandText = "Select @@Identity";
                        jId = (int)outgasDBOleDbCmd.ExecuteScalar();
                        foreach (String ser in jR.GetSerialNumbers())
                        {
                            AddNewSerial(ser, jId);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return jId;
        }

        #endregion

        //Get **************************************************************************************************************
        #region Get

        public int GetAmountOfJobsInBatch(int batchID)
        {
            int count = -1;
            try
            {
                if (openOutgasDB())
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = outgasDBConnection;
                    cmd.CommandText = "SELECT COUNT(*) FROM " + JOBSTABLE + " WHERE BatchID = @batch";
                    cmd.Parameters.AddWithValue("@batch", batchID.ToString());
                    count = (int)cmd.ExecuteScalar();
                    closeOutgasDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            return count;
        }        
        public DataTable GetJob(int jobId)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + JOBQUERY + " WHERE JobId = @job";
            cmd.Parameters.AddWithValue("@job", jobId);
            return GetDataTable(cmd);
        }
        public DataTable GetBatchJobs(int batchID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + JOBQUERY + " WHERE BatchID = @batch";
            cmd.Parameters.AddWithValue("@batch", batchID);
            return GetDataTable(cmd);
        }
        public DataTable GetHistoryJobs(int batchID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + HISTORYQUERY + " WHERE BatchID = @batch";
            cmd.Parameters.AddWithValue("@batch", batchID);
            return GetDataTable(cmd);
        }

        public DataTable GetBatch(int batchID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + EDITBATCHQUERY + " WHERE BatchID = @batch";
            cmd.Parameters.AddWithValue("@batch", batchID);
            return GetDataTable(cmd);
        }
        public DataTable GetBatchTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + BATCHTABLE;
            return GetDataTable(cmd);
        }
        public DataTable GetBatchContact(int batchID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + BATCHCONTACTQUERY + " WHERE BatchID = @batch";
            cmd.Parameters.AddWithValue("@batch", batchID);
            return GetDataTable(cmd);
        }

        public DataTable GetAllJobs()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + ALLJOBSQUERY;
            return GetDataTable(cmd);
        }
        public DataTable GetJobQueueRequests()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + JOBQUEUEQUERY;
            return GetDataTable(cmd);
        }
        public DataTable GetCombineableJobRequests(string mat, string area)
        {
            OleDbCommand cmd = new OleDbCommand();
            if (mat == "Carbon" )
            {
                cmd.CommandText = "SELECT * FROM " + RECEIVEDJOBSQUERY + " WHERE Material = @mat";
                cmd.Parameters.AddWithValue("@mat", mat);
            }            
            else
            {
                cmd.CommandText = "SELECT * FROM " + RECEIVEDJOBSQUERY + " WHERE Area = @area AND Material = @mat";
                cmd.Parameters.AddWithValue("@area", area);
                cmd.Parameters.AddWithValue("@mat", mat);
            }
            return GetDataTable(cmd);
        }
        public DataTable GetCreateAllJobRequests()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + EDITALLJOBSQUERY;
            return GetDataTable(cmd);
        }
        public DataTable GetOperatorTFEJobRequests()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + EDITTFEJOBSQUERY;
            return GetDataTable(cmd);
        }
        public DataTable GetOperatorOtherJobRequests()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + EDITOTHERJOBSQUERY;
            return GetDataTable(cmd);
        }
        public DataTable GetAllJobBatches()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + OPENJOBBATCHQUERY;
            return GetDataTable(cmd);
        }
        public DataTable GetClosedFinishedJobBatches()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + CLOSEDFINISHEDJOBSQUERY;
            return GetDataTable(cmd);
        }
        public DataTable GetPartJobBatchInfo( int jobID)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + PARTJOBBATCHINFOQUERY + " WHERE JobId = @job";
            cmd.Parameters.AddWithValue("@job", jobID);
            return GetDataTable(cmd);
        }
        public DataTable GetEditableBatches()
        {
            OleDbCommand cmd = new OleDbCommand();
            //EditBatchQuery
            cmd.CommandText = "SELECT Jobs.BatchID, Jobs.BatchLineItem, Jobs.DateReceived, OutgasBatch.DateCreated, Jobs.JobId" +
            ", Customer.UserName, Jobs.Qty, PartNumbers.PartNumber, PartNumbers.Description, PartNumbers.Area, PartNumbers.Material " +
            "FROM OutgasBatch INNER JOIN (PartNumbers INNER JOIN (Customer INNER JOIN Jobs ON Customer.CustomerID = Jobs.CustomerId) " +
            "ON PartNumbers.[PartNumber] = Jobs.[PartNumber]) ON OutgasBatch.BatchID = Jobs.BatchID WHERE (((Jobs.BatchID) Is Not Null) " +
            "AND ((Jobs.Status)='Queued' Or (Jobs.Status)='On Deck')) ORDER BY Jobs.BatchID, Jobs.BatchLineItem";
            return GetDataTable(cmd);
        }
        public DataTable GetStartBatches()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + STARTBATCHQUERY;
            return GetDataTable(cmd);                             
        }
        public DataTable GetInProcessBatchesOven1()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + INPROCESSOVEN1BATCHQUERY;
            DataTable tbl = GetDataTable(cmd);
            for (int i = tbl.Rows.Count; i > 1; i--)
                tbl.Rows.RemoveAt(i - 1);
            return tbl;
        }
        public DataTable GetInProcessBatchesOven2()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + INPROCESSOVEN2BATCHQUERY;
            DataTable tbl = GetDataTable(cmd);
            for (int i = tbl.Rows.Count; i > 1; i--)
                tbl.Rows.RemoveAt(i-1);
            return tbl;
        }        
        public DataTable GetPartList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + PARTTABLE + " ORDER BY PartNumber";
            return GetDataTable(cmd);
        }
        public DataTable GetPartInfo(string part)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + PARTTABLE + " WHERE PartNumber = @part";
            cmd.Parameters.AddWithValue("@part", part);
            return GetDataTable(cmd);
        }
        public DataTable GetCustomerList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + CUSTOMERTABLE;
            return GetDataTable(cmd);
        }
        public DataTable GetLocationList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + LOCATIONTABLE;
            return GetDataTable(cmd);
        }
        public DataTable GetOperatorList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + OPERATORTABLE;
            return GetDataTable(cmd);
        }
        public DataTable GetContactList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + CONTACTTABLE;
            return GetDataTable(cmd);
        }
        public DataTable GetSerialNumberList(int jobId)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + SERIALTABLE + " WHERE JobID = @job";
            cmd.Parameters.AddWithValue("@job", jobId);
            return GetDataTable(cmd);
        }
        public DataTable GetCompletedBatches()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + COMPLETEDBATCHQUERY;
            return GetDataTable(cmd);
        }
        public DataTable GetCompletedJobs()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + BATCHQUERY + " WHERE DateCompleted IS NOT NULL";
            return GetDataTable(cmd);
        }
        public DataTable GetClosedJobs()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + BATCHQUERY + " WHERE DateCompleted IS NOT NULL AND Status = @closed";
            cmd.Parameters.AddWithValue("@closed", "Closed");
            return GetDataTable(cmd);
        }
        public DataTable GetFinishedJobs()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + BATCHQUERY + " WHERE DateCompleted IS NOT NULL AND Status = @finished ORDER BY OutgasBatch.DateCompleted DESC";
            cmd.Parameters.AddWithValue("@finished", "Finished");
            return GetDataTable(cmd);
        }
        public DataTable GetTempInfo(string cycle)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + TEMPTABLE + " WHERE CycleId = @cycleId";
            cmd.Parameters.AddWithValue("@cycleId", cycle);
            return GetDataTable(cmd);
        }

        public DataTable GetMaterialList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + MATTABLE + " ORDER BY Material";
            return GetDataTable(cmd);
        }
        public DataTable GetCycleList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + CYCLETABLE +" ORDER BY CycleID";
            return GetDataTable(cmd);
        }
        public DataTable GetAreaList()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM " + AREATABLE + " ORDER BY Area";
            return GetDataTable(cmd);
        }            

        private DataTable GetDataTable(OleDbCommand cmd)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (openOutgasDB())
                {
                    cmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd = cmd;
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(outgasDBOleDbCmd);
                    if(dAdapter != null)
                        dAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return dataTable;
        }
        private DataSet GetDataSet(String selectionString)
        {
            DataSet dataSet = new DataSet();
            try
            {
                if (openOutgasDB())
                {
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(selectionString, OUTGASDBCONNSTRING);
                    dAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return dataSet;
        }

        #endregion

        //Update **********************************************************************************************************
        #region Update

        public bool UpdateJobStatus(int jobId, String status)
        {
            bool success = false;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "UPDATE " + JOBSTABLE + " SET [Status] = @status WHERE [jobId] = @jobID";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@status", status);
                    outgasDBOleDbCmd.Parameters.AddWithValue("@jobID", jobId);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                        success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return success;
        }
        public bool ClearBatch(int jobId)
        {
            bool success = false;
            if (UpdateJobStatus(jobId, "Received"))
            {
                try
                {
                    if (openOutgasDB())
                    {
                        outgasDBOleDbCmd.Connection = outgasDBConnection;
                        outgasDBOleDbCmd.CommandText = "UPDATE " + JOBSTABLE + " SET [BatchID] = @batchID, [BatchLineItem] = @lineItem WHERE [jobId] = @jobID";
                        outgasDBOleDbCmd.Parameters.AddWithValue("@batchID", DBNull.Value);
                        outgasDBOleDbCmd.Parameters.AddWithValue("@lineItem", DBNull.Value);
                        outgasDBOleDbCmd.Parameters.AddWithValue("@jobID", jobId);
                        if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                            success = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Error = true;
                }
            }
            closeOutgasDB();
            return success;
        }
        public bool UpdateLineItemNumbers(int BatchID)
        {
            bool success = true;
            bool empty = true;
            DataTable dt = GetBatch(BatchID);
            int line = 1;
            foreach (DataRow row in dt.Rows)
            {
                empty = false;
                try
                {
                    if (openOutgasDB())
                    {
                        outgasDBOleDbCmd.Connection = outgasDBConnection;
                        outgasDBOleDbCmd.CommandText = "UPDATE " + JOBSTABLE + " SET [BatchLineItem] = @line WHERE [jobId] = @jobID";
                        outgasDBOleDbCmd.Parameters.AddWithValue("@line", line);
                        outgasDBOleDbCmd.Parameters.AddWithValue("@jobID", row.Field<int>("JobId"));
                        outgasDBOleDbCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Error = true;
                    success = false;
                }
                line++;
            }
            if (empty)
            {
                //Remove dateCreated from Batch
                try
                {
                    if (openOutgasDB())
                    {
                        outgasDBOleDbCmd.Connection = outgasDBConnection;
                        outgasDBOleDbCmd.CommandText = "UPDATE " + BATCHTABLE + " SET [DateCreated] = @Null WHERE [BatchID] = @batchID";
                        outgasDBOleDbCmd.Parameters.AddWithValue("@Null", DBNull.Value);
                        outgasDBOleDbCmd.Parameters.AddWithValue("@batchID", BatchID);
                        outgasDBOleDbCmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Error = true;
                    success = false;
                }

            }
            closeOutgasDB();
            return success;
        }
        public bool UpdateBatchStatusFinished(int batchID)
             {
            bool success = false;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "UPDATE " + JOBSTABLE + " SET [Status] = 'Finished' , [Location] = 'Picked up' WHERE [BatchID] = @batchID";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@batchID", batchID);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        closeOutgasDB();
                        if (openOutgasDB())
                        {
                            outgasDBOleDbCmd.Connection = outgasDBConnection;
                            outgasDBOleDbCmd.CommandText = "UPDATE " + BATCHTABLE + " SET [DateCompleted] = (Now()),[OpCompleted] = @op WHERE [BatchID] = @batchId";
                            outgasDBOleDbCmd.Parameters.AddWithValue("@op", Environment.UserName.ToLower());
                            outgasDBOleDbCmd.Parameters.AddWithValue("@batchId", batchID);
                            if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                                 success = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return success;
        }
        public bool UpdateJobStatusClosed(int jobID)
        {
            bool success = false;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "UPDATE " + JOBSTABLE + " SET [Status] = 'Closed' , [Location] = 'Picked Up', [AcknowledgedBy] = @user, [DatePickedUp] = (Now()) WHERE [JobID] = @jobID";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@user", Environment.UserName.ToLower()); 
                    outgasDBOleDbCmd.Parameters.AddWithValue("@jobID", jobID);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        closeOutgasDB();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return success;
        }
        public bool UpdateJobBatchStatusClosed(int batchID)
        {
            bool success = false;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "UPDATE " + JOBSTABLE + " SET [Status] = 'Closed' , [Location] = 'Picked Up', [AcknowledgedBy] = @user, [DatePickedUp] = (Now()) WHERE [BatchID] = @batchID";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@user", Environment.UserName.ToLower()); 
                    outgasDBOleDbCmd.Parameters.AddWithValue("@batchID", batchID);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return success;
        }

        #endregion
        //Delete **********************************************************************************************************
        #region Delete
        public bool DeleteJob(int jobID)
        {
            bool success = false;
            try
            {
                if (openOutgasDB())
                {
                    outgasDBOleDbCmd.Connection = outgasDBConnection;
                    outgasDBOleDbCmd.CommandText = "DELETE FROM " + JOBSTABLE + " WHERE [JobId] = @jobID";
                    outgasDBOleDbCmd.Parameters.AddWithValue("@jobID", jobID);
                    if (outgasDBOleDbCmd.ExecuteNonQuery() != 0)
                        success = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Error = true;
            }
            closeOutgasDB();
            return success;
        }

        #endregion
        //*************************************************************************************************************************

    }
}
