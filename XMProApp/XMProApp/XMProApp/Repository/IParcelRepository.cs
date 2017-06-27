using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMProApp.Models;

namespace XMProApp.Repository
{
    public interface IParcelRepository
    {
        Task<IEnumerable<Parcels>> GetItemsAsync();
        Task<Parcels> GetItemAsync(int parcelID = 0);
        Task<bool> PutItemAsync(Parcels _parcel);
        Task<IEnumerable<Parcels>> GetODataItemsAsync();
        Task<Parcels> GetOdataItemAsync(int parcelID = 0);
        Task<bool> PutOdataItemAsync(Parcels _parcel);
    }
}
