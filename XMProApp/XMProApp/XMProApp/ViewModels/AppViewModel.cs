using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Settings.Abstractions;
using Plugin.Settings;
using XMProApp.Helpers;

namespace XMProApp.ViewModels
{
    public static class AppViewModel
    {
        private static ISettings AppSettings => CrossSettings.Current;
        public static bool IsSQLiteSet => AppSettings.Contains("SQLite");

        public static string _dbPath;
        public static bool _useSQLite;

        public static void LoadSettings()
        {
            if (AppViewModel.IsSQLiteSet)
            {
                AppViewModel._useSQLite = Settings.SQLiteSettings;
            }
            else
            {
                Settings.SQLiteSettings = true;
                AppViewModel._useSQLite = Settings.SQLiteSettings;
            }
        }
    }
}
