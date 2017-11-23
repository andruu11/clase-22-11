using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        int pw;
        bool hide;
        int pwx;
        public Form4()
        {
            InitializeComponent();
            pw = panel2.Width;
            pwx = panel2.Width - 190;
            hide = false;
           // pictureBox2.Visible = false;
            MostrarComboEstante();
            
        }
        metodos.metodos_farmacia metodos_usuario = new metodos.metodos_farmacia();
        public void MostrarComboEstante()
        {
            //metodo para obtener los datos de ciudad en el combo
            metodos_usuario.consulta("SELECT * FROM `estante`", "estante");
            comboBox1.DataSource = metodos_usuario.ds.Tables["estante"];
            comboBox1.DisplayMember = "des_estante";
            comboBox1.ValueMember = "id_estante";
            
        }

        public void MostrarComboSecciones(int a)
        {
            
                //metodo para obtener los datos de ciudad en el combo
                metodos_usuario.consulta("SELECT * FROM `seccion` WHERE seccion.id_estante=" + a, "seccion");
                comboBox2.DataSource = metodos_usuario.ds.Tables["seccion"];

                comboBox2.DisplayMember = "des_seccion";
                comboBox2.ValueMember = "id_seccion";
                
          
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ////cada que cambia el combo1 uno se cambian los valores en combo2
            if (comboBox1.SelectedValue.ToString() != null || comboBox1.SelectedValue.ToString() != "")
            {

                int var = Convert.ToInt32(comboBox1.SelectedIndex.ToString());
                MostrarComboSecciones(var);
            }
        }



        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hide)
            {
                panel2.Width = panel2.Width + 10;

                if (panel2.Width == pw)
                {
                    // pictureBox1.Visible = true;
                    // pictureBox2.Visible = false;
                    bunifuImageButton4.Location = new Point(192, 16);
                    timer1.Stop();
                    hide = false;
                    this.Refresh();
                }
            }
            else
            {
                panel2.Width = panel2.Width - 10;
                //  pictureBox1.Visible = false;
                //  pictureBox2.Visible = true;
                bunifuImageButton4.Location = new Point(3, 16);

                if (panel2.Width == pwx)
                {

                    timer1.Stop();
                    hide = true;
                    this.Refresh();
                }
            }
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form5 ventas = new Form5();
            ventas.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form2 usuarios = new Form2();
            usuarios.Show();
            this.Hide();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Form3 clientes = new Form3();
            clientes.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form5 ventas = new Form5();
            ventas.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //boton cerrar
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            //boton minimizar
            WindowState = FormWindowState.Minimized;

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            //boton maximizar
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 2 && textBox2.Text.Length > 2)
            {
                textBox3.Text = textBox1.Text.Substring(0, 3) + textBox2.Text.Substring(0, 3);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

     

       
    }
}

