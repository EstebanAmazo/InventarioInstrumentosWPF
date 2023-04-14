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

namespace InventarioInstrumentos.Vistas.Modal.TiposInstrumento
{
    /// <summary>
    /// Interaction logic for EliminarTipoModal.xaml
    /// </summary>
    public partial class EliminarTipoModal : Window
    {
        private int idTipo;
        TipoInstrumentoDAO tipoInstrumentoDAO = new TipoInstrumentoDAO();
        public EliminarTipoModal(int idTipo)
        {
            InitializeComponent();
            this.idTipo = idTipo;   
        }

        private void HandleEliminar(object sender, RoutedEventArgs e)
        {
            tipoInstrumentoDAO.Eliminar(idTipo);
            MessageBox.Show("Tipo de instrumento eliminado");
            this.Close();
        }
    }
}
