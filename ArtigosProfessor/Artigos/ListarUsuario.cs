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
    public partial class ListarUsuario : Form
    {
        public bool logado = false;
        private Conexao conn;
        private SqlConnection ConnectOpen;
        public string UsuarioSelecionado = "";

        public ListarUsuario()
        {
            InitializeComponent();
        }

        private void LimparTela()
        {
            btnDeletar.Visible = false;
            txtID.Text = "";
            txtUsuario.Text = "";
            // dt1.Rows.Clear();
        }
        private void ListarUsuario_Load(object sender, EventArgs e)
        {
            var conn = Login.ConnectOpen;
            //Buscar todos usuários cadastrados
            string sql = "Select * from usuarios ";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);           
            
            if(dt.Rows.Count > 0)
            {
                dt1.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //Recuperar a linha selecionadas.
             UsuarioSelecionado = dt1.Rows[e.RowIndex].Cells[0].Value.ToString();

            //Fechar a tela
            Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var conn = Login.ConnectOpen;

            //Confirmar exclusão
            DialogResult result = MessageBox.Show("Deseja REALMENTE excluir?", "Delete",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            //Caso o usuário dê ok, a exclusão prossegue
            if (!result.Equals(DialogResult.OK))
                return; //caso cancele, o código abaixo não será excutado.

            //Buscar usuário selecionado
            string sql = "Delete from usuarios where Usuario = @usuario";

            SqlCommand command = null;
            command = new SqlCommand(sql.ToString(), ConnectOpen);
            command.Parameters.Add(new SqlParameter("@usuario", txtUsuario.Text));
            command.ExecuteNonQuery();
            LimparTela();
            MessageBox.Show("Excluído com sucesso!");
        }
    }
}
