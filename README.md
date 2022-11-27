# ContactsApp
ASP.Net Web API using EF and Identity Server with SPA frontend 
Currently using .Net 7 and Angular 15 for the UI

## Database Setup

Create a `ContactsDemo` Database in your local SQL server (or alternatively replace the EF database provider, and update the connection string in appsettings)
Run the EF Database Migrations

## API Setup

No setup should be necessary, just run it after the database been setup

## Angular App
Run `npm install` in `src\Contacts.UI\ng-contacts` and then run it as usual (`ng s` or `npm start`, whatever tickle your fancy)
