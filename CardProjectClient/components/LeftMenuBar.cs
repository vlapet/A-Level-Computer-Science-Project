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


// REMOVE: Change dock property to left to make panel resize properly

namespace CardProjectClient.components
{
    public partial class LeftMenuBar : UserControl
    {
        private User _CurrentUser;

        public LeftMenuBar()
        {
            //this.CurrentUser = CurrentUser;
            InitializeComponent();
        }

        #region Private Accessors

        public User CurrentUser
        {
            get => _CurrentUser;
            set => _CurrentUser = value;
        }

        #endregion

        #region Functions

        private void btnLMenuBarLogOut_Click(object sender, EventArgs e)
        {
            // TODO: Add better prompt whether user wishes to log out
            /*
            DialogResult MBox = MessageBox.Show("Log Out?","Do you wish to log out", MessageBoxButtons.YesNo);
            if (MBox == DialogResult.No)
                return;
            */

            MainForm.RequestNewForm(new ConfirmLogout(GetParentForm()));
        }

        private void btnLMenuBarMyCollection_Click(object sender, EventArgs e)
        {
            if (GetParentForm().GetType() != typeof(MyCollectionForm))
                MainForm.RequestNewForm(new MyCollectionForm(this.CurrentUser));
        }

        private void btnLMenuBarMyDetails_Click(object sender, EventArgs e)
        {
            if (GetParentForm().GetType() != typeof(MyDetails))
                MainForm.RequestNewForm(new MyDetails(this.CurrentUser));
        }

        private void btnLMenuBarHome_Click(object sender, EventArgs e)
        {
            if (GetParentForm().GetType() != typeof(HomeForm))
                MainForm.RequestNewForm(new HomeForm(this.CurrentUser));
        }

        private void btnLMenuBarCardDrop_Click(object sender, EventArgs e)
        {
            if (GetParentForm().GetType() != typeof(CardDropForm))
                MainForm.RequestNewForm(new CardDropForm(this.CurrentUser));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (GetParentForm().GetType() != typeof(SearchForm))
                MainForm.RequestNewForm(new SearchForm(this.CurrentUser));
        }

        private void btnLMenuBarNews_Click(object sender, EventArgs e)
        {
            if (GetParentForm().GetType() != typeof(NewsForm))
                MainForm.RequestNewForm(new NewsForm(this.CurrentUser));
        }

        #endregion

        #region Helper Methods

        public Form GetParentForm()
        {
            Type type = this.Parent.GetType();
            Control ParentControl = this.Parent;

            while (type.BaseType.Name != "Form")
            {
                ParentControl = ParentControl.Parent;
                type = ParentControl.GetType();
            }

            return (Form)ParentControl;
        }





        #endregion


    }
}
