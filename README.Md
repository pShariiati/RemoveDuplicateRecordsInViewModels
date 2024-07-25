# Hashet - Removing duplicate records before reaching the controller

```
Data from client:
Cars: (Benz, Red), (Benz, Red), (Benz, Green)
In controller:
Cars: (Benz, Red), (Benz, Green)
Second (Benz, Red) is removed because it's duplicate.
```

```
Data from client:
Cars: Benz, Benz, Tesla, Bmw
In controller:
Cars: Benz, Tesla, Bmw
Second Benz is removed because it's duplicate.
```

```
public class UserViewModel
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
```
```
public class UserViewModel
{
    public string FullName { get; set; } = null!;

    public HashSet<string> Cars { get; set; } = null!;
}
```

## Both ```Equals``` and ```GetHashCode``` methods are necessary.
```GetHashCode``` is used for checking duplicate items in fastest way, it calculates the combine hash of ```Name``` And ```Color``` and then if it finds a record with that hash in it's table it thinks there is a another record is exists before.<br>
But ```GetHashCode``` has a problem. The problem is hash capacity is limited. For example ```MD5``` hash algorithm is 32 characters and it can't calculate all objects in the world and make sure all hash results are unique.<br>
Now for fixing this problem we should compare properties in ```Car``` class if ```GetHashCode``` method returns duplicate hash because it maybe (Benz, Red) and (Benz, Green) had a same hash.<br>
So now if two records had a same hash we should use ```Equals``` method to compare the properties and make sure the records are equal or not.

## Summary: We use ```GetHashCode``` method first. Why ? because it's fast but it's not accurate. Now for fixing this problem if we found duplicate hash we should use ```Equals``` method.
