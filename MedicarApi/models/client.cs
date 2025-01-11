using Types;

public class Client : User
{
    public IPreference Preference { get; set; }
    public int TotalAmount { get; set; }
}
