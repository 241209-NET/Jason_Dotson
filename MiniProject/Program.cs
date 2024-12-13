namespace MiniProject;

class Program
{
    static void Main(string[] args)
    {
        
        Menu menu = new Menu();
        
        while(true)
        {
            menu.displayMenu();
            try 
            {
                int selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        menu.displayAthletes();
                        break;
                    
                    case 2:
                        menu.selectAthlete();
                        break;

                    case 3: 
                        menu.createAthlete();
                        break;
                    
                    case 4:
                        Environment.Exit(0);
                        break;
                    
                    default:
                        Console.WriteLine("Please select a number from the menu.");
                        break;
                }
                
            } 
            catch (FormatException)
            {
                Console.WriteLine("\nInvalid input.\n");
            }

        }

        menu.createAthlete();
       
    }
}
