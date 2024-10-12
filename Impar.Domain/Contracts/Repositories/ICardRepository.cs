

using Impar.Domain.Entities;
using Impar.Domain.Pagination;

namespace Impar.Domain.Contracts.Repositories;
public interface ICardRepository
{
    public sealed record GetAllCardInputDto(string? Name, int Page = 1, int Size = 10);
    public Task Create(Card card, CancellationToken cancellationToken);
    public Task<Card?> Get(Guid id, CancellationToken cancellationToken);
    Task<ResultPaginated<Card>> GetAll(GetAllCardInputDto filter, CancellationToken cancellationToken);
    public Task Update(Card card, CancellationToken cancellationToken);
}
