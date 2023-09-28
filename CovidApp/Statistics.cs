using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidApp
{
    public partial class Statistics : Form
    {
        private Menu menuInstance;
        private DataTable dataTable = new DataTable();
        Model1Container context = new Model1Container();
        private List<Area> areas;
        private List<string> areaFields = GetFieldNames(typeof(Area));
        private List<string> dataFields = GetFieldNames(typeof(Data));
        List<DateTime> dateList = GenerateDateList();
        private static List<string> GetFieldNames(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            List<string> fieldNames = new List<string>();
            foreach (FieldInfo field in fields)
            {
                // Check for the format <FieldName>k__BackingField
                if (field.Name.EndsWith(">k__BackingField"))
                {
                    // Remove <, >, and "k__BackingField" from the name
                    string fieldName = field.Name.Substring(1, field.Name.IndexOf(">") - 1);
                    fieldNames.Add(fieldName);
                }
                else
                {
                    fieldNames.Add(field.Name);
                }
            }

            return fieldNames;
        }
        private static List<DateTime> GenerateDateList()
        {
            List<DateTime> dates = new List<DateTime>();

            for (DateTime date = CRUD.startDate; date <= CRUD.endDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            return dates;
        }
        private void PopulateCheckListBoxes()
        {
            areas = context.AreaSet.ToList();
            foreach (var area in areas)
            {
                iso_codeCheckedListBox.Items.Add(area.iso_code);
            }
            for (int i = 2; i < areaFields.Count - 1; i++)
            {
                areaFieldsCheckedListBox.Items.Add(areaFields[i]);
            }
            foreach (DateTime date in dateList)
            {
                dateCheckedListBox.Items.Add(date.ToString("yyyy-MM-dd"));
            }
            for (int i = 2; i < dataFields.Count - 1; i++)
            {
                dataFieldsCheckedListBox.Items.Add(dataFields[i]);
            }
        }
        private void CheckItemsInListBox(CheckedListBox checkedListBox, CheckedListBox.CheckedItemCollection checkedItemList)
        {
            foreach (var item in checkedItemList)
            {
                int index = checkedListBox.Items.IndexOf(item);
                checkedListBox.SetItemChecked(index, true);
            }
        }
        public Statistics(Menu menu, CheckedListBox.CheckedItemCollection[] checkedItemArrays)
        {
            InitializeComponent();
            this.menuInstance = menu;
            PopulateCheckListBoxes();

            CheckItemsInListBox(iso_codeCheckedListBox, checkedItemArrays[0]);
            CheckItemsInListBox(areaFieldsCheckedListBox, checkedItemArrays[1]);
            CheckItemsInListBox(dateCheckedListBox, checkedItemArrays[2]);
            CheckItemsInListBox(dataFieldsCheckedListBox, checkedItemArrays[3]);
        }
        public Statistics(Menu menu)
        {
            InitializeComponent();
            this.menuInstance = menu;
            PopulateCheckListBoxes();
        }
        private void CheckBox_CheckStateChanged(CheckBox checkBox, CheckedListBox checkedListBox)
        {
            if (checkBox.Checked)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemChecked(i, false);
                }
            }
        }
        private void iso_codeCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            CheckBox_CheckStateChanged(checkBox, iso_codeCheckedListBox);
        }

        private void dateCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            CheckBox_CheckStateChanged(checkBox, dateCheckedListBox);
        }

        private void areaFieldsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            CheckBox_CheckStateChanged(checkBox, areaFieldsCheckedListBox);
        }

        private void dataFieldsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            CheckBox_CheckStateChanged(checkBox, dataFieldsCheckedListBox);
        }
        private void CheckedListBox_ItemCheck(ItemCheckEventArgs e, Panel panel, CheckedListBox checkedListBox)
        {
            if (e.NewValue == CheckState.Checked)
            {
                panel.Enabled = true;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                bool atLeastOneChecked = false;
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        if (checkedListBox.GetItemChecked(i))
                        {
                            atLeastOneChecked = true;
                            break;
                        }
                    }
                }
                if (atLeastOneChecked)
                {
                    panel.Enabled = true;
                }
                else
                {
                    panel.Enabled = false;
                }
            }
        }
        private void iso_codeCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox_ItemCheck(e, panel1, iso_codeCheckedListBox);
            viewButtonEnable(panel1);
        }

        private void dateCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox_ItemCheck(e, panel2, dateCheckedListBox);
        }

        private void viewButtonEnable(Panel panel)
        {
            if (panel.Enabled)
                viewButton.Enabled = true;
            else
                viewButton.Enabled = false;
        }
        public void AddColumnToDataTable(Type propertyType, string columnName)
        {
            if (propertyType == typeof(int) || propertyType == typeof(int?))
            {
                dataTable.Columns.Add(new DataColumn(columnName, typeof(int)) {AllowDBNull = true });
            }
            else if (propertyType == typeof(double) || propertyType == typeof(double?))
            {
                dataTable.Columns.Add(new DataColumn(columnName, typeof(double)) { AllowDBNull = true });
            }
            else if (propertyType == typeof(long) || propertyType == typeof(long?))
            {
                dataTable.Columns.Add(new DataColumn(columnName, typeof(long)) { AllowDBNull = true });
            }
            else
            {
                dataTable.Columns.Add(columnName, propertyType);
            }
        }

        private void dataTableColumns()
        {
            dataTable.Columns.Add("iso_code", typeof(string));
            foreach (var item in areaFieldsCheckedListBox.CheckedItems)
            {
                string columnName = item.ToString();
                Type propertyType = typeof(Area).GetProperty(columnName).PropertyType;
                AddColumnToDataTable(propertyType, columnName);
            }
            if (dateCheckedListBox.CheckedItems.Count > 0)
            {
                dataTable.Columns.Add("date", typeof(string));
                foreach (var item in dataFieldsCheckedListBox.CheckedItems)
                {
                    string columnName = item.ToString();
                    Type propertyType = typeof(Data).GetProperty(columnName).PropertyType;
                    AddColumnToDataTable(propertyType, columnName);
                }
            }
        }
        private void dataTableRows()
        {
            void AddDataToDataTable<T>(DataRow newRow, T data, CheckedListBox checkedListBox)
            {
                foreach (var item in checkedListBox.CheckedItems)
                {
                    string columnName = (string)item;
                    PropertyInfo propertyInfo = typeof(T).GetProperty(columnName);
                    var value = propertyInfo.GetValue(data);
                    if (value != null)
                    {
                        newRow[columnName] = value;
                    }
                    else
                    {
                        newRow[columnName] = DBNull.Value;
                    }

                }
            }

            List<string> isoCodes = new List<string>();
            foreach (var checkedItem in iso_codeCheckedListBox.CheckedItems)
            {
                isoCodes.Add((string)checkedItem);
            }

            List<Area> filteredAreas = isoCodes.Join(areas, iso => iso, area => area.iso_code, (iso, area) => area).ToList();

            bool dateColumnExists = dataTable.Columns.Contains("date");

            if (!dateColumnExists)
            {
                foreach (var area in filteredAreas) 
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow["iso_code"] = area.iso_code;
                    AddDataToDataTable(newRow, area, areaFieldsCheckedListBox);
                    dataTable.Rows.Add(newRow);
                }
                
            }
            else
            {
                foreach (var area in filteredAreas)
                {
                    List<Data> dataList = area.Data.ToList();
                    foreach (var checkedItem in dateCheckedListBox.CheckedItems)
                    {
                        string dateString = (string)checkedItem;
                        DateTime dateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        Data uniqueData = dataList.FirstOrDefault(data => data.date == dateTime);

                        DataRow newRow = dataTable.NewRow();
                        newRow["iso_code"] = area.iso_code;
                        AddDataToDataTable(newRow, area, areaFieldsCheckedListBox);
                        newRow["date"] = dateString;
                        if (uniqueData != null)
                        {
                            AddDataToDataTable(newRow, uniqueData, dataFieldsCheckedListBox);
                        }
                        else
                        {
                            foreach (var item in dataFieldsCheckedListBox.CheckedItems)
                            {
                                string columnName = (string)item;
                                newRow[columnName] = DBNull.Value;
                            }
                        }
                        dataTable.Rows.Add(newRow);
                    }
                }
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            dataTableColumns();
            dataTableRows();
            CheckedListBox.CheckedItemCollection[] checkedItemArrays = new CheckedListBox.CheckedItemCollection[]
            {
                iso_codeCheckedListBox.CheckedItems,
                areaFieldsCheckedListBox.CheckedItems,
                dateCheckedListBox.CheckedItems,
                dataFieldsCheckedListBox.CheckedItems
            };
            new viewResults(menuInstance, dataTable, checkedItemArrays).Show();
            this.Hide();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Choose the combination of data that interests you.");
        }

        private void backBbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuInstance.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Statistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
