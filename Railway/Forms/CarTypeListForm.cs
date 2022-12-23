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
    public partial class CarTypeListForm : Form
    {
        public CarTypeListForm()
        {
            InitializeComponent();
            UpdateGrid();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                CarTypeDetailForm detailForm = new CarTypeDetailForm();
                if (detailForm.ShowDialog() != DialogResult.OK) return;
                CarType carType = new CarType
                {
                    Name = detailForm.tbName.Text,
                    Capacity = Convert.ToInt32(detailForm.tbCapacity.Text)
                };
                DbContext.AddCarType(carType);
                DbContext.CarTypes.Clear();
                UpdateGrid();
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
        void UpdateGrid()
        {
            int currentPosition = -1;
            if (dataGridView1.CurrentRow != null)
            {
                currentPosition = dataGridView1.CurrentRow.Index;
            }
            dataGridView1.Rows.Clear();
            DbContext.SetCarType();
            foreach (var s in DbContext.CarTypes) 
            {
                dataGridView1.Rows.Add(s.Id.ToString(), s.Name, s.Capacity.ToString());
            }
            if (currentPosition > -1 && dataGridView1.Rows.Count > 0)
                dataGridView1.CurrentCell = dataGridView1.Rows[currentPosition].Cells[1];
        }

        private void tsbEdit_Click(object sender, EventArgs e)
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
                CarTypeDetailForm detailForm = new CarTypeDetailForm();

                var id = Convert.ToInt32(row.Cells["Id"].Value);
                detailForm.tbName.Text = (string)row.Cells["CarTypeName"].Value;
                detailForm.tbCapacity.Text = row.Cells["Capacity"].Value.ToString();

                if (detailForm.ShowDialog() != DialogResult.OK) return;
                CarType carType = new CarType
                {
                    Id = id,
                    Name = detailForm.tbName.Text,
                    Capacity = Convert.ToInt32(detailForm.tbCapacity.Text)
                };
                DbContext.UpdateCarType(carType);
                DbContext.CarTypes.Clear();
                UpdateGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Close();
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
                var id = Convert.ToInt32(row.Cells["Id"].Value);

                DbContext.DeleteCarType(id);
                DbContext.CarTypes.Clear();
                UpdateGrid();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
