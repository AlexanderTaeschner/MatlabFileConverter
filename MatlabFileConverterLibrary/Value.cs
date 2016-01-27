//----------------------------------------------------------------------------------------------------
// <copyright file="MatlabFileReader.cs" company="GSI Helmholtzzentrum für Schwerionenforschung GmbH">
//     Copyright (c) GSI Helmholtzzentrum für Schwerionenforschung GmbH. All rights reserved.
// </copyright>
// <author>Alexander Täschner</author>
//----------------------------------------------------------------------------------------------------

namespace MatlabFileConverterLibrary
{
    public class Value
    {
        private readonly string name;
        private readonly string description;
        private readonly double[] data;

        public Value(string name, string description, double[] data)
        {
            this.name = name;
            this.description = description;
            this.data = data;
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Description
        {
            get { return this.description; }
        }

        public double[] Data
        {
            get { return this.data; }
        }
    }
}
