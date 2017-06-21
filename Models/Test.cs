using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace frameQuest.Models
{
    public class Test
    {
        [Key]
        public int IdTest { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        public string Descrizione { get; set; }

        [Required]
        [Display(Description = "Argomento")]
        public int IdArgomento { get; set; }
        public virtual Argomento Argomento { get; set; }

        [Required]
        [Display(Description = "Fase")]
        public int IdFase { get; set; }
        public virtual Fase Fase { get; set; }

        [Required]
        [Display(Description = "Docente")]
        public int IdDocente { get; set; }
        public virtual Docente Docente { get; set; }

    }
}