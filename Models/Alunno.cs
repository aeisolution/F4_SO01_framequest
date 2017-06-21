using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace frameQuest.Models
{
    public class Alunno
    {
        [Key]
        public int IdAlunno { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string Cognome { get; set; }

        [StringLength(16)]
        public string CodiceFiscale { get; set; }

        public string Indirizzo{ get; set; }
        public string Comune { get; set; }
        [StringLength(2)]
        public string Provincia { get; set; }
        [StringLength(5)]
        public string Cap { get; set; }

        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }

        public DateTime DataInserimento { get; set; }
    }
}