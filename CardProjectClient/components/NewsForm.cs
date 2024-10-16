using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardProjectClient.client;
using CardProjectClient.game;

namespace CardProjectClient.components
{
    public partial class NewsForm : Form
    {
        User CurrentUser;
        News CurrentNews;
        int Page;
        bool FromSearchForm;
        bool CanScrollRight;

        public NewsForm(User CurrentUser)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            this.leftMenuBar1.CurrentUser = CurrentUser;
            this.Page = 0;
            this.FromSearchForm = false;

        }

        public NewsForm(User CurrentUser, int Page, News CurrentNews)
        {
            InitializeComponent();
            this.CurrentUser = CurrentUser;
            this.leftMenuBar1.CurrentUser = CurrentUser;
            this.Page = Page;
            this.FromSearchForm = true;
        }

        private async void NewsForm_Load(object sender, EventArgs e)
        {
            this.lblInfo.Text = String.Empty;
            this.CanScrollRight = true;

            ShowNews();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (this.CanScrollRight == false)
                return;

            Page++;
            ShowNews();
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            this.CanScrollRight = true;

            if (Page <= 0)
            {
                Page = 0;
                return;
            }

            Page--;
            ShowNews();
        }

        #region Helper Functions

        private async void ShowNews()
        {
            HttpResponseMessage Response;

            try
            {
                Response = await RestClient.GetNews(Page);
            }
            catch
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "An unexpected error has occurred";
                return;
            }
            Console.WriteLine(Response.StatusCode.ToString());

            if (Response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                System.Text.Json.JsonSerializerOptions JOptions = new();
                JOptions.WriteIndented = true;
                string TempString = System.Text.Json.JsonSerializer.Deserialize<string>(await Response.Content.ReadAsStringAsync(), JOptions);
                Console.WriteLine(TempString);
                TempString = TempString.Replace(@"\n", @"\\n");
                this.CurrentNews = System.Text.Json.JsonSerializer.Deserialize<News>(TempString, JOptions);
                this.CurrentNews.Content = this.CurrentNews.Content.Replace(@"\n", Environment.NewLine);

                this.txtBoxTitle.Text = this.CurrentNews.Title;
                this.txtBoxContent.Text = this.CurrentNews.Content;
            }
            else if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "No news found";
                this.CanScrollRight = false;
                this.Page--;
            }
            else
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = $"An unexpected error has occured";
            }


        }

        #endregion


    }
}
