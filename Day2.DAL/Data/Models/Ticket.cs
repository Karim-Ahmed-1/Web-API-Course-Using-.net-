

namespace Day2.DAL;

public class Ticket
{

    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public Department? department { get; set; }
    public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
}

