namespace ContainerManagementApp;

public abstract class Container(double height, double weight, double depth, string name,
double maxCapacity)
{
    private static string _defaultSerialNumber = "KON";
    private static int _id = 1;

    
    public double CargoWeight { get; protected set; } = 0;
    public double Height { get; } = height;
    public double Weight { get; } = weight;
    public double Depth { get; } = depth;
    public string SerialNumber { get; } = _defaultSerialNumber +"-"+ name+"-"+_id++;
    public double MaxCapacity { get; } = maxCapacity;

    public virtual void UnloadCargo()
    {
        if (CargoWeight != 0)
        {
            CargoWeight = 0;
            Console.WriteLine("Positive cargo unload");
            return;
        }
        Console.WriteLine("Container has no cargo to unload");
    }

    public virtual void LoadCargo(double weightToLoad)
    {
        if (weightToLoad + CargoWeight > MaxCapacity)
        {
            throw new OverfillException("Container overfilled");
        }
        
        CargoWeight += weightToLoad;
        Console.WriteLine("Positive cargo load with" + weightToLoad+" kg");
        
    }
    
    public override string ToString()
    {
        return $"Container {SerialNumber}, weight={Weight} (cargo={CargoWeight}/{MaxCapacity}[kg], H/D={Height}/{Depth})";
    }
}