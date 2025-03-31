using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Login : Form
    {
        public Login(string username)
        {
            InitializeComponent();

            this.lbHello.Text = $"Hello, {username}!";
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
