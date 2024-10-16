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
using CardProjectClient.client;
using System.Reflection.Metadata.Ecma335;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using CardProjectClient.lib;

namespace CardProjectClient.components
{
    public partial class MyDetails : Form
    {
        User _CurrentUser;
        UserPut tUser;
        HttpResponseMessage? _Response;

        public MyDetails(User CurrentUser)
        {
            this.CurrentUser = CurrentUser;
            InitializeComponent();

            this.leftMenuBar1.CurrentUser = this.CurrentUser;
            this.btnMyDetailsTopBar.ForeColor = Color.White;
            Console.WriteLine($"MyDetails\tCurrentUser: {CurrentUser}");
        }

        #region Private Accessors

        public User CurrentUser
        {
            get => _CurrentUser;
            set => _CurrentUser = value;
        }

        public HttpResponseMessage? Response
        {
            get => _Response;
            set => _Response = value;
        }

        public Label LblMyDetailsInfo
        {
            get => this.lblMyDetailsInfo;
            set => this.lblMyDetailsInfo = value;
        }

        #endregion

        #region Functions


        private void leftMenuBar1_Load(object sender, EventArgs e)
        {

        }

        private void MyDetails_Load(object sender, EventArgs e)
        {
            Func<string, string> PasswordToAsterisk = x => 
            {
                string tstring = String.Empty;

                for (int i = 0; i < x.Length; i++)
                {
                    tstring += "*";
                }
                return tstring;
            };

            this.txtBoxMyDetailsForename.Enabled = false;
            this.txtBoxMyDetailsSurname.Enabled = false;
            this.txtBoxMyDetailsUsername.Enabled = false;
            this.txtBoxMyDetailsPassword.Enabled = false;
            this.txtBoxMyDetailsDateOfBirth.Enabled = false;
            this.txtBoxMyDetailsUserID.Enabled = false;

            this.txtBoxMyDetailsForename.Text = this.CurrentUser.Forename;
            this.txtBoxMyDetailsSurname.Text = this.CurrentUser.Surname;
            this.txtBoxMyDetailsUsername.Text = this.CurrentUser.Username;
            this.txtBoxMyDetailsPassword.Text = PasswordToAsterisk(this.CurrentUser.Password);
            this.txtBoxMyDetailsDateOfBirth.Text = this.CurrentUser.DateOfBirth.ToShortDateString();
            this.txtBoxMyDetailsUserID.Text = this.CurrentUser.UserID.ToString();

        }

        private void btnMyDetailsTopBar_Click(object sender, EventArgs e)
        {
            return;
        }

        private void btnMyDetailsDeleteAccount_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new ConfirmAccountDeletion(this));

        }

        #endregion

        /// <summary>
        /// Store changed user properties in tUser variable and send UpdateUser request to 
        /// </summary>
        /// <para>Sends UpdateUser request if all fields are parsed successfully - especially date of birth</para>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="ArgumentException"></exception>
        private void btnMyDetailsUpdateAccount_Click(object sender, EventArgs e)
        {
            Func<string, DateOnly?> CheckDateTextBox = tbox =>
            {
                Console.WriteLine($"Checking date\ttbox: {tbox}");

                if (String.IsNullOrWhiteSpace(tbox))
                    return null;
                else if (!DateOnly.TryParse(tbox, out _))
                    throw new ArgumentException("Please enter a valid date");

                return DateOnly.Parse(tbox);
            };

            DateTime? dTime = new DateTime();


            try
            {
                if (CheckDateTextBox(this.txtBoxMyDetailsDateOfBirthNew.Text) == null)
                    dTime = null;
                else
                    dTime = DateTime.Parse(this.txtBoxMyDetailsDateOfBirthNew.Text);

                tUser = new UserPut
                {
                    Forename = String.IsNullOrWhiteSpace(this.txtBoxMyDetailsForenameNew.Text) ? null : this.txtBoxMyDetailsForenameNew.Text,
                    Surname = String.IsNullOrWhiteSpace(this.txtBoxMyDetailsSurnameNew.Text) ? null : this.txtBoxMyDetailsSurnameNew.Text,
                    Username = String.IsNullOrWhiteSpace(this.txtBoxMyDetailsUsernameNew.Text) ? null : this.txtBoxMyDetailsUsernameNew.Text,
                    Password = String.IsNullOrWhiteSpace(this.txtBoxMyDetailsPasswordNew.Text) ? null : DataEncryption.Encrypt(this.txtBoxMyDetailsPasswordNew.Text),
                    DateOfBirth = dTime,
                    UserID = null
                };

                this.lblMyDetailsInfo.Text = String.Empty;
            }
            catch (ArgumentException ex)
            {
                this.lblMyDetailsInfo.Text = ex.Message;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
                this.lblMyDetailsInfo.Text = ex.Message; 
                return;
            }

            MainForm.RequestNewForm(new ConfirmAccountUpdate(this, tUser, CurrentUser));
        }
    }
}
