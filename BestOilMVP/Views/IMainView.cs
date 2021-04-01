using BestOilMVP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOilMVP.Views
{
    public interface IMainView
    {
        EventHandler<EventArgs> PayButtonClicked { get; set; }
        EventHandler<EventArgs> ClearButtonClicked { get; set; }
        EventHandler<EventArgs> SelectedIndexChanged { get; set; }
        List<Payment> Payments { set; }
        List<string> Fuels { set; }
        string FuelPriceText { get; set; }
        string FuelLiterText { get; set; }
        string FuelAutoLiterText { get; set; }
        string PriceText { get; set; }
        string FuelCostText { get; set; }
        bool LiterState { get; set; }
        bool PriceState { get; set; }
        int SelectedIndex { get; set; }
        List<string> FuelNames { get; set; }
    }
}
