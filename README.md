We download the owid-covid-data.json from https://ourworldindata.org/covid-cases?fbclid=IwAR00xyWIIDpTHLZ0tCuJPXt0RlSmDmd72QbYstEeYdcnKcFwzGDa-enBLK8, which contains information about covid-19. 
Specifically The JSON file has a key for each country, which is the country's ISO code, and the value of each key is a JSON object containing information about that specific country. 
This information includes country characteristics such as population, population density, age, GDP, etc., as well as statistics related to the COVID-19 pandemic for that particular country. 
The key "data" contains an array of JSON objects that contain dates and statistical data on the progression of the COVID-19 pandemic in the country. 
Using ADO.NET Entity Data Model, we design two entities. The entity "Area" contains characteristics of each country, such as population, GDP, etc. The entity "Data" contains data related to COVID-19, 
such as dates, new cases, new deaths, and so forth. Each record in the "Area" entity is associated with multiple records in the "Data" entity (a one-to-many relationship). We generate DB from model.

Furthermore using ML.NET (Machine Learning for .NET), we predict future COVID-19 cases for a specific region based on confirmed case data collected up to the given date. The forecasting model was created using the 
Single Spectrum Analysis (SSA) method for time series analysis and prediction of future values.
