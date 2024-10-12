namespace Impar.Domain.Entities;
public sealed class Photo
{
    public Guid Id { get; private set; }
    public string Base64 { get; private set; }
    public DateTime CreateAt { get; private set; }
    public DateTime UpdateAt { get; private set; }


#pragma warning disable CS8618 // Construtor utilizada apenas pelo EntityFramework
    private Photo()
#pragma warning restore CS8618
    {

    }

    public void UpdateBase64(string base64)
    {
        Base64 = base64;
        UpdateAt = DateTime.UtcNow;
    }

    public static Photo Create(string base64)
    {
        Photo photo = new Photo
        {
            Base64 = base64,
            Id = Guid.NewGuid(),
            CreateAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
        };

        return photo;
    }
};