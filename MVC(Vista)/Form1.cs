using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTROLADOR.Paises;
namespace MVC_Vista_
{
    public partial class Form1 : Form
    {
        PaisesDTO paisesDTO = null;
        PaisesDAO paisesDAO = null;
        DataTable Dtt = null;
        public Form1()
        {
            InitializeComponent();
            ListarPaises();
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
        }


        public void ListarPaises()
        {

            paisesDTO = new PaisesDTO();
            paisesDAO = new PaisesDAO(paisesDTO);

            Dtt = new DataTable();
            Dtt = paisesDAO.ListarPaises();

            if (Dtt.Rows.Count > 0)
            {
                dtpaises.DataSource = Dtt;
            }
            else
            {
                MessageBox.Show("No hay registros de paises");
            }
        }


        public void Guardar()
        {
            paisesDTO = new PaisesDTO();
            paisesDTO.setNombrepais(txtnombrepais.Text);
            paisesDAO = new PaisesDAO(paisesDTO);

            paisesDAO.GuardarPais();
            MessageBox.Show("Registro Guardado");




        }

        private void btnguardar_Click(object sender, EventArgs e)
        {


            if (txtnombrepais.Text.Trim() == "") {
                MessageBox.Show("Oye Hacker, intenta un dato valido ");
                txtnombrepais.Focus();

            }
            else {

                Guardar();
                ListarPaises();
                txtnombrepais.Clear();
            }

           
        }

        private void dtpaises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Visible = true;
            label4.Visible = true;
            txtcodigo.Text = dtpaises.Rows[dtpaises.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombrepais.Text = dtpaises.Rows[dtpaises.CurrentRow.Index].Cells[1].Value.ToString();

            btnguardar.Enabled = false;
            btnguardarcambios.Enabled = true;
            btncancelar.Enabled = true;
            btneliminar.Enabled = true;


        }


        public void GuardarCambios()
        {
            paisesDTO = new PaisesDTO();
            paisesDTO.setIdpais(Convert.ToInt16(txtcodigo.Text));
            paisesDTO.setNombrepais(txtnombrepais.Text);
            paisesDAO = new PaisesDAO(paisesDTO);

            paisesDAO.GuardarCambios();
            MessageBox.Show("Registros Cambiados");
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            

            if (txtnombrepais.Text.Trim() == "")
            {
                MessageBox.Show("Oye Hacker, intenta un dato valido ");
                txtnombrepais.Focus();

            }
            else
            {

                GuardarCambios();
                ListarPaises();
                label4.Visible = false;
                txtcodigo.Visible = false;
                btnguardar.Enabled = true;
                btnguardarcambios.Enabled = false;
                txtnombrepais.Clear();
                txtnombrepais.Focus();
                btnguardarcambios.Enabled = false;
                btneliminar.Enabled = false;
                btncancelar.Enabled = false;
            }
        }


        public void EliminarRegistroPais()
        {
            paisesDTO = new PaisesDTO();
            paisesDTO.setIdpais(Convert.ToInt16(txtcodigo.Text));
            paisesDAO = new PaisesDAO(paisesDTO);

            paisesDAO.EliminarPais();
            MessageBox.Show("Registro Eliminado");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistroPais();
            ListarPaises();

            label4.Visible = false;
            txtcodigo.Visible = false;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            txtnombrepais.Clear();
            txtnombrepais.Focus();
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            ListarPaises();

            label4.Visible = false;
            txtcodigo.Visible = false;
            btnguardar.Enabled = true;
            btnguardarcambios.Enabled = false;
            txtnombrepais.Clear();
            txtnombrepais.Focus();
            btnguardarcambios.Enabled = false;
            btneliminar.Enabled = false;
            btncancelar.Enabled = false;
        }
    }
}   
