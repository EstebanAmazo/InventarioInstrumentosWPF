using InventarioInstrumentos.DaoImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventarioInstrumentos.Vistas.Modal
{
    /// <summary>
    /// Interaction logic for DeleteInstrumentConfirmationDialog.xaml
    /// </summary>
    public partial class DeleteInstrumentConfirmationDialog : Window
    {
        public int IdInstrumento { get; set; } 
        public DeleteInstrumentConfirmationDialog()
        {
            InitializeComponent();
        }

        public DeleteInstrumentConfirmationDialog(int idInstrumento)
        {
            this.IdInstrumento = idInstrumento;
            InitializeComponent();

        }

        private void Handle_Eliminar(object sender, RoutedEventArgs e)
        {
            InstrumentoDAO instrumentoDAO = new InstrumentoDAO();


            bool res = instrumentoDAO.Eliminar(IdInstrumento);
            if (res) 
            {
                MessageBox.Show("Instrumento eliminado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error al intentar eliminar el instrumento");
            }
       

        }


    }
}
