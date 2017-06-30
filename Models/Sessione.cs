using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace frameQuest.Models
{
    public class Sessione
    {
        [Key]
        public int IdSessione { get; set; }
        public string Nominativo { get; set; }
        public int Punteggio { get; set; }

        public int IdTest { get; set; }
        public virtual Test Test { get; set; }

        //Elenco delle risposte fornite
        public virtual ICollection<SessioneRisposta> Risposte { get; set; }
    }

    public class SessioneRisposta
    {
        [Key]
        public int IdSessioneRisposta { get; set; }

        public int IdSessione { get; set; }

        public int IdDomanda { get; set; }
        public virtual Domanda Domanda { get; set; }

        public int IdRisposta { get; set; }
        public virtual Risposta Risposta { get; set; }
    }
}