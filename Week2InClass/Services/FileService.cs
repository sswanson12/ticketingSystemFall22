namespace Week2InClass.Services;

public class FileService : IFileService
{
    //I tried to keep this as bare as possible. All I wanted it doing was reading and writing.
    private string file;

    public FileService(string file)
    {
        this.file = file;
    }
    public string Read()
    {
        var fileString = "";
        Console.WriteLine("Reading!");
        if (File.Exists(file))
        {

            StreamReader streamReader = new StreamReader(file);

            streamReader.ReadLine();

            while (!streamReader.EndOfStream)
            {
                fileString += $"{streamReader.ReadLine()}~";
            }
        
            streamReader.Close();
        }
        return fileString;
    }

    public void Write(string fileHead, string ticketString)
    {
        Console.WriteLine("Writing!");
        if (File.Exists(file))
        {
            StreamWriter streamWriter = new StreamWriter(file);
            
            streamWriter.WriteLine(fileHead);

            streamWriter.WriteLine(ticketString);
        
            streamWriter.Close();
        }
    }
}