﻿using CourseWork.Models;

namespace CourseWork.UnitTests
{
    internal class SeidelMethod
    {
        public float Precision { get; set; } = 0.00001F;

        public Vector Solve(Matrix matrix, Vector vector)
        {
            var x = new float[matrix.Size];
            var xNew = new float[matrix.Size];
            bool converge = false;
            while (!converge)
            {
                var loss = 0.0F;
                Array.Copy(x, xNew, x.Length);
                for (var i = 0; i < matrix.Size; i++)
                {
                    var sum1 = 0.0F;
                    var sum2 = 0.0F;
                    for (var j = 0; j < i; j++)
                    {
                        sum1 += matrix.Numbers[i][j] * xNew[j];
                    }

                    for (var j = i + 1; j < matrix.Size; j++)
                    {
                        sum2 += matrix.Numbers[i][j] * x[j];
                    }
                        
                    xNew[i] = (vector.Numbers[i] - sum1 - sum2) / matrix.Numbers[i][i];
                    loss += (float)Math.Pow(xNew[i] - x[i], 2);
                }

                converge = Math.Sqrt(loss) <= Precision;
                Array.Copy(xNew, x, xNew.Length);
            }

            return new Vector(x);
        }
    }
}
