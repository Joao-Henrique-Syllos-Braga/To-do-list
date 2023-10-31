using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, bool> dic = new Dictionary<string, bool>();

    static void TarefaCreate()
    {
        while (true)
        {
            Console.Write("Diga qual tarefa você deseja anotar: ");
            string tarefa = Console.ReadLine();
            dic[tarefa] = false;

            Console.Write("Você deseja continuar (sim/não): ");
            string continuar = Console.ReadLine();

            if (continuar == "não")
            {
                break;
            }
            else if (continuar != "sim")
            {
                while (true)
                {
                    Console.Write("Digite um valor válido, Deseja continuar (sim/não): ");
                    string per = Console.ReadLine();

                    if (per == "sim" || per == "não")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido!");
                    }
                }
            }
        }
    }

    static void MainProgram()
    {
        while (true)
        {
            foreach (var entry in dic)
            {
                string tarefa = entry.Key;
                bool concluida = dic[tarefa];

                if (!concluida)
                {
                    Console.Write($"Você já realizou a tarefa {tarefa}: (sim/não) ");
                    string resultado = Console.ReadLine();

                    if (resultado == "sim")
                    {
                        dic[tarefa] = true;
                    }
                    else if (resultado != "não")
                    {
                        while (true)
                        {
                            Console.WriteLine("Digite um valor válido");
                            Console.Write($"Você realizou a tarefa {tarefa} (sim/não): ");
                            string per = Console.ReadLine();

                            if (per == "sim")
                            {
                                dic[tarefa] = true;
                                break;
                            }
                            else if (per == "não")
                            {
                                dic[tarefa] = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Valor inválido");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Tarefas:");
            foreach (var entry in dic)
            {
                string tarefa = entry.Key;
                bool concluida = entry.Value;
                Console.WriteLine($"{tarefa}: {(concluida ? "Concluída" : "Pendente")}");
            }

            bool todasConcluidas = true;
            foreach (var entry in dic)
            {
                if (!entry.Value)
                {
                    todasConcluidas = false;
                    break;
                }
            }

            if (todasConcluidas)
            {
                Console.WriteLine("Todas as tarefas foram concluídas.");
                break;
            }

            Console.Write("Deseja anotar mais tarefas (sim/não): ");
            string quest = Console.ReadLine();

            if (quest == "sim")
            {
                TarefaCreate();
            }
            else if (quest == "não")
            {
                Console.Write("Deseja encerrar o programa (sim/não): ");
                string encerrar = Console.ReadLine();

                if (encerrar == "sim")
                {
                    break;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        TarefaCreate();
        MainProgram();
    }
}