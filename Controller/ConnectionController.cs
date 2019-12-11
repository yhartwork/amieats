using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace amieats.Controller
{
    class ConnectionController
    {
        private Model.Connection connectionModel;
        private SqlConnection conn;

        public ConnectionController()
        {
            connectionModel = new Model.Connection();
        }

        public void testConnection()
        {
        }
    }
}
