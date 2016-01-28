//----------------------------------------------------------------------------------------------------
// <copyright file="MatrixType.cs" company="GSI Helmholtzzentrum für Schwerionenforschung GmbH">
//  Copyright (c) GSI Helmholtzzentrum für Schwerionenforschung GmbH. All rights reserved.
// </copyright>
// <author>Alexander Täschner</author>
//----------------------------------------------------------------------------------------------------

namespace MatlabFileConverterLibrary
{
    /// <summary>
    /// The type of the MATLAB matrix.
    /// </summary>
    internal enum MatrixType
    {
        /// <summary>
        /// Undefined type.
        /// </summary>
        Undefined,

        /// <summary>
        /// Full matrix with numeric entries.
        /// </summary>
        FullNumeric,

        /// <summary>
        /// Full matrix with text entries.
        /// </summary>
        Text,

        /// <summary>
        /// Sparse matrix with numeric entries.
        /// </summary>
        SparseNumeric
    }
}
