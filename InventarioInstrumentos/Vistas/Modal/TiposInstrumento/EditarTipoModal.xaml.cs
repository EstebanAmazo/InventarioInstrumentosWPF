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
    /// Interaction logic for EditarTipoModal.xaml
    /// </summary>
    public partial class EditarTipoModal : Window
    {

        private int idTipo;
        TipoInstrumentoDAO tipoInstrumentoDAO = new TipoInstrumentoDAO();
        public EditarTipoModal(int idTipo)
        {
            InitializeComponent();
            this.idTipo = idTipo;   
            TipoTextBox.Text = tipoInstrumentoDAO.ObtenerPorId(idTipo).NombreInstrumento;
        }

        private void GuardarTipoBtn(object sender, RoutedEventArgs e)
        {
            TipoInstrumento tipoInstrumento = new TipoInstrumento()
            {
                NombreInstrumento = TipoTextBox.Text,
            };

            tipoInstrumentoDAO.Actualizar(idTipo, tipoInstrumento);
            MessageBox.Show("Tipo de instrumento actualizado");
            this.Close();
        }
    }
}
