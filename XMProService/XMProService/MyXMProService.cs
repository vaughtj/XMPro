using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using TableDependency;
using TableDependency.Enums;
using TableDependency.SqlClient;
using XMProService.Entity;

namespace XMProService
{
    public partial class MyXMProService : ServiceBase
    {
        private  string _connectionString = "data source=DESKTOP-9V2469;initial catalog=XMPro;integrated security=True";
        private SqlTableDependency<SensorData> _dependency;

        private enum _CRUD { Insert, Delete, Update };

        public MyXMProService(string[] args)
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            var mapper = new ModelToTableMapper<SensorData>();
            mapper.AddMapping(model => model.Luminosity, "Luminosity");
            mapper.AddMapping(model => model.Pressure, "Pressure");
            mapper.AddMapping(model => model.ReadingID, "ReadingID");
            mapper.AddMapping(model => model.Temperature, "Temperature");
            mapper.AddMapping(model => model.Timestamp, "Timestamp");

            _dependency = new SqlTableDependency<SensorData>(_connectionString, "SensorData", mapper);
            _dependency.OnChanged += _dependency_OnChanged;
            _dependency.OnError += _dependency_OnError;
            _dependency.Start();

        }
        private void Window1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _dependency.Stop();
        }
        private void _dependency_OnError(object sender, TableDependency.EventArgs.ErrorEventArgs e)
        {
            throw e.Error;
        }
        private void _dependency_OnChanged(object sender, TableDependency.EventArgs.RecordChangedEventArgs<SensorData> e)
        {

            if (e.ChangeType != ChangeType.None)
            {
                switch (e.ChangeType)
                {
                    case ChangeType.Delete:
                        LogDataChange(e.Entity, _CRUD.Delete);
                        break;
                    case ChangeType.Insert:
                        LogDataChange(e.Entity, _CRUD.Insert);
                        break;
                    case ChangeType.Update:
                        LogDataChange(e.Entity, _CRUD.Update);
                        break;
                }
            }

        }

        private void LogDataChange(SensorData _data, _CRUD _crud)
        {
            string curFile = @"C:\alerts.txt";

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            string operation = string.Empty;

            switch (_crud)
            {
                case _CRUD.Insert:
                    operation = "Insert ";
                    break;
                case _CRUD.Delete:
                    operation = "Delete ";
                    break;
                case _CRUD.Update:
                    operation = "Update ";
                    break;
                default:
                    break;
            }

            FileStream fs;

            if (!File.Exists(curFile))
            {
                fs = new FileStream(curFile, FileMode.Create);
            }
            else
            {
                fs = new FileStream(curFile, FileMode.Append);
            }

            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                sw.Write(operation);
                serializer.Serialize(writer, _data);

                sw.WriteLine();

            }
        }

        protected override void OnStop()
        {
        }
    }
}
