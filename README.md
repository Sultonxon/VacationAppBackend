# VacationAppBackend


## Running development server

solution contains 4 projects: VacationApp.Common, VacationApp.Application, VacationApp.Data, VacationApp.

Open VacationApp folder

Run `ng serve` for a dev server. Navigate to `http://localhost:4458/swagger` to see swagger.

##Database

this project automatically migrates database, postgresql database intended to be accessable via localhost:5432 host in development mode, you can change this in appsetting.json file, ConnectionStrings section, Default key.
Don't forget to use user name and passwords for you postresql server, in my case username is postgres, password is web123$

'''

  "ConnectionStrings": {
    "Default": "Server=localhost;Port=5432;Database=Vacation;User Id=postgres;Password=web@1234;"
  }
'''
