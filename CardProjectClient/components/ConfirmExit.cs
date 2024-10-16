using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardProjectClient.game;

namespace CardProjectClient.components
{
    public partial class ConfirmExit : Form
    {
        Form PreviousForm;

        public ConfirmExit(Form PreviousForm)
        {
            this.PreviousForm = PreviousForm;
            InitializeComponent();
        }

        private void btnConfirmExitYes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirmExitNo_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(this.PreviousForm);
        }
    }
}
