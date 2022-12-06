/*
 * Come primo esercizio focalizzatevi bene SOLO sulla classe Prodotto e sottoclasse Acqua dove potete aggiungere le seguenti Eccezioni:
 * 
 *  [] nel costruttore di Acqua, non posso creare un’acqua se la bottiglia ha un ph negativo, oppure superiore a 10. O ancora non posso avere
 *     una capienza sopra la capienza massima o negativa e così via.
 *     
 *  [] nel metodo bevi (double litriDaBere) se l’acqua finisce, restituire un eccezione magari costruita da voi.
 *  
 *  [] metodo riempi(double litri) che riempie la bottiglia di acqua e restituisce un eccezione se supero la sua capienza massima.
 *  
 *  [] un metodo statico convertiInGalloni(double litri) che presa una quantità di litri restituisca la conversione dei litri in galloni,
 *     sapendo che 1 litro è equivalente a 3,785 galloni (ricordatevi di codificare le costanti come 3.785 nel modo corretto come visto in classe).
 *     
 * Una volta terminata la classe Prodotto e Acqua correttamente gestite anche le Eccezioni, vi chiedo di inserire
 * un attributo statico alla classe Prodotto che permetta di contare quanti Prodotti ho istanziato fino ad un determinato istante nel mio programma.
 * Alla fine o durante l’esecuzione del programma principale stampare in Console l’ammontare dei prodotti creati nel vostro negozio online.
 */

using csharp_oop_shop_3;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Bevanda bottigliaDiAcqua = new(nome: "Bottiglia di acqua",
                        descrizione: "Una bottiglia contenente un litro e mezzo di acqua",
                        contenutoMassimoLitri: 1.5,
                        liquido: "acqua",
                        prezzoBase: Bevanda.PrezzoBaseDaComplessivo(2.99, 0.2),
                        iva: 0.2);

bottigliaDiAcqua.Apri();
bottigliaDiAcqua.Bevi(0.6);
bottigliaDiAcqua.Chiudi();