using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetworkConnections_Extractor
{
    public class ConfigurationLogData
    {
        public DateTime FormattedDateTime
        {
            get
            {
                return FormatDateTime();
            }
        }

        [JsonProperty("Date")]
        public string DateTimeString { get; set; }

        public string Key { get; set; }

        public JToken Value { get; set; }

        public string ProcessId { get; set; }

        public string ProcessName { get; set; }

        public string Message { get; set; }

        public ulong LastIndex { get; set; }

        public DateTime FormatDateTime()
        {
            string[] parts = DateTimeString.Split('_');
            DateTime parsedDateTime = DateTime.Now;

            if (parts.Length == 2)
            {
                // Extract date and time from the file name
                string datePart = parts[0];
                string timePart = parts[1];

                // Parse the date and time into a DateTime object
                DateTime.TryParseExact(datePart + timePart, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out parsedDateTime);
            }
            else
            {
                Console.WriteLine("File name format is incorrect.");
            }

            return parsedDateTime;
        }
    }
}
