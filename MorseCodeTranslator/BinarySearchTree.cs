using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
    class BinarySearchTree
    {
        public TreeNode Root { get; set; }

        public BinarySearchTree()
        {
            this.Root = null;
        }

        public void Insert(Character x)
        {
            this.Root = Insert(x, Root, x.code);
        }

        public Character Find(Character x)
        {
            Character result = Find(x, this.Root, x.code).Element;
            return result;
        }

        private Character ElementAt(TreeNode t)
        {
            return t == null ? default(Character) : t.Element;
        }

        //Recursive method
        private TreeNode Find(Character x, TreeNode t, string code)
        {
            while (t != null)
            {
                //the code contains the collection of signals that makes up the morse code for a given character
                if (code.Length > 0)
                {
                    //if current signal is dash, remove signal from code and search remaining code on the left child node
                    if (code[0].CompareTo('-') == 0)
                    {
                        code = code.Remove(0, 1);
                        return Find(x, t.Left, code);
                    }
                    //if current signal is dot, remove signal from code and search remaining code on the right child node
                    else if (code[0].CompareTo('.') == 0)
                    {
                        code = code.Remove(0, 1);
                        return Find(x, t.Right, code);
                    }
                }
                else
                    return t;
            }
            return t;
        }

        protected TreeNode Insert(Character x, TreeNode t, string code)
        {
            if (t == null)
            {
                t = new TreeNode(x);
            }
            else
                if (code.Length > 0)
            {
                if (code[0].CompareTo('-') == 0)
                {
                    code = code.Remove(0, 1);
                    t.Left = Insert(x, t.Left, code);
                }
                else if (code[0].CompareTo('.') == 0)
                {
                    code = code.Remove(0, 1);
                    t.Right = Insert(x, t.Right, code);
                }
            }
            else
            {
                throw new Exception("Duplicate item");
            }

            return t;
        }

        public override string ToString()
        {
            return this.Root.ToString();
        }


    }
}
