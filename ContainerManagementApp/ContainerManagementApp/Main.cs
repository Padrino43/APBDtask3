using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Channels;
using ContainerManagementApp;

List<Ship> ships = new List<Ship>();
List<Container> containers = new List<Container>();
Ship? choosedShip = null;
bool isWorking = true;
int option;
Console.ReadLine();
Console.Clear();

while (isWorking)
{
    if(choosedShip != null)
        Console.WriteLine("Choosed ship:\n"+choosedShip);
    Console.WriteLine("Options:\n(1)Ship\n(2)Container\n(3)Exit");
    option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
        {
            while (isWorking)
            {
                Console.Clear();
                if(choosedShip != null)
                    Console.WriteLine(choosedShip);
                Console.WriteLine("Options:\n(1)Add ship\n(2)Choose ship\n(3)Delete ship\n(4)Add container(s)\n" +
                                  "(5)Move container\n(6)Replace container\n(7)Delete container\n(8)Return");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    {
                        double maxSpeed;
                        int maxContainers;
                        double maxContainersWeight;
                        Console.WriteLine("Enter max speed");
                        maxSpeed = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter max containers");
                        maxContainers = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter max containers in tons");
                        maxContainersWeight = Convert.ToDouble(Console.ReadLine());
                        ships.Add(new Ship(maxSpeed, maxContainers, maxContainersWeight));
                        Console.WriteLine("Created ship");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    case 2:
                    {
                        if (ships.Count > 0)
                        {
                            for (int i = 0; i < ships.Count; i++)
                            {
                                Console.WriteLine($"({i}){ships[i]}");
                            }
                                
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option < ships.Count)
                            {
                                choosedShip = ships[option];
                                Console.WriteLine("Choosed ship " + choosedShip);
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }

                        break;
                    }
                    case 3:
                    {
                        if (ships.Count > 0)
                        {
                            for (int i = 0; i < ships.Count; i++)
                            {
                                Console.WriteLine($"({i}){ships[i]}");
                            }

                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option < ships.Count)
                            {

                                if (ships[option].Equals(choosedShip))
                                    choosedShip = null;
                                ships.RemoveAt(option);
                                Console.WriteLine("Removed ship");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }

                        break;
                    }
                    case 4:
                    {
                        if (containers.Count > 0 && choosedShip != null)
                        {
                            Console.WriteLine("Options:");
                            Console.WriteLine("Options:\n(1)Add container\n(2)Add containers");
                            option = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < containers.Count; i++)
                            {
                                Console.WriteLine($"({i}){containers[i]}");
                            }
                            switch (option)
                            {
                                case 1:
                                {
                                    Console.WriteLine("Choose container to add");
                                    option = Convert.ToInt32(Console.ReadLine());
                                    if(choosedShip.LoadSingleContainer(containers[option]))
                                        containers.RemoveAt(option);
                                    break;
                                }
                                case 2:
                                {
                                    List<Container> tempList = new List<Container>();
                                    Console.WriteLine("Write numbers with enter (Exit when number is out of bound)");
                                    while (option >= 0 && option < containers.Count())
                                    {
                                        option = Convert.ToInt32(Console.ReadLine());
                                        tempList.Add(containers[option]);
                                        containers.RemoveAt(option);
                                    }
                                    
                                    Console.WriteLine("Do you sure you want add this containers?\n(1)yes");
                                    option = Convert.ToInt32(Console.ReadLine());
                                    if (option == 1)
                                    {
                                        if (!choosedShip.LoadMultipleContainers(tempList))
                                        {
                                            Console.WriteLine("Adding not successful");
                                            containers.AddRange(tempList);
                                        }
                                    }
                                    else
                                    {
                                        containers.AddRange(tempList);
                                    }
                                    
                                    break;
                                }
                                
                            }
                            
                        }

                        break;
                    }
                    case 5:
                    {
                        if (choosedShip != null && choosedShip.GetContainerListLenght() > 0)
                        {
                            Console.WriteLine("Which container to move?");
                            Container tempCon;
                            for (int i = 0; i < choosedShip.GetContainerListLenght(); i++)
                            {
                                Console.WriteLine($"({i}){choosedShip.GetContainer(i)}");
                            }
                            
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option < choosedShip.GetContainerListLenght())
                            {
                                tempCon = choosedShip.GetContainer(option)!;
                                Console.WriteLine("Choose ship to move");
                                for (int i = 0; i < ships.Count; i++)
                                {
                                    Console.WriteLine($"({i}){ships[i]}");
                                }
                                option = Convert.ToInt32(Console.ReadLine());
                                if (option >= 0 && option < ships.Count())
                                {
                                    choosedShip.MoveContainer(tempCon,ships[option]);
                                }
                                
                                Console.ReadLine();
                                Console.Clear();
                            }
                           
                            
                        }
                        break;
                    }
                    case 6:
                    {
                        if (choosedShip != null && choosedShip.GetContainerListLenght() > 0 && containers.Count() > 0)
                        {
                            Console.WriteLine("Write container serial number to replace");
                            for (int i = 0; i < choosedShip.GetContainerListLenght(); i++)
                            {
                                Console.WriteLine($"({i}){choosedShip.GetContainer(i)}");
                            }
                            string serialNumber = Console.ReadLine().ToUpper();
                            
                            Console.WriteLine("Choose container to put on ship");
                            for (int i = 0; i < choosedShip.GetContainerListLenght(); i++)
                            {
                                Console.WriteLine($"({i}){choosedShip.GetContainer(i)}");
                            }
                            option = Convert.ToInt32(Console.ReadLine());
                            
                            if (option >= 0 && option < containers.Count())
                            {
                                Container temp;
                                temp = choosedShip.ReplaceContainer(containers[option],serialNumber);
                                if (temp != null)
                                {
                                    containers.Remove(containers[option]);
                                    containers.Add(temp);
                                }
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        
                        break;
                    }
                    case 7:
                    {
                        if (choosedShip != null && choosedShip.GetContainerListLenght() > 0)
                        {
                            Console.WriteLine("Choose container to remove");
                            for (int i = 0; i < choosedShip.GetContainerListLenght(); i++)
                            {
                                Console.WriteLine($"({i}){choosedShip.GetContainer(i)}");
                            }
                            
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option < choosedShip.GetContainerListLenght())
                            {
                                Container temp;
                                temp = choosedShip.GetContainer(option)!;
                                containers.Add(temp);
                                choosedShip.RemoveContainer(temp);
                                Console.ReadLine();
                                Console.Clear();
                            }
                            
                        }
                        break;
                    }
                    case 8:
                    {
                        isWorking = false;
                        Console.Clear();
                        break;
                    }
                    
                }
                
            }
            
            isWorking = true;
            break;
        }
        case 2:
        {
            
            Console.WriteLine("Options:\n(1)Add container\n(2)Load container\n(3)Delete container\n(4)Return");
            
            break;
        }
        case 3:
        {
            isWorking = false;
            break;
        }
        
    }
}


