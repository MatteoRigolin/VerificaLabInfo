//Studente: Matteo Rigolin
//Data: 13/01/2022
/* Scrivere il codice in C# per creare la classe Treni con i seguenti attributi: codtreno, tipo
(regionale, nazionale, internazionale) ,nome e costo. La classe avrà 2 metodi che calcolano il costo del mezzo
utilizzato e il costo per il suo utilizzo (calcolato dal percorso effettuato). Dalla classe si vogliono derivare 2
differenti classi: Passeggeri e Merci che avranno 2 ulteriori attributi: numvagoni e alimentazione.
Dopo aver visualizzato i dati (assegnati nel main o letti in input) calcolare e visualizzare:
1) il costo dei 2 mezzi sapendo che il costo di un mezzo generico è 100.000€ mentre per il Passeggeri è
aumentato del 25% e per il Merci aumenta del 35%;
2) il costo per il suo utilizzo, dopo aver letto in input i km effettuati, sapendo che il prezzo al km per il
treno Merci è di 100€ mentre per il Passeggeri è 150€;
3) Il costo totale dei i due mezzi. 
tempo di svolgimento 1h.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerificaLabInfo
{
    class Treni //classe madre
    {
        //attributi
        public int codtreno;
        public string tipo;
        public string nome;
        public double costo;
        //costruttore
        public Treni(int codtreno, string tipo, string nome, double costo)
        {
            this.codtreno = codtreno;
            this.tipo = tipo;
            this.nome = nome;
            this.costo = costo;
        }
        //metodi
        public virtual double costoMezzo()
        {
            costo = 100000;
            return costo;
        }
        public virtual double costoUtilizzoMezzo(int kmPercorsi)
        {
            costo = 0 * kmPercorsi;
            return costo;
        }
    }
    class Passeggeri : Treni //classe figlia 
    {
        //nuovi attributi 
        public int numvagoni;
        public double alimentazione;
        //costruttore
        public Passeggeri(int codtreno, string tipo, string nome, double costo, int numvagoni, double alimentazione) : base(codtreno, tipo, nome, costo)
        {
            this.numvagoni = numvagoni;
            this.alimentazione = alimentazione;
        }
        //metodi ereditati e modificati con l'override
        public override double costoMezzo() //costo del mezzo per il mantenimento
        {
            costo = 100000 + (100000 * 0.25);
            return costo;
        }
        public override double costoUtilizzoMezzo(int kmPercorsi) //costo del mezzo per l'utilizzo
        {
            costo = 150 * kmPercorsi;
            return costo;
        }
    }
    class Merci : Treni //classe figlia
    {
        //nuovi attributi
        public int numvagoni;
        public double alimentazione;
        //costruttore
        public Merci(int codtreno, string tipo, string nome, double costo, int numvagoni, double alimentazione) : base(codtreno, tipo, nome, costo)
        {
            this.numvagoni = numvagoni;
            this.alimentazione = alimentazione;
        }
        //metodi
        public override double costoMezzo() //costo del mezzo per il mantenimento
        {
            costo = 100000 + (100000 * 0.35);
            return costo;
        }
        public override double costoUtilizzoMezzo(int kmPercorsi) //costo del mezzo per l'utilizzo
        {
            costo = 100 * kmPercorsi;
            return costo;
        }
    }

    class Program //classe principale
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci 1 per visualizzare un treno passeggeri o 2 per un treno merci"); //l'utente sceglie quale treno visualizzare
            string risposta = Console.ReadLine();
            switch (risposta) //in base al valore inserito da tastiera passo ad una funzione diversa
            {
                case "1": nuovoTrenoPasseggeri(); break;
                case "2": nuovoTrenoMerci(); break;
            }
            Console.ReadKey();
        }

        static void nuovoTrenoPasseggeri() //funzione per creare un nuovo treno passeggeri
        {
            Passeggeri passeggeri = new Passeggeri(0, "", "", 0, 0, 0); //inizializzo un nuovo oggetto

            Console.WriteLine("Inserisci il codice del treno: "); //l'utente inserisce il codice
            passeggeri.codtreno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserisci il tipo del treno (regionale, nazionale, internazionale): "); //l'utente inserisce il tipo
            passeggeri.tipo = Console.ReadLine();

            Console.WriteLine("Inserisci il nome del treno: "); //l'utente inserisce il nome
            passeggeri.nome = Console.ReadLine();

            Console.WriteLine("Inserisci il numero di vagoni del treno: "); //l'utente inserisce il numero di vagoni
            passeggeri.numvagoni = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserisci il costo dell'alimentazione del treno: "); //l'utente inserisce il costo dell'alimentazione
            passeggeri.alimentazione = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserisci i chilometri da percorrere: "); //l'utente inserisce quanti chilometri deve percorrere il treno
            int kmPercorsi = Convert.ToInt32(Console.ReadLine());

            double costoTreno = passeggeri.costoMezzo(); //calcolo il costo per il mantenimento del treno
            double costoUtilizzoTreno = passeggeri.costoUtilizzoMezzo(kmPercorsi); //calcolo il costo per l'utilizzo del treno
            passeggeri.costo = costoTreno + costoUtilizzoTreno; //calcolo il costo totale del treno
            //mostro a schermo tutti e tre i costi
            Console.WriteLine("Costo del mezzo: " + costoTreno);
            Console.WriteLine("Costo di utilizzo del mezzo: " + costoUtilizzoTreno);
            Console.WriteLine("Costo totale del mezzo: " + passeggeri.costo);
        }

        static void nuovoTrenoMerci() //funzione per creare un nuovo treno merci
        {
            Merci merci = new Merci(0, "", "", 0, 0, 0); //inizializzo un nuovo oggetto

            Console.WriteLine("Inserisci il codice del treno: "); //l'utente inserisce il codice
            merci.codtreno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserisci il tipo del treno (regionale, nazionale, internazionale): "); //l'utente inserisce il tipo
            merci.tipo = Console.ReadLine();

            Console.WriteLine("Inserisci il nome del treno: "); //l'utente inserisce il nome
            merci.nome = Console.ReadLine();

            Console.WriteLine("Inserisci il numero di vagoni del treno: "); //l'utente inserisce il numero di vagoni
            merci.numvagoni = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserisci il costo dell'alimentazione del treno: "); //l'utente inserisce il costo dell'alimentazione
            merci.alimentazione = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserisci i chilometri da percorrere: "); //l'utente inserisce quanti chilometri deve percorrere il treno
            int kmPercorsi = Convert.ToInt32(Console.ReadLine());

            double costoTreno = merci.costoMezzo(); //calcolo il costo per il mantenimento del treno
            double costoUtilizzoTreno = merci.costoUtilizzoMezzo(kmPercorsi); //calcolo il costo per l'utilizzo del treno
            merci.costo = costoTreno + costoUtilizzoTreno; //calcolo il costo totale del treno
            //mostro a schermo tutti e tre i costi
            Console.WriteLine("Costo del mezzo: " + costoTreno);
            Console.WriteLine("Costo di utilizzo del mezzo: " + costoUtilizzoTreno);
            Console.WriteLine("Costo totale del mezzo: " + merci.costo);
        }
    }
}