namespace ContainerShipmentApp;

public class ShipManagementSystem
{
    public static void ManageShips(){
        
    bool running = true;

    Console.WriteLine("Welcome to the Ship Management System!");

    while (running)
    {
        Console.WriteLine("\nAvailable commands:");
        Console.WriteLine("Create Container - cc");
        Console.WriteLine("Load Container - lc");
        Console.WriteLine("Load Container onto Ship - ls");
        Console.WriteLine("Load List of Containers onto Ship - lls");
        Console.WriteLine("Remove Container from Ship - rc");
        Console.WriteLine("Unload Container - uc");
        Console.WriteLine("Exchange Container on Ship - ex");
        Console.WriteLine("Transfer Container between Ships - tb");
        Console.WriteLine("Print Container Info - ci");
        Console.WriteLine("Ship Info - si");
        Console.WriteLine("Quit -q");

        Console.Write("\nEnter your choice: ");
        string choice = Console.ReadLine()?.ToUpper();

        switch (choice)
            {
                case "cc":
                    
                    break;
                case "lc":
                
                    break;
                case "ls":
                
                    break;
                case "lls":
                
                    break;
                case "rc":
                
                    break;
                case "uc":
                
                    break;
                case "ex": 
                    
                    break;
                case "tb":
                
                    break;
                case "ci":
                
                    break;
                case "si":
                
                    break;
                case "q":
                running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
