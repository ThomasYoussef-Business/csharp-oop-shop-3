﻿using TipiCustom;

namespace csharp_oop_shop_3 {
    public class Bevanda : Prodotto {
        // COSTANTI
        public const double GalloniPerLitro = 3.785; // I valori costanti sono anche static in modo implicito
        // "public static readonly double GalloniPerLitro" è uguale a quanto scritto sopra

        // ATTRIBUTI
        private Litri contenutoAttuale;
        private readonly Litri capienzaMassimaLitri;
        private readonly string liquido;
        private readonly pH pH;

        // STATO
        private bool aperta;

        // PROPRIETÀ
        public Litri ContenutoAttuale { get => contenutoAttuale; private set => contenutoAttuale = value; }
        public Litri CapienzaMassimaLitri { get => capienzaMassimaLitri; private init => capienzaMassimaLitri = value; }
        public pH PH { get => pH; private init => pH = value; }
        public bool Aperta { get => aperta; private set => aperta = value; }
        public string Liquido { get => liquido; private init => liquido = value; }

        // COSTRUTTORI
        public Bevanda(string nome, string descrizione, string liquido, Litri contenutoMassimoLitri, pH pH, double prezzoBase, double iva)
            : base(nome, descrizione, prezzoBase, iva) {
            Liquido = LiquidoValido(liquido).ToLower();
            CapienzaMassimaLitri = contenutoMassimoLitri;
            PH = pH;
            Aperta = false;
            ContenutoAttuale = CapienzaMassimaLitri;
        }

        // METODI PUBBLICI
        public void Bevi(Litri quantoBevi) {
            if (quantoBevi <= 0) { // Provare a bere zero o meno
                throw new ArgumentOutOfRangeException(nameof(quantoBevi), "Non puoi bere niente o meno di niente!");
            }

            if (!Aperta) { // Provare a bere da una bottiglia chiusa
                Console.WriteLine($"Provi a bere {quantoBevi} litri di {Liquido}... ma non hai aperto la bottiglia.");
                return;
            }

            Console.WriteLine($"Provi a bere {quantoBevi} litri di {Liquido}...");

            if (ContenutoAttuale == 0) { // Bottiglia già vuota
                Console.WriteLine($"La bottiglia di {Liquido} è vuota, non hai potuto berne il contenuto.");
            } else if (ContenutoAttuale - quantoBevi is <= 0) { // Bottiglia svuotata dopo che hai bevuto il contenuto
                Console.WriteLine($"Hai bevuto {ContenutoAttuale} litri e svuotato tutto il contenuto della bottiglia, non c'è altro da bere");
                ContenutoAttuale = 0;
            } else { // Bottiglia non vuota dopo aver bevuto
                ContenutoAttuale -= quantoBevi;
                Console.WriteLine($"Hai bevuto {quantoBevi} di {Liquido}. C'è ancora {ContenutoAttuale} di {Liquido} nella bottiglia");
            }

        }

        /// <summary>
        /// Metodo per provare a riempire la bottiglia di una bevanda
        /// </summary>
        /// <param name="quantoRiempi">Quanto riempi la tua bevanda in litri</param>
        /// <exception cref="ArgumentOutOfRangeException">Tirata quando <see cref="quantoRiempi"/> è zero o negativo</exception>
        public void Riempi(Litri quantoRiempi) {
            if (quantoRiempi <= 0) { // Provare a riempire la bottiglia con zero o meno
                throw new ArgumentOutOfRangeException(nameof(quantoRiempi), "Non puoi riempire la bottiglia con niente o meno di niente!");
            }

            if (!Aperta) { // La bottiglia è chiusa
                Console.WriteLine($"Provi a riempire una bottiglia di {Liquido}, ma ti sei dimenticato di aprirla...");
                return;
            }

            Console.WriteLine($"Provi a riempire una bottiglia di {Liquido} con {quantoRiempi} litri...");

            if (ContenutoAttuale.Equals(CapienzaMassimaLitri)) { // Bottiglia già piena
                Console.WriteLine("La bottiglia è già piena.");
            } else if (ContenutoAttuale + quantoRiempi > CapienzaMassimaLitri) { // Bottiglia piena dopo averla riempita
                Console.WriteLine($"Hai riempito la bottiglia di {Liquido} fino alla massima capacità.");
                ContenutoAttuale = CapienzaMassimaLitri;
            } else { // Bottiglia con ancora dello spazio dopo questa operazione
                Console.WriteLine($"Hai riempito la bottiglia di {Liquido} con {quantoRiempi} litri.");
                ContenutoAttuale += quantoRiempi;
            }
        }

        public void Apri() {
            Aperta = true;
        }

        public void Chiudi() {
            Aperta = false;
        }

        public static double ConvertiInGalloni(double litri) => litri * GalloniPerLitro;

        // METODI PRIVATI
        private static string LiquidoValido(string liquido) {
            if (!string.IsNullOrWhiteSpace(liquido)) {
                return liquido;
            } else {
                throw new LiquidoInvalido(nameof(liquido), $"{nameof(liquido)} non può essere vuoto o nullo.");
            }
        }
    }

    public class CapienzaInvalidaException : ArgumentOutOfRangeException {
        public CapienzaInvalidaException() : base() { }
        public CapienzaInvalidaException(string paramName) : base(paramName) { }
        public CapienzaInvalidaException(string paramName, string message) : base(paramName, message) { }
    }

    public class LiquidoInvalido : ArgumentNullException {
        public LiquidoInvalido() : base() { }
        public LiquidoInvalido(string paramName) : base(paramName) { }
        public LiquidoInvalido(string paramName, string message) : base(paramName, message) { }
    }

}
