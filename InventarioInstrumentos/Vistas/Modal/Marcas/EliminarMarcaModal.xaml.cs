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

namespace InventarioInstrumentos.Vistas.Modal.Marcas
{
    /// <summary>
    /// Interaction logic for EliminarMarcaModal.xaml
    /// </summary>
    public partial class EliminarMarcaModal : Window
    {
        private int idMarca;
        MarcaDAO marcaDAO = new MarcaDAO(); 
        public EliminarMarcaModal(int idMarca)
        {
            InitializeComponent();
            this.idMarca = idMarca;
        }

        private void HandleEliminar(object sender, RoutedEventArgs e)
        {
            marcaDAO.Eliminar(idMarca);
            MessageBox.Show("Marca eliminada");
            this.Close();
        }
    }
}
