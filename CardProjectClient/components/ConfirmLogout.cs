using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardProjectClient.components
{
    public partial class ConfirmLogout : Form
    {
        Form PreviousForm;

        public ConfirmLogout(Form PreviousForm)
        {
            this.PreviousForm = PreviousForm;
            InitializeComponent();
        }

        private void btnConfirmLogoutYes_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new SignInForm());
        }

        private void btnConfirmLogoutNo_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(PreviousForm);
        }
    }
}
