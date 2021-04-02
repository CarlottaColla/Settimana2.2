using AccountBanca.Movimenti;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBanca.MenuUtente
{
    class Menu
    {
        public static void MostraMenu()
        {
            Console.WriteLine("Benvenuto! Inserisci i tuoi dati:");
            Console.WriteLine("Nome della Banca:");
            string nome = Console.ReadLine();
            Console.WriteLine("Numero di conto:");
            string numero = Console.ReadLine();
            Account account = new Account(nome, numero);

            string esci = null;
            do
            {
                //Cancello la console a ogni transazione
                Console.Clear();
                //Operazioni possibili
                Console.WriteLine("Scegli il numero dall'operazione che vuoi effettura:\n" +
                    "1 - Deposito\n" +
                    "2 - Prelievo");
                bool corretto = true;
                int op = 1;
                do
                {
                    if (corretto == false || op < 1 || op > 2)
                        Console.WriteLine("Operazione non disponibile, riprova:");
                    corretto = Int32.TryParse(Console.ReadLine(), out op);
                } while (corretto == false || op < 1 || op > 2);

                Console.WriteLine("In che modo vuoi depositare?\n" +
                            "1 - Bonifico\n" +
                            "2 - Contanti\n" +
                            "3 - Carta di credito");
                int tipo = 1;
                do
                {
                    if (corretto == false || tipo < 1 || tipo > 3)
                        Console.WriteLine("Operazione non disponibile, riprova:");
                    corretto = Int32.TryParse(Console.ReadLine(), out tipo);
                } while (corretto == false || tipo < 1 || tipo > 3);

                Factory.FactoryMovement(op, tipo, account);

                //Stampa il resconto
                Console.WriteLine("\nResoconto delle operazioni:");
                account.Statement();
                //L'utente può decidere di effettuare altre operazioni o chiudere l'applicazione
                Console.WriteLine("\nPremi q per uscire, altrimenti continua");
                esci = Console.ReadLine();
            } while (esci != "q");
        }
    }
}
