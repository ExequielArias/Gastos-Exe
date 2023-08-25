using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 

namespace Gastos_Exe
{
    public partial class frmGastos : Form
    {
        public frmGastos()
        {
            InitializeComponent();
        }

        private void frmGastos_Load(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("Ejemplos Conceptos.txt");
            string linea = "";
            while (SR.EndOfStream == false) 
            {
                linea = SR.ReadLine();
                cboConcepto.Items.Add(linea);
            }


             SR.Close();
            SR.Dispose();
            cboConcepto.SelectedIndex = 0; 
        }

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal importe = Convert.ToDecimal(txtImporte.Text);
                if (importe > 0 )
                {
                    StreamWriter SW = new StreamWriter("Gastos.txt", true);
                    SW.Write(dtpFecha.Text);
                    SW.Write(", ");
                    SW.Write(cboConcepto.Text);
                    SW.Write(", ");
                    SW.WriteLine(txtImporte.Text);
                    SW.Close();
                    SW.Dispose();
                    cboConcepto.SelectedIndex = 0;
                    txtImporte.Text = "";
                }
                else
                {
                    MessageBox.Show("INGRESE UN VALOR AYOR A CERO", "¡ERROR!");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("VERIFIQUE LOS DATOS INGRESADOS", "¡AVISO!"); 
            }


           
        }
    }
}
