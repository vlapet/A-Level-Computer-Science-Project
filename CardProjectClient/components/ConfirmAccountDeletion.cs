using CardProjectClient.client;
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
    public partial class ConfirmAccountDeletion : Form
    {
        MyDetails PreviousForm;

        public ConfirmAccountDeletion(MyDetails PreviousForm)
        {
            this.PreviousForm = PreviousForm;
            InitializeComponent();
        }

        private async void btnConfirmAccountDeletionYes_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response;

            try
            {
                response = await RestClient.UserDeleteRequest(PreviousForm.CurrentUser.Username, PreviousForm.CurrentUser.UserID.ToString());
            }
            catch
            {

            }

            //Console.WriteLine($"response: {response.StatusCode}");
            MainForm.RequestNewForm(new SignInForm());
        }

        private void btnConfirmAccountDeletionNo_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(PreviousForm);
        }
    }
}
