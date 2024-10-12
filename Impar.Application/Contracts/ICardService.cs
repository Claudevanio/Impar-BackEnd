using Impar.Application.DTOs.Card;
using Impar.Domain.Entities;
using Impar.Domain.Pagination;
using static Impar.Domain.Contracts.Repositories.ICardRepository;

namespace Impar.Application.Services;
public interface ICardService
{
    Task<ResultPaginated<Card>> GetAll(GetAllCardInputDto filter, CancellationToken cancellationToken);
    public Task Create(CreateCardDto dto, CancellationToken cancellationToken);
    public Task Delete(Guid id, CancellationToken cancellationToken);
    public Task Edit(EditCardDto dto, CancellationToken cancellationToken);
}