using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBanca.Movimenti
{
    class TransfertMovement : IMovement
    {
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }

        //Costruttore con tutti i parametri
        public TransfertMovement(double importo, DateTime data, string bancaO, string bancaD)
        {
            Importo = importo;
            DataMovimento = data;
            BancaDestinazione = bancaD;
            BancaOrigine = bancaO;
        }

        //Override del metodo ToString per la stampa
        public override string ToString()
        {
            return $"Transazione con bonifico:\nImporto transazione = {Importo} euro, data transazione = {DataMovimento}, Banca d'origine: {BancaOrigine} - Banca di destinazione: {BancaDestinazione}";
        }
    }
}
