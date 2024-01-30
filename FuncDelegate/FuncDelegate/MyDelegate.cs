using System.Text;
using System.Xml.Linq;


namespace FuncDelegate
{
    internal class MyDelegate
    {
        static async Task Main(string[] args)
        {
            ///*
            // * Delegate without a Lambda
            // */
            // Func with no input parameters and int return type
            Func<string, string> upper = UppercaseTheString;
            string UppercaseTheString(string inputString)
            {
                return inputString.ToUpper();
            }

            Console.WriteLine(upper("lowercase letters"));
            Console.WriteLine("Click any key to continue");
            Console.Write(Console.ReadLine());
            ///*
            // * Lambda Function that receives no parameters and returns a random number.
            // */
            // Func with no input parameters and int return type
            Func<int> getRandomNumber = () =>
            {
                Random random = new Random();
                return random.Next(1, 101); // Returns a random number between 1 and 100
            };

            int randomNumber = getRandomNumber();
            Console.WriteLine("Random Number: " + randomNumber);

            // Example 2: Func with no input parameters and string return type
            Func<string> getGreeting = () => "Hello, World!";

            string greeting = getGreeting();
            Console.WriteLine("Greeting: " + greeting);
            Console.WriteLine("Click any key to continue");
            Console.Write(Console.ReadLine());


            ///*
            // * Lambda Function that receives a string and returns a character count to the console.
            // */
            Func<string, Task> CharacterCount = async (string input) =>
            {
                var formattedString = String.Format("The sentence: '{0}' has {1} characters in it.", input, input.Length);
                Console.WriteLine(formattedString);

            };

            await CharacterCount("This is a sentence.");
            await CharacterCount("This is a longer sentence");
            Console.WriteLine("Click any key to continue");
            Console.Write(Console.ReadLine());

            // ---------------------------------------------------------------------------------------------------------------
            /*
             * Lambda Function that receives an object, parses it, and writes a formatted string to the console.
             */
            Func<Receipt, Task> PrintReceipt = async (Receipt input) =>
            {
                var formattedString = String.Format("Name: {0} and the amount paid is {1:C2}", input.Name, input.Amount);
                Console.WriteLine(formattedString);

            };

            await PrintReceipt(new Receipt() { Name = "Jimbo", Amount = 39.99 });
            await PrintReceipt(new Receipt() { Name = "Conor", Amount = 99.99 });
            Console.WriteLine("Click any key to continue");
            Console.Write(Console.ReadLine());
            // --------------------------------------------------------------------------------------------------------------
            /*
             * Lambda Function that receives a string and adds it to a list.
             */
            var myList = new List<string>();
            Func<string, Task> AddToList = async (string input) => {
                myList.Add(input);  

            };

            await AddToList("First");
            await AddToList("Second");
            Console.WriteLine(String.Format("There are currently {0} elements in my list.",myList.Count));
            Console.WriteLine("Click any key to continue");
            Console.Write(Console.ReadLine());

            // --------------------------------------------------------------------------------------------------------------
            /*
             * Lambda Function that receives 2 integers, adds them together, determines and returns if the sum is even or odd.
             */

            Func<double, double, bool> IsSumEven = (a, b) => (a + b) % 2 ==0;
           

            Console.WriteLine(String.Format("Is the sum of 1 + 2 is a even number? {0}", IsSumEven(1.0, 2.0)));
            Console.WriteLine(String.Format("Is the sum of 2 + 2 is a even number? {0}", IsSumEven(2, 2)));
            Console.Write(Console.ReadLine());

        }
    }
    public class Receipt
    {
        public string Name { get; set; }
        public double Amount { get; set; }
    }
}