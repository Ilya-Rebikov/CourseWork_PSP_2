﻿namespace CourseWork.Web.Services
{
    using System.Runtime.Serialization.Formatters.Binary;
    using CourseWork.Models;
    using CourseWork.Web.Interfaces;

    /// <summary>
    /// Сервис для сериализация и десериализации.
    /// </summary>
    internal class Serializer : ISerializer
    {
        /// <inheritdoc/>
        public byte[] SerializeVector(Vector vector)
        {
            var bf = new BinaryFormatter();
            using var ms = new MemoryStream();
            bf.Serialize(ms, vector);
            return ms.ToArray();
        }

        /// <inheritdoc/>
        public async Task<Matrix> DeserializeMatrix(string path)
        {
            float[][] numbers = Array.Empty<float[]>();
            using var reader = new StreamReader(path);
            string line;
            int i = 0;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                string[] elements = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                numbers[i] = new float[elements.Length];
                for (int j = 0; j < elements.Length; j++)
                {
                    numbers[i][j] = float.Parse(elements[j]);
                }

                i++;
            }

            return new Matrix(numbers);
        }

        /// <inheritdoc/>
        public async Task<Vector> DeserializeVector(string path)
        {
            float[] numbers = Array.Empty<float>();
            using var reader = new StreamReader(path);
            string line;
            int i = 0;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                numbers[i] = float.Parse(line);
                i++;
            }

            return new Vector(numbers);
        }
    }
}
