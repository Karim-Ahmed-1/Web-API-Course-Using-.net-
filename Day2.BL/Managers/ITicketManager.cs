

using Day2.DAL;

namespace Day2.BL; 
public interface ITicketManager
{
    IEnumerable<TicketReadDto> Getall();
    void AddTicket(Ticket entity);
    Ticket? GetByID(int id);
    void Update(Ticket entity);
    void Delete(Ticket entity);
    void SaveChanges( );

}
