# Photify

## Database Migrations
- PostgreSQL
  - `dotnet ef migrations add MyMigration --context PhotifyContext --project ../Photify.Migrations.PostgreSQL -- --DB_PROVIDER PostgreSQL`

- SQLite
  - `dotnet ef migrations add MyMigration --context PhotifyContext --project ../Photify.Migrations.SQLite -- --DB_PROVIDER SQLite`