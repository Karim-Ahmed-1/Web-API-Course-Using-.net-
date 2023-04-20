
namespace Day2.DAL;

public class TicketsRepo : ITicketsRepo
{
    private CompanyContext _context;

    public TicketsRepo(CompanyContext context)
    {
        _context = context;
    }
    public void AddTicket(Ticket entity)
    {
        _context.Set<Ticket>().Add(entity);
        SaveChanges();

    }

    public void Delete(Ticket entity)
    {
        _context.Set<Ticket>().Remove(entity);
        SaveChanges();


    }

    public Ticket? GetByID(int id)
    {
        return _context.Set<Ticket>().Find(id);
    }

    public List<Ticket> GetTickets()
    {
        return _context.Set<Ticket>().ToList();
    }

    public void SaveChanges( )
    {
        _context.SaveChanges();
    }

    public void Update(Ticket entity)
    {
        Ticket? TicketToEdit = GetByID(entity.Id);
        if (TicketToEdit != null)
        {
            TicketToEdit.Title = entity.Title;
            TicketToEdit.Description = entity.Title;
            TicketToEdit.department = entity.department;
            TicketToEdit.Developers = entity.Developers;

            SaveChanges();
        }
    }
}
