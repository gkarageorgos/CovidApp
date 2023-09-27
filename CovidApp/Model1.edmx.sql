
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/26/2023 15:54:12
-- Generated from EDMX file: C:\Users\jkara\source\repos\CovidApp\CovidApp\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Covid19Data];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AreaSet'
CREATE TABLE [dbo].[AreaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [iso_code] nvarchar(max)  NOT NULL,
    [continent] nvarchar(max)  NULL,
    [location] nvarchar(max)  NOT NULL,
    [population_density] float  NULL,
    [median_age] float  NULL,
    [aged_65_older] float  NULL,
    [aged_70_older] float  NULL,
    [gdp_per_capita] float  NULL,
    [extreme_poverty] float  NULL,
    [cardiovasc_death_rate] float  NULL,
    [diabetes_prevalence] float  NULL,
    [female_smokers] float  NULL,
    [male_smokers] float  NULL,
    [handwashing_facilities] float  NULL,
    [hospital_beds_per_thousand] float  NULL,
    [life_expectancy] float  NULL,
    [human_development_index] float  NULL,
    [population] bigint  NOT NULL
);
GO

-- Creating table 'DataSet'
CREATE TABLE [dbo].[DataSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NOT NULL,
    [total_cases] int  NULL,
    [new_cases] int  NULL,
    [new_cases_smoothed] float  NULL,
    [total_deaths] int  NULL,
    [new_deaths] int  NULL,
    [new_deaths_smoothed] float  NULL,
    [total_cases_per_million] float  NULL,
    [new_cases_per_million] float  NULL,
    [new_cases_smoothed_per_million] float  NULL,
    [total_deaths_per_million] float  NULL,
    [new_deaths_per_million] float  NULL,
    [new_deaths_smoothed_per_million] float  NULL,
    [reproduction_rate] float  NULL,
    [icu_patients] int  NULL,
    [icu_patients_per_million] float  NULL,
    [hosp_patients] int  NULL,
    [hosp_patients_per_million] float  NULL,
    [weekly_icu_admissions] int  NULL,
    [weekly_icu_admissions_per_million] float  NULL,
    [weekly_hosp_admissions] int  NULL,
    [weekly_hosp_admissions_per_million] float  NULL,
    [total_tests] bigint  NULL,
    [new_tests] int  NULL,
    [total_tests_per_thousand] float  NULL,
    [new_tests_per_thousand] float  NULL,
    [new_tests_smoothed] int  NULL,
    [new_tests_smoothed_per_thousand] float  NULL,
    [positive_rate] float  NULL,
    [tests_per_case] float  NULL,
    [tests_units] nvarchar(max)  NULL,
    [total_vaccinations] bigint  NULL,
    [people_vaccinated] bigint  NULL,
    [people_fully_vaccinated] bigint  NULL,
    [total_boosters] bigint  NULL,
    [new_vaccinations] int  NULL,
    [new_vaccinations_smoothed] int  NULL,
    [total_vaccinations_per_hundred] float  NULL,
    [people_vaccinated_per_hundred] float  NULL,
    [people_fully_vaccinated_per_hundred] float  NULL,
    [total_boosters_per_hundred] float  NULL,
    [new_vaccinations_smoothed_per_million] int  NULL,
    [new_people_vaccinated_smoothed] int  NULL,
    [new_people_vaccinated_smoothed_per_hundred] float  NULL,
    [stringency_index] float  NULL,
    [excess_mortality_cumulative_absolute] float  NULL,
    [excess_mortality_cumulative] float  NULL,
    [excess_mortality] float  NULL,
    [excess_mortality_cumulative_per_million] float  NULL,
    [Area_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AreaSet'
ALTER TABLE [dbo].[AreaSet]
ADD CONSTRAINT [PK_AreaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DataSet'
ALTER TABLE [dbo].[DataSet]
ADD CONSTRAINT [PK_DataSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Area_Id] in table 'DataSet'
ALTER TABLE [dbo].[DataSet]
ADD CONSTRAINT [FK_AreaData]
    FOREIGN KEY ([Area_Id])
    REFERENCES [dbo].[AreaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AreaData'
CREATE INDEX [IX_FK_AreaData]
ON [dbo].[DataSet]
    ([Area_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------