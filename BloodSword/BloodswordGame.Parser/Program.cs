using BloodswordGame.Data;
using BloodswordGame.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.RegularExpressions;
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

            var paragraphs = Fb2Parser.Parse(fb2Path);

            var choicePattern1 = new Regex(@"\b(?:на|мини на|обърни на|иди на|отиди на|продължи към|продължи на)\s+(\d{1,4})", RegexOptions.IgnoreCase);
            var choicePattern2 = new Regex(@"#?[\(（](\d{1,4})[\)）]"); // хваща (#123), (123), （123）
            int paragraphNumber = 1;

           



            // Изчистване на таблицата (по избор)
            context.Paragraphs.RemoveRange(context.Paragraphs);
            context.SaveChanges();

            // Запис в базата
            foreach (var p in paragraphs)
            {
                context.Paragraphs.Add(p);
            }
            context.SaveChanges();

            Console.WriteLine($"✅ Импортирани са {paragraphs.Count} параграфа от FB2 файла.");

            foreach (var paragraph in paragraphs)
            {
                var found = new HashSet<int>();

                foreach (Match m in choicePattern1.Matches(paragraph.Text))
                {
                    if (int.TryParse(m.Groups[1].Value, out int num) && found.Add(num))
                    {
                        paragraph.Choices.Add(new Choice
                        {
                            FromParagraph = paragraph,
                            ToParagraphNumber = num,
                            Description = m.Value.Trim()
                        });
                    }
                }

                foreach (Match m in choicePattern2.Matches(paragraph.Text))
                {
                    if (int.TryParse(m.Groups[1].Value, out int num) && found.Add(num))
                    {
                        paragraph.Choices.Add(new Choice
                        {
                            FromParagraph = paragraph,
                            ToParagraphNumber = num,
                            Description = m.Value.Trim()
                        });
                    }
                }
            }
        }
    }
}
