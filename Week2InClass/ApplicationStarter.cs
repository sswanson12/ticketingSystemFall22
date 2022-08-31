using Week2InClass.Objects;
using Week2InClass.Services;

namespace Week2InClass;

public class ApplicationStarter
{
    public static void Start(string file)
    {
        IFileService fileService = new FileService(file);
        TicketFileTranslator ticketFileTranslator = new TicketFileTranslator();
        IMainService mainService = new MainService(fileService, ticketFileTranslator);
        mainService.Invoke();
    }
}