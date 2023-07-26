using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keygenapp
{
    public partial class LoginFrm : Form
    {
        bool loggedIn = false;
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (!loggedIn) {
                User u = new User(username.Text, "", key.Text);
                bool result = u.Verify();
                loggedIn = result;
                resp.Text = result ? "Response: Valid." : "Response: Invalid data.";
                if (result)
                {
                    MainFrm frm = new MainFrm(u, this);
                    frm.Show();
                    this.Hide();
                }
            }
        }
    }
}
