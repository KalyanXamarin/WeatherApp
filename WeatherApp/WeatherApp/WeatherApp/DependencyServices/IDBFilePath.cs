using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.DependencyServices
{
    public interface IDBFilePath
    {
        string GetDBFilePath(string fileName);
    }
}
