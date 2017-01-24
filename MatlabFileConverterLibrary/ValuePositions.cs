namespace MatlabFileConverterLibrary
{
    using System;

    /// <summary>
    /// Class used to represent pairs of position, value names and array indices.
    /// </summary>
    public class ValuePositions
    {
        private readonly string[] valueNames;
        private readonly int[] valueIndices;

        /// <summary>
        /// Initializes a new instance of the ValuePositions class.
        /// </summary>
        /// <param name="position">Position value.</param>
        /// <param name="valueNames">Names of the corresponding values.</param>
        public ValuePositions(double position, params string[] valueNames)
        {
            this.Position = position;
            this.valueNames = valueNames;

            this.valueIndices = new int[valueNames.Length];
            for (int i = 0; i < this.valueIndices.Length; i++)
            {
                this.valueIndices[i] = -1;
            }
        }

        /// <summary>
        /// Gets the position value.
        /// </summary>
        public double Position { get; }

        /// <summary>
        /// Gets the specified value name.
        /// </summary>
        /// <param name="index">Index into the name list.</param>
        /// <returns>The specified value name.</returns>
        public string GetName(int index)
        {
            if ((index < 0) || (index > valueNames.Length))
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return this.valueNames[index];
        }

        /// <summary>
        /// Gets the specified value index.
        /// </summary>
        /// <param name="index">Index into the index list.</param>
        /// <returns>The specified value index.</returns>
        public int GetColumnIndex(int index)
        {
            if ((index < 0) || (index > valueIndices.Length))
            {
                throw new ArgumentOutOfRangeException("index");
            }

            return this.valueIndices[index];
        }

        /// <summary>
        /// Sets the specified value index.
        /// </summary>
        /// <param name="index">Index into the index list.</param>
        /// <param name="columnIndex">The value index.</param>
        public void SetColumnIndex(int index, int columnIndex)
        {
            if ((index < 0) || (index > valueIndices.Length))
            {
                throw new ArgumentOutOfRangeException("index");
            }

            this.valueIndices[index] = columnIndex;
        }
    }
}