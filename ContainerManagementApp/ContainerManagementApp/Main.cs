
using ContainerManagementApp;

List<Container> containers = new List<Container>();
Ship? choosedShip = null;
bool isWorking = true;
int option;

while (isWorking)
{
    Console.Clear();
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
                        new Ship(maxSpeed, maxContainers, maxContainersWeight);
                        Console.WriteLine("Created ship");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    case 2:
                    {
                        if (Ship._ships.Count > 0)
                        {
                            for (int i = 0; i < Ship._ships.Count; i++)
                            {
                                Console.WriteLine($"({i}){Ship._ships[i]}");
                            }
                                
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option < Ship._ships.Count)
                            {
                                choosedShip = Ship._ships[option];
                                Console.WriteLine("Choosed ship " + choosedShip);
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }

                        break;
                    }
                    case 3:
                    {
                        if (Ship._ships.Count > 0)
                        {
                            for (int i = 0; i < Ship._ships.Count; i++)
                            {
                                Console.WriteLine($"({i}){Ship._ships[i]}");
                            }

                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option < Ship._ships.Count)
                            {

                                if (Ship._ships[option].Equals(choosedShip))
                                    choosedShip = null;
                                Ship._ships.RemoveAt(option);
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
                            Console.Clear();
                            Console.WriteLine("Options:\n(1)Add container\n(2)Add containers");
                            option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                {
                                    for (int i = 0; i < containers.Count; i++)
                                    {
                                        Console.WriteLine($"({i}){containers[i]}");
                                    }
                                    Console.WriteLine("Choose container to add");
                                    option = Convert.ToInt32(Console.ReadLine());
                                    if(choosedShip.LoadSingleContainer(containers[option],false))
                                        containers.RemoveAt(option);
                                    break;
                                }
                                case 2:
                                {
                                    List<Container> tempList = new List<Container>();
                                    bool working = true;
                                    while (working)
                                    {
                                        Console.Clear();
                                        for (int i = 0; i < containers.Count; i++)
                                        {
                                            Console.WriteLine($"({i}){containers[i]}");
                                        }
                                        Console.WriteLine("Write numbers with enter (Exit when number is out of bound)");
                                        option = Convert.ToInt32(Console.ReadLine());
                                        if (option < 0 || option > containers.Count() - 1 )
                                        {
                                            working = false;
                                        }else
                                        {
                                            tempList.Add(containers[option]);
                                            containers.RemoveAt(option);
                                        }
                                    }
                                    
                                    Console.WriteLine("Do you sure you want add these containers?\n(1)yes");
                                    option = Convert.ToInt32(Console.ReadLine());
                                    if (option == 1)
                                    {
                                        if (!choosedShip.LoadMultipleContainers(tempList))
                                        {
                                            Console.WriteLine("Adding not successful");
                                            containers.AddRange(tempList);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Adding successful");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Containers have not been moved ");
                                        containers.AddRange(tempList);
                                    }
                                    
                                    break;
                                }
                                
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;
                    }
                    case 5:
                    {
                        if (choosedShip != null && choosedShip.GetContainerListLenght() > 0)
                        {
                            Console.Clear();
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
                                for (int i = 0; i < Ship._ships.Count; i++)
                                {
                                    Console.WriteLine($"({i}){Ship._ships[i]}");
                                }
                                option = Convert.ToInt32(Console.ReadLine());
                                if (option >= 0 && option < Ship._ships.Count())
                                {
                                    choosedShip.MoveContainer(tempCon,Ship._ships[option]);
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
                            Console.Clear();
                            Console.WriteLine("Write container serial number to replace");
                            for (int i = 0; i < choosedShip.GetContainerListLenght(); i++)
                            {
                                Console.WriteLine($"{choosedShip.GetContainer(i)}");
                            }
                            string serialNumber = Console.ReadLine().ToUpper();
                            
                            Console.WriteLine("Choose container to put on ship");
                            for (int i = 0; i < containers.Count(); i++)
                            {
                                Console.WriteLine($"({i}){containers[i]}");
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
                            Console.Clear();
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
                        break;
                    }
                    
                }
                
            }
            
            isWorking = true;
            break;
        }
        case 2:
        {
           
            while (isWorking)
            {
                Console.Clear();
                Console.WriteLine("Options:\n(1)Add container\n(2)Load container\n(3)Unload container\n" +
                                  "(4)Delete container\n(5)Return");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                    {
                        Console.Clear();
                        double height;
                        double weight;
                        double depth;
                        double maxCapacity;
                        Console.WriteLine("Options:\n(1)Liquid container\n(2)Gas container\n(3)Refrigerated container");
                        option = Convert.ToInt32(Console.ReadLine());
                        if (option >= 0 && option < 4)
                        {
                            Console.WriteLine("Enter height[cm]");
                            height = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter weight[kg]");
                            weight = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter depth[cm]");
                            depth = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Enter maxCapacity[kg]");
                            maxCapacity = Convert.ToDouble(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                {
                                    Console.WriteLine("Which cargo it will transport\n(1)DANGER\n(2)NORMAL");
                                    option = Convert.ToInt32(Console.ReadLine());
                                    if (option == 1)
                                    {
                                        containers.Add(
                                            new LContainer(height, weight, depth, maxCapacity, LoadType.DANGER ));
                                        Console.WriteLine("Added new container");
                                    }
                                    if (option == 2)
                                    {
                                        containers.Add(
                                            new LContainer(height, weight, depth, maxCapacity, LoadType.NORMAL ));
                                        Console.WriteLine("Added new container");
                                    }

                                    break;
                                }
                                case 2:
                                {
                                    containers.Add(
                                        new GContainer(height, weight, depth, maxCapacity));
                                    Console.WriteLine("Added new container");
                                    break;
                                }
                                case 3:
                                {
                                    containers.Add(
                                        new CContainer(height, weight, depth, maxCapacity));
                                    Console.WriteLine("Added new container");
                                    break;
                                }

                            }
                            Console.ReadLine();
                            Console.Clear();
                        }

                        break;
                    }
                    
                    case 2:
                    {
                        if (containers.Count() > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Which container do you want to load");
                            for (int i = 0; i < containers.Count(); i++)
                            {
                                Console.WriteLine($"({i}){containers[i]}");
                            }

                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option < containers.Count())
                            {
                                double weight;
                                Console.WriteLine("Enter weight to add to container");
                                weight = Convert.ToDouble(Console.ReadLine());
                                containers[option].LoadCargo(weight);
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                        
                        break;
                    }
                    case 3:
                    {
                        if (containers.Count() > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Which container do you want to unload");
                            for (int i = 0; i < containers.Count(); i++)
                            {
                                Console.WriteLine($"({i}){containers[i]}");
                            }

                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option < containers.Count())
                            {
                                containers[option].UnloadCargo();
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    }
                    case 4:
                    {
                        if (containers.Count() > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Which container do you want to delete");
                            for (int i = 0; i < containers.Count(); i++)
                            {
                                Console.WriteLine($"({i}){containers[i]}");
                            }

                            option = Convert.ToInt32(Console.ReadLine());
                            if (option >= 0 && option <= containers.Count())
                            {
                                containers.RemoveAt(option);
                                Console.WriteLine("Positive container remove");
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    }
                    
                    case 5:
                    {
                        isWorking = false;
                        break;
                    }
                    
                }
                
            }

            isWorking = true;
            break;
        }
        case 3:
        {
            isWorking = false;
            break;
        }
        
    }
}


