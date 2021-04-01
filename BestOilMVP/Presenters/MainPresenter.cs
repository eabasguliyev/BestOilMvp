using BestOilMVP.Data;
using BestOilMVP.Models;
using BestOilMVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOilMVP.Presenters
{
    class MainPresenter
    {
        private PaymentContext _db;
        private IMainView _view;

        public MainPresenter(IMainView view)
        {
            _db = new PaymentContext();
            _view = view;
            _view.PayButtonClicked += PayButtonClick;
            _view.ClearButtonClicked += ClearButtonClick;
            _view.SelectedIndexChanged += SelectedIndexChanged;
            _view.Fuels = new List<string>
            {
                //burda set et
            };
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            if(sender is ComboBox cb)
            {
                _view.SelectedIndex = cb.SelectedIndex;
            }
        }

        
        private void ClearButtonClick(object sender, EventArgs e)
        {
            
        }

        private void PayButtonClick(object sender, EventArgs e)
        {
            var newPayment = new Payment()
            {
                Name = _view.FuelNames[_view.SelectedIndex],
                Liter = double.Parse(_view.FuelLiterText),
                Price = double.Parse(_view.FuelPriceText),
                Pay = double.Parse(_view.FuelCostText),
                DateTime = DateTime.Now
            };

            _db.Payments.Add(newPayment);
            _db.SaveChanges();
        }
    }
}
