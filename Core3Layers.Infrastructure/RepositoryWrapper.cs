using Core3LayersAPI.Core.Interfaces;

namespace Core3LayersAPI.Infrastructure
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
    }
}
