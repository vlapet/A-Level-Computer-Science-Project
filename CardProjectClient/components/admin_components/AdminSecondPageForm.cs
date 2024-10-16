using CardProjectClient.client;
using CardProjectClient.game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardProjectClient.components.admin_components
{
    public partial class AdminSecondPageForm : Form
    {
        User CurrentUser;
        object PreviousForm;

        public AdminSecondPageForm(User CurrentUser, object PreviousForm)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            this.PreviousForm = PreviousForm;
            
            this.lblNewsInfo.Text = String.Empty;
            this.lblAddFrameInfo.Text = String.Empty;
        }

        private async void btnChooseCardFrameImage_Click(object sender, EventArgs e)
        {
            if (ofdFilePicker.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.txtBoxImagePath.Text = ofdFilePicker.FileName;
                    this.txtBoxImagePath.Select(this.txtBoxImagePath.Text.Length, 0);
                }
                catch (SecurityException ex)
                {

                }
            }
        }

        private async void btnAddNewFrame_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtBoxCardFrameName.Text))
            {
                this.lblAddFrameInfo.ForeColor = Color.Red;
                this.lblAddFrameInfo.Text = "Please enter a frame name";
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtBoxImagePath.Text))
            {
                this.lblAddFrameInfo.ForeColor = Color.Red;
                this.lblAddFrameInfo.Text = "Please select an image";
                return;
            }

            this.lblAddFrameInfo.ForeColor = Color.Blue;
            this.lblAddFrameInfo.Text = "Processing...";

            byte[] NewFrameImage = await APIMethods.GetImageBinary(this.txtBoxImagePath.Text);
            string NewFrameName = this.txtBoxCardFrameName.Text;
            int end = 0;

            NewFrameName = System.IO.Path.ChangeExtension(NewFrameName, null);

            AddFrame NewFrame = new AddFrame
            {
                FrameName = NewFrameName,
                FrameImage = NewFrameImage
            };

            var response = await RestClient.AddNewCardFrame(NewFrame);

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                this.lblAddFrameInfo.ForeColor = Color.Red;
                this.lblAddFrameInfo.Text = "Card Frame already exists";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblAddFrameInfo.ForeColor = Color.White;
                this.lblAddFrameInfo.Text = "Frame added successfully";
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            //MainForm.RequestNewForm(PreviousForm);
            MainForm.RequestNewForm(new AdminHomeForm(CurrentUser));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new SignInForm());
        }

        private async void btnPostNews_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtBoxNewsTitle.Text))
            {
                this.lblNewsInfo.ForeColor = Color.Red;
                this.lblNewsInfo.Text = "Title is blank";
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtBoxNewsContent.Text))
            {
                this.lblNewsInfo.ForeColor = Color.Red;
                this.lblNewsInfo.Text = "Content is blank";
                return;
            }

            this.lblNewsInfo.ForeColor = Color.Blue;
            this.lblNewsInfo.Text = "Processing...";

            string CurrentContent = string.Join("\n", this.txtBoxNewsContent.Lines);

            News NewNewsPost = new News
            {
                Title = this.txtBoxNewsTitle.Text,
                Content = CurrentContent
            };

            var Response = await RestClient.CreateNewsPost(NewNewsPost);

            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblNewsInfo.ForeColor = Color.Blue;
                this.lblNewsInfo.Text = "News post created successfully";
            }
            else if (Response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                this.lblNewsInfo.ForeColor = Color.Red;
                this.lblNewsInfo.Text = "A news post with that title already exists";
            }
            else
            {
                this.lblNewsInfo.ForeColor = Color.Red;
                this.lblNewsInfo.Text = "An unexpected error has occured";
            }
        }

        private void AdminSecondPageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
