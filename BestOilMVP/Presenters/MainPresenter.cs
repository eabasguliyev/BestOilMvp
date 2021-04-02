using BestOilMVP.Data;
using BestOilMVP.Models;
using BestOilMVP.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BestOilMVP.Helpers;

namespace BestOilMVP.Presenters
{
    class MainPresenter
    {
        private readonly PaymentContext _db;
        private readonly FuelContext _fuelDb;
        private IMainView _view;

        public MainPresenter(IMainView view)
        {
            _db = new PaymentContext();
            _fuelDb = new FuelContext();

            _view = view;

            _view.ButtonAddClicked += ButtonAddClicked;
            _view.ComboBoxFuelsSelectedIndexChanged += ComboBoxFuelsSelectedIndexChanged;
            _view.RadioButtonLiterCheckedChanged += RadioButtonLiterCheckedChanged;
            _view.RadioButtonPriceCheckedChanged += RadioButtonPriceCheckedChanged;
            _view.ButtonClearClicked += ButtonClearClicked;
            _view.ButtonLoadClicked += ButtonLoadClicked;
            _view.TextBoxFuelLiterTextChanged += TextBoxFuelLiterTextChanged;
            _view.TextBoxFuelPriceTextChanged += TextBoxFuelPriceTextChanged;
            _view.PanelFormTopMouseDown += PanelFormTopMouseDown;
            _view.PanelFormTopMouseMove += PanelFormTopMouseMove;
            _view.PanelFormTopMouseUp += PanelFormTopMouseUp;
            _view.PictureBoxCloseMouseEnter += PictureBoxCloseMouseEnter;
            _view.PictureBoxCloseMouseLeave += PictureBoxCloseMouseLeave;
            _view.PictureBoxCloseMouseClick += PictureBoxCloseMouseClick;
            _view.ButtonRemoveClicked += ButtonRemoveClicked;

            _view.Fuels = _fuelDb.Fuels.ToList();
            //_view.Fuels = new List<Fuel>()
            //{
            //    new Fuel()
            //    {
            //        Name = "AI92",
            //        Price = 1.95,
            //    },
            //    new Fuel()
            //    {
            //        Name = "AI95",
            //        Price = 1.10,
            //    },
            //    new Fuel()
            //    {
            //        Name = "Diesel",
            //        Price = 0.95,
            //    },
            //};
        }

        private void ButtonRemoveClicked(object sender, EventArgs e)
        {
            if (!_db.Payments.Any())
                return;

            _db.Payments.Remove(_view.ListBoxDataSelectedItem);
            _db.SaveChanges();
        }

        private void PictureBoxCloseMouseClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBoxCloseMouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox pbClose)
            {
                pbClose.Image = Properties.Resources.close_window_50px;
            }
        }

        private void PictureBoxCloseMouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox pbClose)
            {
                pbClose.Image = Properties.Resources.close_window_red_50px;
            }
        }

        private void PanelFormTopMouseUp(object sender, EventArgs e)
        {
            FormDraggable.MouseUp();
        }

        private void PanelFormTopMouseMove(object sender, EventArgs e)
        {
            var form = ((MainView)_view);
            var newLocation = FormDraggable.MouseMove();
            form.Location = newLocation == Point.Empty ? form.Location : newLocation;
        }

        private void PanelFormTopMouseDown(object sender, EventArgs e)
        {
            FormDraggable.MouseDown(Cursor.Position, ((MainView)_view).Location);
        }

        private void TextBoxFuelPriceTextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox mbPrice && !_view.TextBoxLiterEnableState)
            {
                if (String.IsNullOrWhiteSpace(mbPrice.Text) == false)
                {
                    var price = Double.Parse(mbPrice.Text);
                    var value =  price / _view.Fuels[_view.ComboBoxSelectedIndex].Price;
                    _view.FuelOrderByLiterText = value.ToString("F");
                    _view.FuelCostText = price.ToString("F");
                }
                else
                {
                    _view.FuelOrderByLiterText = string.Empty;
                    _view.FuelCostText = "0.00";
                }
            }
        }

        private void TextBoxFuelLiterTextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox mbLiter && !_view.TextBoxPriceEnableState)
            {
                if (String.IsNullOrWhiteSpace(mbLiter.Text) == false)
                {
                    var value = Double.Parse(mbLiter.Text) * _view.Fuels[_view.ComboBoxSelectedIndex].Price;
                    _view.FuelOrderByPriceText = value.ToString("F");
                    _view.FuelCostText = value.ToString("F");
                }
                else
                {
                    _view.FuelOrderByPriceText = string.Empty;
                    _view.FuelCostText = "0.00";
                }
            }
        }

        private void ButtonLoadClicked(object sender, EventArgs e)
        {
            var list = _db.Payments.ToList();

            _view.Payments = list;
        }

        private void ButtonClearClicked(object sender, EventArgs e)
        {
            _db.Payments.RemoveRange(_db.Payments.AsEnumerable());
            
            //var list = _db.Payments.ToList();
            
            //list.ForEach(l => _db.Payments.Remove(l));

            _db.SaveChanges();
        }

        private void RadioButtonPriceCheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rdPrice)
            {
                _view.TextBoxPriceEnableState = rdPrice.Checked;
            }
        }

        private void RadioButtonLiterCheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rdLiter)
            {
                _view.TextBoxLiterEnableState = rdLiter.Checked;
            }
        }

        private void ComboBoxFuelsSelectedIndexChanged(object sender, EventArgs e)
        {
            if(sender is ComboBox comboBox)
            {
                var fuel = comboBox.SelectedItem as Fuel;
                _view.FuelNameText = fuel?.Name;
                _view.FuelPriceText = fuel?.Price.ToString();
            }
        }

        private void ButtonAddClicked(object sender, EventArgs e)
        {
            var payment = new Payment()
            {
                Name = _view.FuelNameText,
                Price = Double.Parse(_view.FuelPriceText),
                Liter = Double.Parse(_view.FuelOrderByLiterText),
                Cost = Double.Parse(_view.FuelOrderByPriceText),
                Pay = Double.Parse(_view.FuelCostText),
                DateTime = DateTime.Now,
            };

            _db.Payments.Add(payment);
            _db.SaveChanges();
        }
    }
}
