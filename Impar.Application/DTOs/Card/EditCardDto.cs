namespace Impar.Application.DTOs.Card;

public sealed record EditCardDto(Guid Id, string? Name, string? Base64);
