

namespace Day2.DAL;

public interface ITicketsRepo
{
    List<Ticket> GetTickets();

    Ticket? GetByID(int id);

    void AddTicket(Ticket entity);
    void Update(Ticket entity);
    void Delete(Ticket entity);
    void SaveChanges(  );
}

