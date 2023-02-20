using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioInstrumentos.Dao
{
    public interface IMarcaDAO
    {

        List<Marca> ObtenerTodos();
        Marca ObtenerPorId(int id);
        void Insertar(Marca marca);
        void Actualizar(Marca marca);
        void Eliminar(int Id);
    }
}
