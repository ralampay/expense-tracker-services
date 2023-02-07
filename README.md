# Expense Items API Demo C# ASP Backend

## Commands for Testing (via curl)

### Fetching all Expense Items

```
curl http://localhost:5040/expense_items | jq
```

### Saving a New Expense Item from file `payloads/expenseItem.json`

```
curl -X POST -H "Content-Type: application/json" -d @payloads/expenseItem.json http://localhost:5040/expense_items | jq
```

### Fetching all Categories

```
curl http://localhost:5040/categories | jq
```

### Saving a New Category from file `payloads/category.json`

```
curl -X POST -H "Content-Type: application/json" -d @payloads/category.json http://localhost:5040/categories | jq
```

## Database Setup

### Add SQLServer Dependencies for EntityFramework

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

### Add EntityFrameworkCore Design Package

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Add the Dotnet EF Tool

```
dotnet tool install --global dotnet-ef
```

```
dotnet-ef --version
```

## Exercises

### Exercise 6

1. Establish 2 tables for your project that are related to each other.
2. Modify the models to establish the necessary relationships
3. Create a migration file/s for the changes
4. Create the necessary services for these models
5. Prove via API that you can fetch one or the other related data.