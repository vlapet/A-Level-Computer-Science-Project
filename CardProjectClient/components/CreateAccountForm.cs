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
//using System.Data.SQLite;
using CardProjectClient.lib;
using CardProjectClient.client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography.X509Certificates;
using System.Net;

namespace CardProjectClient.components
{
    public partial class CreateAccountForm : Form
    {
        //Game MainGame;

        #region Constructor
        public CreateAccountForm(object MainGame)
        {
            // Access to the MainGame which includes all of the users created - subject to change as database is being used instead
            //this.MainGame = MainGame as Game;

            InitializeComponent();
        }

        public CreateAccountForm()
        {
            InitializeComponent();
        }

        #endregion
        /// <summary>
        /// Event to be carried out on Create Account button click - check that all boxes are filled with valid info and create new user account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// Move partially to API
        private async void btnCreateAccount_Click(object sender, EventArgs e)
        {
            double UserID;
            HttpResponseMessage response;

            // Make sure that all of the form boxes are filled out - makes sure that all boxes are not null, empty or all whitespace
            if (String.IsNullOrEmpty(this.txtCreateAccountForename.Text.ToString().Trim()) || String.IsNullOrEmpty(this.txtCreateAccountSurname.Text.ToString().Trim())
                || String.IsNullOrEmpty(this.txtCreateAccountUsername.Text.ToString().Trim()) || String.IsNullOrEmpty(this.txtCreateAccountPassword.Text.ToString().Trim())
                || String.IsNullOrEmpty(this.CmbBoxDay.Text) || String.IsNullOrEmpty(this.CmbBoxMonth.Text) || String.IsNullOrEmpty(this.CmbBoxYear.Text))
            {
                this.lblCreateAccountUserCredentialInfo.ForeColor = Color.Red;
                this.lblCreateAccountUserCredentialInfo.Text = "All boxes must be completed";
                return;
            }

            // Make sure that no spaces are used in account details
            if (this.txtCreateAccountForename.Text.Any(Char.IsWhiteSpace) || this.txtCreateAccountSurname.Text.Any(Char.IsWhiteSpace) || 
                this.txtCreateAccountUsername.Text.Any(Char.IsWhiteSpace) || this.txtCreateAccountPassword.Text.Any(Char.IsWhiteSpace))
            {
                this.lblCreateAccountUserCredentialInfo.ForeColor = Color.Red;
                this.lblCreateAccountUserCredentialInfo.Text = "Spaces are disallowed";
                return;
            }
            
            try
            {
                response = await RestClient.UserPostRequest(this.txtCreateAccountForename.Text, this.txtCreateAccountSurname.Text, this.txtCreateAccountUsername.Text, DataEncryption.Encrypt(this.txtCreateAccountPassword.Text), new DateOnly(Convert.ToInt32(this.CmbBoxYear.SelectedItem), (int)this.CmbBoxMonth.SelectedIndex + 1, Convert.ToInt32(this.CmbBoxDay.SelectedItem)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
                this.lblCreateAccountUserCredentialInfo.ForeColor = System.Drawing.Color.Red;
                this.lblCreateAccountUserCredentialInfo.Text = "An unexpected error has occurred";
                return; 
            }

            // BadRequest received when username requested already exists
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                Console.WriteLine("BadRequest");
                this.lblCreateAccountUserCredentialInfo.ForeColor = System.Drawing.Color.Red;
                this.lblCreateAccountUserCredentialInfo.Text = "This user account already exists";
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("OK");
                this.lblCreateAccountUserCredentialInfo.ForeColor = System.Drawing.Color.Blue;
                this.lblCreateAccountUserCredentialInfo.Text = "User account created successfully";
            }

            return;

            // Switch back to the sign in form
            //MainForm.RequestNewForm(new SignInForm(MainGame));
            MainForm.RequestNewForm(new SignInForm());
        }

        /// <summary>
        /// Method to carry out on form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
            this.lblCreateAccountUserCredentialInfo.Text = String.Empty;
        }

        /// <summary>
        /// Go back to sign in form on Cancel button being pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateAccountCancel_Click(object sender, EventArgs e)
        {
            // Go back to Sign In page
            //MainForm.RequestNewForm(new SignInForm(MainGame));
            MainForm.RequestNewForm(new SignInForm());
        }
    }
}
