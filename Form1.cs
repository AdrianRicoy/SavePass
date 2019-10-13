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
        public Index()
        {
            if(Validate())
            {
                InitializeComponent();
            }
        }

        /// <summary>
        /// Obtener los labels con la información del usuario, contraseña
        /// </summary>
        private void GetLabelsUserPass()
        {
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string pass = txtPass.Text;
            string user = txtUser.Text;
        }
    }
}
