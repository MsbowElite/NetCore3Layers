using Core3Layers.Core.Entities;
using Core3Layers.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core3Layers.Infrastructure.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
