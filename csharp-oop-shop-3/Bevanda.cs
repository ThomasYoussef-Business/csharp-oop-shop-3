namespace csharp_oop_shop_3 {
    public class Bevanda : Prodotto {
        // ATTRIBUTI
        private double contenutoAttuale;
        private readonly double contenutoMassimoLitri;
        private readonly string liquido;
        private bool aperta;

        // PROPRIETÀ
        public double ContenutoAttuale { get => contenutoAttuale; private set => contenutoAttuale = Math.Clamp(value, 0, ContenutoMassimoLitri); }
        public double ContenutoMassimoLitri { get => contenutoMassimoLitri; private init => contenutoMassimoLitri = Math.Max(value, 0); }
        public bool Aperta { get => aperta; private set => aperta = value; }
        public string Liquido { get => liquido; private init => liquido = value; }

        // COSTRUTTORI
        public Bevanda(string nome, string descrizione, string liquido, double contenutoMassimoLitri, double prezzoBase, double iva)
            : base(nome, descrizione, prezzoBase, iva) {
            Liquido = LiquidoValido(liquido).ToLower();
            ContenutoMassimoLitri = MassimoBevandaValido(contenutoMassimoLitri);
            Aperta = false;
            ContenutoAttuale = ContenutoMassimoLitri;
        }

        // METODI PUBBLICI
        public void Bevi(double quantoBevi) {
            if (quantoBevi is <= 0) { // Provare a bere zero o meno
                throw new ArgumentOutOfRangeException(nameof(quantoBevi), "Non puoi bere niente o meno di niente!");
            }

            if (!Aperta) { // Provare a bere da una bottiglia chiusa
                Console.WriteLine($"Provi a bere {quantoBevi} litri di {Liquido}... ma non hai aperto la bottiglia.");
                return;
            }

            Console.WriteLine($"Provi a bere {quantoBevi} litri di {Liquido}...");

            if (ContenutoAttuale is 0) { // Bottiglia già vuota
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
        /// <exception cref="ArgumentOutOfRangeException">Tirata quando <see cref="quantoRiempi"/> è 0 o negativo</exception>
        public void Riempi(double quantoRiempi) {
            if (quantoRiempi is <= 0) { // Provare a riempire la bottiglia con zero o meno
                throw new ArgumentOutOfRangeException(nameof(quantoRiempi), "Non puoi riempire la bottiglia con niente o meno di niente!");
            }

            if (!Aperta) { // La bottiglia è chiusa
                Console.WriteLine($"Provi a riempire una bottiglia di {Liquido}, ma ti sei dimenticato di aprirla...");
                return;
            }

            Console.WriteLine($"Provi a riempire una bottiglia di {Liquido} con {quantoRiempi} litri...");

            if (ContenutoAttuale.Equals(ContenutoMassimoLitri)) { // Bottiglia già piena
                Console.WriteLine("La bottiglia è già piena.");
            } else if (ContenutoAttuale + quantoRiempi > ContenutoMassimoLitri) { // Bottiglia piena dopo averla riempita
                Console.WriteLine($"Hai riempito la bottiglia di {Liquido} fino alla massima capacità.");
                ContenutoAttuale = ContenutoMassimoLitri;
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

        // METODI PRIVATI
        private static string LiquidoValido(string liquido) {
            if (!string.IsNullOrWhiteSpace(liquido)) {
                return liquido;
            } else {
                throw new ArgumentNullException(nameof(liquido), $"{nameof(liquido)} non può essere vuoto o nullo");
            }
        }
        private static double MassimoBevandaValido(double contenutoMassimoLitri) {
            if (contenutoMassimoLitri is > 0) {
                return contenutoMassimoLitri;
            } else {
                throw new ArgumentOutOfRangeException(nameof(contenutoMassimoLitri));
            }
        }
    }

    public class CapienzaInvalidaException : ArgumentOutOfRangeException {
        public CapienzaInvalidaException() : base() { }
        public CapienzaInvalidaException(string message) : base(message) { }
    }
}
