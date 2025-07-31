using BloodswordGame.Data;
using BloodswordGame.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml.Linq;

namespace BloodswordGame.Parser
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BloodswordGameDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            using var context = new DataContext(options);

            //C:\Users\Georgi.Hristov\Desktop\GitHub\BloodSword\BloodswordGame1\BloodSword\BloodswordGame.Parser\Dave-Morris-Oliver-Johnson_-_Bojnite_rovove_na_Krart_-_2067-b.fb2

            var fb2Path = @"../../../Dave-Morris-Oliver-Johnson_-_Bojnite_rovove_na_Krart_-_2067-b.fb2";

            if (!File.Exists(fb2Path))
            {
                Console.WriteLine("FB2 файлът не е намерен. Проверете пътя.");
                return;
            }
        }
    }
}
