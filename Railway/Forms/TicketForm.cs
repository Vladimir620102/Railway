using Railway.Data.Model;
using Railway.DbUtils;

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
        int currentTrainId = -1;
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

            SetCar_Types();           
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
                if (list == null) return;
                cbTrain.Items.Clear();  
                foreach(var t in list)
                {
                    cbTrain.Items.Add(t);
                }
                cbTrain.DisplayMember = "Name";
                cbCar_Type.SelectedItem = null;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }    
        }

        private void cbTrain_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbCar_Type_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                // Получить список вагонов
                CarType ct = (CarType)cbCar_Type.SelectedItem;
                if (ct == null) return;
                Route route = (Route)cbTrain.SelectedItem;
                if (route == null) return;

                currentTrainId = DbContext.GetTrainId(route, dateTimePicker1.Value);
                if (currentTrainId == -1)
                {
                    MessageBox.Show($"{route.Name} на {dateTimePicker1.Value.ToShortDateString()} не найден");
                    return;
                }
                var list = DbContext.SelectByCarType(currentTrainId, ct.Id);
                if (list == null || list.Count == 0)
                {
                    MessageBox.Show($"{route.Name} на {dateTimePicker1.Value.ToShortDateString()}, вагон {ct.Name}: мест нет");
                    return;
                }
                cbVagon.Items.Clear();
                foreach (var t in list)
                {
                    cbVagon.Items.Add(t);
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }       
        }

        void SetCar_Types()
        {
            cbCar_Type.Items.Clear();
            DbContext.SetCarType();
            foreach (var s in DbContext.CarTypes)
                cbCar_Type.Items.Add(s);
            cbCar_Type.DisplayMember = "Name";
        }

        private void cbVagon_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbVagon.SelectedItem==null)return;
            try
            {
                // Получить список мест
                int number = (int)cbVagon.SelectedItem;
                Route route = (Route)cbTrain.SelectedItem;
                if (route == null) return;

                currentTrainId = DbContext.GetTrainId(route, dateTimePicker1.Value);

                var list = DbContext.SelectByVagon(currentTrainId, number);
                if (list == null) return;
                cbSeat.Items.Clear();
                foreach (var t in list)
                {
                    cbSeat.Items.Add(t);
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPassanger.Text))
            {
                MessageBox.Show("Введите ФИО пассажира!");
                return;
            }

            // выписываем билет
            try {
                DateTime tickeDate = dateTimePicker1.Value;
                string departureStationName = ((Station)cbDeparture.SelectedItem).Name;
                int departureStationId = ((Station)cbDeparture.SelectedItem).Id;
                int arrivalStationId = ((Station)cbArrival.SelectedItem).Id;
                string arrivalStationName = ((Station)cbArrival.SelectedItem).Name;
                int numberOfTrain = ((Route)cbTrain.SelectedItem).Number;
                int vagon = ((int)cbVagon.SelectedItem);
                int place = ((int)cbSeat.SelectedItem);
                string passanger = tbPassanger.Text;

                Ticket ticket = new Ticket()
                {
                    DepartureDate = tickeDate,
                    DepartureStationId=departureStationId,
                    DepartureStation = departureStationName,
                    ArrivalStationId=arrivalStationId,
                    ArrivalStation = arrivalStationName,
                    Passanger = passanger,
                    Train = numberOfTrain,
                    TrainId = currentTrainId,
                    Vagon = vagon,
                    Place = place
                };
                var ret = DbContext.AddTicket(ticket);
                if (ret)
                {
                    cbSeat.SelectedItem = null;
                    cbSeat.Items.Remove(place);
                    MessageBox.Show("Билет выписан.");
                }
                else MessageBox.Show("Билет не выписан.");

                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cbCar_Type.SelectedItem=null; 
        }

        private void cbDeparture_SelectedValueChanged(object sender, EventArgs e)
        {
            cbCar_Type.SelectedItem = null;
        }

        private void cbDeparture_SelectedValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
