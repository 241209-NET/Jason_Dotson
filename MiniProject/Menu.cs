class Menu 
{   
     List<Athlete> athletes = new List<Athlete>();
    public Menu()
    {
       
    }

    public void displayMenu()
    {
            Console.WriteLine("Main Menu\n");
            Console.WriteLine("1. Show all athletes");
            Console.WriteLine("2. Select athlete (id)");
            Console.WriteLine("3. Create athlete");
            Console.WriteLine("4. Quit");
    }
    public void displayAthletes()
    {   
        Console.WriteLine($"Athletes ({Athlete.totalAthletes}):\n");
        foreach (var athlete in athletes)
        {
            Console.WriteLine($"{athlete.ToString()}\n");
        }
    }

    public void selectAthlete() 
    {
        try 
        {
            Console.Write("Enter the athlete's id: ");
            int selectedId = int.Parse(Console.ReadLine());
            Athlete selectedAthlete = athletes.Find(athlete => athlete.AthleteId == selectedId);
            if (selectedAthlete != null)
            {
                Console.WriteLine("Athlete Found:\n");
                Console.WriteLine(selectedAthlete.ToString());
                Console.WriteLine("1. Convert lbs to kg");
                Console.WriteLine("2. Convert height to total inches");
                try
                {
                    int selection = int.Parse(Console.ReadLine());
                    switch (selection)
                    {
                        case 1: 
                            convertWeight(selectedAthlete.Weight);
                            break;
                        case 2:
                            convertHeight(selectedAthlete.Feet, selectedAthlete.Inches);
                            break;
                        default:
                            Console.WriteLine("Please select a number from the menu.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input.");
        }
    }

    public void createAthlete()
    {
        Console.WriteLine("Enter athlete info below\n");

        Console.Write("First name: ");
        string? firstName = Console.ReadLine();

        Console.Write("Last name: ");
        string? lastName = Console.ReadLine();
    
        Console.Write("Sport: ");
        string? sport = Console.ReadLine();

        Console.Write("Weight(lbs): ");
        int weight = int.Parse(Console.ReadLine());

        Console.Write("Feet: ");
        int feet = int.Parse(Console.ReadLine());

        Console.Write("Inches: ");
        int inches = int.Parse(Console.ReadLine());

        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());

        athletes.Add(new Athlete(firstName, lastName, sport, weight, feet, inches, age));
    }
    // Convert weight from lbs to kg
    public void convertWeight(int athleteWeight)
    {
        Console.WriteLine($"{athleteWeight}lbs = {athleteWeight * 0.453592}kg");
    }
    
    // Convert height from Feet & inches to total inches
    public void convertHeight(int feet, int inches)
    {
        Console.WriteLine($"Height: {feet}'{inches}'' = {(feet * 12) + inches} inches");
    }

}