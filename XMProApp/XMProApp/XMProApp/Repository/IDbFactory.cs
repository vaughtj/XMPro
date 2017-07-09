using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMProApp.Repository
{
    public interface IDbFactory
    {
        void Initialize(string filename);
        SQLiteAsyncConnection GetConn();
    }
}
