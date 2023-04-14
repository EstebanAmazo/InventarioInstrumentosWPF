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

namespace InventarioInstrumentos.Vistas.Modal.Marcas
{
    /// <summary>
    /// Interaction logic for EditarMarcaModal.xaml
    /// </summary>
    public partial class EditarMarcaModal : Window
    {
        private int idMarca;
        MarcaDAO marcaDAO = new MarcaDAO();
        public EditarMarcaModal(int idMarca)
        {
            InitializeComponent();
            this.idMarca = idMarca;

            MarcaTextBox.Text = marcaDAO.ObtenerPorId(idMarca).NombreMarca;
        }

        private void GuardarMarcaBtn(object sender, RoutedEventArgs e)
        {
            Marca marca = new Marca()
            {
                NombreMarca = MarcaTextBox.Text,
            };

            marcaDAO.Actualizar(idMarca, marca);
            MessageBox.Show("Marca actualizada");
            this.Close();
        }
    }
}
