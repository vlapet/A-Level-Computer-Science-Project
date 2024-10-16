using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardProjectClient.client;
using CardProjectClient.game;

namespace CardProjectClient.components
{
    public partial class ConfirmCollectionDeletion : Form
    {
        User CurrentUser;
        Collection CurrentCollection;
        object PreviousForm;

        public ConfirmCollectionDeletion(User CurrentUser, Collection CurrentCollection, object PreviousForm)
        {
            this.CurrentUser = CurrentUser;
            this.CurrentCollection = CurrentCollection;
            this.PreviousForm = PreviousForm;

            InitializeComponent();
        }

        private void btnConfirmCollectionDeletionYes_Click(object sender, EventArgs e)
        {
            var Response = RestClient.DeleteCollection(CurrentCollection);

            MainForm.RequestNewForm(new MyCollectionForm(CurrentUser));
        }

        private void btnConfirmCollectionDeletionNo_Click(object sender, EventArgs e)
        {
            MainForm.RequestNewForm(PreviousForm);
        }
    }
}
