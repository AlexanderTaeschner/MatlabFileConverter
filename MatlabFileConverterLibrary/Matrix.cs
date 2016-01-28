//----------------------------------------------------------------------------------------------------
// <copyright file="Matrix.cs" company="GSI Helmholtzzentrum für Schwerionenforschung GmbH">
//  Copyright (c) GSI Helmholtzzentrum für Schwerionenforschung GmbH. All rights reserved.
// </copyright>
// <author>Alexander Täschner</author>
//----------------------------------------------------------------------------------------------------

namespace MatlabFileConverterLibrary
{
    using System;

    /// <summary>
    /// Stores a matrix.
    /// </summary>
    internal class Matrix
    {
        private readonly string name;
        private readonly Array data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="name">The name of the matrix.</param>
        /// <param name="data">The data of the matrix as jagged array.</param>
        public Matrix(string name, Array data)
        {
            this.name = name;
            this.data = data;
        }

        private Matrix()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the name of the matrix.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the data of the matrix as jagged array.
        /// </summary>
        public Array Data
        {
            get { return this.data; }
        }
    }
}
