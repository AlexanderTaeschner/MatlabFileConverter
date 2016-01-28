//----------------------------------------------------------------------------------------------------
// <copyright file="Value.cs" company="GSI Helmholtzzentrum für Schwerionenforschung GmbH">
//  Copyright (c) GSI Helmholtzzentrum für Schwerionenforschung GmbH. All rights reserved.
// </copyright>
// <author>Alexander Täschner</author>
//----------------------------------------------------------------------------------------------------

namespace MatlabFileConverterLibrary
{
    using System;

    /// <summary>
    /// Class used to represent stored values.
    /// </summary>
    public class Value
    {
        private readonly string name;
        private readonly string description;
        private readonly double[] data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Value"/> class.
        /// </summary>
        /// <param name="name">The name of the value.</param>
        /// <param name="description">The description of the value.</param>
        /// <param name="data">The data array of the value.</param>
        public Value(string name, string description, double[] data)
        {
            this.name = name;
            this.description = description;
            this.data = data;
        }

        private Value()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets the name of the value.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the description of the value.
        /// </summary>
        public string Description
        {
            get { return this.description; }
        }

        /// <summary>
        /// Gets the data array of the value.
        /// </summary>
        public double[] Data
        {
            get { return this.data; }
        }
    }
}
