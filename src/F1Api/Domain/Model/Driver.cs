namespace F1Api;

public class Driver
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }
    // need to fix date parsing before uncommenting
    // public DateOnly DateOfBirth { get; set; }
    public string PlaceOfBirth { get; set; }
    public string Team { get; set; }
    public int NumberOfPodiums { get; set; }
    public int FirstSeason { get; set; }
    public string Note { get; set; }
}
