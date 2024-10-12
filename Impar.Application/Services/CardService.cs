
using Impar.Application.DTOs.Card;
using Impar.Domain.Contracts.Repositories;
using Impar.Domain.Entities;
using Impar.Domain.Pagination;
using static Impar.Domain.Contracts.Repositories.ICardRepository;

namespace Impar.Application.Services;
public sealed class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly IPhotoRepository _photoRepository;
    public CardService(ICardRepository cardRepository, IPhotoRepository photoRepository)
    {
        _cardRepository = cardRepository;
        _photoRepository = photoRepository;
    }

    public async Task Create(CreateCardDto dto, CancellationToken cancellationToken)
    {
        var newPhoto = Photo.Create(dto.Base64);

        await _photoRepository.Create(newPhoto, cancellationToken);

        var newCard = Card.Create(dto.Name, newPhoto);

        await _cardRepository.Create(newCard, cancellationToken);
    }

    public async Task<ResultPaginated<Card>> GetAll(GetAllCardInputDto filter, CancellationToken cancellationToken)
    {
        return await _cardRepository.GetAll(filter, cancellationToken);
    }

    public async Task Edit(EditCardDto dto, CancellationToken cancellationToken)
    {
        var storedCard = await _cardRepository.Get(dto.Id, cancellationToken);

        if (storedCard is null)
        {
            throw new Exception("Card com o ID fornecido não encontrado!");
        }

        if (!string.IsNullOrWhiteSpace(dto.Name))
            storedCard.UpdateName(dto.Name);

        if (!string.IsNullOrWhiteSpace(dto.Base64))
            storedCard.Photo.UpdateBase64(dto.Base64);

        await _cardRepository.Update(storedCard, cancellationToken);
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var storedCard = await _cardRepository.Get(id, cancellationToken);

        if (storedCard is null)
        {
            throw new Exception("Card com o ID fornecido não encontrado!");
        }

        storedCard.Inactive();

        await _cardRepository.Update(storedCard, cancellationToken);
    }
}
