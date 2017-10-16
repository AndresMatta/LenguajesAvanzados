using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LenguajesAvanzados.Models
{
    public class Asignatura
    {
        public int ID { set; get; }
        public int CarreraId { set; get; }
        public int ProfesorId { set; get; }
        [ForeignKey("CarreraId")]
        public virtual Carrera Carrera { get; set; }
        [ForeignKey("ProfesorId")]
        public virtual Profesor Profesor { get; set; }
        public String Nombre { set; get; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }

        public Asignatura()
        {
            this.Estudiantes = new HashSet<Estudiante>();
        }
    }
}