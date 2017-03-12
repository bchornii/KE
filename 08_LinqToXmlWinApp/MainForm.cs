using System;
using System.Windows.Forms;

namespace _08_LinqToXmlWinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAddNewItem_Click(object sender, EventArgs e)
        {
            // Add item to doc
            LinqToXmlObjectModel.InsertNewElement(txtMake.Text, txtColor.Text, txtPetName.Text);

            // Disp current XML inventory 
            txtInventory.Text = LinqToXmlObjectModel.GetXmlInventory().ToString();
        }

        private void btnLookUpColors_Click(object sender, EventArgs e)
        {
            LinqToXmlObjectModel.LookUpColorsForMake(txtMakeToLookUp.Text);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtInventory.Text = LinqToXmlObjectModel.GetXmlInventory().ToString();
        }
    }
}
