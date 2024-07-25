namespace RemoveDuplicateItems.Models;

public class UserViewModel
{
    public string FullName { get; set; } = null!;

    public HashSet<string> Cars { get; set; } = null!;
}
