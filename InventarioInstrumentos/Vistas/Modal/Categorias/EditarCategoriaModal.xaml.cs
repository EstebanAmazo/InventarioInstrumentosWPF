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
    /// Interaction logic for EditarCategoriaModal.xaml
    /// </summary>
    public partial class EditarCategoriaModal : Window
    {

        CategoriaDAO categoriaDAO = new CategoriaDAO();

        private int idCategoria;
        public EditarCategoriaModal(int id)
        {
            InitializeComponent();

            CategoriaTextBox.Text = categoriaDAO.ObtenerPorId(id).NombreCategoria;
            this.idCategoria = id;
        }


        private void GuardarCategoriaBtn(object sender, RoutedEventArgs e)
        {
            Categoria categoria = new Categoria()
            {
                NombreCategoria = CategoriaTextBox.Text
            };

            categoriaDAO.Actualizar(idCategoria, categoria);
            MessageBox.Show("Categoria actualizada.");
            this.Close();

        }
    }
}
