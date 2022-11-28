using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Usporedba_dva_XML_a
{
    internal class Program
    {
        static void Main(string[] args)
        {

       // C: \Users\ucenik\Downloads
            XElement PrviXML = XElement.Load(@"C: \Users\ucenik\Downloads\prvi.xml");
            XElement DrugiXML = XElement.Load(@"C: \Users\ucenik\Downloads\drugi.xml");

            int brojpomagalo = 0;

            foreach (XElement book in PrviXML.Elements())
            {
                book.Name = "Book" + brojpomagalo.ToString();
                brojpomagalo++;
            }

            foreach(XElement book in DrugiXML.Elements())
            {
                book.Name = "Book" + brojpomagalo.ToString();
            }

            IEnumerable<string> UsporedbaIDova = from s in PrviXML.Elements()
                                                 where s.Attribute("id").Value != DrugiXML.Element(s.Name).Attribute("id").Value
                                                 select "\tid is different\t\t" + s.Attribute("id").Value + "\t\t\t" + DrugiXML.Element(s.Name).Attribute("name").Value;
            IEnumerable<string> UsporedbaImageova = from s in PrviXML.Elements()
                                                    where s.Attribute("id").Value != DrugiXML.Element(s.Name).Attribute("image").Value
                                                    select "\timage is different\t\t" + s.Attribute("image").Value +"\t\t\t" +DrugiXML.Element(s.Name).Attribute("name").Value;
            IEnumerable<string> UsporedbaImena = from s in PrviXML.Elements()
                                                 where s.Attribute("name").Value != DrugiXML.Element(s.Name).Attribute("name").Value
                                                 select "\tname is different\t" + s.Attribute("name").Value + "\t\t\t" + DrugiXML.Element(s.Name).Attribute("name").Value;

            Console.WriteLine("Issued\t\tIssue type\t\tIssueInFirst\t\tIssueInSecond");
            foreach (string s in UsporedbaImageova) { Console.WriteLine("1\t" + s.ToString()); }
           foreach (string )
            Console.ReadKey();
        }
    }
}
