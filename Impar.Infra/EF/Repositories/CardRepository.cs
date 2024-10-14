using Impar.Domain.Contracts.Repositories;
using Impar.Domain.Entities;
using Impar.Domain.Pagination;
using Microsoft.EntityFrameworkCore;
using static Impar.Domain.Contracts.Repositories.ICardRepository;
using static Impar.Domain.Entities.Card;

namespace Impar.Infra.EF.Repositories;
public class CardRepository : ICardRepository
{
    private readonly ApplicationDBContext _dbContext;
    public CardRepository(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Create(Card card, CancellationToken cancellationToken)
    {
        await _dbContext.Cards.AddAsync(card, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Card?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Cards.Include(x => x.Photo).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ResultPaginated<Card>> GetAll(GetAllCardInputDto filter, CancellationToken cancellationToken)
    {
        var cardsQuery = _dbContext.Cards.Include(x => x.Photo).AsNoTracking().Where(x => x.Status == CardStatus.Active);

        if (filter.Name is not null)
        {
            cardsQuery = cardsQuery.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
        }

        var skip = (filter.Page - 1) * filter.Size;

        var cards = await cardsQuery
            .Skip(skip)
            .Take(filter.Size)
            .ToListAsync(cancellationToken);

        var totalItems = await cardsQuery.CountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling((double)totalItems / filter.Size);

        return new ResultPaginated<Card>(filter.Page, filter.Size, totalItems, totalPages, cards);
    }

    public async Task Update(Card card, CancellationToken cancellationToken)
    {
        _dbContext.Cards.Update(card);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
