using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {

        public int id { get; set; }
        [DisplayName("Código")]
        public string codigo { get; set; }
        [DisplayName("Nombre")]

        public string nombre { get; set; }
        [DisplayName("Descripción")]

        public string descripcion { get; set; }
        [DisplayName("Url imagen")]

        public string imagenUrl { get; set; }
        [DisplayName("Precio")]

        public decimal precio {  get; set; }
        [DisplayName("Categoria")]

        public Categoria categoria { get; set; }
        [DisplayName("Marca")]

        public Marca marca { get; set; }
        



    }
}
