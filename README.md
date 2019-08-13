# StudentskaPraksa


Local Sql server:
(localdb)\mssqllocaldb

Entity Framework nuget packages:

Microsoft.EntityFrameworkCore.SqlServer   (install-package Microsoft.EntityFrameworkCore.SqlServer)
Microsoft.EntityFrameworkCore.Design   (install-package Microsoft.EntityFrameworkCore.Design)
Bricelam.EntityFrameworkCore.Pluralizer (install-package Bricelam.EntityFrameworkCore.Pluralizer)

Scaffold DB command:
dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=StudentskaPraksa;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models
