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

namespace NBL
{
    public partial class registerUser : Form
    {
        public registerUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            NBL.login login = new NBL.login();
            login.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                string connection = "server=127.0.0.1; database=nbl_ppl;user=root; password=; ";
                MySqlConnection conn = new MySqlConnection(connection);
                MySqlCommand cmd;
                conn.Open();
                try
                {
                    string nome = tb_user.Text;
                    string sql = "SELECT * FROM users WHERE nome ='" + nome + "' OR cpf = '"+ tb_cpf.Text + "'";
                    MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                    MySqlDataReader dr = cmd1.ExecuteReader();
                    if(dr.Read())
                    {
                        MessageBox.Show("Usuário já cadastrado!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }else if(tb_nome.Text == string.Empty || tb_user.Text == string.Empty || tb_password.Text == string.Empty || tb_cpf.Text == string.Empty)
                    {
                        MessageBox.Show("Por favor, preencha todos os campos obrigatórios antes de cadastrar.", "ATENÇÃO", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }else
                    {
                        conn.Close();
                        conn.Open();
                        cmd = conn.CreateCommand();
                        cmd.CommandText = "INSERT INTO users(nome, senha, usuario, cpf, level)VALUES(@nome, @senha, @usuario, @cpf, @level)";
                        cmd.Parameters.AddWithValue("@nome", tb_nome.Text);
                        cmd.Parameters.AddWithValue("@usuario", tb_user.Text);
                        cmd.Parameters.AddWithValue("@senha", tb_password.Text);
                        cmd.Parameters.AddWithValue("@cpf", tb_cpf.Text);
                        cmd.Parameters.AddWithValue("@level", cb_permissao.SelectedIndex + 1);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Usuario " + tb_nome.Text + ", Cadastrado com Sucesso! Faça Login e use o sistema.");
                        tb_user.Text = "";
                        tb_password.Text = "";
                        cb_permissao.SelectedText = "";
                        
                        this.Visible = false;
                        NBL.login login = new NBL.login();
                        login.ShowDialog();

                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tb_rg_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }
    }
}
