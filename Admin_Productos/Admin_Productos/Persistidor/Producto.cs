using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Productos.Persistidor
{
    public class Producto
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }   
        public double Precio { get; set; }
        public int Stock { get; set; }
    }
}
