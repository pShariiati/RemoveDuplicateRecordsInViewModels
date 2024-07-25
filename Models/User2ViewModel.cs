namespace RemoveDuplicateItems.Models;

public class User2ViewModel
{
    public string FullName { get; set; } = null!;

    public HashSet<Car> Cars { get; set; } = null!;
}

public class Car
{
    public override bool Equals(object? obj)
    {
        if (obj is Car car)
        {
            return car.Color == Color && car.Name == Name;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Color);
    }

    public string Name { get; set; } = null!;

    public string Color { get; set; } = null!;
}