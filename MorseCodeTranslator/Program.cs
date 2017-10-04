using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializing processor
            var StringProcessor = new Processor();

            //capture user input
            //dot: .
            //dash: -
            //space: /
            Console.WriteLine("Please enter morse code: ");
            var message = Console.ReadLine();

            StringProcessor.Init();                                                 //initializes dictionary
            var CharacterList = StringProcessor.SplitMessageByLetters(message);      //splits message by characters
            var Results = StringProcessor.Translate(CharacterList);                 //translates each of the characters
            StringProcessor.DisplayResults(Results);                                //displays results
            Console.ReadKey();



        }
    }
}
