using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_Martin
{
    public partial class Form1 : Form
    {


        List<Clientes> Fila = new List<Clientes>();
        List<Clientes> Filtro = new List<Clientes>();
        public Form1()
        {
            InitializeComponent();
        }

        Point DragCursor;
        Point DragForm;
        bool Dragging;

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }
        //mover form1

        private void Limpar()
        {
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void Atualizar(List<Clientes> Lista)
        {
            richTextBox1.Clear();
            foreach (Clientes Dados in Lista)
            {
                richTextBox1.AppendText($"ID:{Fila.IndexOf(Dados)}\nNome:{Dados.Nome}\nSabor de:{Dados.Sabor}\nCobertura de:{Dados.Cobertura}\n\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text) || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("preencha os campos");
                return;
            }

            Fila.Add(new Clientes(textBox1.Text, comboBox1.Text, comboBox2.Text));
            Atualizar(Fila);
            Limpar();
        }//adicionar rich

        private void button2_Click(object sender, EventArgs e)
        {
            if (Fila.Count == 0)
            {
                MessageBox.Show("vazio");
                return;
            }

            else if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MessageBox.Show("Adicione um ID");
                return;
            }

            else if (int.Parse(maskedTextBox1.Text) > Fila.Count - 1)
            {
                MessageBox.Show("Cliente inexistente");
                return;
            }


            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            textBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            panel1.Visible = true;

            int index = int.Parse(maskedTextBox1.Text);

            textBox2.Text = Fila[index].Nome;
            comboBox3.Text = Fila[index].Sabor;
            comboBox4.Text = Fila[index].Cobertura;

        }//pesquisar o ID abrir a edição com os dados do ID

        private void button5_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            panel1.Visible = false;
        }//fechar edição

        private void button6_Click(object sender, EventArgs e)
        {
            Filtro = Fila.Where(x => x.Nome == textBox3.Text).ToList();
            Atualizar(Filtro);
        }//fazer a pesquisa pelo nome

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                int index = int.Parse(maskedTextBox1.Text);
                Fila[index].Editar(textBox2.Text, comboBox3.Text, comboBox4.Text);

                Atualizar(Fila);
            }
            catch (Exception O)
            {
                MessageBox.Show("não é possivel editar", "item inválido");
            }
        }//editar de acordo com o ID

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int index = int.Parse(maskedTextBox1.Text);
                Fila.RemoveAt(index);

                Atualizar(Fila);
            }
            catch (Exception H)
            {
                MessageBox.Show("não é possivel excluir", "Item inválido");
            }
        }//excluir itens_ try catch(erro se estiver vazio)

        private void Sair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ao sair todos os dados serão perdidos\nDeseja continuar?", "SAIR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            {
                this.Close();
            }
        }//botão de sair junto com mensagem de confirmação

        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }//botão de minimizar

        private void button8_Click(object sender, EventArgs e)
        {
            Atualizar(Fila);
        }//limpar o resultado de pesquisa
    }
}
