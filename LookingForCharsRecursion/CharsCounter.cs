using System;

namespace LookingForCharsRecursion
{
    public static class CharsCounter
    {
        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <returns>The number of occurrences of all characters.</returns>
        public static int GetCharsCount(string str, char[] chars)
        {
            // #1. Implement the method using recursive algorithm.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            return GetCharsCount(str, chars, 0, 0);

            static int GetCharsCount(string str, char[] chars, int indexOfString, int indexOfChars)
            {
                int cnt = 0;

                if (str[indexOfString] == chars[indexOfChars])
                {
                    cnt++;
                }

                if (indexOfString == str.Length - 1 && indexOfChars == chars.Length - 1)
                {
                    return cnt;
                }

                if (indexOfString == str.Length - 1)
                {
                    return GetCharsCount(str, chars, 0, indexOfChars + 1) + cnt;
                }

                return GetCharsCount(str, chars, indexOfString + 1, indexOfChars) + cnt;
            }
        }

        /// <summary>
        /// Searches a string for all characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <returns>The number of occurrences of all characters within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex)
        {
            // #2. Implement the method using recursive algorithm.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (startIndex < 0 || startIndex > str.Length || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (endIndex < 0 || endIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            var subStr = str[startIndex..endIndex] + str[endIndex];
            return GetCharsCount(subStr, chars);
        }

        /// <summary>
        /// Searches a string for a limited number of characters that are in <see cref="Array" />, and returns the number of occurrences of all characters within the range of elements in the <see cref="string"/> that starts at the specified index and ends at the specified index.
        /// </summary>
        /// <param name="str">String to search.</param>
        /// <param name="chars">One-dimensional, zero-based <see cref="Array"/> that contains characters to search for.</param>
        /// <param name="startIndex">A zero-based starting index of the search.</param>
        /// <param name="endIndex">A zero-based ending index of the search.</param>
        /// <param name="limit">A maximum number of characters to search.</param>
        /// <returns>The limited number of occurrences of characters to search for within the specified range of elements in the <see cref="string"/>.</returns>
        public static int GetCharsCount(string str, char[] chars, int startIndex, int endIndex, int limit)
        {
            // #3. Implement the method using recursive algorithm.
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (chars is null)
            {
                throw new ArgumentNullException(nameof(chars));
            }

            if (startIndex < 0 || startIndex > str.Length || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (endIndex < 0 || endIndex > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            if (str.Length == 0 || chars.Length == 0)
            {
                return 0;
            }

            int cnt = GetCharsCount(str, chars, startIndex, endIndex);
            if (cnt > limit)
            {
                return limit;
            }
            else
            {
                return GetCharsCount(str, chars, startIndex, endIndex);
            }
        }
    }
}
