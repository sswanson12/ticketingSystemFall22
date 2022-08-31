namespace Week2InClass.Services;

public interface IFileService
{
    public string Read();
        
    public void Write(string fileHead, string ticketString);
    

}