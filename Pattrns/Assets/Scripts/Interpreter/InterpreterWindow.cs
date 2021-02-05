using System;
using Asteroids.Command;
using UnityEngine;
using UnityEngine.UI;


namespace Asteroids.Interpreter
{
    public class InterpreterWindow : MonoBehaviour, IBaseUI
    {
        [SerializeField] private Text _text = null;
        [SerializeField] private InputField _inputField = null;

        private void Start()
        {
            _inputField.onValueChanged.AddListener(ProcessOnce);
        }

        private void ProcessOnce(string value)
        {
            if (Int64.TryParse(value, out var number))
            {
                _text.text = ToKNumbers(number);
            }
        }

        private string ToRoman(long number)
        {
            if ((number < 0) || (number > 3999))
            {
                throw new ArgumentOutOfRangeException(nameof(number), "insert value between 1 and 3999");
            }

            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);

            throw new ArgumentOutOfRangeException(nameof(number), "insert value between 1 and 3999");
        }

        private string ToKNumbers(long number)
        {
            string numberString = number.ToString();
            int pointIdx = numberString.IndexOf(".", StringComparison.Ordinal);
            
            //From like ".13" to line "123.1634"
            if (pointIdx > -1 && pointIdx < 4)
            {
                return numberString;
            }
            
            //With point, but long => after point can be erased
            if (pointIdx > -1)
            {
                numberString = numberString.Substring(0, pointIdx);
            }

            int length = numberString.Length;
            if (length > 24) return numberString.Substring(0, length - 24) + "S";
            if (length > 21) return numberString.Substring(0, length - 21) + "s";
            if (length > 18) return numberString.Substring(0, length - 18) + "Q";
            if (length > 15) return numberString.Substring(0, length - 15) + "q";
            if (length > 12) return numberString.Substring(0, length - 12) + "Т";
            if (length > 9) return numberString.Substring(0, length - 9) + "B";
            if (length > 6) return numberString.Substring(0, length - 6) + "M";
            if (length > 3) return numberString.Substring(0, length - 3) + "K";
            return numberString; //Shouldn't happen
        }
        
        public void Execute()
        {
            gameObject.SetActive(true);
        }

        public void Cancel()
        {
            gameObject.SetActive(false);
        }
    }
}
