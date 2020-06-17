using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class PrognosisDTO
        {
        public int PrognosisID { get; set; }
        public DateTime Date { get; set; }
        public int DiseaseID { get; set; }
        public char ExpectedResult { get; set; }
        }
}