using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.DataBase.Sqlite
{
    public class UserInfo : DBObject
    {
        [PrimaryKey]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserInfo()
        {

        }
        public UserInfo(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
