using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMProApp.Service
{
    public interface IDataService
    {
        Task<dynamic> getDataFromService(string queryString);
        Task<bool> postDataToService(string URL, Object PostData);
        Task<bool> putDataToService(string URL, Object PostData);
        Task<dynamic> getOdataDataFromService(string queryString);
    }
}
