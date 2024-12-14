using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace NetworkConnections_Extractor
{
    public class JsonHelperUtility
    {
        private static JsonHelperUtility instance;
        private JsonHelperUtility()
        {
            configurationLogDataList = new List<ConfigurationLogData>();
        }

        public static JsonHelperUtility Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JsonHelperUtility();
                }

                return instance;
            }
        }

        private List<ConfigurationLogData> configurationLogDataList;

        public List<ConfigurationLogData> LoadJsonData(string jsonFilePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(jsonFilePath))
                {
                    using (JsonTextReader jsonReader = new JsonTextReader(reader))
                    {
                        JsonSerializer serializer = new JsonSerializer();

                        // Deserialize JSON into a list of objects
                        configurationLogDataList = serializer.Deserialize<List<ConfigurationLogData>>(jsonReader);
                        return configurationLogDataList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            return configurationLogDataList;
        }

        public List<ConfigurationLogData> GetConfigurationLogDataList() 
        {
            return configurationLogDataList;
        }

        public List<string> LoadDistinctKeysInConfigurationData(List<ConfigurationLogData> jsonData)
        {
            try
            {
                return jsonData.Select(x => x.Key).Distinct().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            return null;
        }

        /// <summary>
        /// Filter & Sorts by Date Time
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public List<ConfigurationLogData> FilterDataByKey(List<ConfigurationLogData> jsonData, string keyName)
        {
            try
            {
                return jsonData.Where(x => x.Key == keyName).OrderBy(x => x.FormattedDateTime).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            return null;
        }
    }
}
