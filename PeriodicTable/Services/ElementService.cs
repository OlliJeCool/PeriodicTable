using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable
{
    public class ElementService
    {
        private readonly string _path = "./elementlist.txt";

        public List<Element> LoadElements()
        {
            var ellist = new List<Element>();
            var strm = new StreamReader(_path);
            var elements = strm.ReadToEnd();
            string[] array = elements.Split("\r\n");
            foreach (string element in array)
            {
                string[] temp = element.Split(',');
                ellist.Add(new Element { PN = Int32.Parse(temp[0]), Short = temp[1].ToLower(), EnName = temp[2].ToLower(), CzName = temp[3].ToLower(), lName = temp[4].ToLower() });
            }
            return ellist;
        }
    }
}