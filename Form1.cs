﻿using System;
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
    }
}
