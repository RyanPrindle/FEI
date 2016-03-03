using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Cleaning_Scheduler_Interface
{
    class DB
    {
        private String dBConnString { get; set; }
        //@"Provider=Microsoft Office 12.0 Access Database Engine OLE DB Provider;Data Source= " +
        //@"\\hlsql01\Beamtech\Summit\" +     //Path to DB
        //"Summit_Parts_Cleaning_be.mdb";     //DB Name


        private OleDbConnection dBOleConnection { get; set; }
        private OleDbCommand dBOleDbCmd { get; set; }
        public DB(String dBPath, String dBName)
            : this(dBPath + dBName)
        {
        }
        public DB(String dBPathName)
        {
            this.dBConnString = @"Provider=Microsoft Office 12.0 Access Database Engine OLE DB Provider;Data Source= "
                + dBPathName;
        }
        private bool openDB()
        {
            dBOleConnection = new OleDbConnection(dBConnString);
            dBOleDbCmd = new OleDbCommand();
            dBOleDbCmd.Connection = dBOleConnection;
            try
            {
                if (dBOleConnection.State != ConnectionState.Open)
                    dBOleConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private bool closeDB()
        {
            try
            {
                if (dBOleConnection.State == ConnectionState.Open)
                    dBOleConnection.Close();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        public DataTable GetDataTable(OleDbCommand cmd)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (openDB())
                {
                    cmd.Connection = dBOleConnection;
                    dBOleDbCmd = cmd;
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(dBOleDbCmd);
                    if (dAdapter != null)
                        dAdapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDB();
            return dataTable;
        }

        private DataSet GetDataSet(String selectionString)
        {
            DataSet dataSet = new DataSet();
            try
            {
                if (openDB())
                {
                    OleDbDataAdapter dAdapter = new OleDbDataAdapter(selectionString, dBConnString);
                    if (dAdapter != null)
                        dAdapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDB();
            return dataSet;
        }

        public int GetID(OleDbCommand cmd, String columnName)
        {
            int iD = 0;
            try
            {
                if (openDB())
                {                    
                    dBOleDbCmd = cmd;
                    dBOleDbCmd.Connection = dBOleConnection;
                    OleDbDataReader dBReader;
                    dBReader = dBOleDbCmd.ExecuteReader();
                    if (dBReader.Read())
                    {
                        iD = (int)dBReader[columnName];
                        dBReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDB();
            return iD;
        }

        public int AddReturnID(OleDbCommand cmd)
        {
            int iD = 0;
            try
            {
                if (openDB())
                {
                    dBOleDbCmd = cmd;
                    dBOleDbCmd.Connection = dBOleConnection;
                    if (dBOleDbCmd.ExecuteNonQuery() != 0)
                    {
                        dBOleDbCmd.CommandText = "Select @@Identity";
                        iD = (int)dBOleDbCmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            closeDB();
            return iD;
        }
    }
}
