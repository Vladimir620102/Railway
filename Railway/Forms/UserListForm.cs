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
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            UserDetailForm adf = new UserDetailForm();
            if(adf.ShowDialog() != DialogResult.OK) return;


        }
    }
}
