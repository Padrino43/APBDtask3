namespace ContainerManagementApp;

public class CContainer(double height, double weight, double depth, double maxCapacity) 
    : Container(height, weight, depth,"C", maxCapacity)
{
    public Product? ChoosedProduct { get; } = null;
    public double Temperature { get; } = new Random().Next(-300,205) / 10.0;


    public override void LoadCargo(double weightToLoad)
    {
        int option;
        int counter = 0;
        Console.WriteLine("Actual Temperature: "+Temperature);
        foreach (var product in Enum.GetValues<Product>())
        {
            if ((int)product > Temperature)
            {
                Console.WriteLine("("+counter+")"+product);
                counter++;
            }

        }
        
    }
}

public enum Product
{
    Bananas = 133,
    Chocolate = 180,
    Fish = 20,
    Meat = -150,
    IceCream = -18,
    FrozenPizza = -300,
    Cheese = 72,
    Sausages = 50,
    Butter = 205,
    Eggs = 190
    
}