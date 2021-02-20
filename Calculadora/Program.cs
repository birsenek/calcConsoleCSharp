using System;
using CalculadoraOperacoes;

namespace CalculadoraProgram
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Calculadora _calculadora = new Calculadora();
            //Operações
            bool encerrarApp = false;

            Console.WriteLine("Calculadora C#");
            Console.WriteLine("------------------------");

            while (!encerrarApp)
            {
                string numInput1 = null;
                double newInput1 = 0;
                string numInput2 = null;
                double newInput2 = 0;
                double result = 0;
                string operacao = null;

                while (!double.TryParse(numInput1, out newInput1))
                {
                    Console.WriteLine("Digite um número e pressione ENTER.");
                    numInput1 = Console.ReadLine();
                }

                while (!double.TryParse(numInput2, out newInput2))
                {
                    Console.WriteLine("Digite outro número e pressione ENTER.");
                    numInput2 = Console.ReadLine();
                }

                //Menu de Escolha
                bool operacaoEscolhida = false;
                string[] operacoesPossiveis = {"1", "2", "3", "4"};

                Console.WriteLine("Escolha uma operação da lista:");
                Console.WriteLine($"{operacoesPossiveis[0]} - Soma");
                Console.WriteLine($"{operacoesPossiveis[1]} - Subtração");
                Console.WriteLine($"{operacoesPossiveis[2]} - Multiplicação");
                Console.WriteLine($"{operacoesPossiveis[3]} - Divisão");
                Console.WriteLine("Opção escolhida: ");

                //validação escolhas
                while (!operacaoEscolhida)
                {
                    operacao = Console.ReadLine();
                    foreach (string op in operacoesPossiveis)
                    {
                        if (op.Equals(operacao))
                        {
                            operacaoEscolhida = true;
                            break;
                        }
                    }
                    if (!operacaoEscolhida)
                        Console.WriteLine("Operação inválida, escolha outro valor.");
                }

                try
                {
                    result = _calculadora.RealizarOperacao(newInput1, newInput2, operacao);
                    Console.WriteLine("Resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Errou!!" + e.Message);
                }

                //Aguardar ação do usuário para encerrar
                bool novaOperacao = false;
                while (!novaOperacao)
                {
                    Console.Write("Deseja Realizar outra operação? Pressione S para Sim ou N para Não. ");
                    string finalizarCalculadora = Console.ReadLine();
                    if (finalizarCalculadora == "n")
                    {
                        encerrarApp = true;
                        break;
                    }
                    else if (finalizarCalculadora == "s")
                    {
                        Console.WriteLine("Reiniciando variáveis. \n");
                        novaOperacao = true;
                    }
                }
            }
            Console.WriteLine("Encerrando.");

            _calculadora.Finish();
        }
    }
}