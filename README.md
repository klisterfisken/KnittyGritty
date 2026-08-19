# KnittyGritty

A database and Razor Pages CRUD app for keeping track of knitting and crochet patterns. Built to solve a very real problem: patterns scattered across bookmarks, PDFs and notebooks, with no good way to search by what actually matters - yarn weight, needle size, gauge, or which languages a pattern is available in.

## What it does

- Stores patterns with details like gauge, needle/hook size, yarn weight, technique (knit or crochet), and notes
- Links each pattern to a designer, one or more categories, languages, sizes and yarns - so a single sweater pattern can, for example, be searchable by all the sizes and yarns it comes in
- Full CRUD management for patterns, designers, categories, languages, sizes, yarns and yarn brands
- Lets the user filter search results by these attributes
- User accounts via ASP.NET Core Identity, with an admin account seeded on first run

## Tech stack

- ASP.NET Core Razor Pages (.NET 10, C#)
- Entity Framework Core with SQL Server
- ASP.NET Core Identity for authentication
- Bootstrap, using the Minty theme from Bootswatch

## Running it locally

You'll need a local SQL Server instance (LocalDB works fine).

1. Set the admin account credentials via .NET User Secrets:
```bash
   dotnet user-secrets set "AdminCredentials:UserName" "your-username"
   dotnet user-secrets set "AdminCredentials:Password" "your-password"
```
2. Apply the database migrations:
```bash
   dotnet ef database update
```
3. Run the app:
```bash
   dotnet run
```

The app will be available at `https://localhost:7273` (or `http://localhost:5203`).

## Status & vision

Core CRUD functionality and filtering are in place. The long-term goal is to turn this into a genuinely powerful search engine; one where you can combine many different data points (yarn weight, gauge, needle/hook size, category, language, and more) to filter down a large pattern collection with real precision, rather than just browsing a list.
