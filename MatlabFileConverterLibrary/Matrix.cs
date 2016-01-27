//----------------------------------------------------------------------------------------------------
// <copyright file="MatlabFileReader.cs" company="GSI Helmholtzzentrum für Schwerionenforschung GmbH">
//     Copyright (c) GSI Helmholtzzentrum für Schwerionenforschung GmbH. All rights reserved.
// </copyright>
// <author>Alexander Täschner</author>
//----------------------------------------------------------------------------------------------------

namespace MatlabFileConverterLibrary
{
    using System;

    class Matrix
    {
        private readonly string name;
        private readonly Array data;

        public Matrix(string name, Array data)
        {
            this.name = name;
            this.data = data;
        }

        public string Name
        {
            get { return this.name; }
        }

        public Array Data
        {
            get { return this.data; }
        }
    }
}
