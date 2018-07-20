using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        private static int idx;

        static void Main(string[] args)
        {
            
            Console.WriteLine("Entre com a quantidade de grupos");
            var entrada1 = Console.ReadLine();
            Console.WriteLine("Entre com a matriz de grupos separado por espaço(' ') ");
            var entrada2 = Console.ReadLine();

            int aCount = Convert.ToInt32(entrada1);

            int[] grupos = Array.ConvertAll(entrada2.Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] result = solve(grupos).ToArray();

            Console.WriteLine(string.Concat("Tamanho Possiveis dos Barramentos: ", string.Join(" ", result)));

            Console.ReadLine();
        }


      

        static List<int> solve(int[] grupos)
        {

            List<int> result = new List<int>();
            var totalGrupos = 0;
            var totalSentados = 0;
            var tentativasGrupos = new List<int>();
            
            var capacidadeMinima = 0;
            var capacidadeEmbarque = 0;


            foreach (var item in grupos)
            {
                capacidadeMinima = Math.Max(capacidadeMinima, item);
                totalGrupos += item;
                tentativasGrupos.Add(totalGrupos);
            }

            Console.WriteLine("minimo: " + capacidadeMinima);
            Console.WriteLine("total: " + totalGrupos);


            foreach (var grupo in tentativasGrupos)
            {
                if (grupo < capacidadeMinima)
                    continue;
                if (totalGrupos % grupo != 0)
                    continue;
                capacidadeEmbarque = grupo;

                var amigosSentados = 0;
                totalSentados = 0;


                for (int proximoAmigo = 0; proximoAmigo < grupos.Length; proximoAmigo++)
                {
                    amigosSentados += proximoAmigo;
                    if (amigosSentados > capacidadeEmbarque)
                        break;
                    if (amigosSentados == capacidadeEmbarque)
                    {
                        totalSentados += proximoAmigo;
                        amigosSentados = 0;
                        if (totalSentados == totalGrupos)
                        {
                            result.Add(capacidadeEmbarque);
                            break;
                        }
                        continue;
                    }
                    if (totalSentados == amigosSentados)
                    {
                        result.Add(capacidadeEmbarque);
                        break;
                    }
                    totalSentados += proximoAmigo;
                }
            }
            return result;
        }
    }





}
