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
using CardProjectClient.game;

namespace CardProjectClient.components
{
    public partial class ConfirmAccountUpdate : Form
    {
        MyDetails PreviousForm;
        UserPut tUser;
        User CurrentUser;

        public ConfirmAccountUpdate(MyDetails previousForm, UserPut tUser, User currentUser)
        {
            PreviousForm = previousForm;
            this.tUser = tUser;
            this.CurrentUser = currentUser;

            InitializeComponent();
        }

        private async void btnConfirmAccountUpdateYes_Click(object sender, EventArgs e)
        {
            Func<string, string, string> CheckSet = (CurrentUserProperty, UpdateUserProperty) =>
            {
                if (String.IsNullOrWhiteSpace(UpdateUserProperty))
                    return CurrentUserProperty;

                return UpdateUserProperty;
            };


            HttpResponseMessage response;

            try
            {
                response = await RestClient.UserUpdateRequest(tUser, CurrentUser);
            }
            catch
            {
                PreviousForm.LblMyDetailsInfo.ForeColor = Color.Red;
                PreviousForm.LblMyDetailsInfo.Text = "An unexpected error has occurred";
                MainForm.RequestNewForm(PreviousForm);
                return;
            }

            Console.WriteLine($"Response statuscode from form:{response.StatusCode}");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                PreviousForm.LblMyDetailsInfo.ForeColor = Color.Blue;
                PreviousForm.LblMyDetailsInfo.Text = "Account updated successfully";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotAcceptable)
            {
                PreviousForm.LblMyDetailsInfo.ForeColor = Color.Red;
                PreviousForm.LblMyDetailsInfo.Text = "The requested username already exists";
            }
            else
            {
                PreviousForm.LblMyDetailsInfo.ForeColor = Color.Red;
                PreviousForm.LblMyDetailsInfo.Text = "An error has occurred";
            }

            // Password is never sent back to client so no need to update it
            CurrentUser = new User(CheckSet(CurrentUser.Forename, tUser.Forename),
                CheckSet(CurrentUser.Surname, tUser.Surname),
                CheckSet(CurrentUser.Username, tUser.Username),
                CurrentUser.Password,
                DateOnly.FromDateTime(DateTime.Parse(CheckSet(CurrentUser.DateOfBirth.ToString(), tUser.DateOfBirth.ToString()))),
                CurrentUser.UserID);

            //MainForm.RequestNewForm(PreviousForm);
            MainForm.RequestNewForm(new MyDetails(CurrentUser));
        }

        private void btnConfirmAccountUpdateNo_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(PreviousForm);
        }
    }
}
