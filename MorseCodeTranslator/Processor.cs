using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
    class Processor
    {
        private BinarySearchTree Dictionary = new BinarySearchTree();

        //Initializes dictionary 
        public void Init() {
            //Creating the alphabet with each letter referencing a morse signal
            Character[] Alphabet = {
                       new Character {letter = "ROOT", code = ""},
                       new Character {letter = "E", code = "."},
                       new Character {letter = "T", code = "-"},
                       new Character {letter = "I", code =  ".."},
                       new Character {letter = "A", code = ".-"},
                       new Character {letter = "N", code = "-."},
                       new Character {letter = "M", code = "--"},
                       new Character {letter = "S", code = "..."},
                       new Character {letter = "U", code = "..-"},
                       new Character {letter = "R", code = ".-."},
                       new Character {letter = "W", code = ".--"},
                       new Character {letter = "D", code = "-.."},
                       new Character {letter = "K", code = "-.-"},
                       new Character {letter = "G", code = "--."},
                       new Character {letter = "O", code = "---"},
                       new Character {letter = "H", code = "...."},
                       new Character {letter = "V", code = "...-"},
                       new Character {letter = "F", code = "..-."},
                       new Character {letter = "L", code = ".-.."},
                       new Character {letter = "P", code = ".--."},
                       new Character {letter = "J", code = ".---"},
                       new Character {letter = "B", code = "-..."},
                       new Character {letter = "X", code = "-..-"},
                       new Character {letter = "C", code = "-.-."},
                       new Character {letter =  "Y", code = "-.--"},
                       new Character {letter = "Z", code = "--.."},
                       new Character{letter = "Q", code = "--.-"}
                    };

            //Creating the dictionary of words with a binary search tree

            foreach (Character letter in Alphabet)
            {
                Dictionary.Insert(letter);
            }
        }

        //Splitting message into its characters. If original message is --/---/..-/.../.
        //It will be transformed to:
        //[--]
        //[---]
        //[..-]
        //[...]
        //[.]
        public List<Character> SplitMessageByLetters(string message) {
            var Characters = new List<Character>();            string signal = "";



            //for each character in the message
            for (int i = 0; i < message.Length; i++)
            {
                //if end of message, create a new Character object with the last signals and add it to list of characters
                if (i == message.Length - 1)
                {
                    Characters.Add(new Character()
                    {
                        code = string.Concat(signal, message[i])
                    });
                }
                //Add signal to character variable until meeting the "/" key
                else if (message[i].CompareTo('/') != 0)
                {
                    signal = string.Concat(signal, message[i]);
                }
                //When meeting the "/" key, create a new Alphabet object and add it to the list of characters
                else
                {
                    Characters.Add(new Character()
                    {
                        code = signal
                    });
                    signal = "";
                }
            }

            return Characters;
        }

        //searching each word in the tree
        public List<string> Translate(List<Character> wordSplit) {
            var Results = new List<string>();
            foreach (Character word in wordSplit)
            {
                string myletter = Dictionary.Find(word).letter;
                Results.Add(myletter);
            }

            return Results;
        }

        public void DisplayResults(List<string> results) {
            foreach (string w in results)
            {
                Console.WriteLine("Value: {0}", w);
            }
        }

    }
}
