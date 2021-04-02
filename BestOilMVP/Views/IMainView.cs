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
        EventHandler<EventArgs> ComboBoxFuelsSelectedIndexChanged { get; set; }
        EventHandler<EventArgs> RadioButtonLiterCheckedChanged { get; set; }
        EventHandler<EventArgs> RadioButtonPriceCheckedChanged { get; set; }
        EventHandler<EventArgs> ButtonAddClicked { get; set; }
        EventHandler<EventArgs> ButtonClearClicked { get; set; }
        EventHandler<EventArgs> ButtonLoadClicked { get; set; }
        EventHandler<EventArgs> TextBoxFuelLiterTextChanged { get; set; }
        EventHandler<EventArgs> TextBoxFuelPriceTextChanged { get; set; }
        EventHandler<EventArgs> PanelFormTopMouseDown { get; set; }
        EventHandler<EventArgs> PanelFormTopMouseUp { get; set; }
        EventHandler<EventArgs> PanelFormTopMouseMove { get; set; }
        EventHandler<EventArgs> PictureBoxCloseMouseEnter { get; set; }
        EventHandler<EventArgs> PictureBoxCloseMouseLeave { get; set; }
        EventHandler<EventArgs> PictureBoxCloseMouseClick { get; set; }
        EventHandler<EventArgs> ButtonRemoveClicked { get; set; }
        EventHandler<EventArgs> ListBoxDataSelectedIndexChanged { get; set; }

        int ComboBoxSelectedIndex { get; set; }
        List<Fuel> Fuels { get; set; }
        List<Payment> Payments { set; }
        
        string FuelNameText { get; set; }
        string FuelPriceText { get; set; }
        string FuelOrderByLiterText { get; set; }
        string FuelOrderByPriceText { get; set; }
        string FuelCostText { get; set; }

        bool TextBoxLiterEnableState { get; set; }
        bool TextBoxPriceEnableState { get; set; }
        Payment ListBoxDataSelectedItem { get; }
    }
}
