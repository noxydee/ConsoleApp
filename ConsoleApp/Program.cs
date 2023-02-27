namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataReader reader = new DataReader();
            reader.ImportAndPrintData("data.csv");
        }
    }
}
