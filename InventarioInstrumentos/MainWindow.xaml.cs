using InventarioInstrumentos.DaoImpl;
using InventarioInstrumentos.Modelos;
using InventarioInstrumentos.Vistas.Modal;
using InventarioInstrumentos.Vistas.Modal.Categorias;
using InventarioInstrumentos.Vistas.Modal.Marcas;
using InventarioInstrumentos.Vistas.Modal.TiposInstrumento;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace InventarioInstrumentos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InstrumentoDAO instrumentoDAO = new InstrumentoDAO();
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        MarcaDAO marcaDAO = new MarcaDAO();
        TipoInstrumentoDAO tipoInstrumentoDAO = new TipoInstrumentoDAO();

        public MainWindow()
        {
            InitializeComponent();
            /**
             * 
             
            instrumentosDataGrid.ItemsSource = instrumentos;
            Console.WriteLine(instrumentoDAO.ObtenerNombreCategoria(3));
            Instrumento instrumento1 = new Instrumento()
            {
                Serial = "HSC234",
                Modelo = "FDC-432",
                Stock = 54,
                Precio = 500300,
                Estado = Estado.USADO,
                Gama = Gama.INTERMEDIO,
                FechaIngreso = new DateTime(2020, 8, 3),
                Categoria = new Categoria()
                {
                    Id = 3,
                },
                Marca = new Marca()
                {
                    Id = 1,
                },
                TipoInstrumento = new TipoInstrumento() { Id = 1, }

            };

            instrumentoDAO.Insertar(instrumento1);
             
             */

            this.ActualizarListado();
            this.ActualizarListadoCategorias();
            this.ActualizarListadoTipos();
            this.ActualizarListadoMarcas();
        }

        public void ActualizarListado()
        {
            instrumentosDataGrid.ItemsSource = instrumentoDAO.ObtenerTodos();
        }

        public void ActualizarListadoCategorias()
        {
            CategoriasDataGrid.ItemsSource = categoriaDAO.ObtenerTodos();
        }

        public void ActualizarListadoMarcas()
        {
            MarcasDataGrid.ItemsSource = marcaDAO.ObtenerTodos();
        }

        public void ActualizarListadoTipos()
        {
            TiposDataGrid.ItemsSource = tipoInstrumentoDAO.ObtenerTodos();
        }

        private void Button_Editar(object sender, RoutedEventArgs e)
        {

        }

        private void AgregarInstrumentoBtn(object sender, RoutedEventArgs e)
        {
            Window agregarInstrumento = new AgregarInstrumentoModal();
            agregarInstrumento.ShowDialog();
            ActualizarListado();
        }


        private void EditarInstrumentoBtn(object sender, RoutedEventArgs e)
        {
            // Obtener el botón que disparó el evento
            Button btnEliminar = sender as Button;
            DataGridRow fila = FindAncestor<DataGridRow>(btnEliminar);
            // Obtener el valor de la celda "id"
            int id = ((Instrumento)fila.Item).Id;
            Window editarInstrumentoModal = new EditarInstrumentoModal(id);
            editarInstrumentoModal.ShowDialog();
            ActualizarListado();

        }
        private void EliminarInstrumentoBtn(object sender, RoutedEventArgs e)
        {
            // Obtener el botón que disparó el evento
            Button btnEliminar = sender as Button;
            DataGridRow fila = FindAncestor<DataGridRow>(btnEliminar);
            // Obtener el valor de la celda "id"
            int id = ((Instrumento)fila.Item).Id;
            DeleteInstrumentConfirmationDialog deleteConfirmation = new DeleteInstrumentConfirmationDialog(id);
            deleteConfirmation.ShowDialog();
            ActualizarListado();

        }

        private void AgregarCategoriaBtn(object sender, RoutedEventArgs e)
        {
            Window agregarCategoriaModal = new AgregarCategoriaModal();
            agregarCategoriaModal.ShowDialog();
            ActualizarListadoCategorias();
        }


        private void EliminarCategoriaBtn(object sender, RoutedEventArgs e)
        {
            {
                // Obtener el botón que disparó el evento
                Button btnEliminar = sender as Button;
                DataGridRow fila = FindAncestor<DataGridRow>(btnEliminar);
                // Obtener el valor de la celda "id"
                int id = ((Categoria)fila.Item).Id;
                EliminarCategoriaModal eliminarCategoriaModal = new EliminarCategoriaModal(id);
                eliminarCategoriaModal.ShowDialog();
                ActualizarListadoCategorias();
                ActualizarListado();
            }
        }

        private void EditarCategoriaBtn(object sender, RoutedEventArgs e)
        {
            Button btnEditar = sender as Button;
            DataGridRow fila = FindAncestor<DataGridRow>(btnEditar);
            // Obtener el valor de la celda "id"
            int id = ((Categoria)fila.Item).Id;
            EditarCategoriaModal editarCategoriaModal = new EditarCategoriaModal(id);
            editarCategoriaModal.ShowDialog();
            ActualizarListadoCategorias();
            ActualizarListado();
        }



        private void AgregarMarcaBtn(object sender, RoutedEventArgs e)
        {
            AgregarMarcaModal agregarMarcaModal = new AgregarMarcaModal();
            agregarMarcaModal.ShowDialog();
            ActualizarListadoMarcas();
            ActualizarListado();
        }

        private void EditarMarcaBtn(object sender, RoutedEventArgs e)
        {
            Button btnEditar = sender as Button;
            DataGridRow fila = FindAncestor<DataGridRow>(btnEditar);
            // Obtener el valor de la celda "id"
            int id = ((Marca)fila.Item).Id;
            EditarMarcaModal editarMarcaModal = new EditarMarcaModal(id);
            editarMarcaModal.ShowDialog();
            ActualizarListadoMarcas();
            ActualizarListado();
        }

        private void EliminarMarcaBtn(object sender, RoutedEventArgs e)
        {
            Button btnEliminar = sender as Button;
            DataGridRow fila = FindAncestor<DataGridRow>(btnEliminar);
            // Obtener el valor de la celda "id"
            int id = ((Marca)fila.Item).Id;
            EliminarMarcaModal eliminarMarcaModal = new EliminarMarcaModal(id);
            eliminarMarcaModal.ShowDialog();
            ActualizarListadoMarcas();
            ActualizarListado();
        }



        private void AgregarTipoBtn(object sender, RoutedEventArgs e)
        {
            AgregarTipoModal agregarTipoModal = new AgregarTipoModal();
            agregarTipoModal.ShowDialog();
            ActualizarListadoTipos();
            ActualizarListado();

        }

        private void EditarTipoBtn(object sender, RoutedEventArgs e)
        {
            Button btnEditar = sender as Button;
            DataGridRow fila = FindAncestor<DataGridRow>(btnEditar);
            // Obtener el valor de la celda "id"
            int id = ((TipoInstrumento)fila.Item).Id;
            EditarTipoModal editarTipoModal = new EditarTipoModal(id);
            editarTipoModal.ShowDialog();
            ActualizarListadoTipos();
            ActualizarListado();
        }


        private void EliminarTipoBtn(object sender, RoutedEventArgs e)
        {
            Button btnEliminar = sender as Button;
            DataGridRow fila = FindAncestor<DataGridRow>(btnEliminar);
            // Obtener el valor de la celda "id"
            int id = ((TipoInstrumento)fila.Item).Id;
            EliminarTipoModal eliminarTipoModal = new EliminarTipoModal(id);
            eliminarTipoModal.ShowDialog();
            ActualizarListadoTipos();
            ActualizarListado();
        }

        private static T FindAncestor<T>(DependencyObject current)
        where T : DependencyObject
        {
            do
            {
                if (current is T parent)
                {
                    return parent;
                }
                current = VisualTreeHelper.GetParent(current);
            } while (current != null);
            return null;
        }

    }
}
