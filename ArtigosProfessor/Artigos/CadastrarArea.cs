using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Artigos
{
    public partial class CadastrarArea : Form
    {
        private Conexao conn;
        private SqlConnection ConnectOpen;
        public string UsuarioSelecionado = "";

        //public SqlConnection ConnectOpen { get; private set; }

        public CadastrarArea()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void CadastrarArea_Load(object sender, EventArgs e)
        {
            ListarAreas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //adicionar o listar usuário 
            //adicionar o valor selecionar no controle txtRevisor

            var listarUsu = new ListarUsuario();
            listarUsu.ShowDialog();

            //Verificar se foi selecionado algum item
            if (listarUsu.UsuarioSelecionado == "")
                return;

            var conn = Login.ConnectOpen;
            //Buscar usuário selecionado
            string sql = "Select * from usuarios where Usuario = '" + listarUsu.UsuarioSelecionado + "'";


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);

            //Linha 0, coluna 0
            txtRevisor.Text = dt.Rows[0][0].ToString();

            //Linha 0, coluna 1
            //txtSenha.Text = dt.Rows[0][1].ToString();

            /*string PerfilSelecionado;

            switch (dt.Rows[0][2].ToString())
            {
                case "1":
                    PerfilSelecionado = "Autores";
                    break;
                case "2":
                    PerfilSelecionado = "Revisores";
                    break;
                case "3":
                    PerfilSelecionado = "Gerente";
                    break;
                default:
                    PerfilSelecionado = "Autores";
                    break;
            }

            cmbPerfil.Text = PerfilSelecionado;

            //Trocar o text do cadastrar para alterar
            btnCadastrar.Text = "Alterar";*/
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //incluir o using System.Text
            StringBuilder sql = new StringBuilder();
            sql.Append("Insert into area(nome, Usuario) ");
            sql.Append("Values (@nome, @Usuario)");
            SqlCommand command = null;
           
            try
            {
                command = new SqlCommand(sql.ToString(), Login.ConnectOpen);
                command.Parameters.Add(new SqlParameter("@nome", txtArea.Text));
                command.Parameters.Add(new SqlParameter("@Usuario", txtRevisor.Text));
                command.ExecuteNonQuery();
                ListarAreas();
                MessageBox.Show("Cadastrado com sucesso!");
               // Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar" + ex);
                throw;
            }


        }



        private void ListarAreas() {

            var conn = Login.ConnectOpen;
            //Buscar todos usuários cadastrados
            string sql = "Select * from area ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                dgvAreas.DataSource = dt;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAreas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvAreas_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvAreas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex < 0)
                    return;

                //Recuperar a linha selecionadas.
                UsuarioSelecionado = dgvAreas.Rows[e.RowIndex].Cells[1].Value.ToString();


                var conn = Login.ConnectOpen;
                //Buscar usuário selecionado
                string sql = "Select * from usuarios where Usuario = '" + UsuarioSelecionado  + "'";


                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);

                //Linha 0, coluna 0
                txtArea.Text = dt.Rows[0][0].ToString();

                //Linha 0, coluna 1
                txtRevisor.Text = dt.Rows[0][1].ToString();



                //criar a lógica do alterar;


            }
        }
    }
}
