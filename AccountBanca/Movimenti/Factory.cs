using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBanca.Movimenti
{
    class Factory
    {
        //In questa factory effettuo i prelievi/versamenti con il tipo scelto dall'utente (contanti, bonifico, carta)
        public static void FactoryMovement(int op, int tipo, Account account)
        {
            //op = 1 deposito, op = 2 prelievo
            //tipo = 1 bonifico, tipo = 2 contanti, tipo = 3 carta

            IMovement movimento = null;

            //Variabile utilizzata per il TryPArse
            bool corretto = true;
            switch (op)
            {
                //Deposito
                case 1:
                    //Contanti, carta o bonifico
                    switch (tipo)
                    {
                        //Bonifico
                        case 1:
                            Console.WriteLine("Inserisci l'importo:");
                            double importo = 0;
                            do
                            {
                                if (corretto == false)
                                    Console.WriteLine("Operazione non disponibile, riprova:");
                                corretto = Double.TryParse(Console.ReadLine(), out importo);
                            } while (corretto == false);
                            Console.WriteLine("Banca d'origine:");
                            string bancaO = Console.ReadLine();
                            //La banca di origine deve essere uguale a quella del conto
                            while(bancaO.ToLower().Trim() != account.NomeBanca.ToLower().Trim())
                            {
                                Console.WriteLine("La banca d'origine deve essere uguale a quella del conto, riprova:");
                                bancaO = Console.ReadLine();
                            };
                            Console.WriteLine("Banca di destinazione:");
                            string bancaD = Console.ReadLine();
                            movimento = new TransfertMovement(importo, DateTime.Now, bancaO, bancaD);
                            break;
                        //Contanti
                        case 2:
                            Console.WriteLine("Inserisci l'importo:");
                            double importo2 = 0;
                            do
                            {
                                if (corretto == false)
                                    Console.WriteLine("Operazione non disponibile, riprova:");
                                corretto = Double.TryParse(Console.ReadLine(), out importo2);
                            } while (corretto == false);
                            Console.WriteLine("Nome dell'esecutore:");
                            string esecutore = Console.ReadLine();
                            movimento = new CashMovement(importo2, DateTime.Now, esecutore);
                            break;
                        //Carta
                        case 3:
                            Console.WriteLine("Inserisci l'importo:");
                            double importo3 = 0;
                            do
                            {
                                if (corretto == false)
                                    Console.WriteLine("Operazione non disponibile, riprova:");
                                corretto = Double.TryParse(Console.ReadLine(), out importo3);
                            } while (corretto == false);
                            Console.WriteLine("Tipo di carta:\n" +
                                "1 - AMEX,\n" +
                                "2 - VISA,\n" +
                                "3 - MASTERCARD,\n" +
                                "4 - OTHER");
                            int carta = 1;
                            do
                            {
                                if (corretto == false || carta < 1 || carta > 4)
                                    Console.WriteLine("Carta non disponibile, riprova:");
                                corretto = Int32.TryParse(Console.ReadLine(), out carta);
                            } while (corretto == false || carta < 1 || carta > 4);
                            TipoEnum tipoCarta = (TipoEnum)carta - 1;
                            Console.WriteLine("Numero della carta:");
                            string numeroCarta = Console.ReadLine();
                            movimento = new CreditCardMovement(importo3, DateTime.Now, tipoCarta, numeroCarta);
                            break;
                    }
                    account += movimento;
                    break;
                //Prelievo
                case 2:
                    //Contanti, carta o bonifico
                    switch (tipo)
                    {
                        //Bonifico
                        case 1:
                            Console.WriteLine("Inserisci l'importo:");
                            double importo = 0;
                            do
                            {
                                if (corretto == false)
                                    Console.WriteLine("Operazione non disponibile, riprova:");
                                corretto = Double.TryParse(Console.ReadLine(), out importo);
                            } while (corretto == false);
                            Console.WriteLine("Banca d'origine:");
                            string bancaO = Console.ReadLine();
                            //La banca di origine deve essere uguale a quella del conto
                            while (bancaO.ToLower().Trim() != account.NomeBanca.ToLower().Trim())
                            {
                                Console.WriteLine("La banca d'origine deve essere uguale a quella del conto, riprova:");
                                bancaO = Console.ReadLine();
                            };
                            Console.WriteLine("Banca di destinazione:");
                            string bancaD = Console.ReadLine();
                            movimento = new TransfertMovement(importo, DateTime.Now, bancaO, bancaD);                            break;
                        //Contanti
                        case 2:
                            Console.WriteLine("Inserisci l'importo:");
                            double importo2 = 0;
                            do
                            {
                                if (corretto == false)
                                    Console.WriteLine("Operazione non disponibile, riprova:");
                                corretto = Double.TryParse(Console.ReadLine(), out importo2);
                            } while (corretto == false);
                            Console.WriteLine("Nome dell'esecutore:");
                            string esecutore = Console.ReadLine();
                            movimento = new CashMovement(importo2, DateTime.Now, esecutore);
                            break;
                        //Carta
                        case 3:
                            Console.WriteLine("Inserisci l'importo:");
                            double importo3 = 0;
                            do
                            {
                                if (corretto == false)
                                    Console.WriteLine("Operazione non disponibile, riprova:");
                                corretto = Double.TryParse(Console.ReadLine(), out importo3);
                            } while (corretto == false);

                            Console.WriteLine("Tipo di carta:\n" +
                                "1 - AMEX,\n" +
                                "2 - VISA,\n" +
                                "3 - MASTERCARD,\n" +
                                "4 - OTHER");
                            int carta = 1;
                            do
                            {
                                if (corretto == false || carta < 1 || carta > 4)
                                    Console.WriteLine("Carta non disponibile, riprova:");
                                corretto = Int32.TryParse(Console.ReadLine(), out carta);
                            } while (corretto == false || carta < 1 || carta > 4);
                            TipoEnum tipoCarta = (TipoEnum)carta - 1;
                            Console.WriteLine("Numero della carta:");
                            string numeroCarta = Console.ReadLine();
                            movimento = new CreditCardMovement(importo3, DateTime.Now, tipoCarta, numeroCarta);
                            break;
                    }
                    account -= movimento;
                    break;
            }

        }
    }
}
