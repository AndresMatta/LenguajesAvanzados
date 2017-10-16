using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LenguajesAvanzados.Models
{
    public class Universidad
    {
        public int ID { set; get; }
        public String Nombre { set; get; }

        public virtual ICollection<Carrera> Carreras { get; set; }
    }
}