using System;
using System.Collections.Generic;
using System.IO;

namespace Frozen
{
    class Program
    {
        class Frozen
        {
            string person;
            string item;
            
            public Frozen(string _person, string _item)
            {
                item = _item;
                person = _person;
            }
            public string Person { get { return person; } }
            public string Item { get { return item; } }
        }
        class ListOfPersons
        {
            List<Frozen> Persons;
            string Name;
            public ListOfPersons()
            {
                Persons = new List<Frozen>();
                Name = "";
            }

            public void Addpersonstolist(string personname, string itemname)
            {
                Frozen newperson = new Frozen(personname, itemname);
                Persons.Add(newperson);
            }
            public void PrintPerson()
            {
                foreach (Frozen personfromlist in Persons)
                {
                    Console.WriteLine($"{personfromlist.Person} wants {personfromlist.Item} for christmas!!!");
                }
            }
        }
        static void Main(string[] args)
        {
            ListOfPersons NewPerson = new ListOfPersons();
            string Filepath = @"C:\Users\stenk\samples";
            string Filename = @"Frozen.txt";
            string fullpath = Path.Combine(Filepath, Filename);
            

            string[] Personsfromfile = File.ReadAllLines(fullpath);

            foreach (string line in Personsfromfile)
            {
                string[] tempArray = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string personName = tempArray[0];
                string Itemname = tempArray[1];
               

                NewPerson.Addpersonstolist(personName, Itemname);
            }
            NewPerson.PrintPerson();

        }
    }
}
