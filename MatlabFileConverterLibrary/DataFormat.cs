//----------------------------------------------------------------------------------------------------
// <copyright file="MatlabFileReader.cs" company="GSI Helmholtzzentrum für Schwerionenforschung GmbH">
//     Copyright (c) GSI Helmholtzzentrum für Schwerionenforschung GmbH. All rights reserved.
// </copyright>
// <author>Alexander Täschner</author>
//----------------------------------------------------------------------------------------------------

namespace MatlabFileConverterLibrary
{
    enum DataFormat
    {
        Undefined,
        DoublePrecision,
        SinglePrecision,
        SignedInteger32,
        SignedInteger16,
        UnsignedInteger16,
        UnsignedInteger8
    }
}
