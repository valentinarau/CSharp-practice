using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstOOPProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] file = ReadFile("values.csv");
            List<Person> people = new List<Person>();
            people = GetPeople(file);   // get the people from de csv file
            PrintPeople (people);
            Console.ReadKey();
        }
        /// <summary>
        /// Read from a file and return lines
        /// </summary>
        /// <param name="filename">Path to file</param>
        /// <returns>String array of file lines</returns>
        static string[] ReadFile (string filename)
        {
            string[] lines = System.IO.File.ReadAllLines (filename);
            return lines;
        }

        /// <summary>
        /// Get people from file
        /// </summary>
        /// <param name="file">file lines</param>
        /// <returns>List of people</returns>
        static List<Person> GetPeople(string[] file)
        {
            
            Dictionary<int, List<string>> file_items = new Dictionary<int, List<string>>();
            List<Person> people = new List<Person> ();
            
            // Get items from file
            for (int i = 0; i < file.Length; i++) file_items.Add(i,GetItems(file[i]));
            
            // Create person objects
            for (int i = 1; i < file.Length; i++)
            {
                Person p;
                string firstname = "", lastname = "", occupation = "";
                int age = 0;

                for(int j = 0; j < file_items[0].Count(); j++)
                {

                    // check what value are we on (hardcoded)
                    switch (file_items[0][j].ToLower())
                    {
                        case "firstname":
                            firstname = file_items[i][j];
                            break;
                        case "lastname":
                            lastname = file_items[i][j];
                            break;
                        case "occupation":
                            occupation = file_items[i][j];
                            break ;
                        case "age":
                            age = int.Parse(file_items[i][j]);
                            break;
                        default:
                            Console.WriteLine($"Header '{file_items[0][j]}' is not a valid header");
                            break;
                    }
                }
                p = new Person(firstname,lastname,occupation,age);
                people.Add(p);
            }

            // Return new instance of people
            return new List<Person> (people);
            
        }

        /// <summary>
        /// Get items from line
        /// </summary>
        /// <param name="line">line</param>
        /// <returns>list of items</returns>
        static List<string> GetItems(string line)
        {
            string current_word = "";
            List<string> items = new List<string>();

            // split line, make up the word and save to items
            foreach (char c in line)
            {
                if (c == ',')
                {
                    if (!string.IsNullOrEmpty(current_word))
                    {
                        items.Add(current_word);
                        current_word = "";
                    }
                }
                else
                {
                    // form the word, char by char
                    current_word += c.ToString();
                }
            }
            // add left over item if exists
            if (!string.IsNullOrEmpty(current_word)) items.Add(current_word);

            // return new instance of list items (dont return a reference to it! it can be lost or modified)
            return new List<string>(items);
        }   
        /// <summary>
        /// Print information about every person in people
        /// </summary>
        /// <param name="people">list of people</param>
        static void PrintPeople(List<Person> people)
        {
            foreach (Person p in people)
            {
                Console.WriteLine($"{p.Firstname} {p.Lastname} is {p.Age.ToString()} years old and works as a(n) {p.Occupation}");
            }
        }

    }
}
