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
            //ComposingLambdaExpressions();
            //NaturalOrdering();
            //OtherOperators();
            //Sequences();
            //MixedSyntaxQueries();
            //DefferedExecution();
            //Reevaluation();
            //Reevaluation2();
            //CapturedVariables();
            Subqueries();
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

        public static void NaturalOrdering()
        {
            int[] numbers = { 10, 9, 8, 7, 6 };

            IEnumerable<int> firstThree = numbers.Take(3);
            IEnumerable<int> lastTwo = numbers.Skip(3);
            IEnumerable<int> reversed = numbers.Reverse();

            Console.WriteLine("Ausgabe der ersten 3 Zahlen:");
            foreach (int number in firstThree) Console.Write(number + " ");

            Console.WriteLine();
            Console.WriteLine("Überspringen der ersten 3 Zahlen");
            foreach (int number in lastTwo) Console.Write(number + " ");

            Console.WriteLine();
            Console.WriteLine("Umkehren der Zahlenreihe:");
            foreach (int number in reversed) Console.Write(number + " ");
        }

        public static void OtherOperators()
        {
            int[] numbers = { 10, 9, 8, 7, 6 };

            Console.WriteLine("Die Nummern sind:");
            foreach(int number in numbers) Console.Write(number + " ");
            Console.WriteLine();

            int firstNumber = numbers.First();
            Console.WriteLine("Die erste Nummer ist: " + firstNumber);

            int lastNumber = numbers.Last();
            Console.WriteLine("Die letze Nummer ist: " + lastNumber);

            int secondNumber = numbers.ElementAt(1);
            Console.WriteLine("Die zweite Nummer ist: " + secondNumber);

            int secondLowest = numbers.OrderBy(n => n).Skip(1).First();
            Console.WriteLine("Die zweitkleinste Nummer ist: " + secondLowest);

            int count = numbers.Count();
            Console.WriteLine("Anzahl der Werte: " + count);

            int min = numbers.Min();
            Console.WriteLine("Kleinster Wert: " + min);

            bool hasTheNumberNine = numbers.Contains(9);
            Console.WriteLine("Enthält die Zahl 9: " + hasTheNumberNine);

            bool hasMoreThanZeroElements = numbers.Any();
            Console.WriteLine("Enthält mehr als 0 Elemente: " + hasMoreThanZeroElements);

            bool hasAnOddElement = numbers.Any(n => n % 2 != 0);
            Console.WriteLine("Besitzt ein Odd Element: " + hasAnOddElement);
        }

        public static void Sequences()
        {
            int[] seq1 = { 1, 2, 3 };
            int[] seq2 = { 3, 4, 5 };

            Console.WriteLine("Werte in Sequenz 1: ");
            foreach (var seq in seq1) Console.Write(seq + " ");

            Console.WriteLine();
            Console.WriteLine("Werte in Sequenz 2: ");
            foreach (var seq in seq2) Console.Write(seq + " ");

            Console.WriteLine();
            IEnumerable<int> concat = seq1.Concat(seq2);
            Console.WriteLine("Sequenzen mit Concat verbunden:");
            foreach (var number in concat) Console.Write(number + " ");

            Console.WriteLine();
            IEnumerable<int> union = seq1.Union(seq2);
            Console.WriteLine("Sequenzen mit Union verbunden:");
            foreach (var number in union) Console.Write(number + " ");
        }

        public static void MixedSyntaxQueries()
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            Console.WriteLine("Anzahl der Namen die ein a enthalten:");
            var matches = (from n in names where n.Contains("a") select n).Count();
            Console.WriteLine(matches);

            Console.WriteLine("Der erste Name in alphabetischer Reihenfolge:");
            var first = (from n in names orderby n select n).First();
            Console.WriteLine(first);
        }

        public static void DefferedExecution()
        {
            var numbers = new List<int>();

            numbers.Add(1);

            IEnumerable<int> query = numbers.Select(n => n * 10);

            numbers.Add(2);

            foreach (var n in query) Console.Write(n + "|");

            Console.WriteLine();
            Action a = () => Console.WriteLine("Foo");
            // at this point the console does nothing with the Action
            a(); // the magic happens here ;)
        }

        public static void Reevaluation()
        {
            var numbers = new List<int> { 1, 2 };

            IEnumerable<int> query = numbers.Select(n => n * 10);
            foreach (var n in query) Console.Write(n + "|"); // 10|20|

            numbers.Clear();
            foreach (var n in query) Console.Write(n + "|"); // <nothing>
        }

        public static void Reevaluation2()
        {
            var numbers = new List<int> { 1, 2 };

            List<int> timesTen = numbers.Select(n => n * 10).ToList(); // executes immediately into a List<int>

            numbers.Clear();
            Console.WriteLine(timesTen.Count);
        }

        public static void CapturedVariables()
        {
            int[] numbers = { 1, 2 };

            int factor = 10;
            IEnumerable<int> query = numbers.Select(n => n * factor);
            factor = 20;
            foreach (var n in query) Console.Write(n + "|"); // 20|40|

            Console.WriteLine();
            IEnumerable<char> query2 = "Not what you might expect";
            query2 = query2.Where(c => c != 'a');
            query2 = query2.Where(c => c != 'e');
            query2 = query2.Where(c => c != 'i');
            query2 = query2.Where(c => c != 'o');
            query2 = query2.Where(c => c != 'u');
            foreach (var c in query2) Console.Write(c); // Nt wht y mght xpct

            Console.WriteLine();
            string vowels = "aeiou";
            for (int i = 0; i > vowels.Length; i++) query2 = query2.Where(c => c != vowels[i]);
            foreach (var c in query2) Console.Write(c);
        }

        public static void Subqueries()
        {
            string[] musos = { "David Gilmour", "Roger Waters", "Rick Wright", "Nick Mason" };

            IEnumerable<string> query = musos.OrderBy(m => m.Split().Last());
            foreach (var q in query) Console.WriteLine(q);

            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            IEnumerable<string> outerQuery = names.Where(n => n.Length == names.OrderBy(n2 => n2.Length).Select(n2 => n2.Length).First());
            foreach (var o in outerQuery) Console.WriteLine(o);
        }
    }
}
