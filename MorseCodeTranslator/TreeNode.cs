using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTranslator
{
    class TreeNode
    {
        public Character Element { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(Character element)
        {
            this.Element = element;
        }

        public override string ToString()
        {
            string nodeString = "[" + this.Element.letter + " ";

            // Leaf node
            if (this.Left == null && this.Right == null)
            {
                nodeString += " (Leaf) ";
            }

            if (this.Left != null)
            {
                nodeString += "Left: " + this.Left.ToString();
            }

            if (this.Right != null)
            {
                nodeString += "Right: " + this.Right.ToString();
            }

            nodeString += "] ";

            return nodeString;
        }
    }
}
