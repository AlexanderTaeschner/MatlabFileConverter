//----------------------------------------------------------------------------------------------------
// <copyright file="MatlabFileReader.cs" company="GSI Helmholtzzentrum für Schwerionenforschung GmbH">
//     Copyright (c) GSI Helmholtzzentrum für Schwerionenforschung GmbH. All rights reserved.
// </copyright>
// <author>Alexander Täschner</author>
//----------------------------------------------------------------------------------------------------

namespace MatlabFileConverter
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal static class MatlabFileReader
    {
        public static List<Value> ReadFile(string matlabFileName)
        {
            char[][] name = null;
            char[][] description = null;
            int[][] dataInfo = null;
            double[][] data1 = null;
            double[][] data2 = null;

            using (FileStream fs = new FileStream(matlabFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (fs.Position < fs.Length)
                    {
                        Matrix matrix = ReadMatrix(br);

                        switch (matrix.Name)
                        {
                            case "Aclass":
                                break;
                            case "name":
                                name = matrix.Data as char[][];
                                break;
                            case "description":
                                description = matrix.Data as char[][];
                                break;
                            case "dataInfo":
                                dataInfo = matrix.Data as int[][];
                                break;
                            case "data_1":
                                data1 = matrix.Data as double[][];
                                break;
                            case "data_2":
                                data2 = matrix.Data as double[][];
                                break;
                            default:
                                throw new NotSupportedException();
                        }
                    }
                }
            }

            /* Die "dataInfo"-Matrix schluesselt die Speicherung der Simulationswerte in "data_1" und "data_2"
             *
             * Beispiel:
             * =========
             * int dataInfo(5,4)
             * 0 1 0 -1  # Time
             * 2 2 0 -1  # _dummy
             * 2 3 0 -1  # _derdummy
             * 1 2 0  0  # Parameter1
             * 2 4 0 -1  # Variable1
             *
             * Auszug aus einem Dymola-Export mit Erklaerung der Architektur:
             * ==============================================================
             * dataInfo(i,1)= j: name i data is stored in matrix "data_j".
             * (1,1)=0, means that name(1) is used as abscissa
             * for ALL data matrices!
             *
             * dataInfo(i,2)= k: name i data is stored in column abs(k) of matrix
             * data_j with sign(k) used as sign.
             *
             * dataInfo(i,3)= 0: Linear interpolation of the column data
             * = 1..4: Piecewise convex hermite spline interpolation
             * of the column data. Curve is differentiable upto
             * order 1..4. The spline is defined by a polygon.
             * It touches the polygon in the middle of every segment
             * and at the beginning and final point. Between such
             * points the spline is convex. The polygon is also the
             * convex envelope of the spline.
             *
             * dataInfo(i,4)= -1: name i is not defined outside of the defined time range
             * = 0: Keep first/last value outside of time range
             * = 1: Linear interpolation through first/last two points outside
             * of time range.
             */
            if ((name == null) || (description == null) || (dataInfo == null) || (data1 == null) || (data2 == null))
            {
                throw new NotSupportedException();
            }

            if ((name.Length != description.Length) || (name.Length != dataInfo.Length))
            {
                throw new NotSupportedException();
            }

            List<Value> valueList = new List<Value>(name.Length);

            for (int i = 0; i < name.Length; i++)
            {
                string valueName = new string(name[i]);
                valueName = valueName.TrimEnd('\0');
                string valueDescription = new string(description[i]);
                valueDescription = valueDescription.TrimEnd('\0');
                int storageMatrix = dataInfo[i][0];
                int storageColumn = Math.Abs(dataInfo[i][1]);
                int sign = Math.Sign(dataInfo[i][1]);
                int interpolation = dataInfo[i][2];
                int extrapolation = dataInfo[i][3];

                double[] values;

                if (storageMatrix == 2)
                {
                    int col = storageColumn - 1;
                    if ((col < 0) || (col >= data2[0].Length))
                    {
                        throw new NotImplementedException();
                    }

                    values = new double[data2.Length];
                    for (int row = 0; row < data2.Length; row++)
                    {
                        values[row] = sign * data2[row][col];
                    }
                }
                else if (storageMatrix == 1) // fixed parameters
                {
                    if (data1.Length != 2)
                    {
                        throw new NotSupportedException();
                    }

                    int col = storageColumn - 1;
                    if ((col < 0) || (col >= data1[0].Length))
                    {
                        throw new NotImplementedException();
                    }

                    if (data1[0][col] != data1[1][col])
                    {
                        throw new NotImplementedException();
                    }

                    values = new double[data2.Length];
                    for (int row = 0; row < data2.Length; row++)
                    {
                        values[row] = sign * data1[0][col];
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }

                Value value = new Value(valueName, valueDescription, values);
                valueList.Add(value);
            }

            return valueList;
        }

        private static Matrix ReadMatrix(BinaryReader br)
        {
            int type = br.ReadInt32();

            if (type > 9999)
            {
                throw new NotSupportedException();
            }

            int numericFormat = type / 1000;
            switch (numericFormat)
            {
                case 0: // IEEE Little Endian (PC, 386, 486, DEC Risc)
                    break;
                case 1: // IEEE Big Endian (Macintosh, SPARC®, Apollo, SGI, HP 9000/300, other Motorola systems)
                case 2: // VAX D-float
                case 3: // VAX G-float
                case 4: // Cray
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException();
            }

            int zero = (type - numericFormat * 1000) / 100;
            if (zero != 0)
            {
                throw new NotSupportedException();
            }

            int dataFormatFlag = (type - numericFormat * 1000) / 10;
            DataFormat dataFormat = DataFormat.Undefined;
            switch (dataFormatFlag)
            {
                case 0:
                    dataFormat = DataFormat.DoublePrecision;
                    break;
                case 1:
                    dataFormat = DataFormat.SinglePrecision;
                    break;
                case 2:
                    dataFormat = DataFormat.SignedInteger32;
                    break;
                case 3:
                    dataFormat = DataFormat.SignedInteger16;
                    break;
                case 4:
                    dataFormat = DataFormat.UnsignedInteger16;
                    break;
                case 5:
                    dataFormat = DataFormat.UnsignedInteger8;
                    break;
                default:
                    throw new NotSupportedException();
            }

            int matrixTypeFlag = type - numericFormat * 1000 - dataFormatFlag * 10;
            MatrixType matrixType = MatrixType.Undefined;
            switch (matrixTypeFlag)
            {
                case 0:
                    matrixType = MatrixType.FullNumeric;
                    break;
                case 1:
                    matrixType = MatrixType.Text;
                    break;
                case 2:
                    matrixType = MatrixType.SparseNumeric;
                    break;
                default:
                    throw new NotSupportedException();
            }

            int numberOfRows = br.ReadInt32();
            if (numberOfRows <= 0)
            {
                throw new NotSupportedException();
            }

            int numberOfColumns = br.ReadInt32();
            if (numberOfColumns <= 0)
            {
                throw new NotSupportedException();
            }

            int imaginaryFlag = br.ReadInt32();
            if (imaginaryFlag != 0)
            {
                throw new NotImplementedException();
            }

            int lengthOfName = br.ReadInt32();

            string name = string.Empty;
            for (int i = 0; i < lengthOfName - 1; i++)
            {
                char c = br.ReadChar();
                name += c;
            }

            char cz = br.ReadChar();
            if (cz != '\0')
            {
                throw new NotSupportedException();
            }

            Matrix matrix;
            switch (matrixType)
            {
                case MatrixType.FullNumeric:
                    matrix = ReadFullNumericMatrix(br, dataFormat, name, numberOfColumns, numberOfRows);
                    break;
                case MatrixType.Text:
                    matrix = ReadTextMatrix(br, dataFormat, name, numberOfColumns, numberOfRows);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return matrix;
        }

        private static Matrix ReadFullNumericMatrix(BinaryReader br, DataFormat dataFormat, string name, int numberOfColumns, int numberOfRows)
        {
            switch (dataFormat)
            {
                case DataFormat.SignedInteger32:
                    return ReadSignedInteger32Matrix(br, name, numberOfColumns, numberOfRows);
                case DataFormat.DoublePrecision:
                    return ReadDoublePrecisionMatrix(br, name, numberOfColumns, numberOfRows);
                default:
                    throw new NotImplementedException();
            }
        }

        private static Matrix ReadTextMatrix(BinaryReader br, DataFormat dataFormat, string name, int numberOfColumns, int numberOfRows)
        {
            if (dataFormat != DataFormat.UnsignedInteger8)
            {
                throw new NotImplementedException();
            }

            char[][] matrix = new char[numberOfColumns][];
            for (int col = 0; col < numberOfColumns; col++)
            {
                matrix[col] = new char[numberOfRows];
                for (int row = 0; row < numberOfRows; row++)
                {
                    matrix[col][row] = br.ReadChar();
                }
            }

            return new Matrix(name, matrix);
        }

        private static Matrix ReadSignedInteger32Matrix(BinaryReader br, string name, int numberOfColumns, int numberOfRows)
        {
            int[][] matrix = new int[numberOfColumns][];
            for (int col = 0; col < numberOfColumns; col++)
            {
                matrix[col] = new int[numberOfRows];
                for (int row = 0; row < numberOfRows; row++)
                {
                    matrix[col][row] = br.ReadInt32();
                }
            }

            return new Matrix(name, matrix);
        }

        private static Matrix ReadDoublePrecisionMatrix(BinaryReader br, string name, int numberOfColumns, int numberOfRows)
        {
            double[][] matrix = new double[numberOfColumns][];
            for (int col = 0; col < numberOfColumns; col++)
            {
                matrix[col] = new double[numberOfRows];
                for (int row = 0; row < numberOfRows; row++)
                {
                    matrix[col][row] = br.ReadDouble();
                }
            }

            return new Matrix(name, matrix);
        }
    }
}
