using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        string command;
        var dictClients = new Dictionary<int, BankAccount>();

        while ((command = Console.ReadLine()) != "End")
        {
            var cmdArgs = command.Split().ToArray();

            var cmdType = cmdArgs[0];
            switch (cmdType)
            {
                case "Create":
                    Create(cmdArgs, dictClients);
                    break;
                case "Deposit":
                    Deposit(cmdArgs, dictClients);
                    break;
                case "Withdraw":
                    Withdraw(cmdArgs, dictClients);
                    break;
                case "Print":
                    Print(cmdArgs, dictClients);
                    break;
            }
        }
    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> dictClients)
    {
        var id = int.Parse(cmdArgs[1]);

        if (dictClients.ContainsKey(id))
        {
            Console.WriteLine(dictClients[id]);
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> dictClients)
    {
        var id = int.Parse(cmdArgs[1]);
        var withdraw = decimal.Parse(cmdArgs[2]);
        if (!dictClients.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            if (dictClients[id].Balance < withdraw)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                dictClients[id].Withdraw(withdraw);
            }
        }
    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> dictClients)
    {
        var id = int.Parse(cmdArgs[1]);
        var deposit = decimal.Parse(cmdArgs[2]);
        if (!dictClients.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            dictClients[id].Deposit(deposit);
        }
    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> dictClients)
    {
        var id = int.Parse(cmdArgs[1]);
        if (dictClients.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.Id = id;
            dictClients.Add(id, acc);
        }
    }


}
