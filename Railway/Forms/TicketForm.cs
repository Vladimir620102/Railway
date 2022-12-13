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
            Helper.stations.Sort();
            cbArrival.Items.Clear();
            foreach (var s in Helper.stations)
            {
                cbArrival.Items.Add(s);
            }
            
            cbDeparture.Items.Clear();
            foreach (var s in Helper.stations)
            {
                cbDeparture.Items.Add(s);
            }

            cbCar_Type.Items.Clear();
            foreach (var s in Helper.car_type)      
            cbCar_Type.Items.Add(s) ;
        }
    }
}
