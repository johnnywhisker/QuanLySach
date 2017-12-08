using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach
{
    class Database
    {
        public static List<Book> books = new List<Book>();

        public static void UpdateDatabase()
        {
            List<string> lines = new List<string>();
            foreach (Book book in books) {
                StringBuilder line = new StringBuilder();
                Dictionary<string, string> processDictionary = book.getData();
                foreach (string key in processDictionary.Keys) {
                    if (key == "name")
                    {
                        line.Append(processDictionary[key]);
                    }
                    else {
                        line.Append("-" + processDictionary[key]);
                    }
                }
                lines.Add(line.ToString());
            }
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"books.txt")) {
                foreach (string line in lines) {
                    file.WriteLine(line);
                }
            }
        }
        public static void UpdateDataset() {
            string[] lines = System.IO.File.ReadAllLines(@"books.txt");
            foreach (string line in lines) {
                string[] processString = line.Split('-');
                Book tempBook = new Book(processString[0], processString[1], processString[2], processString[3], float.Parse(processString[4]), Convert.ToInt32(processString[5]),processString[6]);
                books.Add(tempBook);
            }
        }
    }
}
