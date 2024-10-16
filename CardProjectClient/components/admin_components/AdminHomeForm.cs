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
using CardProjectClient.client;
using CardProjectClient.game;
using CardProjectClient.lib;

namespace CardProjectClient.components.admin_components
{
    public partial class AdminHomeForm : Form
    {
        User CurrentUser;

        public AdminHomeForm(User currentUser)
        {
            this.CurrentUser = currentUser;
            InitializeComponent();

            this.lblAddCardInfo.Text = String.Empty;
            this.lblAddRarityInfo.Text = String.Empty;
        }

        private async void btnChooseCardImage_Click(object sender, EventArgs e)
        {
            if (ofdFilePicker.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /*
                    var NewStream = new StreamReader(ofdFilePicker.FileName);
                    this.txtBoxImagePath.Text = await NewStream.ReadToEndAsync();
                    */

                    this.txtBoxImagePath.Text = ofdFilePicker.FileName;
                    this.txtBoxImagePath.Select(this.txtBoxImagePath.Text.Length, 0);
                }
                catch (SecurityException ex)
                {

                }
            }
        }

        private async void btnAddNewCard_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtBoxCardName.Text))
            {
                this.lblAddCardInfo.ForeColor = Color.Red;
                this.lblAddCardInfo.Text = "Please enter a card name";
                return;
            }
            if (String.IsNullOrWhiteSpace(this.txtBoxImagePath.Text))
            {
                this.lblAddCardInfo.ForeColor = Color.Red;
                this.lblAddCardInfo.Text = "Please select an image";
                return;
            }
            if (cmbBoxRarities == null || cmbBoxRarities.SelectedItem == null)
            {
                this.lblAddCardInfo.ForeColor = Color.Red;
                this.lblAddCardInfo.Text = "Please select a rarity";
                return;
            }

            this.lblAddCardInfo.ForeColor = Color.Blue;
            this.lblAddCardInfo.Text = "Processing...";

            byte[] ThisCardImage = await APIMethods.GetImageBinary(this.txtBoxImagePath.Text);
            string ThisCardName = this.txtBoxCardName.Text;
            string ThisCardRarity = cmbBoxRarities.SelectedItem.ToString();

            int end = 0;

            ThisCardName = System.IO.Path.ChangeExtension(ThisCardName, null);

            AddCard NewCard = new AddCard
            {
                CardName = ThisCardName,
                CardImage = ThisCardImage,
                CardRarity = ThisCardRarity
            };

            var response = await RestClient.AddNewCard(NewCard);

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                this.lblAddCardInfo.ForeColor = Color.Red;
                this.lblAddCardInfo.Text = "Card Name already exists";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblAddCardInfo.ForeColor = Color.White;
                this.lblAddCardInfo.Text = "Card added successfully";
            }
        }

        private async void btnAddNewRarity_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.txtBoxRarity.Text))
            {
                this.lblAddRarityInfo.ForeColor = Color.Red;
                this.lblAddRarityInfo.Text = "Please enter a rarity";
                return;
            }

            this.lblAddRarityInfo.ForeColor = Color.Blue;
            this.lblAddRarityInfo.Text = "Processing...";

            var response = await RestClient.AddNewRarity(this.txtBoxRarity.Text);

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                this.lblAddRarityInfo.ForeColor = Color.Red;
                this.lblAddRarityInfo.Text = "Rarity already exists";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                this.lblAddRarityInfo.ForeColor = Color.White;
                this.lblAddRarityInfo.Text = "Rarity added successfully";
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new SignInForm());
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(new AdminSecondPageForm(CurrentUser, this));
        }

        private async void AdminHomeForm_Load(object sender, EventArgs e)
        {
            await GetRarities();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await GetRarities();
        }

        #region Helper methods

        public async Task GetRarities()
        {
            if (this.cmbBoxRarities.Items.Count > 0)
                this.cmbBoxRarities.Items.Clear();

            HttpResponseMessage Response;

            try
            {
                Response = await RestClient.GetAllRarities();
            }
            catch
            {
                this.lblAddCardInfo.ForeColor = Color.Red;
                this.lblAddCardInfo.Text = "An unexpected error has occurred";
                return;
            }
            List<string> CardRarities;

            if (Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                this.lblAddCardInfo.ForeColor = Color.Red;
                this.lblAddCardInfo.Text = "No rarities found";
                return;
            }

            CardRarities = await JsonParseMethods.ParseToObjectFromWebResponse<List<string>>(Response);

            this.cmbBoxRarities.Items.AddRange(CardRarities.ToArray());
            this.lblAddCardInfo.Text = String.Empty;
        }

        #endregion
    }
}
