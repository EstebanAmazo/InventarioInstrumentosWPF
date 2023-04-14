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
    /// Interaction logic for AgregarMarcaModal.xaml
    /// </summary>
    public partial class AgregarMarcaModal : Window
    {
        MarcaDAO marcaDAO = new MarcaDAO();
        public AgregarMarcaModal()
        {
            InitializeComponent();
        }

        private void GuardarMarcaBtn(object sender, RoutedEventArgs e)
        {
            Marca marca = new Marca()
            {
                NombreMarca = MarcaTextBox.Text,
            };
            marcaDAO.Insertar(marca);
            MessageBox.Show("Marca agregada");
            this.Close();


        }
    }
}
