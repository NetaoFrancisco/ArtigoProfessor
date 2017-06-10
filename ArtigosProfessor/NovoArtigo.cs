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
    public partial class CadastrarArtigo : Form
    {
        public SqlConnection ConnectOpen { get; private set; }

        public CadastrarArtigo()
        {
            InitializeComponent();
        }

        private void CadastrarArtigo_Load(object sender, EventArgs e)
        {

        }


        private void ListarArtigos()
        {

            //var conn = Login.ConnectOpen;
            ////Buscar todos usuários cadastrados
            //string sql = "Select * from usuarios ";
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            //da.Fill(dt);

            //if (dt.Rows.Count > 0)
            //{
            //    dt1.DataSource = dt;
            //}

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*{
                if (btnCadastrar.Text == "Alterar")
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" update usuarios set ");
                    sql.Append(" senha = @senha, ");
                    sql.Append(" perfil = @perfil "); //Não esqueçam de dar um espaço no final 
                    sql.Append(" where usuario = @usuario");

                    SqlCommand command = null;
                    int perfilSeleted = 0;
                    switch (cmbPerfil.Text)
                    {
                        case "Autores":
                            perfilSeleted = 1;
                            break;
                        case "Revisores":
                            perfilSeleted = 2;
                            break;
                        case "Gerente":
                            perfilSeleted = 3;
                            break;
                        default:
                            perfilSeleted = 1;
                            break;
                    }

                    command = new SqlCommand(sql.ToString(), ConnectOpen);
                    command.Parameters.Add(new SqlParameter("@senha", txtSenha.Text));
                    command.Parameters.Add(new SqlParameter("@perfil", perfilSeleted));
                    command.Parameters.Add(new SqlParameter("@usuario", txtUsuario.Text));
                    command.ExecuteNonQuery();

                    MessageBox.Show("Alterado com sucesso!");
                    LimparTela();
                }
                else
                */
            //incluir o using System.Text
            StringBuilder sql = new StringBuilder();


            sql.Append("Insert into artigos(titulo, autor, nome, texto) ");
            sql.Append(" Values (@titulo, @autor, @nome, @texto)");
            SqlCommand command = null;

            /*int perfilSeleted = 0;
            switch (cmbPerfil.Text)
            {
                case "Autores":
                    perfilSeleted = 1;
                    break;
                case "Revisores":
                    perfilSeleted = 2;
                    break;
                case "Gerente":
                    perfilSeleted = 3;
                    break;
                default:
                    perfilSeleted = 1;
                    break;
            }
            */

            try
            {
                command = new SqlCommand(sql.ToString(), Login.ConnectOpen);
                command.Parameters.Add(new SqlParameter("@titulo", txtTitulo.Text));
                command.Parameters.Add(new SqlParameter("@autor", txtAutor.Text));
                command.Parameters.Add(new SqlParameter("@nome", txtNome.Text));
                command.Parameters.Add(new SqlParameter("@texto", txtTexto.Text));
                command.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com sucesso!");
                //Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar" + ex);
                throw;
            }
            // }//Fim else 

        }

        private void button7_Click(object sender, EventArgs e)
        {
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
            txtNome.Text = dt.Rows[0][0].ToString();

        }
    }
}     
    

