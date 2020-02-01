using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core3LayersAPI.Core.Models;

namespace Core3LayersAPI.Core.Interfaces
{
    public interface IContratosAprovacoesPendentesRepository
    {
        Task<IEnumerable<ConsultarContratosAprovacoesPendentesViewModel>> GetByUserName(string userName);
    }
}
