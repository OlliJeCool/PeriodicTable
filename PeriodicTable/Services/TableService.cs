using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable
{
    public class TableService
    {
        #region Fields
        private readonly Element _error = new Element { PN = 0, Short = "NN", EnName = "DoesNotExist", CzName = "Neexistuje", lName = "No" };
        private int score = 0;
        #endregion

        #region Main code
        public void Run()
        {
            // Initiates a new instance of ElementService
            var app = new ElementService();
            // Loads all Elements into a list
            var a = app.LoadElements();
            bool highp = true;
            bool proceed = true;
            while (highp)
            {
                Console.Clear();
                Console.Write("Type p to practice, s to search or e to quit... ");
                //Selecting what to do
                switch (Console.ReadLine())
                {
                    case "p":
                        //Calls the practice function
                        Practice(a);
                        break;
                    case "s":
                        while (proceed)
                        {
                            var input = Console.ReadLine();
                            //Decides wether the input is a short or full name, calls appropriate function
                            if (input.Length <= 2) { var output = FetchElementByShort(input.ToLower(), a); Console.WriteLine($"{output.PN}, Short: {output.Short}; EN: {output.EnName}, CZ: {output.CzName}, LAT: {output.lName}"); }
                            else { var output = FetchElementByName(input.ToLower(), a); Console.WriteLine($"{output.PN}; EN: {output.EnName}, CZ: {output.CzName}, LAT: {output.lName}"); }
                            Console.Write("Type s to continue searching or e to exit to main menu... ");
                            switch (Console.ReadLine())
                            {
                                case "s":
                                    Console.Clear();
                                    continue;
                                case "e":
                                    Console.Clear();
                                    proceed = false;
                                    break;

                            }
                        }
                        break;
                    case "e":
                        highp = false;
                        break;
                }
            }
        }
        #endregion

        #region Element fetching
        public Element FetchElementByShort(string input, List<Element> list)
        {
            foreach (var item in list)
            {
                //checks if there is an element with inputed short name and returns the element
                if (item.Short == input) { return item; }
                else { continue; }
            }
            //otherewise an error element is returned
            return _error;
        }

        public Element FetchElementByName(string input, List<Element> list)
        {
            foreach (var item in list)
            {
                //checks if there is an element with inputed name in any of the three languages and returns the element
                if (item.EnName == input) { return item; }
                else if (item.CzName == input) { return item; }
                else if (item.lName == input) { return item; }
                else { continue; }
            }
            //otherewise an error element is returned
            return _error;
        }
        #endregion

        #region Practice func
        public void Practice(List<Element> list)
        {
            var rand = new Random();
            bool proceed = true;
            while (proceed)
            {
                Console.Clear();
                var num = list[rand.Next(rand.Next(0, list.Count - 1))]; //selects a random element
                switch (rand.Next(0, 1)) //randomly selects the question from the two options - element from short name or short name from latin name
                {
                    case 0:
                        Console.WriteLine($"Napiš cesky nazev podle zkratky {num.Short}");
                        var an = Console.ReadLine();
                        if (an.ToLower() == num.CzName) { score++; Console.WriteLine($"Correct! Current score is {score}."); }
                        else { score = 0; Console.WriteLine($"Bzzz! That's not correct! The correct answer is {num.CzName}"); }
                        break;
                    case 1:
                        Console.WriteLine($"Napis zkratku podle latinskeho nazvu {num.lName}");
                        var answ = Console.ReadLine();
                        if (answ.ToLower() == num.Short) { score++; Console.WriteLine($"Correct! Current score is {score}."); }
                        else { score = 0; Console.WriteLine($"Bzzz! That's not correct! The correct answer is {num.Short}"); }
                        break;
                }
                Console.Write("Press enter to continue or type e to exit to main menu... ");
                switch (Console.ReadLine())
                {
                    case "e":
                        proceed = false;
                        break;
                    default:
                        continue;
                }
            }
        }
        #endregion
    }
}
