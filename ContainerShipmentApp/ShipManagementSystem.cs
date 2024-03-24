using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Xml;

namespace ContainerShipmentApp;

public class ShipManagementSystem
{
    public static List<Container> Containers = new List<Container>();

    public static List<Ship> Ships = new List<Ship>();
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
                    lc();
                    break;
                case "ls":
                    loadShip();
                    break;
                case "cs":
                    createShip();
                    break;
                case "lls":
                    loadListShip();
                    break;
                case "rc":
                
                    break;
                case "uc":
                    uc();
                    break;
                case "ex": 
                    
                    break;
                case "tb":
                
                    break;
                case "ci":
                    DisplayContainers();
                    break;
                case "si":
                    DisplayShips();
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


    public static void DisplayContainers()
    {
        if (Containers.Any())
        {
            Console.WriteLine("Containers list:");
            foreach (var container in Containers)
                Console.WriteLine(container.ToString());
            return;
        }

        else
        {
            Console.WriteLine("No containers to display.");
            
        }
    }

    public static void DisplayShips()
    {
        if (!Ships.Any())
        {
            Console.WriteLine("No ships are currently registered in the system.");
            return;
        }

        Console.WriteLine("Displaying information for all ships:");

        foreach (Ship ship in Ships)
        {
            Console.WriteLine(ship.ToString());
            Console.WriteLine("---------------------------------------");
        }
        return;
    }


    public static void loadShip()
    {
        DisplayContainers();

        if (Containers.Any())
        {
            Console.WriteLine("Enter container serial number:");
            string serial = Console.ReadLine();
            Container containerToLoad = Containers.FirstOrDefault(c => c.SerialNumber == serial);
            if (containerToLoad != null)
            {
                DisplayShips();
                if (Ships.Any())
                {
                    Console.WriteLine("Enter ships name:");
                    string name = Console.ReadLine();
                    Ship ShipToLoad = Ships.FirstOrDefault(s => s.Name == name);
                    if (ShipToLoad != null)
                    {
                        ShipToLoad.AddContainer(containerToLoad);
                        Console.WriteLine("Container loaded succesfully");
                    }
                    else
                    {
                        Console.WriteLine("Ship not found.");
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Container not found.");
            }

        }
    }

    public static void createShip()
    {
        Console.WriteLine("Enter name for the ship:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter ship's max speed:");
        double maxSpeed = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter ship's max number of containers:");
        int maxContainerCount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter ship's max container mass");
        double maxContainerMass = Convert.ToDouble(Console.ReadLine());
        
        
        Console.WriteLine($"Ship {name} created succesfuly");
        Ships.Add(new Ship(maxSpeed, maxContainerCount, maxContainerMass, name));
        
    }

    public static void loadListShip()
    {
        bool con = true;
        bool ans;
        while (con)
        {
            lc();
            ans = true;
            while (ans)
            {
                
                Console.WriteLine("Would you like to continue loading containers? Y/N");
                string answer = Console.ReadLine().ToUpper();
                if (answer.Equals("Y"))
                    ans = false;
                else if (answer.Equals("N"))
                {
                    ans = false;
                    con = false;
                }
            }
        }
        
    }

    public static void uc()
    {
        DisplayContainers();

        if (Containers.Any())
        {
            Console.WriteLine("Enter container serial number:");
            string serial = Console.ReadLine();
            Container containerToUnload = Containers.FirstOrDefault(c => c.SerialNumber == serial);
            if (containerToUnload != null)
            {
                containerToUnload.UnloadContainer();
            }
            else
            {
                Console.WriteLine("Container not found.");
            }
        }
    }

    public static void removeContainerFromShip()
    {
        if (Ships.Count == 0 || Ships == null)
        {
            Console.WriteLine("There are no ships registered in the system.");
            return;
        }
        
        DisplayShips();
        Ship ChosenShip = null;
        if (Ships.Any())
        {
            Console.WriteLine("Enter ships name:");
            string name = Console.ReadLine();
            ChosenShip = Ships.FirstOrDefault(s => s.Name == name);
            if (ChosenShip == null)
            {
             Console.WriteLine("Ship not found");
             return;
            }
        }
        
        Console.WriteLine(ChosenShip.ToString());

        
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
        
        // Usuwanie wybranego kontenera
        Container containerToRemove = selectedShip.Containers[containerChoice - 1];
        selectedShip.Containers.RemoveAt(containerChoice - 1);
        Console.WriteLine($"Container {containerToRemove.SerialNumber} has been removed from the ship.");
    }










}

    
