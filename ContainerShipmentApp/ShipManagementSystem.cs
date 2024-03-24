namespace ContainerShipmentApp;

public class ShipManagementSystem
{
    public static void ManageShips(){
        
        bool running = true;

        List<Container> Containers = new List<Container>();

        List<Ship> Ships = new List<Ship>();

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
                    Container newContainer = cc();
                    if (newContainer != null)
                        Containers.Add(newContainer);
                    break;
                
                case "lc":
                    
                    Console.WriteLine("Enter container serial number:");
                    string serial = Console.ReadLine();
                    Container containerToLoad = Containers.FirstOrDefault(c => c.SerialNumber == serial);
                    if(containerToLoad != null)
                    {
                        Console.WriteLine("Enter load mass:");
                        double mass = Convert.ToDouble(Console.ReadLine());
                        containerToLoad.LoadContainer(mass);
                        Console.WriteLine("Container loaded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Container not found.");
                    }
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

    public static Container cc()
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
            return (newContainer);
            
        }

        return null;
    }
    // public static void displayContainers(List<Container> containers) {
    //     for (c : containers)
    // }

}

    