# ValidationAPI README

## Table of Contents
- [Overview](#overview)
- [Running the Application Locally](#running-the-application-locally)
- [Examples of Using the Developed Endpoint](#examples-of-using-the-developed-endpoint)
- [Note](#note)

## Overview

ValidationAPI is a versatile and powerful web application designed to provide comprehensive validation and filtering of country data. This project aims to offer a simple yet robust solution for retrieving country information based on various filters and sorting criteria. By utilizing this API, developers can seamlessly access and manipulate country data for a wide range of use cases, from educational projects to data analysis and application development.

The core functionality of ValidationAPI centers around retrieving country data through a well-defined endpoint. This endpoint accepts query parameters that allow you to filter countries based on their names, population, and other attributes. Additionally, the API supports sorting and pagination, enabling you to retrieve and display the data in a structured manner. The project is built using ASP.NET Core and leverages modern programming patterns to ensure efficiency, maintainability, and scalability.

## Running the Application Locally

To run the ValidationAPI locally on your machine, follow these steps:

1. Clone this repository to your local machine.
2. Navigate to the `ValidationAPI` directory.
3. Open the solution file (`ValidationAPI.sln`) using a compatible IDE (e.g., Visual Studio, Visual Studio Code with C# extension).
4. Build the solution to restore dependencies and compile the project.
5. Configure the required settings in the `appsettings.json` file, such as API endpoints and other configuration options.
6. Run the application by executing the project.

Ensure you have the necessary .NET runtime and SDK installed on your machine before attempting to run the application.

## Examples of Using the Developed Endpoint

Here are some examples of how to use the developed endpoint to retrieve country data with various filters and sorting options:

1. Retrieve all countries:
   `GET /countries`

2. Retrieve countries with a specific name:
   `GET /countries?CountryName=Canada`

3. Retrieve countries with a population greater than 100 million:
   `GET /countries?CountryPopulation=100000000`

4. Retrieve countries sorted by name in ascending order:
   `GET /countries?SortBy=ascend`

5. Retrieve countries sorted by population in descending order:
   `GET /countries?SortBy=descend`

6. Retrieve countries with pagination (e.g., first 10 countries):
   `GET /countries?Pagination=10`

7. Retrieve countries with a specific name and population range:
   `GET /countries?CountryName=United&CountryPopulation=50000000`

8. Retrieve countries with population between 50 million and 200 million:
   `GET /countries?CountryPopulation=50000000-200000000`

9. Retrieve countries with specific name and sorted by population:
   `GET /countries?CountryName=India&SortBy=descend`

10. Retrieve countries with pagination and sorted by name:
    `GET /countries?Pagination=5&SortBy=ascend`