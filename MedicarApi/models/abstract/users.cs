using Types;

public abstract class User
{
    public readonly string Id;
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public IdentityDocument Document { get; set; }
    public string ProfilePhotoUrl { get; set; }
    public readonly DateTime CreatedAt;
    public DateTime UpdatedAt { get; set; }
}

public abstract class IdentityDocument
{
    public string Code { get; set; }
    public IDocumentType Type { get; set; }
    public string PhotoUrl { get; set; }
}
