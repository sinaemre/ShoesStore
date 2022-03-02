# ShoeStrore

### Project Structure 
```
/src
* Application Core
* Infrastructure
* Web

/tests
*UnitTests

```

### Migrations
```
/Infrastructure
Add-Migration InitialCreate -Context StoreContext -OutputDir "Data\Migrations"
Update-Database -Context StoreContext 




```

### Packages
```
/Application Core
Install-Package Ardalis.Specification

/Infrastructure
Install-Package Microsoft.EntityFrameworkCore -v 5.0.14
Install-Package Npgsql.EntityFrameWorkCore.PostgreSql -v 5.0.10
Install-Package Ardalis.Specification.EntityFrameworkCore -v 5.2.0

```

### Resources

* https://github.com/yigith/TechMarket
* https://github.com/dotnet-architecture/eShopOnWeb
* https://www.connectionstrings.com/postgresql/
