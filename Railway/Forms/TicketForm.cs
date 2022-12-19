using Railway.DbUtils;
using Railway.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway.Forms
{
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
            DbContext.SetStations();
            cbArrival.Items.Clear();
            foreach (var s in DbContext.Stations)
            {
                cbArrival.Items.Add(s);
            }
            cbArrival.DisplayMember = "Name";

            cbDeparture.Items.Clear();
            foreach (var s in DbContext.Stations)
            {
                cbDeparture.Items.Add(s);
            }
            cbDeparture.DisplayMember = "Name";
            cbCar_Type.Items.Clear();
            foreach (var s in Helper.car_type)      
            cbCar_Type.Items.Add(s) ;
        }

        private void cbArrival_SelectedValueChanged(object sender, EventArgs e)
        {
            // Получить список поездов 
            
        }
    }
}
