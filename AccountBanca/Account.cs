using AccountBanca.Movimenti;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AccountBanca
{
    class Account
    {
        public string NumeroConto { get; set; }
        public string NomeBanca { get; set; }
        public double Saldo { get; set; } = 0.0;
        public DateTime UltimaOperazione { get; set; }

        //Salvo lo storico di tutti i movimenti
        public List<IMovement> Movimenti = new List<IMovement>();

        //Costruttori
        public Account(string banca, string numero)
        {
            NumeroConto = numero;
            NomeBanca = banca;
            //Il saldo iniziale è 0.0
            //La data dell'ultima operazione viene settata con il valore di default
            //La lista di movimenti è vuota
        }


        //Overload degli operatori + e -
        public static Account operator +(Account account, IMovement movimento)
        {
            account.Movimenti.Add(movimento);
            account.Saldo += movimento.Importo;
            account.UltimaOperazione = movimento.DataMovimento;
            Console.WriteLine("Deposito effettuato con successo");
            return account;
        }

        public static Account operator -(Account account, IMovement movimento)
        {
            //Il saldo può andare in negativo
            account.Saldo -= movimento.Importo;
            //Lo aggiungo con il meno davanti perchè è un prelievo
            movimento.Importo *= (-1);
            account.Movimenti.Add(movimento);
            account.UltimaOperazione = movimento.DataMovimento;
            Console.WriteLine("Prelievo effettuato con successo");
            return account;
        }

        //Stampa i dati del conto con la lista dei movimenti
        public void Statement()
        {
            //Dati del conto
            Console.WriteLine($"Nome della banca: {NomeBanca}\n" +
                $"Numero del conto: {NumeroConto}\n" +
                $"Saldo disponibile : {Saldo}\n" +
                $"Data ultima operazione: {UltimaOperazione}");
            //Stampa della lista dei movimenti
            Console.WriteLine("Lista dei movimenti:");
            if (Movimenti.Count == 0)
                Console.WriteLine("Nessun movimento effettuato");
            else
            {
                foreach (var item in Movimenti)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
