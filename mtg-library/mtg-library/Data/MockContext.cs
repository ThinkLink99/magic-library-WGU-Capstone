using mtg_library.Models;
using SQLite;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

namespace mtg_library.Data
{
    public class MockContext : IDataContext
    {
        private readonly SQLiteAsyncConnection _database;
        private static MockContext _instance;

        public static MockContext Instance
        {
            get
            {
               if(_instance == null)
                {
                    _instance = new MockContext();
                }

               return _instance;
            }
        }
        public static void InitializeSingleton ()
        {
            _instance = new MockContext();
        }

        public MockContext()
        {
             var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyData.db");
            _database = new SQLiteAsyncConnection(databasePath);
            try
            {
                _database.CreateTableAsync<Card>().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.InnerException);
            }
        }
    }
}
