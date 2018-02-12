using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public Person(string name, int age)
    {
        this.age = age;
        this.name = name;
        accounts = new List<BankAccount>();
    }
    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.age = age;
        this.name = name;
        this.accounts = accounts;
    }

    public decimal GetBalance()
    {
        return accounts.Select(account => account.Balance).FirstOrDefault();
    }
}

