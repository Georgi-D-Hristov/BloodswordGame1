using BloodswordGame.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BloodswordGame.Parser
{
    public class Fb2Parser
    {
        public static List<Paragraph> Parse(string filePath)
        {
            var doc = XDocument.Load(filePath);
            XNamespace ns = "http://www.gribuser.ru/xml/fictionbook/2.0";

            var sections = doc.Descendants(ns + "section");
            var paragraphs = new List<Paragraph>();

            foreach (var section in sections)
            {
                var pTags = section.Elements(ns + "p").ToList();
                if (!pTags.Any()) continue;

                var text = string.Join("\n", pTags.Select(p => p.Value.Trim()));
                if (string.IsNullOrWhiteSpace(text)) continue;

                paragraphs.Add(new Paragraph
                {
                    Text = text
                });
            }

            return paragraphs;
        }
    }
}
