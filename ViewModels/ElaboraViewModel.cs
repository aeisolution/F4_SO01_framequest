using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frameQuest.ViewModels
{
    public class ElaboraViewModel
    {
        public string chiave { get; set; }
        public string valore { get; set; }

        public int IdDomanda { get; set; }
        public int IdRisposta { get; set; } 
    }
}