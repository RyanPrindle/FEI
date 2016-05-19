using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace Cleaning_Request_Interface
{
    class PartsDB
    {
        private static String cleaningPartsDBFullPath = @"\\hlsql01\Beamtech\Summit\Summit_Parts_Cleaning_be.mdb";
        private DB partDB;

        public PartsDB()
        {
            partDB = new DB(cleaningPartsDBFullPath);
        }
        public DataTable GetCleanTable()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = @"SELECT * FROM CLEAN ORDER BY CLEAN.[P/N]";
            return partDB.GetDataTable(cmd);
        }
    }
}
