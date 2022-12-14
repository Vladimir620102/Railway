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
    public partial class RouteDetailForm : Form
    {
        List<RouteItem> _routeItems = new List<RouteItem>();
        public List<RouteItem> RouteItems { get=>_routeItems; }

        Route _route;
        public Route CurrentRoute
        {
            get { return _route; }
            set
            {
                _route= value;
                RouteItems.Clear();
                RouteItems.AddRange(_route.Items);
            }
        }
        public DateTime DeparureDate { get; set; }

        RouteItem routeItemArrival = new RouteItem();
        RouteItem routeItemDeparture = new RouteItem();
        public RouteDetailForm()
        {
            InitializeComponent();
            tsbAdd.Enabled = false;
            tsbDelete.Enabled = false;
            tsbEdit.Enabled = false;
            _routeItems.Clear();
            tbArrival.Text= string.Empty;
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RouteItemForm itemForm = new RouteItemForm();
                itemForm.labelTrain.Text = $"Поезд № {tbNumber.Text} {((Station)cbDeparture.SelectedItem).Name} - {((Station)cbArrival.SelectedItem).Name}";
                SetStation(itemForm.cbStation);
                itemForm.dtpArrivalTime.Value = dtpDeparture.Value;
                itemForm.dtpDepartureTime.Value = dtpDeparture.Value;
                
                if (itemForm.ShowDialog() != DialogResult.OK) return;

                var stationId = ((Station)itemForm.cbStation.SelectedItem).Id;
                if (stationId == ((Station)cbDeparture.SelectedItem).Id
                    || stationId == ((Station)cbArrival.SelectedItem).Id)
                {
                    MessageBox.Show("Промежуточная станция не может совпадать с начальной или кнечной");
                    return;
                }

                var countDayArrival = string.IsNullOrWhiteSpace(itemForm.tbArrival.Text) ? 0 : Convert.ToInt32(itemForm.tbArrival.Text);
                var countDayDeparture = string.IsNullOrWhiteSpace(itemForm.tbDeparture.Text) ? 0 : Convert.ToInt32(itemForm.tbDeparture.Text);

                var dataArrival = dtpDeparture.Value.Date.AddDays(countDayArrival);
                var dataDeparture = dtpDeparture.Value.Date.AddDays(countDayDeparture);
                var hourArrival = itemForm.dtpArrivalTime.Value.Hour;
                var minuteArrival = itemForm.dtpArrivalTime.Value.Minute;
                var hourDeparture= itemForm.dtpDepartureTime.Value.Hour;
                var minuteDeparture = itemForm.dtpDepartureTime.Value.Minute;

                var arrivalDate = new DateTime(dataArrival.Year,
                    dataArrival.Month,
                    dataArrival.Day,
                    hourArrival,
                    minuteArrival, 0
                    );
                var departureDate = new DateTime(dataDeparture.Year,
                    dataDeparture.Month,
                    dataDeparture.Day,
                    hourDeparture,
                    minuteDeparture, 0
                );
                AddRouteItems(stationId, arrivalDate, departureDate);

                UpdateGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetStation(ComboBox cbStation)
        {

            cbStation.Items.Clear();
            DbContext.SetStations();
            foreach (var c in DbContext.Stations)
            {
                c.Name = c.Name.Trim();
                cbStation.Items.Add(c);
                cbStation.DisplayMember = "Name";
            }
        }

        private void UpdateGrid()
        {
            int currentPosition = -1;
            if (dataGridView1.CurrentRow != null)
            {
                currentPosition = dataGridView1.CurrentRow.Index;
            }
            dataGridView1.Rows.Clear();
            RouteItems.Sort(delegate (RouteItem r1, RouteItem r2)
            {
                if (r1.ArrivalTime == null && r2.ArrivalTime == null) return 0;
                else if (r1.ArrivalTime == null) return -1;
                else if (r2.ArrivalTime == null) return 1;
                else if (r2.ArrivalTime == r1.ArrivalTime) return 0;
                else return r1.ArrivalTime > r2.ArrivalTime ? 1 : -1;
            });

            foreach (var r in RouteItems)
            {
                var st = DbContext.GetStation(r.Station);
                //dataGridView1.Rows.Add(-1, r.Station, st.Name,
                //    r.ArrivalTime.HasValue ? r.ArrivalTime.Value.ToShortTimeString() : string.Empty,
                //    r.DepartureTime.HasValue ? r.DepartureTime.Value.ToShortTimeString() : string.Empty,
                //    r.ArrivalTime == null, r.DepartureTime == null);
                dataGridView1.Rows.Add(-1, r.Station, st.Name,
                  r.ArrivalTime.HasValue ? r.ArrivalTime.Value.ToShortTimeString(): string.Empty,
                  r.DepartureTime.HasValue ? r.DepartureTime.Value.ToShortTimeString() : string.Empty,
                  r.ArrivalTime == null, r.DepartureTime == null);
            }
            if (currentPosition > -1 && dataGridView1.Rows.Count > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[currentPosition].Cells[2];
        //    dataGridView1.Sort(dataGridView1.Columns["Arrived"], ListSortDirection.Ascending);
        }

        private void AddRouteItems(int stationId, DateTime arrivalDate, DateTime departureDate)
        {
            try
            {
                var find = RouteItems.FirstOrDefault(r => r.Station == stationId);
                if (find != null) return;
                var routeItem = new RouteItem { Station = stationId, ArrivalTime = arrivalDate, DepartureTime = departureDate };
                RouteItems.Add(routeItem);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetRouteItems(int stationId, DateTime arrivalDate, DateTime departureDate)
        {
            var find = RouteItems.FirstOrDefault(r => r.Station == stationId);
            if (find == null) return;
            RouteItems.Remove(find);
            var routeItem = new RouteItem { Station = stationId, ArrivalTime = arrivalDate, DepartureTime = departureDate };
            RouteItems.Add(routeItem);
        }

        private void dtpDeparture_ValueChanged(object sender, EventArgs e)
        {
            SetValues();
        }

        void SetValues()
        {
            try
            {
                if (cbDeparture.SelectedItem == null) return;
                if (cbArrival.SelectedItem == null) return;

                tsbAdd.Enabled = true;
                tsbDelete.Enabled = true;
                tsbEdit.Enabled = true;


                routeItemDeparture.Station = ((Station)cbDeparture.SelectedItem).Id;
                routeItemDeparture.ArrivalTime = null;
                routeItemDeparture.DepartureTime = dtpDeparture.Value;
                routeItemArrival.Station = ((Station)cbArrival.SelectedItem).Id;

                var countDayArrival = string.IsNullOrWhiteSpace(tbArrival.Text) ? 0 : Convert.ToInt32(tbArrival.Text);

                var dataArrival = dtpDeparture.Value.Date.AddDays(countDayArrival);
                var hourArrival = dtpArrival.Value.Hour;
                var minuteArrival = dtpArrival.Value.Minute;

                var arrivalDate = new DateTime(dataArrival.Year,
                    dataArrival.Month,
                    dataArrival.Day,
                    hourArrival,
                    minuteArrival, 0
                    );

                routeItemArrival.ArrivalTime = dtpArrival.Value;
                routeItemArrival.DepartureTime = null;

                var find = RouteItems.FirstOrDefault(r => r.Station == routeItemDeparture.Station);
                if (find != null) RouteItems.Remove(find);
                find = RouteItems.FirstOrDefault(r => r.Station == routeItemArrival.Station);
                if (find != null) RouteItems.Remove(find);

                RouteItems.Add(routeItemDeparture);
                RouteItems.Add(routeItemArrival);
                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpArrival_ValueChanged(object sender, EventArgs e)
        {
            SetValues();
        }

        private void cbDeparture_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
            SetValues();
        }

        private void cbArrival_SelectedValueChanged(object sender, EventArgs e)
        {
            SetValues();
        }

        private void tsbSaveAndClose_Click(object sender, EventArgs e)
        {
            if (cbDeparture.SelectedItem == null
                || cbArrival.SelectedItem == null
                || string.IsNullOrWhiteSpace(tbNumber.Text))
            {
                MessageBox.Show("Введите все реквизиты");
                return;
            }
            try
            {
                Route route = new Route();
                route.DepartureStationId = ((Station)cbDeparture.SelectedItem).Id;
                route.DepartureStationName = ((Station)cbDeparture.SelectedItem).Name;
                route.ArrivalStationId = ((Station)cbArrival.SelectedItem).Id;
                route.ArrivalStationName = ((Station)cbArrival.SelectedItem).Name;
                route.Number = Convert.ToInt32(tbNumber.Text);
                if(CurrentRoute != null)
                route.Id = CurrentRoute.Id;

                foreach(var ri in RouteItems)
                {
                    route.Items.Add(ri);
                }

                DbContext.SaveRoute(route);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.CurrentRow == null) return;
                var stationId = (int)dataGridView1.CurrentRow.Cells["StationId"].Value;
                if (stationId == routeItemArrival.Station
                    || stationId == routeItemDeparture.Station) return;
                RouteItemForm itemForm = new RouteItemForm();
                itemForm.labelTrain.Text = $"Поезд № {tbNumber.Text} {((Station)cbDeparture.SelectedItem).Name} - {((Station)cbArrival.SelectedItem).Name}";

                SetStation(itemForm.cbStation);

                DateTime d = DateTime.Now.Date;

                foreach (var s in itemForm.cbStation.Items)
                {
                    if (((Station)s).Id == stationId)
                    {
                        itemForm.cbStation.SelectedItem = s;

                        var routeItem = RouteItems.FirstOrDefault(ri => ri.Station == stationId);
                        if (routeItem == null)
                        {
                            MessageBox.Show("Ошибка в данных промежуточной станции!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var depTime = SplitTime(dataGridView1.CurrentRow.Cells["Departure"].Value.ToString());
                        //var depDate = new DateTime( DeparureDate.Date.Year, DeparureDate.Date.Month,DeparureDate.Date.Day, depTime.Item1,depTime.Item2,0);
                        itemForm.dtpDepartureTime.Value = routeItem.DepartureTime.Value;
                        var arrTime = SplitTime(dataGridView1.CurrentRow.Cells["Arrived"].Value.ToString());
                        //var arrDate = new DateTime(DeparureDate.Date.Year, DeparureDate.Month, DeparureDate.Day, arrTime.Item1, arrTime.Item2, 0);
                        itemForm.dtpArrivalTime.Value = routeItem.ArrivalTime.Value;
                        var day = (itemForm.dtpArrivalTime.Value.Date - dtpDeparture.Value.Date).Days;
                        if (day > 0) itemForm.tbArrival.Text = day.ToString();
                        day = (itemForm.dtpDepartureTime.Value.Date - dtpDeparture.Value.Date).Days;
                        if (day > 0) itemForm.tbDeparture.Text = day.ToString();
                    }
                }

                if (itemForm.ShowDialog() != DialogResult.OK) return;

                stationId = ((Station)itemForm.cbStation.SelectedItem).Id;
                if (stationId == ((Station)cbDeparture.SelectedItem).Id) return;
                if (stationId == ((Station)cbArrival.SelectedItem).Id) return;

                var countDayArrival = string.IsNullOrWhiteSpace(itemForm.tbArrival.Text) ? 0 : Convert.ToInt32(itemForm.tbArrival.Text);
                var countDayDeparture = string.IsNullOrWhiteSpace(itemForm.tbDeparture.Text) ? 0 : Convert.ToInt32(itemForm.tbDeparture.Text);

                var dataArrival = dtpDeparture.Value.Date.AddDays(countDayArrival);
                var dataDeparture = dtpDeparture.Value.Date.AddDays(countDayDeparture);
                var hourArrival = itemForm.dtpArrivalTime.Value.Hour;
                var minuteArrival = itemForm.dtpArrivalTime.Value.Minute;
                var hourDeparture = itemForm.dtpDepartureTime.Value.Hour;
                var minuteDeparture = itemForm.dtpDepartureTime.Value.Minute;

                var arrivalDate = new DateTime(dataArrival.Year,
                    dataArrival.Month,
                    dataArrival.Day,
                    hourArrival,
                    minuteArrival, 0
                    );
                var departureDate = new DateTime(dataDeparture.Year,
                    dataDeparture.Month,
                    dataDeparture.Day,
                    hourDeparture,
                    minuteDeparture, 0
                );
                SetRouteItems(stationId, arrivalDate, departureDate);

                UpdateGrid();
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

        (int, int) SplitTime(string time)
        {
            string[] temp = time.Split(':');
            return (Convert.ToInt32( temp[0]), Convert.ToInt32(temp[1]));
        }
    }
}
