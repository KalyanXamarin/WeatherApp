using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.DataBase.Sqlite;
using WeatherApp.DependencyServices;
using Xamarin.Forms;

namespace WeatherApp.DataBase
{
    public class DataManagerRepository
    {
        readonly SQLiteConnection _connection;

        static DataManagerRepository _instanace;
        public static DataManagerRepository Instanace
        {
            get
            {
                if(_instanace == null)
                {
                    _instanace = new DataManagerRepository();
                }
                return _instanace;
            }
        }
        public DataManagerRepository()
        {
            try
            {
                var path = DependencyService.Get<IDBFilePath>().GetDBFilePath("WeatherApp.db3");
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex);
                }
            }
            catch (Exception ex)
            {
                // handle exception;
            }
        }

        public bool RegisterUser(UserInfo userInfo)
        {
            try
            {
                var userInfoManager = new AbstractDataManager<UserInfo>(_connection);
                userInfoManager.Insert(userInfo);
                return true;
            }
            catch (Exception ex)
            {
                //Handle exception if any
                return false;
            }
        }

        public List<UserInfo> GetUsersList()
        {
            try
            {
                var userInfoManager = new AbstractDataManager<UserInfo>(_connection);
                userInfoManager.Get();
            }
            catch (Exception ex)
            {
                //Handle exception if any
            }
            return null;
        }
    }
}
