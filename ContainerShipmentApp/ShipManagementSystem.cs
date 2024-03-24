using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ContainerShipmentApp;

public class ShipManagementSystem
{
    public static List<Container> Containers = new List<Container>();

    public List<Ship> Ships = new List<Ship>();
    public void ManageShips(){
        
        bool running = true;

        

        Console.WriteLine("Welcome to the Ship Management System!"); 
        while (running)
            {
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("Create Container - cc");
            Console.WriteLine("Load Container - lc");
            Console.WriteLine("Create Ship - cs");
            Console.WriteLine("Load Container onto Ship - ls"); 
            Console.WriteLine("Load List of Containers onto Ship - lls");
            Console.WriteLine("Remove Container from Ship - rc");
            Console.WriteLine("Unload Container - uc");
            Console.WriteLine("Exchange Container on Ship - ex");
            Console.WriteLine("Transfer Container between Ships - tb");
            Console.WriteLine("Print Container Info - ci");
            Console.WriteLine("Ship Info - si");
            Console.WriteLine("Quit - q");

            Console.Write("\n ==> ");
            string choice = Console.ReadLine()?.ToLower();

            switch (choice)
            {
                case "cc":
                    cc();
                    break;
                
                case "lc":
                    

                    break;
                case "ls":
                
                    break;
                case "cs":
                
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

    public static void cc()
    {
        Console.WriteLine("Select container type: [L]iquid, [G]as, [R]efrigerated");
        string containerType = Console.ReadLine().ToUpper();
        Console.WriteLine("Enter container height:");
        int height = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter container weight:");
        double weight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter container depth:");
        int depth = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter container max load capacity:");
        double maxLoadCapacity = Convert.ToDouble(Console.ReadLine());
        string serialNumber = $"KON-{new Random().Next(1000, 9999)}"; 
        
        Container newContainer = null;
        switch (containerType)
        {
            case "L":
                newContainer = new LiquidContainer(height, weight, depth, serialNumber, maxLoadCapacity, false);
                break;
            case "G":
                Console.WriteLine("Enter container pressure:");
                double pressure = Convert.ToDouble(Console.ReadLine());
                newContainer = new GasContainer(height, weight, depth, serialNumber, maxLoadCapacity, pressure);
                break;
            case "R":
                Console.WriteLine("Enter required temperature:");
                double requiredTemperature = Convert.ToDouble(Console.ReadLine());
                newContainer = new RefrigeratedContainer(height, weight, depth, serialNumber, maxLoadCapacity, requiredTemperature);
                break;
            default:
                Console.WriteLine("Invalid container type.");
                break;
        }
        if(newContainer != null)
        {
            Console.WriteLine("Container created successfully.");
            Containers.Add(newContainer);
            
        }
    }

    public static void lc()
    {
        DisplayContainers();
        
        if (Containers.Any())
        {
            Console.WriteLine("Enter container serial number:");
            string serial = Console.ReadLine();
            Container containerToLoad = Containers.FirstOrDefault(c => c.SerialNumber == serial);
            if (containerToLoad != null)
            {
                if (containerToLoad is RefrigeratedContainer refrigeratedContainerToLoad)
                {
                    Console.WriteLine("Enter load mass:");
                    double mass = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter type of cargo that you want to load:");
                    string type = Convert.ToString(Console.ReadLine());
                    refrigeratedContainerToLoad.LoadContainer(mass, type);
                    Console.WriteLine("Container loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Enter load mass:");
                    double mass = Convert.ToDouble(Console.ReadLine());
                    containerToLoad.LoadContainer(mass);
                    Console.WriteLine("Container loaded successfully.");
                }
            }
            else
            {
                Console.WriteLine("Container not found.");
            }
        }
        
        
        
    }


    public static bool DisplayContainers()
    {
        if (Containers.Any())
        {
            Console.WriteLine("Containers list:");
            foreach (var container in Containers)
                Console.WriteLine(container.ToString());
            return true;
        }

        else
        {
            Console.WriteLine("No containers to display.");
            return false;
        }
    }

    public static bool DisplayShips(List<Ship> Ships)
    {
        if (Ships == null || Ships.Count == 0)
        {
            Console.WriteLine("No ships are currently registered in the system.");
            return false;
        }

        Console.WriteLine("Displaying information for all ships:");

        foreach (Ship ship in Ships)
        {
            Console.WriteLine(ship.ToString());
            Console.WriteLine("---------------------------------------");
        }
        return true;
    }

    
    



    
    

}

    
