using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artigos
{
    public partial class Dashboard : Form
    {
            //1 - Autores
            //2 - Revisores
            //3 - Gerente
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            var frmLogin = new Login();
            frmLogin.ShowDialog();

            if (frmLogin.logado == false) {
                Close();
            }

            if (Login.perfilUsuario == 3)
            {
                btnCadastraArea.Enabled = true;
                btnRevisarArtigo.Enabled = true;
                btnCadastraUsuario.Enabled = true;
                btnListarRevisores.Enabled = true;
                btnCadastraRevisor.Enabled = true;
                btnRevisarArtigo.Enabled = true;
                btnEnviaArtigo.Enabled = true;
            }
        }



        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCadastraUsuario_Click(object sender, EventArgs e)
        {
            var cad = new Cadastrar();
            cad.ShowDialog();
        }

        private void btnCadastraRevisor_Click(object sender, EventArgs e)
        {
            var cad = new Cadastrar();
            cad.ShowDialog();
        }

        private void btnListarRevisores_Click(object sender, EventArgs e)
        {
            var cad = new ListarUsuario();
            cad.ShowDialog();
        }

        private void btnRevisarArtigo_Click(object sender, EventArgs e)
        {
            var cad = new RevisarArtigo();
            cad.ShowDialog();
        }

        private void btnEnviaArtigo_Click(object sender, EventArgs e)
        {
            var cad = new CadastrarArtigo();
            cad.ShowDialog();
        }

        private void btnCadastraArea_Click(object sender, EventArgs e)
        {
            var cad = new CadastrarArea();
            cad.ShowDialog();
        }
    }
}
