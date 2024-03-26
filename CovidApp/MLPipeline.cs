using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CovidApp
{
    public partial class MLPipeline : Form
    {
        private CRUD crud = new CRUD();

        public List<ConfirmedData> CreateConfirmedDataList(List<Data> datas)
        {
            List<ConfirmedData> confirmedDatas = new List<ConfirmedData>();
            foreach (Data data in datas)
            {
                int? totalConfirmed = crud.GetFieldFromData(data, "new_cases");
                if (totalConfirmed == null)
                    totalConfirmed = 0;
                Console.WriteLine($"date: {data.date}, new_cases: {totalConfirmed}");
                ConfirmedData confirmedData = new ConfirmedData(data.date, (int)totalConfirmed);
                confirmedDatas.Add(confirmedData);
            }
            return confirmedDatas;
        }
        
        public float[] ML(Area area, DateTime dateTime)
        {
            List<Data> datas = crud.GetDataForArea(area);

            List<Data> filteredData = crud.FilterDataBeforeDate(datas, dateTime);

            List<ConfirmedData> confirmedDatas = CreateConfirmedDataList(filteredData);

            // Creates a new instance of the MLContext class
            MLContext mL = new MLContext();

            // Loads data from an enumerable (in-memory collection) of ConfirmedData objects using MLContext's Data.LoadFromEnumerable method.
            IDataView data = mL.Data.LoadFromEnumerable<ConfirmedData>(confirmedDatas);
            
            //Creating an ML Pipeline for time series analysis using the Single Spectrum Analysis (SSA) 
            //method in ML.NET. SSA is a method for analyzing time series data that can be used for 
            //forecasting values in time series.


            SsaForecastingEstimator pipeline = mL.Forecasting.ForecastBySsa(
                    // The name of the field in the output data where the forecasted values will be stored.
                    nameof(ConfirmedForecast.Forecast),
                    // The name of the field in the input data (time series) that contains the values to be forecasted.
                    nameof(ConfirmedData.TotalConfirmed),
                    // The window size used in Single Spectrum Analysis (SSA). It determines the number of previous observations considered for forecasting.
                    windowSize: 30,
                    // The length of the time series window used in SSA. It specifies how many recent observations are taken into account.
                    seriesLength: 45,
                    // The size of the training data used to build the forecasting model. In this case, it's set to 1300.
                    trainSize: filteredData.Count(),
                    // The number of future time steps for which forecasts will be generated.
                    horizon: 7
                );

            // Train the forecasting model using the provided data and pipeline.
            SsaForecastingTransformer model = pipeline.Fit(data);

            // Create a time series forecasting engine based on the trained model.
            TimeSeriesPredictionEngine<ConfirmedData, ConfirmedForecast> forecastingEngine = model.CreateTimeSeriesEngine<ConfirmedData, ConfirmedForecast>(mL);

            // Generate forecasts using the forecasting engine.
            ConfirmedForecast forecasts = forecastingEngine.Predict();

            // Extract the forecasted values from the PredictedForecast object
            float[] forecastedValues = forecasts.Forecast;
            
            return forecastedValues;

        }
        public MLPipeline(string iso_code, DateTime dateTime)
        {
            InitializeComponent();

            List<Area> areas = crud.GetAreas();

            Area area = crud.GetArea(areas, iso_code);

            float[] forecastedValues = ML(area, dateTime);

            locationLabel.Text = area.location;

            // Display or process the forecasted values as needed
            for (int i = 0; i < forecastedValues.Length; i++)
            {
                DateTime date = dateTime.AddDays(i);
                string formattedDate = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                var forecast = forecastedValues[i];
                forecastListBox.Items.Add($"{formattedDate}: {(int)forecast}");
            }
        }
    }
}
