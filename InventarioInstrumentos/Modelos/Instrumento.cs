using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioInstrumentos.Modelos
{
    public class Instrumento
    {

        public int Id { get; set; }
        public string Serial { get; set; }
        public string Modelo { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public Estado Estado { get; set; }
        public Gama Gama { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }
        public TipoInstrumento TipoInstrumento { get; set; }

    }
}
