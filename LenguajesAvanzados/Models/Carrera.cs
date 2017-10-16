using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LenguajesAvanzados.Models
{
    public class Carrera
    {
        public int ID { set; get; }
        public int UniversidadId { set; get; }
        [ForeignKey("UniversidadId")]
        public virtual Universidad Universidad { get; set; }
        public String Nombre { set; get; }

        public virtual ICollection<Asignatura> Asignaturas { get; set; }
    }
}