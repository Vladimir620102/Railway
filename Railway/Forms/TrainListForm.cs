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
                if (row.Cells[0].Value == null)
                {
                    MessageBox.Show("Не заполнены все реквизиты");
                    return;
                }
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
                int currentPosition = -1;
                if (dataGridView1.CurrentRow != null)
                {
                    currentPosition = dataGridView1.CurrentRow.Index;
                }
                SetTrains(routeId);
                dataGridView1.Rows.Clear();

                //RouteItems.Sort(delegate (RouteItem r1, RouteItem r2)
                //{
                //    if (r1.ArrivalTime == null && r2.ArrivalTime == null) return 0;
                //    else if (r1.ArrivalTime == null) return -1;
                //    else if (r2.ArrivalTime == null) return 1;
                //    else if (r2.ArrivalTime == r1.ArrivalTime) return 0;
                //    else return r1.ArrivalTime > r2.ArrivalTime ? 1 : -1;
                //});

                foreach (var t in DbContext.Trains)
                {
                    dataGridView1.Rows.Add(t.Id, t.Number,
                        t.DepartureStationId, t.DepartureStationName,
                        t.ArrivalStationId, t.ArrivalStationName,
                        t.Departure, t.Arrival);
                }

                dataGridView1.Sort(dataGridView1.Columns[6], ListSortDirection.Ascending);

                if (currentPosition > -1 && dataGridView1.Rows.Count > 0)
                {
                    if (currentPosition >= dataGridView1.Rows.Count) currentPosition = dataGridView1.Rows.Count - 1;
                    dataGridView1.CurrentCell = dataGridView1.Rows[currentPosition].Cells[1];
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
                var sharedVagon = string.IsNullOrWhiteSpace(tdf.tbShared.Text)?0: Convert.ToInt32(tdf.tbShared.Text);
                var economVagon = string.IsNullOrWhiteSpace(tdf.tbEconom.Text) ? 0 : Convert.ToInt32(tdf.tbEconom.Text);
                var compartVagon = string.IsNullOrWhiteSpace(tdf.tbCompart.Text) ? 0 : Convert.ToInt32(tdf.tbCompart.Text);
                var businesVagon = string.IsNullOrWhiteSpace(tdf.tbBusiness.Text) ? 0 : Convert.ToInt32(tdf.tbBusiness.Text);

                Train train = new Train();
                train.Number = r.Number;
                train.ArrivalStationId = r.ArrivalStationId;
                train.DepartureStationId = r.DepartureStationId;

                var dataDeparture = GetDateTime(r);
                if(dataDeparture == null)
                {
                    MessageBox.Show("Не найдено время отправления маршрута");
                    return;
                }

                var days = (tdf.dtpDate.Value.Date - dataDeparture.Value.Date).Days;
                int d1=0, d2=0;
                foreach (var ri in r.Items)
                {
                    if (ri.DepartureTime == null)
                    {
                        train.Arrival = ri.ArrivalTime.Value.AddDays(days);
                    }
                    if (ri.ArrivalTime == null)
                    {
                        train.Departure = ri.DepartureTime.Value.AddDays(days);
                    }
                }
                if (d1 < d2) train.Arrival = train.Arrival.AddDays(1);
                train.RouteId = r.Id;

                DbContext.AddTrain(train, sharedVagon, economVagon, compartVagon, businesVagon);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateGrid(r.Id);
        }

        DateTime? GetDateTime(Route route)
        {
            foreach(var ri in route.Items)
            {
                if (!ri.ArrivalTime.HasValue)
                    return ri.DepartureTime.Value;
            }
            return null;
        }
    }
}
