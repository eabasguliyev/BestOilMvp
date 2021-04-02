using BestOilMVP.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BestOilMVP.Views
{
    public partial class MainView : Form, IMainView
    {
        public EventHandler<EventArgs> ComboBoxFuelsSelectedIndexChanged { get; set; }
        public EventHandler<EventArgs> RadioButtonLiterCheckedChanged { get; set; }
        public EventHandler<EventArgs> RadioButtonPriceCheckedChanged { get; set; }
        public EventHandler<EventArgs> ButtonAddClicked { get; set; }
        public EventHandler<EventArgs> ButtonClearClicked { get; set; }
        public EventHandler<EventArgs> ButtonLoadClicked { get; set; }
        public EventHandler<EventArgs> TextBoxFuelLiterTextChanged { get; set; }
        public EventHandler<EventArgs> TextBoxFuelPriceTextChanged { get; set; }
        public EventHandler<EventArgs> PanelFormTopMouseDown { get; set; }
        public EventHandler<EventArgs> PanelFormTopMouseUp { get; set; }
        public EventHandler<EventArgs> PanelFormTopMouseMove { get; set; }
        public EventHandler<EventArgs> PictureBoxCloseMouseEnter { get; set; }
        public EventHandler<EventArgs> PictureBoxCloseMouseLeave { get; set; }
        public EventHandler<EventArgs> PictureBoxCloseMouseClick { get; set; }
        public EventHandler<EventArgs> ButtonRemoveClicked { get; set; }
        public EventHandler<EventArgs> ListBoxDataSelectedIndexChanged { get; set; }

        public int ComboBoxSelectedIndex
        {
            get => ComboBoxFuels.SelectedIndex;
            set => ComboBoxFuels.SelectedIndex = value;
        }

        public List<Fuel> Fuels
        {
            get => (List<Fuel>)ComboBoxFuels.DataSource;
            set
            {
                ComboBoxFuels.DataSource = null;
                ComboBoxFuels.DataSource = value;
                ComboBoxFuels.DisplayMember = "Name";
            }
        }

        public List<Payment> Payments
        {
            set
            {
                ListBoxData.DataSource = null;
                ListBoxData.DataSource = value;
            }
        }

        public string FuelNameText { get; set; }

        public string FuelPriceText { get=> TextBoxPrice.Text; set => TextBoxPrice.Text = value; }
        public string FuelOrderByLiterText { get => TextBoxFuelLiter.Text; set => TextBoxFuelLiter.Text = value; }
        public string FuelOrderByPriceText { get => TextBoxFuelPrice.Text; set => TextBoxFuelPrice.Text = value; }
        public string FuelCostText { get => TextBoxFuelCost.Text; set => TextBoxFuelCost.Text = value; }

        public bool TextBoxLiterEnableState
        {
            get => TextBoxFuelLiter.Enabled;
            set => TextBoxFuelLiter.Enabled = value;
        }

        public bool TextBoxPriceEnableState
        {
            get => TextBoxFuelPrice.Enabled;
            set => TextBoxFuelPrice.Enabled = value;
        }

        public Payment ListBoxDataSelectedItem => (Payment)ListBoxData.SelectedItem;

        public MainView()
        {
            InitializeComponent();
        }


        private void ComboBoxFuels_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxFuelsSelectedIndexChanged.Invoke(sender, e);
        }

        private void RadioButtonLiter_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonLiterCheckedChanged.Invoke(sender, e);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            ButtonAddClicked.Invoke(sender, e);
            ButtonLoadClicked.Invoke(sender, e);
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            ButtonLoadClicked.Invoke(sender, e);
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ButtonClearClicked.Invoke(sender, e);
            ButtonLoadClicked.Invoke(sender, e);
        }

        private void RadioButtonPrice_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonPriceCheckedChanged.Invoke(sender, e);
        }

        private void TextBoxFuelLiter_TextChanged(object sender, EventArgs e)
        {
            TextBoxFuelLiterTextChanged.Invoke(sender, e);
        }

        private void TextBoxFuelPrice_TextChanged(object sender, EventArgs e)
        {
            TextBoxFuelPriceTextChanged.Invoke(sender, e);
        }

        private void MainView_Load(object sender, EventArgs e)
        {   

        }

        private void PanelFormTop_MouseDown(object sender, MouseEventArgs e)
        {
            PanelFormTopMouseDown.Invoke(sender, e);
        }

        private void PanelFormTop_MouseMove(object sender, MouseEventArgs e)
        {
            PanelFormTopMouseMove.Invoke(sender, e);
        }

        private void PanelFormTop_MouseUp(object sender, MouseEventArgs e)
        {
            PanelFormTopMouseUp.Invoke(sender, e);
        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            PictureBoxCloseMouseClick.Invoke(sender, e);
        }

        private void PictureBoxClose_MouseLeave(object sender, EventArgs e)
        {
            PictureBoxCloseMouseLeave.Invoke(sender, e);
        }

        private void PictureBoxClose_MouseEnter(object sender, EventArgs e)
        {
            PictureBoxCloseMouseEnter.Invoke(sender, e);
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            ButtonRemoveClicked.Invoke(sender, e);
            ButtonLoadClicked.Invoke(sender, e);
        }

        // sile bilersen...
        private void ListBoxData_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListBoxDataSelectedIndexChanged.Invoke(sender, e);
        }
    }
}
