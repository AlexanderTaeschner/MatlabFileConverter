//----------------------------------------------------------------------------------------------------
// <copyright file="DataFormat.cs" company="GSI Helmholtzzentrum für Schwerionenforschung GmbH">
//  Copyright (c) GSI Helmholtzzentrum für Schwerionenforschung GmbH. All rights reserved.
// </copyright>
// <author>Alexander Täschner</author>
//----------------------------------------------------------------------------------------------------

namespace MatlabFileConverterLibrary
{
    /// <summary>
    /// Data format of the stored value.
    /// </summary>
    internal enum DataFormat
    {
        /// <summary>
        /// Undefined data format.
        /// </summary>
        Undefined,

        /// <summary>
        /// Double precision format.
        /// </summary>
        DoublePrecision,

        /// <summary>
        /// Single precision (float) format.
        /// </summary>
        SinglePrecision,

        /// <summary>
        /// Signed integer format with 32 bits (int).
        /// </summary>
        SignedInteger32,

        /// <summary>
        /// Signed integer format with 16 bits (short).
        /// </summary>
        SignedInteger16,

        /// <summary>
        /// Unsigned integer format with 16 bits (ushort).
        /// </summary>
        UnsignedInteger16,

        /// <summary>
        /// Unsigned integer format with 8 bits (byte).
        /// </summary>
        UnsignedInteger8
    }
}
