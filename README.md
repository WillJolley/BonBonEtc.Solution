# _BonBon, Etc._

#### By _Will Jolley_

#### _A web app for managing a database of treats and flavors_

## Technologies Used

* C#
* ASP.NET core MVC
* Razor Pages


## Description

BonBon, Etc. is a web app that allows users to create and edit lists of treats and flavors.   

## Setup Instructions

- Note: An installation of the .NET SDK is required in order to run this application locally. [See Here](https://dotnet.microsoft.com/en-us/) for installation.
1. Clone this repo.
2. Open your shell (e.g., Terminal or GitBash) and navigate to this project's directory called "BonBonEtc/". 
3. Create a file named `appsettings.json`: `$ touch appsettings.json`
4. Within `appsettings.json` add the following code, replacing the `uid` and `pwd` values with your own username and password for MySQL.

    ```json
    {
      "ConnectionStrings": {
          "DefaultConnection": "Server=localhost;Port=3306;database=bonbon_etc;uid=[YOUR-USERNAME];pwd=[YOUR-MYSQL-PASSWORD];"
      }
    }
    ```
5. Set up the database: `$ dotnet ef database update`
6. Navigate to the project directory: `$ cd BonBonEtc`
7. Run `$ dotnet watch run` in the command line to start the project in development mode with a watcher.
8. Open the browser at: _https://localhost:5001_. If you cannot access localhost:5001 it is likely because you have not configured a .NET developer security certificate for HTTPS. To learn about this, review this lesson: [Redirecting to HTTPS and Issuing a Security Certificate](https://www.learnhowtoprogram.com/c-and-net/basic-web-applications/redirecting-to-https-and-issuing-a-security-certificate).

## Known Bugs

N/A

## License

e-mail me at yeswilljolley@gmail.com with any issues, questions, ideas, concerns.

MIT

Copyright (c) 2023 Will Jolley