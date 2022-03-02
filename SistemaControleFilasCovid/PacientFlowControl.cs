using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaControleFilasCovid
{
    public class PacientFlowControl
    {
        public EntryQueue EntryQueue { get; set; }
        public int EntryCount { get; set; }

        public PacientFlowControl()
        {

        }

        public void Entry()
        {
            EntryCount++;
            
        }

    }
}
