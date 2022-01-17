using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstOOPProject
{
    internal class Person
    {
        // private fields

        private string _firstname = "";
        private string _lastname = "";
        private string _occupation = "";
        private int _age = 0;

        // public fields

        public string Firstname { get { return _firstname; } }
        public string Lastname { get { return _lastname; } }
        public string Occupation { get { return _occupation; } }
        public int Age { get { return _age; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstname">First name</param>
        /// <param name="lastname">Last name</param>
        /// <param name="occupation">Occupation</param>
        /// <param name="age">Age</param>
        public Person(string firstname, string lastname, string occupation, int age)
        {
            _firstname = firstname;
            _lastname = lastname;
            _occupation = occupation;
            _age = age;

        }
    }
}
