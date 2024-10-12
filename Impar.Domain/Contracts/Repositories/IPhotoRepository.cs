

using Impar.Domain.Entities;

namespace Impar.Domain.Contracts.Repositories;
public interface IPhotoRepository
{
    public Task Create(Photo photo, CancellationToken cancellationToken);
}
