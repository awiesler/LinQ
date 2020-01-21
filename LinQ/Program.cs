using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqQueries();
            //ChainingQueryOperators();
            ComposingLambdaExpressions();
        }

        public static void LinqQueries()
        {
            string[] names = { "Tom", "Dick", "Harry" };

            IEnumerable<string> filteredNames = System.Linq.Enumerable.Where(names, n => n.Length >= 4);

            Console.WriteLine("Namen mit weniger als 5 Zeichen:");
            foreach (string n in filteredNames)
            {
                Console.WriteLine(n);
            }

            IEnumerable<string> filteredNames2 = names.Where(n => n.Length < 4);

            Console.WriteLine("Namen mit mehr als 4 Zeichen:");
            foreach (string n in filteredNames2)
            {
                Console.WriteLine(n);
            }

            var filteredNames3 = names.Where(n => n.StartsWith("D"));

            Console.WriteLine("Namen die mit D beginnen:");
            foreach(string n in filteredNames3)
            {
                Console.WriteLine(n);
            }
        }

        public static void ChainingQueryOperators()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<string> query = names.Where(n => n.Contains("a")).OrderBy(n => n.Length).Select(n => n.ToUpper());

            foreach (string name in query) Console.WriteLine(name);

            //sweete version der ausgabe:
            IEnumerable<string> filtered = names.Where(n => n.Contains("a"));
            IEnumerable<string> sorted = filtered.OrderBy(n => n.Length);
            IEnumerable<string> finalQuery = sorted.Select(n => n.ToUpper());

            Console.WriteLine("Sweete Version:");
            Console.WriteLine("nach der Filterung:");
            foreach (string name in filtered) Console.Write(name + "|");
            Console.WriteLine();
            Console.WriteLine("nach der Sortierung:");
            foreach (string name in sorted) Console.Write(name + "|");
            Console.WriteLine();
            Console.WriteLine("das finale Ergebnis:");
            foreach (string name in finalQuery) Console.Write(name + "|");
        }

        public static void ComposingLambdaExpressions()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            IEnumerable<int> query = names.Select(n => n.Length);

            Console.WriteLine("Gibt die Länge der Namen als Wert aus:");
            foreach (string name in names) Console.Write(name + " ");
            Console.WriteLine();
            foreach (int length in query) Console.Write(length + "|");

            Console.WriteLine();
            IEnumerable<string> sortedByLength, sortedAlphabetically;
            sortedByLength = names.OrderBy(n => n.Length); // int key
            sortedAlphabetically = names.OrderBy(n => n);  // string key

            Console.WriteLine("Sortiert nach Länge:");
            foreach (string name in sortedByLength) Console.Write(name + " ");
            Console.WriteLine();
            Console.WriteLine("Sortiert nach dem Alphabet:");
            foreach (string name in sortedAlphabetically) Console.Write(name + " ");
        }
    }
}
