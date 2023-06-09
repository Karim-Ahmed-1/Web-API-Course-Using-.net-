﻿
using Day2.DAL;

namespace Day2.BL;

public class TicketManager : ITicketManager
{
    private ITicketsRepo _TicketsRepo;

    public TicketManager(ITicketsRepo ticketsRepo)
    {
        _TicketsRepo = ticketsRepo;

    }
    public void AddTicket(Ticket entity)
    {
        _TicketsRepo.AddTicket(entity);
    }

    public void Delete(Ticket entity)
    {
        _TicketsRepo.Delete(entity);
    }

    public List<Ticket> Getall()
    {
       var TicketsFromDB = _TicketsRepo.GetTickets();

        return TicketsFromDB;

        
       
    }

    public Ticket? GetByID(int id)
    {
        return _TicketsRepo.GetByID(id);
        
    }

    public void SaveChanges( )
    {
        _TicketsRepo.SaveChanges();
    }

    public void Update(Ticket entity)
    {
        _TicketsRepo.Update(entity);
    }
}
