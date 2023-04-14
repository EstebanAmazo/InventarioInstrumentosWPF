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

namespace InventarioInstrumentos.Vistas.Modal.Categorias
{
    /// <summary>
    /// Interaction logic for AgregarCategoriaModal.xaml
    /// </summary>
    public partial class AgregarCategoriaModal : Window
    {
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        public AgregarCategoriaModal()
        {
            InitializeComponent();
        }

        private void GuardarCategoriaBtn(object sender, RoutedEventArgs e)
        {
            Categoria categoria = new Categoria()
            {
                NombreCategoria = CategoriaTextBox.Text
            };

            categoriaDAO.Insertar(categoria);
            MessageBox.Show("Categoria agregada.");
            this.Close();

        }
    }
}
