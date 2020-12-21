using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLTransfer.Models
{
    interface Factory
    {
        SqlService GetSqlService();
    }
    class GetSqlServiceFactory : Factory
    {
        public SqlService GetSqlService()
        {
            return new SqlService();
        }
        public Object GetSqlService(string type)
        {
            return new SqlService();
        }
    }
    
}
