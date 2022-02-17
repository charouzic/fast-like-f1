# Formula 1 API

## Motivation behind
This project is made from pure joy and enthusiasm about Formula 1 after watching the Drive to Survive Netflix series. 
It is dedicated to serve data about drivers, teams and many more in a conscise way so one does not need to spend hours
going through wikipedia and finding facts about Formula 1. Everything is in one place and easy for use.

The project also represents a playground for trying out the [FuncSharp](https://github.com/siroky/FuncSharp) library maintained and widely use by 
[Mews](mews.com) (Czech company within hospitality). It is adopting functional way of writing code, using immutable data structures, pattern matching
and many more cool stuf that functional langugues like Scala posses.

## Prerequisities for running the project
The machine you will run this project on needs to have installed [docker](https://www.docker.com/get-started) and [dotnet](https://dotnet.microsoft.com/en-us/download).

## Running the Project

After that you can navigate to the root directory of the project and run command to run shell script setting up database (make sure that the docker is running):
```
./setupDb.sh
```

Note that you might need to grant permissions the shell script. You can do that by running the following command:
```
chmod +x ./setupDb.sh
```

Ater that you should be able to see the swagger API representation at both urls:
- https://localhost:7143/swagger
- http://localhost:5036/swagger

Or by just calling the given endpoints from postman for example.
