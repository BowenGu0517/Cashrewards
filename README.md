# Cashrewards

## Tech stacks
ASP.NET Core Web API 3.1 + React 16.13.1 + SQL Server 2017 latest ubuntu docker image


## Steps to run the project
Under VS 2019:
- Run `docker-compose up` to fire up the linux sql server express 2017 docker container 
- Publish "DataBase" project with `Load Profile` "DataBase.publish.xml" under it, it will generate the `Cashrewards` database and `Merchant` table
- Build and Start the Visual Studio Solution as one go (Or run `npm install` followed by `npm start` separately to only start the frontend project). The project is using CRA template as frontend wich integrates with .net core Web API as backend. The CRA project folder is under `Cashrewards.Host/ClientApp`


## Project Architecture
Backend is using clean architecuture:
- `Cashrewards.Infrastructure` manages the data access logic with sql server
- `Cashrewards.Application` manages the application logic, including incoming request validation, data aggregating. It talks to `Cashrewards.Infrastructure` and `Cashrewards.Host`
- `Cashrewards.Host` manages the backend surface web apis. The `MerchantsController` defines all the CRUD endpoints required for the project.

Frontend:
- `Cashrewards.Host\ClientApp\src\components` defines all the re-usable functional components
- `Cashrewards.Host\ClientApp\src\containers`defines all the higher level container components
- `Cashrewards.Host\ClientApp\src\api` defines all the apis which interact with backend apis

Tests:
- `Cashrewards.Unit.Test` and `Cashrewards.Funtional.Test` are the unit and functional tests for backend project, by using Xunit, Moq.
- Frontend tests are under each component folder, by using Jest.


## Project Feature
1. Show all the available merchats in the application home page, as a table.
2. Provide the functionality of creating new merchant
3. Provide the functionality of editing a existing merchant
4. Provide the functionality of deleting a existing merchant
5. Request paramter format validation for both frontend and backend 
6. Each CRUD action has been separated in backend so easier for manage and align to the separation of concern principle.


## Things to be improved
1. Current Add/Save/Delete frontend action does not give user a confirmation popup. Would be nicer if adding the functionality.
2. Current drop down options for Country and Currency are stored in frontend. Ideally these can be fetched from backend. However backend does have validtion logic to make sure the data is valid. This is just a consideration of improvement for data consistency.
3. Current "WebsitUrl" validation logic only checks whether the input value is not null or empty. Would be nicer to improve the logic to check certain format by using regex or built-in url validator.
4. Current UI does not have a navigation header. Due to the project size, there are only two main pages, I put the table in the main page and the other page handle add/save logic. But it would still be nicer to create a navigation bar. 
