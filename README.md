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