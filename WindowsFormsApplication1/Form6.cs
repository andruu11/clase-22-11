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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            lbl_usuario.Text = Form1.id_user_sesion;
        }
        metodos.metodos_farmacia metodos_usuario = new metodos.metodos_farmacia();
        public static int cont_fila = 0;
        public static double total;
        
        private void button2_Click(object sender, EventArgs e)
        {
            //boton colocar
            //metodos.validarcamposvacios.ValidarCamposVacios(this, errorProvider1);
            bool existe = false;
            int num_fila = 0;
            if (cont_fila == 0)
            {
                dataGridView1.Rows.Add(txtCodigo.Text, txtProducto.Text, txtPrecio.Text, txtCantidad.Text);
                double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value);
                dataGridView1.Rows[cont_fila].Cells[4].Value = importe;
                cont_fila++;
            }
            else { 
            
            foreach(DataGridViewRow Fila in dataGridView1.Rows){
                if(Fila.Cells[0].Value.ToString() == txtCodigo.Text){
                    existe = true;
                    num_fila = Fila.Index;
                }
             }
            if (existe == true)
            {
                dataGridView1.Rows[num_fila].Cells[3].Value = (Convert.ToDouble(txtCantidad.Text) + Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value)).ToString();
                double importe = Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[3].Value);
                dataGridView1.Rows[num_fila].Cells[4].Value = importe;
                num_fila++;
            }
            else {
                dataGridView1.Rows.Add(txtCodigo.Text, txtProducto.Text, txtPrecio.Text, txtCantidad.Text);
                double importe = Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[cont_fila].Cells[3].Value);
                dataGridView1.Rows[cont_fila].Cells[4].Value = importe;
                cont_fila++;
            }
            }
            total = 0;
            foreach (DataGridViewRow Fila in dataGridView1.Rows)
            {
                total+=Convert.ToDouble(Fila.Cells[4].Value);
            }
            lbl_total.Text = "Bs. "+ total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string asd = metodos_usuario.DevolverDato(textBox6.Text.Trim());
            if (asd == "")
            {
                textBox7.Clear();
                textBox7.BackColor = Color.Red;
                MessageBox.Show("El cliente no esta registrado en la Base de Datos");
            }
            else {
                textBox7.Text = asd;
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 formulario7 = new Form7();
            formulario7.ShowDialog();
            if(formulario7.DialogResult == DialogResult.OK){
                txtCodigo.Text = formulario7.dataGridView1.Rows[formulario7.dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                txtProducto.Text = formulario7.dataGridView1.Rows[formulario7.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                txtPrecio.Text = formulario7.dataGridView1.Rows[formulario7.dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(cont_fila > 0){
                total = total - Convert.ToDouble(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
                lbl_total.Text = "Bs. " + total.ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                cont_fila--;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LimpiarCampos(this);
            total = 0;
            cont_fila = 0;
            dataGridView1.Rows.Clear();
            lbl_total.Text = "Bs. 0";
        }

        public void LimpiarCampos(Control control)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedIndex = 0;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //metodo para insertar en tabla venta('',total,ci_nit_cliente);
            foreach (DataGridViewRow Fila in dataGridView1.Rows)
            {
                //tendrian que recorrer cada elemento de la tabla con el foreach
                //metodo para obtener el ultimo registro en tabla venta
                //insertar a tabla venta producto ('',celda[0],id_venta_obtenido,celda[3],celda[4])
                //metodo para hacer un update o actualizar tabla producto y especificamente el campo stock WHERE id_producto = celda[0] y lo actualizado sea stock= stockactual - celda[3]
                                
                   
                
            }
            //este boton debera mandar a un reporte para que se imprima la factura 
        }
        
    }
}
