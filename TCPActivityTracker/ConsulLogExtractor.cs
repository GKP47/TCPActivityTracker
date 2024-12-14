using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using NetworkConnections_Extractor.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetworkConnections_Extractor
{
    public partial class ConsulLogExtractor : Form
    {
        public ConsulLogExtractor()
        {
            InitializeComponent();
            //SetupUI();
        }

        private string SelectFile()
        {
            try
            {
                //using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
                //{
                //    folderDialog.Description = "Select a folder containing CSV files";

                //    if (folderDialog.ShowDialog() == DialogResult.OK)
                //    {
                //        // Get the selected folder path
                //        string selectedFolder = folderDialog.SelectedPath;
                //        SelectedFolderPathLabel.Text = selectedFolder;
                //        return LoadFilesFromFolder(selectedFolder);
                //    }
                //}

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                    openFileDialog.Title = "Select a JSON file";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Get the selected file path
                        string selectedFile = openFileDialog.FileName;
                        SelectedFolderPathLabel.Text = selectedFile; // Display the selected file path
                        //return LoadFilesFromFolder(selectedFile);
                        return selectedFile;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception {ex.Message}, Stack Trace {ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private string[] LoadFilesFromFolder(string selectedFolderPath)
        {
            try
            {
                string[] jsonFiles = Directory.GetFiles(selectedFolderPath, "*.json");

                if (jsonFiles.Any())
                {
                    return jsonFiles;
                }
                else
                {
                    MessageBox.Show("No JSON files found in the selected folder.", "No Files Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception {ex.Message}, Stack Trace {ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var selectedFile = SelectFile();
                if (!string.IsNullOrWhiteSpace(selectedFile) && File.Exists(selectedFile))
                {
                    var jsonData = JsonHelperUtility.Instance.LoadJsonData(selectedFile);
                    if (jsonData != null)
                    {
                        LoadConfigurationDataKey(jsonData);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void LoadConfigurationDataKey(List<ConfigurationLogData> jsonData)
        {
            try
            {
                var distinctKeys = JsonHelperUtility.Instance.LoadDistinctKeysInConfigurationData(jsonData);
                if (distinctKeys != null)
                {
                    ConfigurationDataListBox.DataSource = null;
                    ConfigurationDataListBox.DataSource = distinctKeys;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void ConfigurationDataListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ConfigurationDataListBox.SelectedItem != null)
                {
                    var selectedKey = ConfigurationDataListBox.SelectedItem.ToString();
                    LoadDataForSelectedKey(selectedKey);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }
        }

        private void ShowOnlyDifferencesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfigurationDataListBox.SelectedItem != null)
            {
                var selectedKey = ConfigurationDataListBox.SelectedItem.ToString();
                LoadDataForSelectedKey(selectedKey);
            }
        }

        private void LoadDataForSelectedKey(string key)
        {
            var configDataForSelectedKey = JsonHelperUtility.Instance.FilterDataByKey(JsonHelperUtility.Instance.GetConfigurationLogDataList(), key);

            LoadHighLevelData(configDataForSelectedKey);

            if (!ShowOnlyDifferencesCheckBox.Checked)
            {
                ValueDataGridView.DataSource = LoadAllData(configDataForSelectedKey);
                return;
            }

            //FilterRowsBasedOnDifferences(configDataForSelectedKey.Select(x => x.Value).ToList());
            //ValueDataGridView.DataSource = FilterRowsBasedOnLastIndexKeyDifference(configDataForSelectedKey);
            //ValueDataGridView.DataSource = configDataForSelectedKey.DistinctBy(x => x.LastIndex);

            //var distinctObjects = configDataForSelectedKey.GroupBy(o => o.LastIndex).Select(g => g.First()).ToList();

            LoadDifferences(configDataForSelectedKey);
        }

        private void LoadDifferences(List<ConfigurationLogData> jsonData)
        {
            bool allSame = jsonData.All(p => p.LastIndex == jsonData[0].LastIndex);

            var differences = allSame
                ? new List<ConfigurationLogData>() // If all are the same, return an empty list
                : jsonData.DistinctBy(p => p.LastIndex).ToList();

            ValueDataGridView.DataSource = differences;
        }

        
        private void LoadHighLevelData(List<ConfigurationLogData> jsonData)
        {
            var startDateTime = jsonData[0].FormattedDateTime;
            var endDateTime = jsonData[jsonData.Count - 1].FormattedDateTime;

            StartDateTimeLabel.Text = startDateTime.ToString();
            EndDateTimeLabel.Text = endDateTime.ToString();

            TimeSpan difference = endDateTime - startDateTime;
            DurationLabel.Text = $"{difference.Days} days, {difference.Hours} hours, {difference.Minutes} minutes, {difference.Seconds} seconds";

            TotalNumberOfEntriesLabel.Text = jsonData.Count.ToString();
        }

        private DataTable LoadAllData(List<ConfigurationLogData> jsonData)
        {
            try
            {
                DataTable table = new DataTable();

                foreach (var item in jsonData)
                {
                    var currentFormattedDateTime = item.FormattedDateTime;
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.Value.ToString());
                    if (data == null || data.Count == 0)
                    {
                        return table;
                    }

                    if (!table.Columns.Contains("DateTime"))
                    {
                        table.Columns.Add("DateTime");
                    }

                    if (!table.Columns.Contains("LastIndex"))
                    {
                        table.Columns.Add("LastIndex");
                    }

                    foreach (var key in data.Keys)
                    {
                        if (!table.Columns.Contains(key))
                        {
                            table.Columns.Add(key);
                        }
                    }

                    var row = table.NewRow();
                    row["DateTime"] = currentFormattedDateTime;
                    row["LastIndex"] = item.LastIndex;
                    foreach (var key in data.Keys)
                    {
                        row[key] = data[key] ?? DBNull.Value; // Handle null values
                    }
                    table.Rows.Add(row);
                }

                return table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} {ex.StackTrace}");
            }

            return null;
        }

        private List<JToken> FilterRowsBasedOnDifferences(List<JToken> data)
        {
            var filteredList = new List<JToken>();

            if (data == null || data.Count == 0)
                return filteredList;

            // Always include the first row
            filteredList.Add(data[0]);

            // Compare subsequent rows with the previous row
            for (int i = 1; i < data.Count; i++)
            {
                if (HasAnyDifference(data[i], data[i - 1]))
                {
                    filteredList.Add(data[i]);
                }
            }

            return filteredList;
        }

        private List<ConfigurationLogData> FilterRowsBasedOnLastIndexKeyDifference(List<ConfigurationLogData> data) 
        {
            var filteredList = new List<ConfigurationLogData>();

            if (data == null || data.Count == 0)
                return filteredList;

            // Always include the first row
            //filteredList.Add(data[0]);

            // Compare subsequent rows with the previous row
            for (int i = 1; i < data.Count; i++)
            {
                if (HasAnyDifference(data[i], data[i - 1]))
                {
                    filteredList.Add(data[i]);
                }
            }

            return filteredList;
        }

        private bool HasAnyDifference(JToken currentRow, JToken previousRow)
        {
            foreach (var property in currentRow.Children<JProperty>())
            {
                JToken currentValue = property.Value;
                JToken previousValue = previousRow[property.Name];

                if (!JToken.DeepEquals(currentValue, previousValue))
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasAnyDifference(ConfigurationLogData currentRow, ConfigurationLogData previousRow)
        {
            return currentRow.LastIndex != previousRow.LastIndex;
        }

        //private void SetupUI()
        //{
        //    this.Text = "JSON Viewer & Comparator";
        //    this.Size = new System.Drawing.Size(1000, 600);

        //    // Setup UI components
        //    JsonTreeView = new TreeView { Dock = DockStyle.Left, Width = 300 };
        //    JsonTreeView.AfterSelect += JsonTreeView_AfterSelect;
        //    this.Controls.Add(JsonTreeView);

        //    JsonDataGridView = new DataGridView
        //    {
        //        Dock = DockStyle.Left,
        //        Width = 300,
        //        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        //        ReadOnly = true
        //    };
        //    this.Controls.Add(JsonDataGridView);

        //    ComparisonDataGridView = new DataGridView
        //    {
        //        Dock = DockStyle.Fill,
        //        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        //        ReadOnly = true
        //    };
        //    this.Controls.Add(ComparisonDataGridView);

        //    // Dropdowns for selecting JSON objects to compare
        //    //compareComboBox1 = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
        //    //compareComboBox2 = new ComboBox { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList };
        //    //compareComboBox1.SelectedIndexChanged += CompareJsonObjects;
        //    //compareComboBox2.SelectedIndexChanged += CompareJsonObjects;

        //    //var panel = new Panel { Dock = DockStyle.Top, Height = 50 };
        //    //panel.Controls.Add(compareComboBox1);
        //    //panel.Controls.Add(compareComboBox2);
        //    //this.Controls.Add(panel);
        //}

        //public void LoadJson(string json)
        //{
        //    var parsedJson = JToken.Parse(json);
        //    if (parsedJson is JObject obj)
        //    {
        //        jsonObjects.Add(obj);
        //        //compareComboBox1.Items.Add($"Object {jsonObjects.Count}");
        //        //compareComboBox2.Items.Add($"Object {jsonObjects.Count}");
        //    }

        //    var rootNode = new TreeNode($"Object {jsonObjects.Count}") { Tag = parsedJson };
        //    JsonTreeView.Nodes.Add(rootNode);
        //    AddJsonToTree(parsedJson, rootNode);
        //    JsonTreeView.ExpandAll();
        //}

        //private void CompareJsonObjects(object sender, EventArgs e)
        //{
        //    if (compareComboBox1.SelectedIndex < 0 || compareComboBox2.SelectedIndex < 0)
        //        return;

        //    var obj1 = jsonObjects[compareComboBox1.SelectedIndex];
        //    var obj2 = jsonObjects[compareComboBox2.SelectedIndex];

        //    DisplayComparison(obj1, obj2);
        //}

        //private void DisplayComparison(JObject obj1, JObject obj2)
        //{
        //    ComparisonDataGridView.Columns.Clear();
        //    ComparisonDataGridView.Rows.Clear();

        //    ComparisonDataGridView.Columns.Add("Property", "Property");
        //    ComparisonDataGridView.Columns.Add("Value1", "Object 1 Value");
        //    ComparisonDataGridView.Columns.Add("Value2", "Object 2 Value");
        //    ComparisonDataGridView.Columns.Add("Status", "Comparison Result");

        //    var allKeys = obj1.Properties().Select(p => p.Name)
        //        .Union(obj2.Properties().Select(p => p.Name)).Distinct();

        //    foreach (var key in allKeys)
        //    {
        //        var value1 = obj1[key]?.ToString() ?? "Missing";
        //        var value2 = obj2[key]?.ToString() ?? "Missing";
        //        var status = value1 == value2 ? "Match" : "Different";

        //        ComparisonDataGridView.Rows.Add(key, value1, value2, status);
        //    }
        //}
    }
}
