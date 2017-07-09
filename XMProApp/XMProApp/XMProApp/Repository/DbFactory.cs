using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMProApp.Models;

namespace XMProApp.Repository
{
    public class DbFactory : IDbFactory
    {
        private static DbFactory instance;
        public SQLiteAsyncConnection conn;

        public void Initialize(string filename)
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));

            // TODO: dispose any existing connection
            if (instance != null)
                instance.conn.GetConnection().Dispose();

            instance = new DbFactory(filename);
        }

        public SQLiteAsyncConnection GetConn()
        {
            if (instance.conn != null)
                return instance.conn;
            else
            {
                Initialize(App._dbPath);

                if (instance.conn != null)
                    return instance.conn;
                else
                    throw new ArgumentNullException(nameof(App._dbPath));
            }
        }

        public DbFactory()
        {

        }

        private DbFactory(string dbPath)
        {
            // TODO: Initialize a new SQLiteConnection
            conn = new SQLiteAsyncConnection(dbPath);
            
            // TODO: Create the tables
            conn.CreateTableAsync<Parcels>().Wait();
        }

    }
}
