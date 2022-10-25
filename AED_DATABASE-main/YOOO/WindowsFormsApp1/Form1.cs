using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Crud Estudiante = new Crud();


        private void btnInsertar_Click(object sender, EventArgs e)
        {
            Boolean Band = Estudiante.Insertar("Estudiante", int.Parse(txtCarnet.Text), 
                txtNombres.Text, txtApellidos.Text, DateTime.Parse(txtFechaNac.Text), 
                int.Parse(txtNota.Text));

            if (Band == true)
                MessageBox.Show("Estudiante Insertado");
            else
                MessageBox.Show("Error al Insertar");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Boolean Band = Estudiante.Eliminar("Estudiante", int.Parse(txtCarnet.Text));

            if (Band == true)
                MessageBox.Show("Estudiante Eliminado");
            else
                MessageBox.Show("Estudiante no se encuentra");
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Boolean Band = Estudiante.Modificar("Estudiante", int.Parse(txtCarnet.Text),
                txtNombres.Text, txtApellidos.Text, DateTime.Parse(txtFechaNac.Text),
                int.Parse(txtNota.Text));

            if (Band == true)
                MessageBox.Show("Estudiante Modificado");
            else
                MessageBox.Show("Estudiante no Actualizado");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            dgImprimir.DataSource = Estudiante.Consultar("Estudiante");
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt;
            dt = Estudiante.Consultar("Estudiante", int.Parse(txtCarnet.Text));

            if (dt.Rows.Count > 0)
            {
                dgImprimir.DataSource = dt;
                txtNombres.Text = Convert.ToString(dt.Rows[0][1]);
                txtApellidos.Text = Convert.ToString(dt.Rows[0][2]);
                txtNota.Text = Convert.ToString(dt.Rows[0][4]);
                txtFechaNac.Text = Convert.ToString(dt.Rows[0][3]);
            }
            else
            {
                MessageBox.Show("No esta el estudiante");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
