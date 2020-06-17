using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IDiseaseService
    {
        IEnumerable<DiseaseDTO> GetDiseases(int page);
    }
}