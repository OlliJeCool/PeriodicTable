using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable
{
    public class TableService
    {
        private readonly Element _error = new Element { PN = 0, Short = "NN", EnName = "DoesNotExist", CzName = "Neexistuje", lName = "No" };
        public void Run()
        {
            var app = new ElementService();
            var a = app.LoadElements();
            bool proceed = true;

                while (proceed)
                {
                    var input = Console.ReadLine();
                    if (input.Length <= 2) { var output = FetchElementByShort(input.ToLower(), a); Console.WriteLine($"{output.PN}, Short: {output.Short}; EN: {output.EnName}, CZ: {output.CzName}, LAT: {output.lName}"); }
                    else { var output = FetchElementByName(input.ToLower(), a); Console.WriteLine($"{output.PN}; EN: {output.EnName}, CZ: {output.CzName}, LAT: {output.lName}"); }
                    Console.Write("Type s to continue searching or e to exit to main menu... ");
                    switch (Console.ReadLine())
                    {
                        case "s":
                            continue;
                        case "e":
                            proceed = false;
                            break;
                    }
                }
        }

        public Element FetchElementByShort(string input, List<Element> list)
        {
            foreach (var item in list)
            {
                if (item.Short == input) { return item; }
                else { continue; }
            }
            return _error;
        }

        public Element FetchElementByName(string input, List<Element> list)
        {
            foreach (var item in list)
            {
                if (item.EnName == input) { return item; }
                else if (item.CzName == input) { return item; }
                else if (item.lName == input) { return item; }
                else { continue; }
            }
            return _error;
        }

        public void Practice(List<Element> list)
        {
            var rand = new Random();
            
        }
    }
}
