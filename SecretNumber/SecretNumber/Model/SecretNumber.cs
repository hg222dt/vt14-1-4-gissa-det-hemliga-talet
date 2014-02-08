using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace SecretNumber.Model
{
    public class SecretNumber
    {
        //Hemligt nummer sparas i detta fält
        private int _number;

        //Lista som innehåller alla tidigare gissningar
        private List<int> _previousGuesses;

        //Konstant som anger maximala antalet gissningar
        private const int MaxNumberOfGuesses = 7;


        //Egenskap som returnerar huruvida användaren kan göra fler gissningar eller inte
        public bool CanMakeGuess 
        { 
            get
            {
                if(Count >= MaxNumberOfGuesses)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //Egneskap som returnerar hur många gissningar som gjorts.
        public int Count 
        { 
            get
            {
                int c = 1;

                foreach(int i in PreviousGuesses)
                {
                    c++;
                }

                return c;
            }
        }

        //Egenskap som returnerar det hemliga talet, OM det inte går att göra fler gissningar.
        public int? Number 
        { 
            get
            {
                if(CanMakeGuess)
                { 
                    return null; 
                }
                else
                {
                    return _number;
                }
            }
        }

        //Egenskap av enum-typen Outcome som håller koll på senaste gissningens status.
        public Outcome Outcome { get; set; }

        //Egenskap som gör att tidigare gissningar bli läsbara utifrån objektet.
        public ReadOnlyCollection<int> PreviousGuesses
        {
            get
            {
                //Vet inte om det går att göra så. omvandla till IEnumerable??
                return _previousGuesses.AsReadOnly();
            }
        }

        //Metod som initierar ett spel genom att slumpa fram ett nytt tal, och sätter Outcome till Indefinite.
        public void Initialize()
        {            
            Random rnd = new Random();
            
            _number = rnd.Next(1, 100);

            _previousGuesses.Clear();

            Outcome = Model.Outcome.Indefinite;
        }

        //Metod som anropas när användare gör en gissning. Sätter enum-typen Outcome till rätt status beroende på gissning.
        public Outcome MakeGuess(int guess)
        {
            bool guessExcisits = false;

            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (CanMakeGuess)
                {
                    if (guess < _number)
                    {
                        Outcome = Model.Outcome.Low;
                    }
                    else if (guess > _number)
                    {
                        Outcome = Model.Outcome.High;
                    }
                    else if (guess == _number)
                    {
                        Outcome = Model.Outcome.Correct;
                    }

                    //Loopar igenom alla tidigare gissningar för att se om det gissade talet tidigare har gissats på.
                    foreach (int i in PreviousGuesses)
                    {
                        if (i == guess)
                        {
                            guessExcisits = true;
                            Outcome = Model.Outcome.PreviousGuess;
                            break;
                        }
                    }
                }
                else
                {
                    Outcome = Model.Outcome.NoMoreGuesses;
                }

                //Om gissningen inte gissats på tidigare.
                if (!guessExcisits)
                {
                    //Ytterliggare ett element läggs till listan som håller kolla på tidigare gissninger och lägger gissningens värde i detta sista element.
                    _previousGuesses.Add(guess);
                }
            }

            return Outcome;
        }

        //Konstruktor
        public SecretNumber()
        {
            //Lista för tidigare gissningar skapas.
            _previousGuesses = new List<int>();

            //Initialize anropas
            Initialize();
        }
    }

    //Enum-typ som är till för att hålla koll på senaste gissningens status.
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }
}