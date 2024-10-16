using CardProjectClient.client;
using CardProjectClient.lib;
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
    public partial class SignInSettingsForm : Form
    {
        #region Constructor
        public SignInSettingsForm()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Apply settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignInSettingsApply_Click(object sender, EventArgs e)
        {
            //Globals.APIEndpoint = this.txtBoxSignInSettingsServerURI.Text;     // Sets the server URI
            RestClient.EndPoint = this.txtBoxSignInSettingsServerURI.Text;     // Sets the server URI
            this.lblSignInSettingsInfo.Text = "Server URI added successfully";
        }

        /// <summary>
        /// Go back to sign in form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignInSettingsCancel_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new SignInForm());
        }
    }
}
