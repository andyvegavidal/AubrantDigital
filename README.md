# Aubrant Digital Project

This project consists of a backend API built with .NET and a frontend application built with Angular. Below are the steps to run the solution locally and execute unit tests.

## Backend Setup (Product API)

### Steps:
1. Navigate to the `AubrantDigitalBackend/ProductApi` directory:
   ```bash
   cd AubrantDigitalBackend/ProductApi

2. Build the solution:
   ```bash
   dotnet build

3. Run the backend API:
   ```bash
   dotnet run
The API will be hosted at http://localhost:5172/.

4. Access the Swagger documentation at:
   ```bash
   http://localhost:5172/swagger/index.html
Swagger will allow you to interact with and test the API endpoints directly in your browser.


## Frontend Setup (Angular)

### Steps:
1. Navigate to the AubrantDigitalFrontEnd directory:
   ```bash
   cd AubrantDigitalFrontEnd

2. Install the required npm dependencies:
   ```bash
   npm install

3. Run the frontend application:
   ```bash
   ng serve

The Angular frontend will be available at: http://localhost:4200/

## Frontend Setup (Angular)

### Steps:
1. Navigate to the AubrantDigitalBackend/ProductApi.test directory:
   ```bash
   cd AubrantDigitalBackend/ProductApi.test

2. Run the unit tests:
   ```bash
   dotnet test

The results of the unit tests will be displayed in the terminal.
