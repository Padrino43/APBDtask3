namespace ContainerManagementApp;

public class GContainer(double height, double weight, double depth, double maxCapacity) 
    : Container(height, weight, depth, "G", maxCapacity), IHazardNotifier
{
    public override void UnloadCargo()
    {
        if (IsOnShip) return;
        if (CargoWeight != 0)
        {
            CargoWeight *= 0.05;
            Console.WriteLine("Positive cargo unload");
            return;
        }
        Console.WriteLine("Container has no cargo to unload");
    }

    public override void LoadCargo(double weightToLoad)
    {
        if(Weight + CargoWeight + weightToLoad > MaxCapacity)
            NotifyHazard("Error loading");
        else
            base.LoadCargo(weightToLoad);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("IMPORTANT!: "+message+"("+SerialNumber+")");
    }
}