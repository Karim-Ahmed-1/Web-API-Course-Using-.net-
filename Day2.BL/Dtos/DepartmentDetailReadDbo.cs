

using Day2.DAL;

namespace Day2.BL;

public class DepartmentDetailReadDbo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<TicketChildReadDto> Tickets { get; init; } = new();
}
