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