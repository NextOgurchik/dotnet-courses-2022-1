using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using BLL;
using DAL;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appConfig.json");
            var config = configurationBuilder.Build();
            var connectionString = config["ConnectionString"];

            var userDAO = new UserListDAO(connectionString);
            var rewardDAO = new RewardListDAO(connectionString);
            Application.Run(new MainForm(new UserBL(userDAO), new RewardBL(rewardDAO)));
        }
    }
}
