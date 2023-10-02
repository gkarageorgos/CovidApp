using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidApp
{
    public partial class MLPipeline : Form
    {
        private AreaController areaController = new AreaController();
        public List<ConfirmedData> CreateConfirmedDataList(List<DateTime> dateTimes, List<Data> datas)
        {
            List<ConfirmedData> confirmedDatas = new List<ConfirmedData>();
            foreach (DateTime date in dateTimes)
            {
                Data data = areaController.FindDataByDate(datas, date);

                int totalConfirmed = areaController.GetNewCasesFieldFromData(data);

                ConfirmedData confirmedData = new ConfirmedData(date, totalConfirmed);
                confirmedDatas.Add(confirmedData);
            }
            return confirmedDatas;
        }
        
        public float[] ML(Area area)
        {
            List<Data> datas = areaController.GetDataForArea(area);

            List<Data> filteredData = datas.Where(d => d.date < new DateTime(2023, 9, 18)).ToList();//

            List<DateTime> dates = areaController.GetDatesFieldFromData(filteredData);

            List<ConfirmedData> confirmedDatas = CreateConfirmedDataList(dates, filteredData);

            // Creates a new instance of the MLContext class
            var context = new MLContext();

            // Loads data from an enumerable (in-memory collection) of ConfirmedData objects using MLContext's Data.LoadFromEnumerable method.
            var data = context.Data.LoadFromEnumerable<ConfirmedData>(confirmedDatas);

            //Creating an ML Pipeline for time series analysis using the Single Spectrum Analysis (SSA) 
            //method in ML.NET. SSA is a method for analyzing time series data that can be used for 
            //forecasting values in time series.


            var pipeline = context.Forecasting.ForecastBySsa(
                    // The name of the field in the output data where the forecasted values will be stored.
                    nameof(ConfirmedForecast.Forecast),
                    // The name of the field in the input data (time series) that contains the values to be forecasted.
                    nameof(ConfirmedData.TotalConfirmed),
                    // The window size used in Single Spectrum Analysis (SSA). It determines the number of previous observations considered for forecasting.
                    windowSize: 5,
                    // The length of the time series window used in SSA. It specifies how many recent observations are taken into account.
                    seriesLength: 10,
                    // The size of the training data used to build the forecasting model. In this case, it's set to 1300.
                    trainSize: dates.Count(),
                    // The number of future time steps for which forecasts will be generated.
                    horizon: 7
                );

            // Train the forecasting model using the provided data and pipeline.
            var model = pipeline.Fit(data);

            // Create a time series forecasting engine based on the trained model.
            var forecastingEngine = model.CreateTimeSeriesEngine<ConfirmedData, ConfirmedForecast>(context);

            // Generate forecasts using the forecasting engine.
            var forecasts = forecastingEngine.Predict();

            // Extract the forecasted values from the PredictedForecast object
            float[] forecastedValues = forecasts.Forecast;

            return forecastedValues;

        }
        public MLPipeline()
        {
            InitializeComponent();

            List<Area> areas = areaController.GetAreas(new Model1Container());

            Area area = areaController.GetArea(areas, "GRC");

            float[] forecastedValues = ML(area);

            locationLabel.Text = area.location;

            // Display or process the forecasted values as needed
            for (int i = 0; i < forecastedValues.Length; i++)
            {
                DateTime date = new DateTime(2023, 9, 18).AddDays(i);
                string formattedDate = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                var forecast = forecastedValues[i];
                forecastListBox.Items.Add($"{formattedDate}: {(int)forecast}");
            }
        }
    }
}
