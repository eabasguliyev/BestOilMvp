using System;
using System.Windows.Forms;
using BestOilMVP.Presenters;
using BestOilMVP.Views;

namespace BestOilMVP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new MainView();
            var presenter = new MainPresenter(view);

            Application.Run(view);
        }
    }
}
