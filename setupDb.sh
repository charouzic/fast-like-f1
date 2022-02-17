echo "Starting up the contaier"
docker-compose up -d

cd src/F1.DbUp

echo "Setting up the database"
dotnet run

# need to run the command inside the docker
# Run psql
#docker exec -it fast-like-f1-f1.postgres-database-1 psql -U api -d f1api

# import CSV
#\copy Drivers FROM '/Users/viki/Desktop/projects_programming/fast-like-f1/src/data/drivers.csv' DELIMITER ',' CSV HEADER;
#psql -c "Drivers(id, firstName, lastName, country, dateOfBirth, placeOfBirth, team, numberOfPodiums, firstSeason, note) from '/Users/viki/Desktop/projects_programming/fast-like-f1/src/data/drivers.csv' DELIMITER ',' CSV HEADER"

echo "Finished"
echo "DB connection: 'Host=localhost;Username=api;password=api;database=f1api;Port=5432'"

cd ..

cd F1Api
echo "Running the project"
dotnet run
