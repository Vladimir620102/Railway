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
    public partial class RouteListForm : Form
    {
        public RouteListForm()
        {
            InitializeComponent();
            try
            {
                UpdateGrid();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {

            RouteDetailForm rdf=new RouteDetailForm();
            try
            {
                SetStations(rdf);
                var dr = rdf.ShowDialog();
                if (dr != DialogResult.OK) return;
                if (rdf.cbArrival.SelectedItem == null
                    || rdf.cbDeparture.SelectedItem == null) return;

                var number = Convert.ToInt32(rdf.tbNumber.Text);
                int fromStationId = Convert.ToInt32(((Station)(rdf.cbDeparture.SelectedItem)).Id);
                int toStationId = Convert.ToInt32(((Station)(rdf.cbArrival.SelectedItem)).Id);
                var route = new Route()
                {
                    Number = number,
                    DepartureStationId = fromStationId,
                    ArrivalStationId = toStationId
                };
                foreach (var ri in rdf.RouteItems)
                {
                    route.Items.Add(ri);
                }

                DbContext.AddRoute(route);
                UpdateGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetStations(RouteDetailForm rdf)
        {
            rdf.cbArrival.Items.Clear();
            rdf.cbDeparture.Items.Clear();

            rdf.cbArrival.DisplayMember= "Name";
            rdf.cbDeparture.DisplayMember= "Name";

            DbContext.SetStations();

            foreach(var st in DbContext.Stations)
            {
                rdf.cbArrival.Items.Add(st);
                rdf.cbDeparture.Items.Add(st);
            }
        }

        void UpdateGrid()
        {
            int currentPosition = -1;
            if (dataGridView1.CurrentRow != null)
            {
                currentPosition = dataGridView1.CurrentRow.Index;
            }
            dataGridView1.Rows.Clear();
            DbContext.SetRoutes();
            foreach (var s in DbContext.Routes)
            {
                dataGridView1.Rows.Add(s.Id.ToString(), s.Number, s.DepartureStationId, s.DepartureStationName, s.ArrivalStationId, s.ArrivalStationName);
            }
            if (currentPosition > -1 && dataGridView1.Rows.Count > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[currentPosition].Cells[1];
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;

            try
            {
                if (row == null
                    || row.Cells["ArrivalStationId"].Value == null
                    || row.Cells["DepartureStationId"].Value == null
                    || row.Cells["Number"].Value == null)
                {
                    MessageBox.Show("Не заполнены все реквизиты");
                    return;
                }
                RouteDetailForm rdf = new RouteDetailForm();

                rdf.tbNumber.Text = row.Cells["Number"].Value.ToString();

                int routeId = Convert.ToInt32(row.Cells["Id"].Value);
                Route route = DbContext.GetRoute(routeId);

                rdf.CurrentRoute = route;
                SetStations(rdf);

                foreach (var r in rdf.cbArrival.Items)
                {
                    if (((Station)r).Id == (int)row.Cells["ArrivalStationId"].Value)
                    {
                        rdf.cbArrival.SelectedItem = r;
                        
                        foreach(var ri in route.Items)
                        {
                            if (ri.DepartureTime == null) rdf.dtpArrival.Value = ri.ArrivalTime.Value;
                        }
                        break;
                    }
                }
                foreach (var r in rdf.cbDeparture.Items)
                {
                    if (((Station)r).Id == (int)row.Cells["DepartureStationId"].Value)
                    {
                        rdf.cbDeparture.SelectedItem = r;
                        foreach (var ri in route.Items)
                        {
                            if (ri.ArrivalTime== null) rdf.dtpDeparture.Value = ri.DepartureTime.Value;
                        }
                        break;
                    }
                }
                //
                var day = (rdf.dtpArrival.Value.Date - rdf.dtpDeparture.Value.Date).Days;
                if (day > 0) rdf.tbArrival.Text = day.ToString();
                var dr = rdf.ShowDialog();
                if (dr != DialogResult.OK) return;


                if (string.IsNullOrEmpty(rdf.cbArrival.SelectedText)
                    || string.IsNullOrEmpty(rdf.cbDeparture.SelectedText)) return;
                var number = Convert.ToInt32(rdf.tbNumber.Text);
                int fromStationId = Convert.ToInt32(((RouteItem)(rdf.cbDeparture.SelectedItem)).Station);
                int toStationId = Convert.ToInt32(((RouteItem)(rdf.cbArrival.SelectedItem)).Station);
                route.Number = number;
                route.DepartureStationId = fromStationId;
                route.ArrivalStationId = toStationId;
                foreach (var ri in rdf.RouteItems)
                {
                    route.Items.Add(ri);
                }
                DbContext.SaveRoute(route);
                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dataGridView1.CurrentRow;
                if (row == null) return;
                if (row.Cells["Id"].Value == null) 
                {
                    MessageBox.Show("Не заполнены все реквизиты");
                    return;
                }
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                DbContext.DeleteRoute(id);
                UpdateGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
