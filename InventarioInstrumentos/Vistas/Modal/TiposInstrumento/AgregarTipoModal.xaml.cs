using InventarioInstrumentos.DaoImpl;
using InventarioInstrumentos.Modelos;
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

namespace InventarioInstrumentos.Vistas.Modal.TiposInstrumento
{
    /// <summary>
    /// Interaction logic for AgregarTipoModal.xaml
    /// </summary>
    public partial class AgregarTipoModal : Window
    {

        TipoInstrumentoDAO tipoInstrumentoDAO = new TipoInstrumentoDAO();
        public AgregarTipoModal()
        {
            InitializeComponent();
        }

        private void GuardarTipoBtn(object sender, RoutedEventArgs e)
        {
            TipoInstrumento tipoInstrumento = new TipoInstrumento()
            {
                NombreInstrumento = TipoTextBox.Text,

            };

            tipoInstrumentoDAO.Insertar(tipoInstrumento);
            MessageBox.Show("Tipo de instrumento agregado");
            this.Close();

        }
    }
}
