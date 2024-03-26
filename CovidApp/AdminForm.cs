using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidApp
{
    public partial class AdminForm : Form
    {
        private CRUD CRUD = new CRUD();

        internal static DateTime startDate = new DateTime(2020, 1, 1);
        internal static DateTime endDate = new DateTime(2023, 8, 31);

        public AdminForm()
        {
            InitializeComponent();
        }
        private static JObject GetJsonObject(string jsonFilePath)
        {
            try
            {
                using (StreamReader fileReader = new StreamReader(jsonFilePath))
                using (JsonTextReader jsonReader = new JsonTextReader(fileReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    return serializer.Deserialize<JObject>(jsonReader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        private (Dictionary<string, JToken>, JObject[]) AreaDictionary(JObject jsonObject)
        {
            Dictionary<string, JToken> areaDictionary = new Dictionary<string, JToken>();
            JObject[] jsonObjects = null;

            foreach (var property in jsonObject.Properties())
            {
                string areaField = property.Name;
                JToken areaValue = property.Value;

                if (areaField == "data")
                {
                    jsonObjects = areaValue.ToObject<JObject[]>();
                    break;
                }

                areaDictionary[areaField] = areaValue;
            }

            return (areaDictionary, jsonObjects);
        }
        public Dictionary<string, JToken>[] DataDictionaries(JObject[] jsonObjects)
        {
            if (jsonObjects == null)
                return null;

            Dictionary<string, JToken>[] dataDictionaries = new Dictionary<string, JToken>[jsonObjects.Length];

            for (int i = 0; i < jsonObjects.Length; i++)
            {
                JObject jsonObject = jsonObjects[i];

                dataDictionaries[i] = new Dictionary<string, JToken>();

                foreach (var property in jsonObject.Properties())
                    dataDictionaries[i][property.Name] = property.Value;
            }

            return dataDictionaries;

        }
        private (Dictionary<string, JToken>, Dictionary<string, JToken>[]) JsonObjectToDictionaries(JObject jsonObject)
        {
            var result = AreaDictionary(jsonObject);

            Dictionary<string, JToken> areaDictionary = result.Item1;
            JObject[] jsonObjects = result.Item2;

            Dictionary<string, JToken>[] dataDictionaries = DataDictionaries(jsonObjects);

            return (areaDictionary, dataDictionaries);
        }
        private void ReadJObject(JObject jsonObject)
        {
            foreach (var property in jsonObject.Properties())
            {
                string iso_code = property.Name;

                JObject areaJsonObject = (JObject)property.Value;

                var result = JsonObjectToDictionaries(areaJsonObject);

                Dictionary<string, JToken> areaDictionary = result.Item1;
                Dictionary<string, JToken>[] dataDictionaries = result.Item2;

                //Add new Area
                CRUD.addArea(iso_code, areaDictionary, dataDictionaries);
            }
        }
        private void AddData(JObject jsonObject)
        {
            List<Area> areas = CRUD.GetAreas();
            
            int areaIndex = 0;

            foreach (var property in jsonObject.Properties())
            {

                Area area = areas[areaIndex];

                JObject areaJsonObject = (JObject)property.Value;
                JObject[] jsonObjects = areaJsonObject["data"].ToObject<JObject[]>();

                List<JObject> filteredJsonObjects = new List<JObject>();

                foreach (var dataJsonObject in jsonObjects)
                {
                    string dateString = (string)dataJsonObject["date"];
                    DateTime dateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    if (dateTime > endDate)
                        filteredJsonObjects.Add(dataJsonObject);

                }

                Dictionary<string, JToken>[] dataDictionaries = DataDictionaries(filteredJsonObjects.ToArray());

                CRUD.addData(ref area, dataDictionaries);

                areaIndex++;

            }
        }
        
        private void FillButton_Click(object sender, EventArgs e)
        {
            JObject jsonObject = GetJsonObject("owid-covid-data.json");
            ReadJObject(jsonObject);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            CRUD.DeleteData(endDate);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //Delete data starting from endDate

            JObject jsonObject = GetJsonObject("owid-covid-data.json");
            AddData(jsonObject);
        }
    }
}
