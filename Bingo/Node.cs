using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Node
    {
        private object info;
        private Node next, prior;

        //Valor do nó
        public object Info
        {
            get { return info;}
            set { info = value;}
        }

        //Proximo nó
        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        //Nó anterior
        public Node Prior
        {
            get { return prior; }
            set { prior = value; }
        }
    }
}
