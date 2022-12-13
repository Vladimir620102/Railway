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
    public partial class CountryListForm : Form
    {
        public CountryListForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            CountryItemForm cf = new CountryItemForm();
            DialogResult dr = cf.ShowDialog();
            if (dr != DialogResult.OK) return;
            if (string.IsNullOrWhiteSpace(cf.tbName.Text)) return;
            DbContext.AddCountry(cf.tbName.Text.Trim());
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
            DbContext.SetCountries();
            foreach (var c in DbContext.Countries)
            {
                dataGridView1.Rows.Add(c.Id.ToString(), c.Name, c.ShortName);
            }
            if (currentPosition > -1 && dataGridView1.Rows.Count > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[currentPosition].Cells[0];
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null) return;
            CountryItemForm cf = new CountryItemForm();
            cf.tbName.Text = ((string)row.Cells["CountryName"].Value).Trim();
            DialogResult dr = cf.ShowDialog();
            if (dr != DialogResult.OK) return;
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            DbContext.UpdateCountry(id, cf.tbName.Text);
            UpdateGrid();

        }

        private void tsbExit_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            if (row == null) return;
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            DbContext.DeleteCountry(id);
            UpdateGrid();
        }
    }
}
