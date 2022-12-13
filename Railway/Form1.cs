using Railway.DbUtils;
using Railway.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway
{
    public partial class Form1 : Form
    {
        DbContext _dbContext;
        public Form1()
        {
            InitializeComponent();
             _dbContext = new DbContext();
        }

        private void btTicket_Click(object sender, EventArgs e)
        {
            TicketForm tf = new TicketForm();
            tf.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void билетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TicketForm tf = new TicketForm();
            tf.ShowDialog();
        }

        private void miCountry_Click(object sender, EventArgs e)
        {
            CountryListForm countryListForm = new CountryListForm();
            countryListForm.ShowDialog();
        }

        private void городаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CityListForm cityListForm = new CityListForm();
            cityListForm.ShowDialog();
        }
    }
}
