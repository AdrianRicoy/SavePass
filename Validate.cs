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

                if (result == DialogResult.OK) Application.Exit();
            }
        }
        /// <summary>
        /// Valida si la contraseña es correcta, para iniciar la aplicación
        /// </summary>
        /// <param name="pass">Contraseña a evaluar</param>
        /// <returns>Boolean</returns>
        private bool ValidatePass(string pass)
        {
            string password = string.Format("Pass: {0}{1}{2}{3}", 
                      DateTime.Now.Hour, DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            return pass == password ? true : false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
