using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();

            foreach(Paquete actual in this.correo.Paquetes)
            {
                switch (actual.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(actual);
                        break;

                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(actual);
                        break;

                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(actual);
                        break;
                }
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete p = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                p.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
                this.correo += p;
                this.ActualizarEstados();
            }
            catch(TrackingIdRepetidoException f)
            {
                MessageBox.Show(f.Message);
            }

        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!(object.Equals(elemento,null)))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento) + "\n";
                GuardaString.Guardar(this.rtbMostrar.Text, "salida.txt");
            }
        }
     
        private void mostrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
