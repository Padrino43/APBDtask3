namespace ContainerManagementApp;

public class LContainer(double height, double weight, double depth, double maxCapacity, 
    LoadType loadType) : Container(height, weight, depth, "L", maxCapacity), IHazardNotifier
{
    public LoadType LoadType { get; } = loadType;
    
    
    public void NotifyHazard(string message)
    {
        Console.WriteLine("IMPORTANT!: "+message+"("+SerialNumber+")");
    }

    public override void LoadCargo(double weightToLoad)
    {
        switch (LoadType)
        {
            case LoadType.NORMAL:
            {
                if (weightToLoad + CargoWeight > MaxCapacity * 0.90)
                {
                    NotifyHazard("Safe cargo overloaded(max 90%)");
                }
                else
                {
                    base.LoadCargo(weightToLoad);
                }
                
                break;
            }
            case LoadType.DANGER:
            {
                if (weightToLoad + CargoWeight > MaxCapacity / 2)
                {
                    NotifyHazard("Danger cargo overloaded(max 50%)");
                }
                else
                {
                    base.LoadCargo(weightToLoad);
                }
                
                break;
            }
                
        }
        
    }
}

public enum LoadType
{
    DANGER,
    NORMAL
}
