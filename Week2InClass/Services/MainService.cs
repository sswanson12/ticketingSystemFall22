using Week2InClass.Objects;

namespace Week2InClass.Services;

public class MainService : IMainService
{
    private IFileService _fileService;
    private TicketFileTranslator _ticketFileTranslator;
    private List<Ticket> _ticketList;

    public MainService(IFileService fileService, TicketFileTranslator ticketFileTranslator)
    {
        _fileService = fileService;
        _ticketFileTranslator = ticketFileTranslator;
        _ticketList = new List<Ticket>();
    }
        
    public void Invoke()
    {
        Console.WriteLine("Would you like to read or write?" +
                          "\n(1) Read \n(2) Write");

        var restart = true;
        while (restart)
        {
            restart = false;
            var choice = Console.ReadLine();
            
            switch (choice) 
            {
                case "1" :
                    ReadFile();
                    break;
                case "2" :
                    WriteFile();
                    break;
                default:
                    Console.WriteLine("Try entering either (1) to read, or (2) to write again.");
                    restart = true;
                    break;
            }
        }

        void ReadFile()
        {
            _ticketList = _ticketFileTranslator.MakeTickets(_fileService.Read());

            foreach (var ticket in _ticketList)
            {
                Console.WriteLine(ticket.ToString());
            }
        }

        void WriteFile()
        {
            MakeTickets();
            _fileService.Write(_ticketFileTranslator.fileHead, _ticketFileTranslator.WriteTickets(_ticketList));
        }

        void MakeTickets()
        {
            var continueLoop = "y";

            while (continueLoop.Equals("y"))
            {
                Console.Write("Please enter the following.\n" +
                                  "TicketID: ");

                var ticketId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Summary: ");

                var summary = Convert.ToString(Console.ReadLine());

                Console.Write("Status: ");

                var status = Convert.ToString(Console.ReadLine());
                
                Console.Write("Priority: ");
                
                var priority = Convert.ToString(Console.ReadLine());
                
                Console.Write("Submitter: ");
                
                var submitter = Convert.ToString(Console.ReadLine());
                
                Console.Write("Assigned: ");
                
                var assigned = Convert.ToString(Console.ReadLine());
                
                Console.Write("How many people are watching? ");

                var watching = new string[Convert.ToInt32(Console.ReadLine())];

                Console.Write("Please enter each name individually, pressing enter after each name.");

                for (var i = 0; i < watching.Length; i++)
                {
                    Console.Write($"Name {i + 1}: ");

                    watching[i] = Console.ReadLine() + "";
                }
                
                _ticketList.Add(new Ticket(ticketId,summary,status,priority,submitter,assigned,watching));

                Console.WriteLine("Ticket was successfully created! Enter (y) if you would like to add another ticket, otherwise enter any other key to exit.");

                continueLoop = Console.ReadLine()?.ToLower();
            }
        }
    }
}