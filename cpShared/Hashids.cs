using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace cpShared.HashIds
{
    //https://github.com/ullmark/hashids.net/blob/master/Hashids.net/Hashids.cs

    /// <summary>
    /// Generate YouTube-like hashes from one or many numbers. Use hashids when you do not want to expose your database ids to the user.
    /// </summary>
    public class Hashids
    {
        public const string DEFAULT_ALPHABET = "ABCDEFGHJKLMNPQRSTUVWXYZ1234567890";
        public const string DEFAULT_SEPS = "CFHSTU";
        public const string ORIGINAL_ALPHABET = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public const string ORIGINAL_SEPS = "cfhistuCFHISTU";

        private const int _min_alphabet_length = 16;
        private const double _sep_div = 3.5;
        private const double _guard_div = 12.0;

        private string _alphabet;
        private string _salt;
        private string _seps;
        private string _guards;
        private int _minHashLength;

        private Regex _guardsRegex;
        private Regex _sepsRegex;
        private static Regex _hexValidator = new Regex("^[0-9a-fA-F]+$", RegexOptions.Compiled);
        private static Regex _hexSplitter = new Regex(@"[\w\W]{1,12}", RegexOptions.Compiled);

        /// <summary>
        /// Instantiates a new Hashids with the default setup.
        /// </summary>
        public Hashids()
            : this(string.Empty, 0, DEFAULT_ALPHABET, DEFAULT_SEPS)
        { }

        /// <summary>
        /// Instantiates a new Hashids en/de-crypter.
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="minHashLength"></param>
        /// <param name="alphabet"></param>
        /// <param name="seps"></param>
        public Hashids(string salt = "", int minHashLength = 0, string alphabet = DEFAULT_ALPHABET, string seps = DEFAULT_SEPS)
        {
            if (string.IsNullOrWhiteSpace(alphabet))
                throw new ArgumentNullException("alphabet");

            _salt = salt;
            _alphabet = string.Join(string.Empty, alphabet.Distinct());
            _seps = seps;
            _minHashLength = minHashLength;

            if (_alphabet.Length < 16)
                throw new ArgumentException("alphabet must contain atleast 4 unique characters.", "alphabet");

            SetupSeps();
            SetupGuards();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetupSeps()
        {
            // seps should contain only characters present in alphabet; 
            _seps = new string(_seps.Intersect(_alphabet.ToArray()).ToArray());

            // alphabet should not contain seps.
            _alphabet = new string(_alphabet.Except(_seps.ToArray()).ToArray());

            _seps = ConsistentShuffle(_seps, _salt);

            if (_seps.Length == 0 || _alphabet.Length / _seps.Length > _sep_div)
            {
                var sepsLength = (int)Math.Ceiling(_alphabet.Length / _sep_div);
                if (sepsLength == 1)
                    sepsLength = 2;

                if (sepsLength > _seps.Length)
                {
                    var diff = sepsLength - _seps.Length;
                    _seps += _alphabet.Substring(0, diff);
                    _alphabet = _alphabet.Substring(diff);
                }

                else _seps = _seps.Substring(0, sepsLength);
            }

            _sepsRegex = new Regex(string.Concat("[", _seps, "]"), RegexOptions.Compiled);
            _alphabet = ConsistentShuffle(_alphabet, _salt);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetupGuards()
        {
            var guardCount = (int)Math.Ceiling(_alphabet.Length / _guard_div);

            if (_alphabet.Length < 3)
            {
                _guards = _seps.Substring(0, guardCount);
                _seps = _seps.Substring(guardCount);
            }

            else
            {
                _guards = _alphabet.Substring(0, guardCount);
                _alphabet = _alphabet.Substring(guardCount);
            }

            _guardsRegex = new Regex(string.Concat("[", _guards, "]"), RegexOptions.Compiled);
        }

        /// <summary>
        /// Encrypts the provided hex string to a hashids hash.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public virtual string EncodeHex(string hex)
        {
            if (!_hexValidator.IsMatch(hex))
                return string.Empty;

            var numbers = new List<int>();
            var matches = _hexSplitter.Matches(hex);

            foreach (Match match in matches)
            {
                var number = Convert.ToInt32(string.Concat("1", match.Value), 16);
                numbers.Add(number);
            }

            return Encode(numbers.ToArray());
        }


        /// <summary>
        /// Decodes the provided hash into a hex-string
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public virtual string DecodeHex(string hash)
        {
            var ret = new StringBuilder();
            var numbers = Decode(hash);

            foreach (var number in numbers)
                ret.Append(string.Format("{0:X}", number).Substring(1));

            return ret.ToString();
        }

        /// <summary>
        /// Encodes the provided numbers into a string
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public virtual string Encode(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return string.Empty;

            string ret;
            var alphabet = _alphabet;

            int numbersHashInt = 0;
            for (var i = 0; i < numbers.Length; i++)
                numbersHashInt += numbers[i] % (i + 100);

            var lottery = alphabet[numbersHashInt % alphabet.Length];
            ret = lottery.ToString();

            for (var i = 0; i < numbers.Length; i++)
            {
                var number = numbers[i];
                var buffer = lottery + _salt + alphabet;

                alphabet = ConsistentShuffle(alphabet, buffer.Substring(0, alphabet.Length));
                var last = Hash(number, alphabet);

                ret += last;

                if (i + 1 < numbers.Length)
                {
                    number %= last[0] + i;
                    var sepsIndex = number % _seps.Length;

                    ret += _seps[sepsIndex];
                }
            }

            if (ret.Length < _minHashLength)
            {
                var guardIndex = (numbersHashInt + ret[0]) % _guards.Length;
                var guard = _guards[guardIndex];

                ret = guard + ret;

                if (ret.Length < _minHashLength)
                {
                    guardIndex = (numbersHashInt + ret[2]) % _guards.Length;
                    guard = _guards[guardIndex];

                    ret += guard;
                }
            }

            var halfLength = alphabet.Length / 2;
            while (ret.Length < _minHashLength)
            {
                alphabet = ConsistentShuffle(alphabet, alphabet);
                ret = alphabet.Substring(halfLength) + ret + alphabet.Substring(0, halfLength);

                var excess = ret.Length - _minHashLength;
                if (excess > 0)
                    ret = ret.Substring(excess / 2, _minHashLength);
            }

            return ret.ToString();
        }

        public string Hash(int input, string alphabet)
        {
            var hash = string.Empty;

            do
            {
                hash = alphabet[input % alphabet.Length] + hash;
                input = input / alphabet.Length;
            } while (input > 0);

            return hash;
        }

        public int Unhash(string input, string alphabet)
        {
            int number = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var pos = alphabet.IndexOf(input[i]);
                number += (int)(pos * Math.Pow(alphabet.Length, input.Length - i - 1));
            }

            return number;
        }

        /// <summary>
        /// Decodes the provided hash
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public virtual int[] Decode(string hash)
        {

            if (string.IsNullOrWhiteSpace(hash))
                return new int[0];

            var alphabet = string.Copy(_alphabet);
            var ret = new List<int>();
            int i = 0;

            var hashBreakdown = _guardsRegex.Replace(hash, " ");
            var hashArray = hashBreakdown.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (hashArray.Length == 3 || hashArray.Length == 2)
                i = 1;

            hashBreakdown = hashArray[i];
            if (hashBreakdown[0] != default(char))
            {
                var lottery = hashBreakdown[0];
                hashBreakdown = hashBreakdown.Substring(1);

                hashBreakdown = _sepsRegex.Replace(hashBreakdown, " ");
                hashArray = hashBreakdown.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (var j = 0; j < hashArray.Length; j++)
                {
                    var subHash = hashArray[j];
                    var buffer = lottery + _salt + alphabet;

                    alphabet = ConsistentShuffle(alphabet, buffer.Substring(0, alphabet.Length));
                    ret.Add(Unhash(subHash, alphabet));
                }

                if (Encode(ret.ToArray()) != hash)
                    ret.Clear();
            }

            return ret.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alphabet"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private string ConsistentShuffle(string alphabet, string salt)
        {
            if (string.IsNullOrWhiteSpace(salt))
                return alphabet;

            int v, p, n, j;
            v = p = n = j = 0;

            for (var i = alphabet.Length - 1; i > 0; i--, v++)
            {
                v %= salt.Length;
                p += n = salt[v];
                j = (n + v + p) % i;

                var temp = alphabet[j];
                alphabet = alphabet.Substring(0, j) + alphabet[i] + alphabet.Substring(j + 1);
                alphabet = alphabet.Substring(0, i) + temp + alphabet.Substring(i + 1);
            }

            return alphabet;
        }
    }
}
