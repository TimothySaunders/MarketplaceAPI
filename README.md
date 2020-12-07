# MarketplaceAPI
Simple RESTful API for CRUD actions on a product database built using .NET Core 3.1 and Postgresql

## Prerequisites
- ASP.NET Core Runtime 3.1
- Postgresql **OR** Docker (for containerized postgresql db, preferred)

## Installation
1. 
**Preferred Option:** Use Docker to create a containerized postgresql database using the command:
***$ docker run --name my_postgres -p 5433:5432 -e POSTGRES_PASSWORD=postgres postgres***

**Alternative Option:** Ensure Connection string is correct for local postgresql databse, in appsettings.json
> - Password must be set to the password user chose during postgres installation (Windows), or User Id / Password combination if not using the postgres superuser("postgres")
> - default port for local postgresql is 5432
> - If running on MacOS there may be no password set in which case both "User ID=..." and "Password=..." can be removed
> - In the unlikely event you already have a Postgres database named ProductsDB you should change "database=..." to a name of your own choosing

2. In command prompt, navigate to project directory and run the command:
***$ dotnet run***

## API End Points
Accessible through http//:localhost:5000, https//:localhost:5001
- ***HTTPGET* */swagger***         : Shows OpenAPI swagger inspector
- ***HTTPGET* */products***        : Shows all products
- ***HTTPGET* */product/{id}***    : Shows individual product
- ***HTTPPOST* */product***        : Creates new product
- ***HTTPPUT* */product/{id}***    : Modifies product
- ***HTTPDELETE* */product/{id}*** : Deletes product
