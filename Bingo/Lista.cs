using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{

    /// Lista duplamente ligada cicular
    class Lista
    {
        private Node listaInicio = null;
        private Node listaFim = null;

        //Retorna o primeiro nó
        public Node FirstNode
        {
            get { return listaInicio; }
        }

        //Retorna o ultimo nó
        public Node LastNode
        {
            get { return listaFim; }
        }

        //Insere um novo nó
        public void Insert(object x)
        {
            Node n = new Node();
            n.Info = x;

            if (listaInicio == null)
            {
                n.Next = n;
                n.Prior = n;
                listaInicio = n;
                listaFim = n;
            }
            else
            {
                n.Next = listaInicio;
                n.Prior = listaFim;
                listaFim.Next = n;
                listaInicio.Prior = n;
                listaFim = n;
            }
        }

        //Acha nó da lista
        public Node Find(int x)
        {
            Node p = FirstNode;

            //Índice
            int aux = x;

            //Varia o índice até achar a posição
            while (x != 0)
            {
                if (x != aux)
                    p = p.Next;
                x--;
            }
            return p;
        }

        //Remove um nó da lista
        public void Remove(Node p)
        {
            if (p == FirstNode)
                listaInicio = p.Next;
            if (p == LastNode)
                listaFim = p.Prior;
                
            p = p.Prior;
            p.Next = p.Next.Next;
            p = p.Next;
            p.Prior = p.Prior.Prior;
        }

        //Remove a lista inteira
        public void ZeraLista()
        {
            listaFim = null;
            listaInicio = null;
        }
    }
}
