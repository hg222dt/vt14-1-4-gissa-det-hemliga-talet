using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecretNumber.Model
{
    public class SecretNumber
    {
        private int _number;

        private List<int> _previousGuesses;

        private const int MaxNumberOfGuesses;


        public bool CanMakeGuess { get; }

        public int Count { get; }

        public int? Number { get; }

        public Outcome Outcome
        {
            get;
            set;
        }

        public IEnumerable<int> PreviousGuesses
        {
            get;
        }


        public void Initialize()
        {

        }

        public Outcome MakeGuess(int guess)
        {
            return this;
        }

        public SecretNumber()
        {

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