using InventarioInstrumentos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioInstrumentos.Dao
{
    public interface ITipoInstrumentoDAO
    {

        List<TipoInstrumento> ObtenerTodos();
        TipoInstrumento ObtenerPorId(int id);
        void Insertar(TipoInstrumento tipoInstrumento);
        void Actualizar(TipoInstrumento tipoInstrumento);
        void Eliminar(int Id);
    }
}
