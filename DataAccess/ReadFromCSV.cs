using CsvHelper;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace DataAccess
{
    public class ReadFromCSV<T>
    {
        public List<T> Read(string filePath)
        {
            using (var reader = new StreamReader(Path.GetFullPath(filePath)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>();
                return (List<T>)records;
            }
        }


        public void Write(List<string> list, string filePath)
        {

            string createText = "Hello and Welcome" + Environment.NewLine;
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "customer."), createText);
            //foreach (var item in list)
            //{
            //    item.ToString();
            //    File.AppendAllText(Path.GetFullPath(filePath), item);
            //}
        }
        //public void Write(List<T> list, string filePath)
        //{
        //    var records = list;   

        //    using (var writer = new StreamWriter(Path.GetFullPath(filePath)))
        //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //    {
        //        csv.WriteRecords(records);
        //    }
           
        //}
    }
}
