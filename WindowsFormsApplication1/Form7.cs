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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            MostrarDatos();
           
        }
        metodos.metodos_farmacia metodos_producto = new metodos.metodos_farmacia();

       

        public void MostrarDatos()
        {
            //metodo para mostrar datos
            metodos_producto.consulta("SELECT * FROM `producto` INNER JOIN laboratorio ON producto.id_laboratorio = laboratorio.id_laboratorio INNER JOIN presentacion ON producto.id_presentacion = presentacion.id_presentacion INNER JOIN unidad ON producto.id_unidad = unidad.id_unidad INNER JOIN seccion ON producto.id_seccion = seccion.id_seccion INNER JOIN estante ON seccion.id_estante = estante.id_estante", "producto");
            dataGridView1.DataSource = metodos_producto.ds.Tables["producto"];
            dataGridView1.Columns["id_laboratorio"].Visible = false;
            dataGridView1.Columns["id_laboratorio1"].Visible = false;
            dataGridView1.Columns["id_presentacion"].Visible = false;
            dataGridView1.Columns["id_presentacion1"].Visible = false;
            dataGridView1.Columns["id_unidad"].Visible = false;
            dataGridView1.Columns["id_unidad1"].Visible = false;
            dataGridView1.Columns["id_seccion"].Visible = false;
            dataGridView1.Columns["id_seccion1"].Visible = false;
            dataGridView1.Columns["id_estante"].Visible = false;
            dataGridView1.Columns["id_estante1"].Visible = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //boton para filtrar productos
            metodos_producto.Buscar("(SELECT * FROM `producto` INNER JOIN laboratorio ON producto.id_laboratorio = laboratorio.id_laboratorio INNER JOIN presentacion ON producto.id_presentacion = presentacion.id_presentacion INNER JOIN unidad ON producto.id_unidad = unidad.id_unidad INNER JOIN seccion ON producto.id_seccion = seccion.id_seccion INNER JOIN estante ON seccion.id_estante = estante.id_estante WHERE nombre_producto LIKE '%" + textBox1.Text + "%')", "producto");
            dataGridView1.DataSource = metodos_producto.ds.Tables["producto"];
            dataGridView1.Columns["id_laboratorio"].Visible = false;
            dataGridView1.Columns["id_laboratorio1"].Visible = false;
            dataGridView1.Columns["id_presentacion"].Visible = false;
            dataGridView1.Columns["id_presentacion1"].Visible = false;
            dataGridView1.Columns["id_unidad"].Visible = false;
            dataGridView1.Columns["id_unidad1"].Visible = false;
            dataGridView1.Columns["id_seccion"].Visible = false;
            dataGridView1.Columns["id_seccion1"].Visible = false;
            dataGridView1.Columns["id_estante"].Visible = false;
            dataGridView1.Columns["id_estante1"].Visible = false;
     
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0){
                return;
            }else{
                DialogResult = DialogResult.OK;
                Close();
            }

        }
    }
}
