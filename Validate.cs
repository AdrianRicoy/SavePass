using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavePass
{
    public partial class Validate : Form
    {
        public Validate()
        {
            InitializeComponent();
        }

        public void BtnAccept_Click(object sender, EventArgs e)
        {
            if (ValidatePass(txtPass.Text))
            {
                Index index = new Index();
                index.Show();

                this.Hide();
            }
            else
            {
                // Initializes the variables to pass to the MessageBox.Show method.

                string message = "Incorrect password";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.OK) this.Close();
            }
        }

        private bool ValidatePass(string pass)
        {
            return pass == "123" ? true : false;
        }
    }
}
