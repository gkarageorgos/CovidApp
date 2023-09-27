//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CovidApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Data
    {
        public int Id { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> total_cases { get; set; }
        public Nullable<int> new_cases { get; set; }
        public Nullable<double> new_cases_smoothed { get; set; }
        public Nullable<int> total_deaths { get; set; }
        public Nullable<int> new_deaths { get; set; }
        public Nullable<double> new_deaths_smoothed { get; set; }
        public Nullable<double> total_cases_per_million { get; set; }
        public Nullable<double> new_cases_per_million { get; set; }
        public Nullable<double> new_cases_smoothed_per_million { get; set; }
        public Nullable<double> total_deaths_per_million { get; set; }
        public Nullable<double> new_deaths_per_million { get; set; }
        public Nullable<double> new_deaths_smoothed_per_million { get; set; }
        public Nullable<double> reproduction_rate { get; set; }
        public Nullable<int> icu_patients { get; set; }
        public Nullable<double> icu_patients_per_million { get; set; }
        public Nullable<int> hosp_patients { get; set; }
        public Nullable<double> hosp_patients_per_million { get; set; }
        public Nullable<int> weekly_icu_admissions { get; set; }
        public Nullable<double> weekly_icu_admissions_per_million { get; set; }
        public Nullable<int> weekly_hosp_admissions { get; set; }
        public Nullable<double> weekly_hosp_admissions_per_million { get; set; }
        public Nullable<long> total_tests { get; set; }
        public Nullable<int> new_tests { get; set; }
        public Nullable<double> total_tests_per_thousand { get; set; }
        public Nullable<double> new_tests_per_thousand { get; set; }
        public Nullable<int> new_tests_smoothed { get; set; }
        public Nullable<double> new_tests_smoothed_per_thousand { get; set; }
        public Nullable<double> positive_rate { get; set; }
        public Nullable<double> tests_per_case { get; set; }
        public string tests_units { get; set; }
        public Nullable<long> total_vaccinations { get; set; }
        public Nullable<long> people_vaccinated { get; set; }
        public Nullable<long> people_fully_vaccinated { get; set; }
        public Nullable<long> total_boosters { get; set; }
        public Nullable<int> new_vaccinations { get; set; }
        public Nullable<int> new_vaccinations_smoothed { get; set; }
        public Nullable<double> total_vaccinations_per_hundred { get; set; }
        public Nullable<double> people_vaccinated_per_hundred { get; set; }
        public Nullable<double> people_fully_vaccinated_per_hundred { get; set; }
        public Nullable<double> total_boosters_per_hundred { get; set; }
        public Nullable<int> new_vaccinations_smoothed_per_million { get; set; }
        public Nullable<int> new_people_vaccinated_smoothed { get; set; }
        public Nullable<double> new_people_vaccinated_smoothed_per_hundred { get; set; }
        public Nullable<double> stringency_index { get; set; }
        public Nullable<double> excess_mortality_cumulative_absolute { get; set; }
        public Nullable<double> excess_mortality_cumulative { get; set; }
        public Nullable<double> excess_mortality { get; set; }
        public Nullable<double> excess_mortality_cumulative_per_million { get; set; }
    
        public virtual Area Area { get; set; }
    }
}