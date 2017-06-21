using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace frameQuest.Models
{
    public class Classe
    {
        [Key]
        public int IdClasse { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Materia { get; set; }

        [Required]
        public int IdDocente { get; set; }
        public virtual Docente Docente { get; set; }

        public virtual ICollection<Alunno> Alunni { get; set; }
    }
}