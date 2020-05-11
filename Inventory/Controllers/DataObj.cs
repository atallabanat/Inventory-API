using System;
using System.Data.SqlClient;

namespace Inventory.Controllers
{
    public class DataObj
    {
        public string dataObj { get; set; }

        public static implicit operator DataObj(SqlDataReader v)
        {
            throw new NotImplementedException();
        }
    }
}