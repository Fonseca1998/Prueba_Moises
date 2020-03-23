using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConexSql();
        }
        public static SqlCommand ComandoSq;

        public void ConexSql()
        {
            ComandoSq = new SqlCommand(@"Select * From Clientes", Conexion.conexion);
            Conexion.conexion.Open();
            DataTable tabla = new DataTable();
            SqlDataAdapter usar = new SqlDataAdapter(ComandoSq);
            usar.Fill(tabla);
            dataGridView1.DataSource = tabla;
            Conexion.conexion.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar el dato?","Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (respuesta == DialogResult.Yes)
                    {
                        Conexion.conexion.Open();
                        ComandoSq.ExecuteNonQuery();
                        ComandoSq.CommandText = "Delete From Productos Where id_cliente = " + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "; ";
                        ComandoSq.Connection = Conexion.conexion;
                        Conexion.conexion.Close();
                        MessageBox.Show("El Cliente fue Eliminado Exitosamente");
                        ConexSql();
                    }
                    else if (respuesta == DialogResult.No) ConexSql();
                }
                catch (Exception oo)
                {
                    Conexion.conexion.Close();
                    MessageBox.Show(oo.ToString());
                }
            }
            else MessageBox.Show("Favor de seleeccionar un dato de la tabla");
        }
    }
}
