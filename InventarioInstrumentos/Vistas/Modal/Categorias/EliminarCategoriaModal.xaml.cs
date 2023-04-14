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

namespace InventarioInstrumentos.Vistas.Modal.Categorias
{
    /// <summary>
    /// Interaction logic for EliminarCategoriaModal.xaml
    /// </summary>
    public partial class EliminarCategoriaModal : Window
    {
        private int idCategoria;

        public EliminarCategoriaModal(int id)
        {
            InitializeComponent();
            this.idCategoria = id;
        }

        private void HandleEliminar(object sender, RoutedEventArgs e)
        {
            CategoriaDAO categoriaDAO = new CategoriaDAO();
            categoriaDAO.Eliminar(idCategoria);
            this.Close();
        }
    }
}
