# Create Migration Another Location

```console
dotnet ef migrations add init --startup-project .\codeislife.crm.web.app.csproj --project ..\codeislife.crm.data\ --context CrmDbContext
```

# Update Database

```console
dotnet ef database update--startup-project .\codeislife.crm.web.app.csproj --project ..\codeislife.crm.data\ --context CrmDbContext
```