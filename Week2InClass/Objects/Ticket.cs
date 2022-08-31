namespace Week2InClass.Objects;

public class Ticket
{
    private int ticketId;
    private string summary;
    private string status;
    private string priority;
    private string submitter;
    private string assigned;
    private string[] watching;

    public Ticket(int ticketId, string summary, string status, string priority, string submitter, string assigned, string[] watching)
    {
        this.ticketId = ticketId;
        this.summary = summary;
        this.status = status;
        this.priority = priority;
        this.submitter = submitter;
        this.assigned = assigned;
        this.watching = watching;
    }

    public int TicketId => ticketId;

    public string Summary => summary;

    public string Status => status;

    public string Priority => priority;

    public string Submitter => submitter;

    public string Assigned => assigned;

    public string[] Watching => watching;

    public override string ToString()
    {
        var watchingString = "";

        foreach (var person in watching)
        {
            watchingString += $"{person}, ";
        }

        return
            $"Ticket ID: {ticketId} - Summary: {summary} - Status: {status} - Priority: {priority} - Submitter: {submitter} - " +
            $"Assigned: {assigned} - Watching: {watchingString.Substring(0, watchingString.Length - 2)}";
    }
}