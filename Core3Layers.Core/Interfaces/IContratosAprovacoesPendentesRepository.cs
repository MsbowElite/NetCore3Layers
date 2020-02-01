using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core3Layers.Core.Models;

namespace Core3Layers.Core.Interfaces
{
    public interface IContratosAprovacoesPendentesRepository
    {
        Task<IEnumerable<ConsultarContratosAprovacoesPendentesViewModel>> GetByUserName(string userName);
    }
}
