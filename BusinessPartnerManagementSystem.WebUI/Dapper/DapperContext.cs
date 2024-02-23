using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BusinessPartnerManagementSystem.WebUI.Dapper
{
    public class DapperContext : IDapperContext
    {
        private readonly string _connString;

        public DapperContext()
        {
            _connString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=BusinessPartnerManagementSystem;Integrated Security=True";
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connString);
        }
    }
}