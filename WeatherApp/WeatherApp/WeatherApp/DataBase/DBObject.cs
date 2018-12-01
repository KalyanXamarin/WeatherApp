using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.DataBase
{
    public class DBObject
    {
        [PrimaryKey]
        public virtual string Id
        {
            get;
            set;
        }
    }
}
