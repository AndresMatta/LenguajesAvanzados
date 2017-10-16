using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LenguajesAvanzados.Models
{
    public class Calificacion
    {
        public int ID { set; get; }
        public int EstudianteId { set; get; }
        public int AsignaturaId { set; get; }
        [ForeignKey("EstudianteId")]
        public virtual Estudiante Estudiante { get; set; }
        [ForeignKey("AsignaturaId")]
        public virtual Asignatura Asignatura { get; set; }
        public int PrimerTrimestre { set; get; }
        public int SegundoTrimestre { set; get; }
        public int TercerTrimestre { set; get; }
        public int NotalFinal
        {
            get
            {
                return (PrimerTrimestre + SegundoTrimestre + TercerTrimestre) / 3;
            }
        }
    }
}