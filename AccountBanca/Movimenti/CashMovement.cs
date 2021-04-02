using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBanca.Movimenti
{
    class CashMovement : IMovement
    {
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Esecutore { get; set; }

        //Costruttore con tutti i parametri
        public CashMovement(double importo, DateTime data, string esecutore)
        {
            Importo = importo;
            DataMovimento = data;
            Esecutore = esecutore;
        }

        //Override di ToString per la stampa
        public override string ToString()
        {
            return $"Transazione con contanti:\nImporto transazione = {Importo} euro, data transazione = {DataMovimento}, Esecutore: {Esecutore}";
        }


    }
}
