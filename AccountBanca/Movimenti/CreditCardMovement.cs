using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBanca.Movimenti
{
    class CreditCardMovement : IMovement
    {
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public TipoEnum Tipo { get; set; }
        public string NumeroCarta { get; set; }

        //Costruttore con tutti i parametri
        public CreditCardMovement(double importo, DateTime data, TipoEnum tipo, string numero)
        {
            Importo = importo;
            DataMovimento = data;
            Tipo = tipo;
            NumeroCarta = numero;
        }

        //Override di ToString per la stampa
        public override string ToString()
        {
            return $"Transazione con carta di credito:\nImporto transazione = {Importo} euro, data transazione = {DataMovimento}, carta utilizzata: {Tipo} numero: {NumeroCarta}";
        }

    }

    public enum TipoEnum
    {
        AMEX,
        VISA,
        MASTERCARD,
        OTHER
    }
}
