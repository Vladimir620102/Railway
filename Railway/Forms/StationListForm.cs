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
    public partial class StationListForm : Form
    {
        public StationListForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {

            StationDetailForm detailForm = new StationDetailForm();
            SetCities(detailForm.cbCity);
            DialogResult dr = detailForm.ShowDialog();
            if (dr != DialogResult.OK) return;
            if (string.IsNullOrWhiteSpace(detailForm.tbNumber.Text)) return;
            if (string.IsNullOrWhiteSpace(detailForm.tbName.Text)) return;

            int cityId = 0;
            if (!string.IsNullOrEmpty(detailForm.cbCity.Text))
                cityId = Convert.ToInt32(((City)(detailForm.cbCity.SelectedItem)).Id);
            var number = Convert.ToInt32(detailForm.tbNumber.Text);
            DbContext.AddStation(number, detailForm.tbName.Text, cityId);
            UpdateGrid();
        }

        private void SetCities(ComboBox cb)
        {
            cb.Items.Clear();
            DbContext.SetCities();
            foreach (var c in DbContext.Cities)
            {
                c.Name = c.Name.Trim();
                cb.Items.Add(c);
                cb.DisplayMember = "Name";
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
            DbContext.SetStations();
            foreach (var s in DbContext.Stations)
            {
                dataGridView1.Rows.Add(s.Id.ToString(), s.Number, s.Name, s.CityId, s.CityName );
            }
            if (currentPosition > -1 && dataGridView1.Rows.Count > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[currentPosition].Cells[1];
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null) return;
            StationDetailForm detailForm = new StationDetailForm();
            SetCities(detailForm.cbCity);

            foreach (var item in detailForm.cbCity.Items)
            {
                if (((City)item).Id == Convert.ToInt32(row.Cells["CityId"].Value))
                    detailForm.cbCity.SelectedItem = item;
            }
            DialogResult dr = detailForm.ShowDialog();
            if (dr != DialogResult.OK) return;
            if (string.IsNullOrWhiteSpace(detailForm.tbName.Text)) return;
            if (string.IsNullOrWhiteSpace(detailForm.tbNumber.Text)) return;
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            int number = Convert.ToInt32(detailForm.tbNumber.Text);

            City c = (City)detailForm.cbCity.SelectedItem;
            DbContext.UpdateStation(new Station() { Id = id, Number= number, Name = detailForm.tbName.Text.Trim(), CityName = c.Name, CityId = c.Id });
            UpdateGrid();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null) return;
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            DbContext.DeleteStation(id);
            UpdateGrid();
        }
    }
}
