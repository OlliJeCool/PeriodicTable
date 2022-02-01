using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicTable
{
    public class ElementService
    {
        #region Fields
        private readonly string _path = "./elementlist.txt";
        #endregion

        #region Loading Elements
        public List<Element> LoadElements() //loads elements from text file
        {
            var ellist = new List<Element>();
            var strm = new StreamReader(_path);
            var elements = strm.ReadToEnd();
            string[] array = elements.Split("\r\n"); //formating
            foreach (string element in array)
            {
                string[] temp = element.Split(','); //formating
                ellist.Add(new Element { PN = Int32.Parse(temp[0]), Short = temp[1].ToLower(), EnName = temp[2].ToLower(), CzName = temp[3].ToLower(), lName = temp[4].ToLower() });
                //adds each new element into a list
            }
            return ellist;
            //returns list of elements
        }
        #endregion
    }
}