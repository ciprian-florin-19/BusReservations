using System.Reflection;
using System.Text;

namespace BusReservations.Core
{
    public sealed class LocalBackupUtilities
    {
        private StreamWriter? _streamWriter;
        private static LocalBackupUtilities? _instance = null;

        private LocalBackupUtilities() { }

        public static LocalBackupUtilities Instance => _instance ?? (_instance = new LocalBackupUtilities());
        public void WriteCollectionToFile<T>(IEnumerable<T> collection, string filepath)
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
        private string GenerateLine<T>(T item)
        {
            List<PropertyInfo> properties = new List<PropertyInfo>(item.GetType().GetProperties());
            return string.Join(',', properties.Select(p => p.GetValue(item)));
        }
        private string GenerateBody<T>(IEnumerable<T> collection)
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
