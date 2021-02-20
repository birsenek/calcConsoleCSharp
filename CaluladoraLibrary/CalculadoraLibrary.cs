using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculadoraOperacoes
{
    public class Calculadora
    {
        JsonWriter writer;
        public Calculadora()
        {
           //gerar logs txt e json.
            StreamWriter logFileTxt = File.CreateText("calculadora.log");
            StreamWriter logFileJson = File.CreateText("calculadora.json");
            Trace.Listeners.Add(new TextWriterTraceListener(logFileTxt));
            Trace.AutoFlush = true;
            writer = new JsonTextWriter(logFileJson);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
            Trace.WriteLine("Carregando o Log da Calculadora");
            Trace.WriteLine(string.Format("Iniciado {0}", System.DateTime.Now.ToString()));
        }
        public double RealizarOperacao(double num1, double num2, string operacao)
        {
            double result = double.NaN;

            //escrever json
            writer.WriteStartObject();
            writer.WritePropertyName("Valor1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Valor2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operacao");
           
            switch (operacao)
            {
                case "1":
                    result = num1 + num2;
                    Trace.WriteLine(string.Format("{0} + {1} = {2}", num1, num2, result));
                    writer.WriteValue("Soma");
                    break;
                case "2":
                    result = num1 - num2;
                    Trace.WriteLine(string.Format("{0} - {1} = {2}", num1, num2, result));
                    writer.WriteValue("Subtracao");
                    break;
                case "3":
                    result = num1 * num2;
                    Trace.WriteLine(string.Format("{0} * {1} = {2}", num1, num2, result));
                    writer.WriteValue("Multiplicacao");
                    break;
                case "4":
                    while (num2 == 0)
                    {
                        Console.WriteLine("Impossível dividir por 0. Escolha outro valor como divisor");
                        num2 = Convert.ToDouble(Console.ReadLine());
                    }

                    result = num1 / num2;
                    Trace.WriteLine(string.Format("{0} / {1} = {2}", num1, num2, result));
                    writer.WriteValue("Divisao");
                    writer.WritePropertyName("NovoValor2");
                    writer.WriteValue(num2);
                    break;
                default:
                    break;
            }

            writer.WritePropertyName("Resultado");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        //encerrar Json
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }

}
