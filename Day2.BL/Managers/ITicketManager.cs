

using Day2.DAL;

namespace Day2.BL; 
public interface ITicketManager
{
    List<Ticket> Getall();
    void AddTicket(Ticket entity);
    Ticket? GetByID(int id);
    void Update(Ticket entity);
    void Delete(Ticket entity);
    void SaveChanges( );

}
