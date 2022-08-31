namespace Week2InClass.Objects;

public class TicketFileTranslator
{
    public string fileHead = "TicketID,Summary,Status,Priority,Submitter,Assigned,Watching";

    public string FileHead => fileHead;

    public string WriteTickets(List<Ticket> ticketList)
    {
        var ticketString = "";
        
        foreach (var ticket in ticketList)
        {
            ticketString += $"{ticket.TicketId},{ticket.Summary},{ticket.Status},{ticket.Priority},{ticket.Submitter},{ticket.Assigned},";

            foreach (var person in ticket.Watching)
            {
                ticketString += $"{person}|";
            }

            ticketString = $"{ticketString.Substring(0, ticketString.Length - 1)}\n";
        }

        return ticketString;
    }

    public List<Ticket> MakeTickets(string ticketString)
    {
        var ticketList = new List<Ticket>();

        var ticketStringArray = ticketString.Split("~");

        foreach (var ticketLine in ticketStringArray)
        {
            if (ticketLine.Length > 1)
            {
                var ticketComponents = ticketLine.Split(",");

                var newTicket = new Ticket(Convert.ToInt32(ticketComponents[0]), ticketComponents[1],
                    ticketComponents[2], ticketComponents[3], ticketComponents[4], ticketComponents[5],
                    ticketComponents[6].Split("|"));

                ticketList.Add(newTicket);
            }
        }

        return ticketList;
    }
}