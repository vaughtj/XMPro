using Newtonsoft.Json;
using Simple.OData.Client;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XMProApp.Models;
using XMProApp.Service;

namespace XMProApp.Repository
{
    public class ParcelRepository : IParcelRepository
    {
        IDataService _dataService;
        IDbFactory _dbFactory;
        SQLiteAsyncConnection conn;

        public ParcelRepository(IDataService dataService, IDbFactory dbFactory)
        {
            _dbFactory = dbFactory; 
            _dataService = dataService;
            conn = _dbFactory.GetConn();
        }
        public async Task<IEnumerable<Parcels>> GetItemsAsync()
        {

            ODATAObject myODataObject = new ODATAObject();
            List<Parcels> myParcels = new List<Parcels>();

            dynamic results = await _dataService.getDataFromService("http://192.168.1.147:8080/Parcels");

            if (results != null)
            {
                myODataObject = JsonConvert.DeserializeObject<ODATAObject>(results);
                myParcels = myODataObject.value;
            }
            
            foreach (Parcels par in myParcels)
            {
                int result = 0;
                try
                {
                    result = await conn.InsertAsync(par);
                }
                catch { }
            }

            myParcels = await conn.Table<Parcels>().ToListAsync();

            return myParcels;
        }
        public async Task<Parcels> GetItemAsync(int parcelID = 0)
        {            
            Parcels myParcels = new Parcels();

            //dynamic results = await _dataService.getDataFromService("http://192.168.1.147:8080/Parcels?Id=" + parcelID);

            //if (results != null)
            //{
            //    myParcels = JsonConvert.DeserializeObject<Parcels>(results);
            //}

            var query = conn.Table<Parcels>().Where(v => v.ParcelID == parcelID).FirstOrDefaultAsync();

            myParcels = await query;

            return myParcels;
        }

        public async Task<bool> PutItemAsync(Parcels _parcel)
        {            
            bool _return = false;

            dynamic results = await _dataService.putDataToService("http://192.168.1.147:8080/Parcels?Id=" + _parcel.ParcelID, _parcel);

            return _return;
        }

        public async Task<bool> PutOdataItemAsync(Parcels _parcel)
        {

            Parcels myParcels = new Parcels();


            ODataClientSettings cSettings = new ODataClientSettings();
            cSettings.PayloadFormat = ODataPayloadFormat.Json;
            cSettings.BaseUri = new Uri(string.Format("http://192.168.1.147:8080/", string.Empty));

            var client = new ODataClient(cSettings);

            await Task.Run(async () =>
            {
                await client
                    .For<Parcels>()
                    .Key(_parcel)
                    .UpdateEntryAsync();
                });


            return true;
        }


        public async Task<IEnumerable<Parcels>> GetODataItemsAsync()
        {
            List<Parcels> myParcels = new List<Parcels>();

            ODataClientSettings cSettings = new ODataClientSettings();
            cSettings.PayloadFormat = ODataPayloadFormat.Json;
            cSettings.BaseUri = new Uri(string.Format("http://192.168.1.147:8080/", string.Empty));

            var client = new ODataClient(cSettings);
            await Task.Run(async () =>
            {
                var parcels = await client
                .For<Parcels>()
                .FindEntriesAsync();

                if (App._useSQLite)
                {
                    foreach (Parcels par in parcels)
                    {
                        int result = 0;
                        try
                        {
                            result = await conn.InsertAsync(par);
                        }
                        catch { }
                    }

                    myParcels = await conn.Table<Parcels>().ToListAsync();
                }
                else
                {
                    foreach (var package in parcels)
                    {
                        myParcels.Add(package);
                    }
                }
            });

            return myParcels;
        }

        public async Task<Parcels> GetOdataItemAsync(int parcelID = 0)
        {
            Parcels myParcels = new Parcels();

            if (App._useSQLite)
            {
                var query = conn.Table<Parcels>().Where(v => v.ParcelID == parcelID).FirstOrDefaultAsync();

                myParcels = await query;

                return myParcels;
            }
            else
            {
                ODataClientSettings cSettings = new ODataClientSettings();
                cSettings.PayloadFormat = ODataPayloadFormat.Json;
                cSettings.BaseUri = new Uri(string.Format("http://192.168.1.147:8080/", string.Empty));

                var client = new ODataClient(cSettings);

                await Task.Run(async () =>
                {
                    var products = await client
                        .For<Parcels>()
                        .Filter(x => x.ParcelID == parcelID)
                        .FindEntriesAsync();

                    foreach (var package in products)
                    {
                        if (package.ParcelID == parcelID)
                        {
                            myParcels = package;
                        }
                    }
                });
            }

            return myParcels;
        }
    }
}
