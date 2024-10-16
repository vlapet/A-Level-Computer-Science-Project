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
using CardProjectClient.lib;
//using System.Data.SQLite;
using CardProjectClient.client;
using CardProjectClient.components.admin_components;

// Using Newtonsoft.Json NuGet package
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Xml.Schema;
using System.Net;

namespace CardProjectClient.components
{
    public partial class SignInForm : Form
    {
        //Game MainGame;

        #region Constructor
        /// <summary>
        /// Constructor for Sign In form
        /// </summary>
        /// <param name="MainGame">The MainGame that is being played - stores all of the users</param>
        public SignInForm(object MainGame)
        {
            // Access to the MainGame which includes all of the users created
            //this.MainGame = MainGame as Game;
            InitializeComponent();
        }

        public SignInForm()
        {
            InitializeComponent();
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Sign in to user when login button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("SHA512:\t" + DataEncryption.Encrypt(this.txtUsername.Text).ToLower());

            User CurrentUser;

            // Added encryption
            UserGet UserDetails = new UserGet(this.txtUsername.Text, DataEncryption.Encrypt(this.txtPassword.Text));

            if (string.IsNullOrWhiteSpace(this.txtUsername.Text) && string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                this.lblSignInUserCredentialsInfo.ForeColor = Color.Red;
                this.lblSignInUserCredentialsInfo.Text = "Please enter login credentials";
                return;
            }

            if (string.IsNullOrWhiteSpace(RestClient.EndPoint))
            {
                this.lblSignInUserCredentialsInfo.ForeColor = Color.Red;
                this.lblSignInUserCredentialsInfo.Text = "URI is empty";
                return;
            }

            this.lblSignInUserCredentialsInfo.ForeColor = Color.Blue;
            this.lblSignInUserCredentialsInfo.Text = "Processing...";

            HttpResponseMessage Response;

            try
            {
                Response = await RestClient.UserGetRequest(UserDetails);
            }
            catch
            {
                this.lblSignInUserCredentialsInfo.ForeColor = Color.Red;
                this.lblSignInUserCredentialsInfo.Text = "Could not connect to the server";
                return;
            }

            if (Response.StatusCode == HttpStatusCode.NotFound)
            {
                this.lblSignInUserCredentialsInfo.ForeColor = Color.Red;
                this.lblSignInUserCredentialsInfo.Text = "Login credentials are incorrect";
                return;
            }

            //UserPut CurrentUserPut = await System.Text.Json.JsonSerializer.DeserializeAsync<UserPut>(await Response.Content.ReadAsStreamAsync());
            UserPut CurrentUserPut = await JsonParseMethods.ParseToObjectFromWebResponse<UserPut>(Response);
            CurrentUser = new User(CurrentUserPut.Forename, CurrentUserPut.Surname, CurrentUserPut.Username, CurrentUserPut.Password, DateOnly.FromDateTime((DateTime)CurrentUserPut.DateOfBirth), (int)CurrentUserPut.UserID);


            //Console.WriteLine("CurrentUser: " + CurrentUser.Username + " " + CurrentUser.Password);

            // Only admin account can have this ID - allows developers to add new features to the game
            if (CurrentUser.UserID == 0)
            {
                MainForm.RequestNewForm(new AdminHomeForm(CurrentUser));
                return;
            }


            MainForm.RequestNewForm(new HomeForm(CurrentUser));
        }

        /// <summary>
        /// Change to Create Account form when link pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linklblCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm.RequestNewForm(new CreateAccountForm());
        }

        /// <summary>
        /// Change to Confirm Exit form when cancel button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignInCancel_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new ConfirmExit(this));
        }

        /// <summary>
        /// Opens settings page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new SignInSettingsForm());
        }
    }
}
