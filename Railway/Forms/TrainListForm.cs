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
            var row = dataGridView1.CurrentRow;
            if(row==null) return;
            if(row.Cells[0].Value == null) return;
            int id = (int)row.Cells[0].Value;
            DbContext.DeleteTrain(id);
        }

        void UpdateGrid(int routeId)
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

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            TrainDetailForm tdf = new TrainDetailForm();

        }
    }
}
