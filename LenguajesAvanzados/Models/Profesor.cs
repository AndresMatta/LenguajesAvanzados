using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LenguajesAvanzados.Models
{
    public class Profesor
    {
        public int ID { set; get; }
        public String Cedula { set; get; }
        public String Nombre { set; get; }
        public String Apellidos { set; get; }

        public virtual ICollection<Asignatura> Asignaturas { get; set; }
    }
}