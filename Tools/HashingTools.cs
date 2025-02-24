namespace Todo.API.Tools
{
    public static class HashingTools
    {
        /// <summary>
        /// Calculates a jenkins hash.
        /// </summary>
        /// <param name="input">A 32bit positive number.</param>
        /// <returns>Returns the calculated hash converted to hex.</returns>
        public static string JenkinsHash(uint input)
        {
            uint hash = 0;

            // First byte.
            hash += (input & 0xFF); // Add byte to hash.
            hash += hash << 10;     // Spread the bits.
            hash ^= hash >> 6;      // Mix the bits.

            // Second byte.
            hash += ((input >> 8) & 0xFF); // Add the bytes to hash, rest is same same.
            hash += hash << 10;
            hash ^= hash >> 6;

            // Third byte.
            hash += ((input >> 16) & 0xFF);
            hash += hash << 10;
            hash ^= hash >> 6;

            // Fourth byte.
            hash += ((input >> 24) & 0xFF);
            hash += hash << 10;
            hash ^= hash >> 6;

            // Final avalanche phase - ensures that each input bit affects many output bits
            hash += hash << 3;  // Spread.
            hash ^= hash >> 11; // Mix.
            hash += hash << 15; // Spread.

            // Hash to hex representation.
            return hash.ToString("X8");
        }
    }
}
