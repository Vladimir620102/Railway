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
    public partial class CityListForm : Form
    {
        public CityListForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            CityItemForm cf = new CityItemForm();
            SetCountry(cf.cbCountry);
            DialogResult dr = cf.ShowDialog();
            if (dr != DialogResult.OK) return;
            if (string.IsNullOrWhiteSpace(cf.tbCity.Text)) return;
            int countryId = 0;
            if(!string.IsNullOrEmpty(cf.cbCountry.Text)) countryId = Convert.ToInt32(((Country)(cf.cbCountry.SelectedItem)).Id);
            DbContext.AddCity(cf.tbCity.Text.Trim(), countryId);
            UpdateGrid();
        }
        void UpdateGrid()
        {
            int currentPosition = -1;
            if (dataGridView1.CurrentRow != null)
            {
                currentPosition = dataGridView1.CurrentRow.Index;
            }
            dataGridView1.Rows.Clear();
            DbContext.SetCities();
            foreach (var c in DbContext.Cities)
            {
                var countryId = string.Empty;
                if (c.CountryId > 0) countryId = c.CountryId.ToString();
                dataGridView1.Rows.Add(c.Id.ToString(), countryId, c.CountryName, c.Name);
            }
            if (currentPosition == -1) return;
            if (dataGridView1.Rows.Count == 0) return;
            if (currentPosition >= dataGridView1.Rows.Count)
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null) return;
            CityItemForm cf = new CityItemForm();
            cf.tbCity.Text = ((string)row.Cells["CityName"].Value).Trim();
            SetCountry(cf.cbCountry);
            foreach (var item in cf.cbCountry.Items)
            {
                if (((Country)item).Id == Convert.ToInt32( row.Cells["CountryId"].Value))
                    cf.cbCountry.SelectedItem = item;
            }
            DialogResult dr = cf.ShowDialog();
            if (dr != DialogResult.OK) return;
            if (string.IsNullOrWhiteSpace(cf.tbCity.Text)) return;
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            Country country = (Country)cf.cbCountry.SelectedItem;
            DbContext.UpdateCity(new City() { Id = id, CountryId = country.Id, CountryName = country.Name, Name = cf.tbCity.Text.Trim() });
            UpdateGrid();
        }

        void SetCountry(ComboBox cb)
        {
            cb.Items.Clear();
            DbContext.SetCountries();
            foreach (var c in DbContext.Countries)
            {
                c.Name = c.Name.Trim(); 
                cb.Items.Add(c);
                cb.DisplayMember= "Name";
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null) return;
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            DbContext.DeleteCity(id);
            UpdateGrid();
        }
    }
}
