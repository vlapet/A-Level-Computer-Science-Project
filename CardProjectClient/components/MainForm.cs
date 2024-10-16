using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardProjectClient.game;

namespace CardProjectClient.components
{
    public partial class MainForm : Form
    {
        #region Enable console
        /// <summary>
        /// Enable console
        /// <para> Remove this later </para>
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]
        
        public static extern bool AllocConsole();
        #endregion

        //Game MainGame;
        public MainForm()
        {
            // Remove
#if DEBUG
            AllocConsole();
#endif

            // MainGame = new Game(); <- Don't need this anymore (changed 07/11/2022: 4:25pm)
            InitializeComponent();
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadForm(new SignInForm());
        }
        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Helper Functions

        /// <summary>
        /// Passes new form request to MainForm
        /// </summary>
        /// <param name="Form">The form which is to be opened</param>
        public static void RequestNewForm(object Form)
        {
            //if (Application.OpenForms.OfType<MainForm>().Count() == 1)                Application.OpenForms.OfType<MainForm>().First().Close();

            //MainForm frm = new MainForm();

            // Maybe add check to see if it is part of openforms
            MainForm frm = Application.OpenForms[0] as MainForm;

            frm.LoadForm(Form);
        }

        /// <summary>
        /// Loads a new form
        /// </summary>
        /// <param name="Form"></param>
        public void LoadForm(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        #endregion
    }
}
