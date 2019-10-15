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
    public partial class Index : Form
    {
        private bool showTable = false;
        public Index()
        {
            InitializeComponent();
            GetDataUserPass();
        }

        /// <summary>
        /// Obtener los labels con la información del usuario, contraseña
        /// </summary>
        private void GetDataUserPass()
        {
            HandleUserPass data = new HandleUserPass();
            List<String> lstUserPasword = data.GetDataPassAndUser();

            foreach (String user in lstUserPasword)
            {
                ListViewItem list = new ListViewItem();
                list.SubItems.Add(user.Split(';')[0]);
                
                try
                {
                    list.SubItems.Add(user.Split(';')[1]);
                } catch(Exception e) { list.SubItems.Add("Nop"); }

                list.SubItems.Add("");
                lstData.Items.Add(list);
            } 
        }
        /// <summary>
        /// Agregar un nuevo registro al archivo de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            string user = txtUser.Text;

            HandleUserPass handleUser = new HandleUserPass();
            
            if(handleUser.AddUserPass(user, pass))
            {
                ListViewItem list = new ListViewItem();
                list.SubItems.Add(user);
                list.SubItems.Add(pass);
                list.SubItems.Add("");
                lstData.Items.Add(list);
            }
        }
        /// <summary>
        /// Button para cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Genera una constraseña aleatoria para el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRandom_Click(object sender, EventArgs e)
        {
            string result = "";
            Random random = new Random();

            int lim = random.Next(15, 20);

            for(int i = 0; i < lim; i++)
            {
                int n = random.Next(33, 160);
                result += (char)n;
            }

            txtPass.Text = result;
        }
        /// <summary>
        /// Minimizar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Eliminar un registro dentro del archivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;

            bool delete = new HandleUserPass().DeleteUserPass(user);

            string message = "The username and password have been successfully deleted.";
            string caption = "Right";
            

            if (!delete)
            {
                message = "Opp! The record could not be deleted.";
                caption = "Error";
            } 

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);

            Index index = new Index();
            index.Show();

            this.Close();
        }
        /// <summary>
        /// Actualizar un registro en el archivo de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string pass = txtPass.Text;

            bool update = new HandleUserPass().UpdateUserPass(user, pass);

            string message = "The username ( " + user + " ) and password have been updated";
            string caption = "Right";


            if (!update)
            {
                message = "Opp! The record could not be updated.";
                caption = "Error";
            }

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.None, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign);

            Index index = new Index();
            index.Show();

            this.Close();
        }
        /// <summary>
        /// Hacer más grande o pequeña la tabla de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            if(!showTable)
            {
                lstData.Location = new Point(283, 35);
                btnShowData.Location = new Point(283, 0);
                lstData.Height = 408;
                showTable = true;
            } else
            {
                lstData.Location = new Point(283, 258);
                btnShowData.Location = new Point(283, 216);
                lstData.Height = 192;
                showTable = false;
            }
        }
    }
}
