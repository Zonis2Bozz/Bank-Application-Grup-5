using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DataAccess
{
    public static class CSV
    {
        /// <summary>
        /// Returns a List<T> from selected FilePath
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<T> Read<T>(string filePath)
        {
            using var reader = new StreamReader(filePath);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            using var csv = new CsvReader(reader,config);
            var records = csv.GetRecords<T>();

            List<T> save = records.ToList();
            return save;
        }
        /// <summary>
        /// Saves a List<T> to selected FilePath
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="filePath"></param>
        public static void Write<T>(List<T> list, string filePath)
        {
            var records = list;
            using var writer = new StreamWriter(Path.GetFullPath(filePath));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(records);
        }
    }
}
