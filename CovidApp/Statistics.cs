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
        private CRUD crud = new CRUD();
        private Menu menuInstance;
        private DataTable dataTable = new DataTable();
        private List<Area> areas;
        private string[] areaFields = CRUD.GetFieldNames(typeof(Area));
        private string[] dataFields = CRUD.GetFieldNames(typeof(Data));
        DateTime[] dateArray = GenerateDateArray();

        private static DateTime[] GenerateDateArray()
        {
            int numberOfDays = (AdminForm.endDate - AdminForm.startDate).Days + 1;
            DateTime[] dates = new DateTime[numberOfDays];
            for (int i = 0; i < numberOfDays; i++)
            {
                dates[i] = AdminForm.startDate.AddDays(i);
            }
            return dates;
        }

        //Form construction
        private void PopulateCheckListBoxes()
        {
            areas = crud.GetAreas();
            foreach (var area in areas)
            {
                iso_codeCheckedListBox.Items.Add(area.iso_code);
            }
            for (int i = 2; i < areaFields.Length - 1; i++)
            {
                areaFieldsCheckedListBox.Items.Add(areaFields[i]);
            }
            for (int i = 0; i < dateArray.Length; i++)
            {
                DateTime date = dateArray[i];
                dateCheckedListBox.Items.Add(date.ToString("yyyy-MM-dd"));
            }
            for (int i = 2; i < dataFields.Length - 1; i++)
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

        // the change in the state of the checkboxes (checked or unchecked)
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

        // an item's check state changes in the CheckedListBox
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
        private void viewButtonEnable(Panel panel)
        {
            if (panel.Enabled)
                viewButton.Enabled = true;
            else
                viewButton.Enabled = false;
        }
        private void iso_codeCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox_ItemCheck(e, areaPanel, iso_codeCheckedListBox);
            viewButtonEnable(areaPanel);
        }

        private void dateCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox_ItemCheck(e, DataPanel, dateCheckedListBox);
        }

        // Creating the DataTable
        private void AddColumnToDataTable(Type propertyType, string columnName)
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
        private void AddColumnsToDataTable(List<string> columns, Type classType)
        {
            foreach (string columnName in columns)
            {
                Type propertyType = classType.GetProperty(columnName).PropertyType;
                AddColumnToDataTable(propertyType, columnName);
            }
        }
        private void dataTableColumns(List<string> areaColumns, List<string> dataColumns)
        {
            AddColumnsToDataTable(areaColumns, typeof(Area));
            if (dataColumns != null)
            {
                dataTable.Columns.Add("date", typeof(string));
                AddColumnsToDataTable(dataColumns, typeof(Data));
            }
        }
        private void AddRows(ref DataRow row, Dictionary<string, List<object>> fieldValues, List<string> columns)
        {
            foreach (string columnName in columns)
            {
                var value = fieldValues[columnName][0];

                if (value == null)
                    row[columnName] = DBNull.Value;
                else
                    row[columnName] = value;
            }
        }
        private void dataTableRows(List<string> isoCodes, List<string> areaColumns, List<string> dataColumns)
        {
            List<Area> filteredAreas = crud.AreasByISO(isoCodes, areas);

            foreach (Area area in filteredAreas)
            {
                DataRow constantRow = dataTable.NewRow();

                Dictionary<string, List<object>> fieldValues = crud.GetFieldsValuesFromArea(new List<Area> { area}, areaColumns.ToArray());

                AddRows(ref constantRow, fieldValues, areaColumns);

                if (dataColumns == null)
                    dataTable.Rows.Add(constantRow);
                else
                {
                    List<Data> dataList = crud.GetDataForArea(area);

                    foreach (var checkedItem in dateCheckedListBox.CheckedItems)
                    {
                        string dateString = (string)checkedItem;
                        DateTime dateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        Data data = crud.FindDataByDate(dataList, dateTime);

                        DataRow newRow = dataTable.NewRow();

                        newRow.ItemArray = constantRow.ItemArray;

                        newRow["date"] = dateString;

                        if (data == null)
                        {
                            foreach (string columnName in dataColumns)
                            {
                                newRow[columnName] = DBNull.Value;
                            }
                        }
                        else
                        {
                            Dictionary<string, List<object>> keyValues = crud.GetFieldsValuesFromData(new List<Data> { data }, dataColumns.ToArray());

                            AddRows(ref newRow, keyValues, dataColumns);
                        }

                        dataTable.Rows.Add(newRow);
                    }
                }
            }
        }
        private (List<string>, List<string>) GetColumns()
        {
            List<string> areaColumns = new List<string>();
            areaColumns.Add("iso_code");
            foreach (var item in areaFieldsCheckedListBox.CheckedItems)
            {
                string columnName = item.ToString();
                areaColumns.Add(columnName);
            }
            if (dateCheckedListBox.CheckedItems.Count > 0)
            {
                List<string> dataColumns = new List<string>();
                foreach (var item in dataFieldsCheckedListBox.CheckedItems)
                {
                    string columnName = item.ToString();
                    dataColumns.Add(columnName);
                }
                return (areaColumns, dataColumns);
            }
            return (areaColumns, null);
        }

        // Displaying the DataTable on the form viewResult
        private void viewButton_Click(object sender, EventArgs e)
        {
            var columns = GetColumns();
            List<string> areaColumns = columns.Item1;
            List<string> dataColumns = columns.Item2;

            dataTableColumns(areaColumns, dataColumns);

            List<string> isoCodes = new List<string>();
            foreach (var checkedItem in iso_codeCheckedListBox.CheckedItems)
            {
                isoCodes.Add((string)checkedItem);
            }

            dataTableRows(isoCodes, areaColumns, dataColumns);

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
