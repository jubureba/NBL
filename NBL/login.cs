using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;


namespace NBL
{
    public partial class login : Form
    {
        telaP principal = new telaP();
        
        public login()
        {
            InitializeComponent();
           


        }

        private void login_Load(object sender, EventArgs e)
        {

        }
        //EVENTO DO CLIQUE NO BOTÃO LOGIN
        private void button1_Click(object sender, EventArgs e)
        {
            //1 ABRIR COMUNICAÇÃO COM BANCO DE DADOS MYSQL
            try
            {
                string connection = "server=127.0.0.1; database=nbl_ppl;user=root; password=; ";
                MySqlConnection conn = new MySqlConnection(connection);
                conn.Open();

                MySqlDataReader dr; //data reader
                MySqlCommand cmd; //command

               // string sql = "SELECT * FROM users WHERE nome = '" + tb_user.Text + "' and senha = MD5('" + tb_password.Text + "')";
                string sql = "SELECT * FROM users WHERE nome = '" + tb_user.Text + "' and senha = '" + tb_password.Text + "'";
                cmd = new MySqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = conn;
                dr = cmd.ExecuteReader();
                if (dr.HasRows) //if data reader not null
                {
                    while (dr.Read())
                    {
                        if (dr["level"].ToString() == "1")
                        //IF level é 1, ele é admin
                        {
                            MessageBox.Show("Bem Vindo Administrador usando nivel de acessso 1", "Information");
                            this.Visible = false;
                            principal.ShowDialog();
                         
                        }
                        else if (dr["level"].ToString() == "2")
                        {
                            MessageBox.Show("Bem Vindo Usuário usando nivel de acesso 2", "Information");
                            this.Visible = false;
                            principal.ShowDialog();
                        }
                        else if (dr["level"].ToString() == "3")
                        {
                            MessageBox.Show("Bem Vindo MODO DE CONSULTA", "Information");
                            this.Visible = false;
                            principal.ShowDialog();
                        }
                        else
                        {
                            //messagem para não cadastrados
                            MessageBox.Show("Usuario Não cadastrado", "Warning");
                        }
                    }
                }
                else
                {
                    //mostrar mensagem de usuario ou senha incorretos
                    MessageBox.Show("Usuario e/ou Senha incorretos", "Warning");
                }
                conn.Close(); //fechar conexão
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //1------------------------------------------
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            registerUser registerUser = new registerUser();
            registerUser.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CONFIRMAÇÃO PARA FINALIZAR O SISTEMA
            if (MessageBox.Show("Deseja realmente fechar o sistema?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
  
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
 
            string nome = Interaction.InputBox("Digite seu usuário: ", "RECUPERAÇÃO DE SENHA");
            string connection = "server=127.0.0.1; database=nbl_ppl;user=root; password=; ";
            MySqlConnection conn = new MySqlConnection(connection);
            conn.Open();

            try
            {
                string sql = "SELECT * FROM users WHERE nome = '" +nome+ "';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    do
                    {
                        MessageBox.Show("***Recuperação de Senha***\n\nPorfavor, anote seus dados:\n\nUsuário:  " + dr["nome"].ToString() + "\nSenha:  " + dr["senha"].ToString(), "RECUPERAÇÃO DE SENHA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } while (dr.Read());
                }
                else
                {
                    MessageBox.Show("Nenhum Usuário encontrado com o Login digitado.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
         
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
