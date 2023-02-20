using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioInstrumentos.Dao
{
    public interface ICategoriaDAO
    {

        List<Categoria> ObtenerTodos();
        Categoria ObtenerPorId(int id);
        void Insertar(Categoria categoria);
        void Actualizar(Categoria categoria);
        void Eliminar(int Id);
    }
}
