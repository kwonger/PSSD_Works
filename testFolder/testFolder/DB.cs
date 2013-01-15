using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace testFolder
{
    class DB
    {
        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Log On Log\logOnlog.accdb");

        public DB()
        {
            
        }

        public void OpenConnection()
        {
            connection.Open();
        }
    }
}
