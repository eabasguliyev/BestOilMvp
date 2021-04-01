using BestOilMVP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BestOilMVP.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public List<Payment> Payments { set
            {
                ListBoxData.DataSource = null;
                ListBoxData.DataSource = value;
            }
        }
        public List<string> Fuels { get => FuelNames; set
            {
                ComboBoxFuels.DataSource = null;
                ComboBoxFuels.DataSource = value;
            }
        }

        public List<string> FuelNames { get; set; }
        public int SelectedIndex { get; set; }
        public string FuelPriceText { get => TextBoxPrice.Text; set => TextBoxPrice.Text = value; }
        public string FuelLiterText { get => MaskedBoxLiter.Text; set => MaskedBoxLiter.Text = value; }
        public string FuelAutoLiterText { get => TextBoxLiter.Text; set => TextBoxLiter.Text = value; }
        public string PriceText { get => MaskedBoxPrice.Text; set => MaskedBoxPrice.Text = value; }
        public string FuelCostText { get => TextBoxFuelCost.Text; set => TextBoxFuelCost.Text = value; }
        public bool LiterState { get => RadioButtonLiter.Checked; set => RadioButtonLiter.Checked = value; }
        public bool PriceState { get => RadioButtonPrice.Checked; set => RadioButtonPrice.Checked = value; }
        public EventHandler<EventArgs> PayButtonClicked { get; set; }
        public EventHandler<EventArgs> ClearButtonClicked { get; set; }
        public EventHandler<EventArgs> SelectedIndexChanged { get; set; }

        private void ButtonPay_Click(object sender, System.EventArgs e)
        {

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxFuels_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
