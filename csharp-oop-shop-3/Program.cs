/*
 * Come primo esercizio focalizzatevi bene SOLO sulla classe Prodotto e sottoclasse Acqua dove potete aggiungere le seguenti Eccezioni:
 * 
 *  [x] nel costruttore di Acqua, non posso creare un’acqua se la bottiglia ha un ph negativo, oppure superiore a 10. O ancora non posso avere
 *     una capienza sopra la capienza massima o negativa e così via.
 *     
 *  [] nel metodo bevi (double litriDaBere) se l’acqua finisce, restituire un eccezione magari costruita da voi.
 *
 *  [] metodo riempi(double litri) che riempie la bottiglia di acqua e restituisce un eccezione se supero la sua capienza massima.
 *  
 *  [x] un metodo statico convertiInGalloni(double litri) che presa una quantità di litri restituisca la conversione dei litri in galloni,
 *     sapendo che 1 litro è equivalente a 3,785 galloni
 *     (ricordatevi di codificare le costanti come 3.785 nel modo corretto come visto in classe).
 *     
 * Una volta terminata la classe Prodotto e Acqua correttamente gestite anche le Eccezioni, vi chiedo di inserire
 * un attributo statico alla classe Prodotto che permetta di contare quanti Prodotti ho istanziato
 * fino ad un determinato istante nel mio programma.
 * Alla fine o durante l’esecuzione del programma principale stampare in Console l’ammontare dei prodotti creati nel vostro negozio online.
 */

using csharp_oop_shop_3;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Bevanda bottigliaDiAcqua = new(nome: "Bottiglia di acqua",
                        descrizione: "Una bottiglia contenente un litro e mezzo di acqua",
                        contenutoMassimoLitri: 1.5,
                        pH: 7,
                        liquido: "acqua",
                        prezzoBase: Prodotto.PrezzoBaseDaComplessivo(2.99, 0.08),
                        iva: 0.08);

Bevanda succoDiArancia = new(nome: "Succo all'arancia",
                        descrizione: "Una bottiglia di succo di arance, ricco di Vitamina C",
                        contenutoMassimoLitri: 2,
                        pH: 2.46,
                        liquido: "succo all'arancia",
                        prezzoBase: Prodotto.PrezzoBaseDaComplessivo(4.99, 0.05),
                        iva: 0.05);

Bevanda teAllaPesca = new(nome: "Tè alla pesca",
                        descrizione: "Una bottiglia di tè alla pesca, perfetto per l'estate",
                        contenutoMassimoLitri: 1.5,
                        pH: 3.11,
                        liquido: "tè alla pesca",
                        prezzoBase: Prodotto.PrezzoBaseDaComplessivo(4.49, 0.06),
                        iva: 0.06);

Prodotto prodottoUtente = null;

string nome, descrizione;
double prezzoBase, iva;

bool continua = true;
while (continua) {
    try {
        Console.WriteLine("Inserisci un nome per il tuo prodotto: ");
        nome = Console.ReadLine();
        Console.WriteLine("Inserisci una descrizione per il tuo prodotto: ");
        descrizione = Console.ReadLine();
        Console.WriteLine("Inserisci un prezzo per il tuo prodotto: ");
        prezzoBase = double.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci una tassa IVA da 0 a 1 per il tuo prodotto: ");
        iva = double.Parse(Console.ReadLine());

        prodottoUtente = new Prodotto(nome, descrizione, prezzoBase, iva);
        continua = false;
    } catch (System.Exception) {
        Console.WriteLine("Questi input non sono validi! Riprova.");
    }
}



List<Prodotto> prodotti = new() { bottigliaDiAcqua, succoDiArancia, teAllaPesca, prodottoUtente };
foreach (Prodotto p in prodotti) {
    Console.WriteLine(p + Environment.NewLine);
}

Console.WriteLine($"Hai creato {Prodotto.ProdottiCreati} prodotti nel tuo programma!");