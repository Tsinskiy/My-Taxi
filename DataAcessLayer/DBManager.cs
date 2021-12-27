using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models; 

namespace DataAcessLayer
{
    public class DBManager
    {
        private static DBManager instance;

        public TaxiEntities DB;

        private DBManager()
        {
            DB = new TaxiEntities();
        }

        public static DBManager Instance()
        {
            if (instance == null)
            
                instance = new DBManager();
            return instance;
        }
    }
}
