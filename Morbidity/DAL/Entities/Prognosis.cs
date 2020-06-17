using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Prognosis
    {
        public int PrognosisID { get; set; }
        public DateTime Date { get; set; }
        public int DiseaseID { get; set; }
        public char Expected { get; set; }
    }
}
