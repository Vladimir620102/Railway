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
    public partial class TrainListForm : Form
    {
        public TrainListForm()
        {
            InitializeComponent();
            SetRoutes();
        }

        private void SetRoutes()
        {
            try
            {
                DbContext.SetRoutes();
                cbRoute.Items.Clear();
                foreach (var r in DbContext.Routes)
                {
                    cbRoute.Items.Add(r);
                }
                cbRoute.DisplayMember= "Name";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbRoute_SelectedValueChanged(object sender, EventArgs e)
        {
            /*
            var row = dataGridView1.CurrentRow;
            if (row == null) return;
            if (row.Cells[0].Value == null) return;
            int id = (int)row.Cells[0].Value;
            */

            var r = (Route)cbRoute.SelectedItem;
            if (r == null) return;

            UpdateGrid(r.Id);

        }

        private void SetTrains(int routeId)
        {
          DbContext.SetTrains(routeId);
        }

       
       

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var r = (Route)cbRoute.SelectedItem;
            if (r == null)
            {
                MessageBox.Show("Не выбран маршрут");
                return;
            }

            try
            {
                var row = dataGridView1.CurrentRow;
                if (row == null) return;
                if (row.Cells[0].Value == null) return;
                int id = (int)row.Cells[0].Value;
                DbContext.DeleteTrain(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateGrid(r.Id);
        }

        void UpdateGrid(int routeId)
        {
            try
            {
                SetTrains(routeId);
                dataGridView1.Rows.Clear();
                foreach (var t in DbContext.Trains)
                {
                    dataGridView1.Rows.Add(t.Id, t.Number,
                        t.DepartureStationId, t.DepartureStationName,
                        t.ArrivalStationId, t.ArrivalStationName,
                        t.Departure, t.Arrival);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {

            var r = (Route)cbRoute.SelectedItem;
            if (r == null) {
                MessageBox.Show("Не выбран маршрут");
                return;
            }
            try
            {

                TrainDetailForm tdf = new TrainDetailForm();
                if (tdf.ShowDialog() != DialogResult.OK) return;
                var sharedVagon = Convert.ToInt32(tdf.tbShared.Text);
                var economVagon = Convert.ToInt32(tdf.tbEconom.Text);
                var compartVagon = Convert.ToInt32(tdf.tbCompart.Text);
                var businesVagon = Convert.ToInt32(tdf.tbBusiness.Text);

                Train train = new Train();
                train.Number = r.Number;
                train.ArrivalStationId = r.ArrivalStationId;
                train.DepartureStationId = r.DepartureStationId;
                foreach (var ri in r.Items)
                {
                    if (ri.DepartureTime == null)
                        train.Arrival = ri.ArrivalTime.Value;
                    if (ri.ArrivalTime == null)
                        train.Departure = ri.DepartureTime.Value;
                }
                train.RouteId = r.Id;

                DbContext.AddTrain(train, sharedVagon, economVagon, compartVagon, businesVagon);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateGrid(r.Id);
        }


    }
}
