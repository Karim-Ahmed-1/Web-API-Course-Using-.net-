

namespace Day2.BL;

public class TicketChildReadDto
{
    public required int Id { get; set; }
    public required string Description { get; set; } = string.Empty;

    public required int DevelopersCount { get; set; }
}
