using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frameQuest.ViewModels
{
    public class DomandaDto
    {
        public int IdDomanda { get; set; }
        public int IdTest { get; set; }
        public string Testo { get; set; }
        public int Punti { get; set; }

        // Opzioni di Risposta da 2 a 4
        public string Ris1_Testo { get; set; }
        public bool Ris1_Esatta { get; set; }

        public string Ris2_Testo { get; set; }
        public bool Ris2_Esatta { get; set; }

        public string Ris3_Testo { get; set; }
        public bool Ris3_Esatta { get; set; }

        public string Ris4_Testo { get; set; }
        public bool Ris4_Esatta { get; set; }

    }
}