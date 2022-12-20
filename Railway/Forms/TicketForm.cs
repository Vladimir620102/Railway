using Railway.Data.Model;
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
            DbContext.SetCarType();
            foreach (var s in DbContext.CarTypes)      
                cbCar_Type.Items.Add(s) ;
            cbCar_Type.DisplayMember = "Name";
        }

        private void cbArrival_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbArrival.SelectedItem == null ||
                cbDeparture.SelectedItem == null) return;

            try
            {
                // Получить список поездов 
                var from_id = ((Station)cbDeparture.SelectedItem).Id;
                var to_id = ((Station)cbArrival.SelectedItem).Id;

                var list = DbContext.SelectTrainForTicket(from_id, to_id);
                cbTrain.Items.Clear();  
                foreach(var t in list)
                {
                    cbTrain.Items.Add(t);
                }
                cbTrain.DisplayMember = "Name";

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }    
        }

        private void cbTrain_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbCar_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            // Получить список вагонов

        }
    }
}
