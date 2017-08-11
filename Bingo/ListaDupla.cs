using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{

    /// Lista duplamente ligada encadeada
    class ListaDupla
    {
        private Node lista;
        private int count;

        //retorna o primeiro nó
        public Node FirstNode
        {
            get { return lista; }
        }

        //retorna o count
        public int Count
        {
            get { return count; }
        }

        // Construtor
        public ListaDupla()
        {
            lista = null;
            count = 0;
        }

        //Insere um novo nó
        public void Insert(object x)
        {
            Node n = new Node();
            n.Info = x;
            n.Next = null;
            n.Prior = null;
            count++;

            if (lista == null)
            {
                lista = n;
                n.Next = n;
                n.Prior = n;
            }
        }
    }
}
