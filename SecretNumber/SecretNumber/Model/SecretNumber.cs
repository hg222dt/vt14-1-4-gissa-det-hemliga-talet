using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace SecretNumber.Model
{
    public class SecretNumber
    {
        private int _number;

        private List<int> _previousGuesses;

        private const int MaxNumberOfGuesses = 7;


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

        public int Count 
        { 
            get
            {
                int c = 0;

                foreach(int i in PreviousGuesses)
                {
                    c++;
                }

                return c;
            }
        }

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

        public Outcome Outcome { get; set; }

        public ReadOnlyCollection<int> PreviousGuesses
        {
            get
            {
                //Vet inte om det går att göra så. omvandla till IEnumerable??
                return _previousGuesses.AsReadOnly();
            }
        }

        public void Initialize()
        {            
            Random rnd = new Random();
            
            //Ska eventuellt gå via egenskapen Number ist eller på något sätt validera skiten.
            _number = rnd.Next(1, 100);

            _previousGuesses.Clear();

            Outcome = Model.Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (CanMakeGuess)
                {
                    if (guess < Number)
                    {
                        Outcome = Model.Outcome.Low;
                    }
                    else if (guess > Number)
                    {
                        Outcome = Model.Outcome.High;
                    }
                    else if (guess == Number)
                    {
                        Outcome = Model.Outcome.Correct;
                    }

                    bool guessExcisits = false;

                    foreach (int i in PreviousGuesses)
                    {
                        if (i == guess)
                        {
                            guessExcisits = true;
                            Outcome = Model.Outcome.PreviousGuess;
                            break;
                        }
                    }

                    if (!guessExcisits)
                    {
                        _previousGuesses.Add(guess);
                    }
                }
                else
                {
                    Outcome = Model.Outcome.NoMoreGuesses;
                }
            }

            return Outcome;
        }

        public SecretNumber()
        {
            //Slumpa tal
            //Skapa list-objekt med sju element som ska innehålla gjorda gissningar.
            //Anropar initialize?

            //osäker på om den verkligen skapar 7 element. men låt gå. möjligtvis noll-determinerad.
            _previousGuesses = new List<int>();
            Initialize();

        }


    }

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