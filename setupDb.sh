echo "Starting up the contaier"
docker-compose up -d

cd src/F1.DbUp

echo "Setting up the database"
dotnet run

echo "Finished"
echo "DB connection: 'Host=localhost;Username=api;password=api;database=f1api;Port=5432'"