using Impar.Domain.Contracts.Repositories;
using Impar.Domain.Entities;

namespace Impar.Infra.EF.Repositories;
public class PhotoRepository : IPhotoRepository
{
    private readonly ApplicationDBContext _dbContext;
    public PhotoRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Create(Photo photo, CancellationToken cancellationToken)
    {
        await _dbContext.Photos.AddAsync(photo, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
