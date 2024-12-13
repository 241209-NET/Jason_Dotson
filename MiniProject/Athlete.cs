class Athlete
{
    private string firstName;
    private string lastName;
    private string sport;
    private int weight;
    private int feet;
    private int inches;
    private int age;
    private int athleteId;
    public static int id = 1;
    public static int totalAthletes = 0;

     // Create getters and setters
     public int AthleteId
     {
        get { return athleteId; }
     }

     public string FirstName 
     {
        get { return firstName; }
        set { firstName = value; }
     }

     public string LastName 
     {
        get { return lastName; }
        set { lastName = value; }
     }

     public string Sport 
     {
        get { return sport; }
        set { sport = value; }
     }

    public int Weight 
     {
        get { return weight; }
        set { weight = value; }
     }
    public int Feet 
     {
        get { return feet; }
        set { feet = value; }
     }

    public int Inches 
     {
        get { return inches; }
        set { inches = value; }
     }

    public int Age 
     {
        get { return age; }
        set { age = value; }
     }


    public Athlete(string firstName, string lastName, string sport,
                   int weight, int feet, int inches, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.sport = sport;
        this.weight = weight;
        this.feet = feet;
        this.inches = inches;
        this.age = age;
        this.athleteId = id;
        id++;
        totalAthletes++;
        Console.WriteLine("\nAthlete created.\n");
        Console.WriteLine(this.ToString());
    }

    // Override toString method to display athlete info
    public override string ToString() 
    {
        return $"Athlete ID: {athleteId}\nFirst name: {firstName}\nLast name: {lastName}\nSport: {sport}\nWeight: {weight}lbs\nFeet: {feet}\nInches: {inches}\nAge: {age}\n";
    }
}