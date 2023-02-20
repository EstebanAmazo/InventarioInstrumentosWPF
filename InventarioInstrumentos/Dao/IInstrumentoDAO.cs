using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioInstrumentos.Dao
{
    public interface IInstrumentoDAO
    {
        List<Instrumento> ObtenerTodos();
        Instrumento ObtenerPorId(int id);
        void Insertar(Instrumento instrumento);
        void Actualizar(Instrumento instrumento);
        void Eliminar(int Id);
    }
}
