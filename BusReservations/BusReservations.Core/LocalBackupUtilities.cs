using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusReservations.Core
{
    public class LocalBackupUtilities
    {
        private StreamWriter? _streamWriter;

        public void WriteCollectionToFile(IEnumerable<object> collection, string filepath)
        {
            using (_streamWriter = new StreamWriter(filepath, false))
            {
                Type type = collection.GetType().GetGenericArguments().Single();
                _streamWriter.WriteLine(GenerateHeader(type));
                _streamWriter.Write(GenerateBody(collection));
            }
        }

        private string GenerateHeader(Type type)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>(type.GetProperties());
            return string.Join(',', properties.Select(p => p.Name));
        }
        private string GenerateLine(object item)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>(item.GetType().GetProperties());
            return string.Join(',', properties.Select(p => p.GetValue(item)));
        }
        private string GenerateBody(IEnumerable<object> collection)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in collection)
            {
                stringBuilder.AppendLine(GenerateLine(item));
            }
            return stringBuilder.ToString();
        }
    }
}
