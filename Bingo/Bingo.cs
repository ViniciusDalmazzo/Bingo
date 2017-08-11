using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Bingo
    {
        Lista listaBingo = new Lista();

        //Insere valores padrões na lista do bingo
        public void InsereBingo()
        {
            int i;

            for (i = 0; i < 75; i++)
            {
                listaBingo.Insert(i + 1);
            }
        }

        //Retorna os valores aleatórios dentro de um hash table
        //Remove valor já sortiado
        public Lista NumSortiados(int qtd)
        {
            Random r = new Random();
            Lista nums = new Lista();
            Node aux;
            int i, count = 100;

            for (i = 0; i < qtd; i++)
            {
                aux = listaBingo.Find(r.Next(1, count));
                nums.Insert(aux.Info);
                listaBingo.Remove(aux);
                count--;
            }
            return nums;
        }

        

        //Zera lista
        public void ZeraLista()
        {
            listaBingo.ZeraLista();
        }
    }
}
