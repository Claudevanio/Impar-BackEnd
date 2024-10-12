using System.Net.NetworkInformation;

namespace Impar.Domain.Entities;
public sealed class Card
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public CardStatus Status { get; private set; }
    public Guid PhotoId { get; private set; }
    public Photo Photo { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime UpdateAt { get; private set; }

#pragma warning disable CS8618 // Construtor utilizada apenas pelo EntityFramework
    private Card() { }
#pragma warning restore CS8618

    public static Card Create(string name, Photo photo)
    {
        Card card = new()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Status = CardStatus.Active,
            PhotoId = photo.Id,
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
        };

        return card;
    }

    public void UpdateName(string name)
    {
        Name = name;
        UpdateAt = DateTime.UtcNow;
    }
    public void Inactive()
    {
        Status = CardStatus.Inactive;
        UpdateAt = DateTime.UtcNow;
    }

    public enum CardStatus
    {
        Active = 1,
        Inactive = 2,
    }
};
