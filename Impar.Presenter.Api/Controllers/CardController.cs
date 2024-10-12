using Impar.Application.DTOs.Card;
using Impar.Application.Services;
using Impar.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static Impar.Domain.Contracts.Repositories.ICardRepository;

namespace Impar.Presenter.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ILogger<CardController> _logger;
    private readonly ICardService _cardService;

    public CardController(ILogger<CardController> logger, ICardService cardService)
    {
        _logger = logger;
        _cardService = cardService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCardDto dto, CancellationToken cancellationToken)
    {
        await _cardService.Create(dto, cancellationToken);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCardInputDto filter, CancellationToken cancellationToken)
    {
        return Ok(await _cardService.GetAll(filter, cancellationToken));
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditCardDto dto, CancellationToken cancellationToken)
    {
        await _cardService.Edit(dto, cancellationToken);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        await _cardService.Delete(id, cancellationToken);
        return NoContent();
    }
}
