using Core3Layers.Core.Entities;
using Core3Layers.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Layers.Infrastructure.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
