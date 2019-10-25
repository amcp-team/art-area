# ArtArea

Service for source control and management of digital art projects 

### Project Structure

Solution : ArtArea
- Web Client : `ArtArea.Web` - created as empty ASP.NET Core project (`dotnet new web`)
   - Models : stores Data Services & dbs (ef core & mongodb)
   - ViewModels : stores models used in views
   - Controllers : stores controllers
   - Views : stores views & shared files
- Models : `ArtArea.Models` - for future desktop client (`dotnet new lib`) 

Both projects use .NET Core 3.0

Packages:
- MongoDb.Driver
- MongoDB.Driver.GridFS
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.InMemory
- Microsoft.EntityFrameworkCore.SqlServer
...

### Plan

// views are developed in parallel
1. User model for login authorization
1. Identity | Models | Data Service Interfaces
1. Home Controller
1. Auth Controller - requires db logic (mongodb) for adding users
1. User Ccontroller - requires db logic for users & repositories
1. Repository Controller - requires db logic for -//- + canvases
1. Canvas Controller - requires complex view for it and db logic 
...

### (Un)Useful links 

Saving user data in WPF application:
- [c# - approach for saving user settings in a WPF application?](https://stackoverflow.com/questions/3784477/c-sharp-approach-for-saving-user-settings-in-a-wpf-application)
- [Managing Application Settings (.NET)](https://docs.microsoft.com/en-us/visualstudio/ide/managing-application-settings-dotnet?view=vs-2015&redirectedfrom=MSDN)
- [User Settings in WPF](https://blogs.msdn.microsoft.com/patrickdanino/2008/07/23/user-settings-in-wpf/)
- [WPF/C#: Where should I be saving user preferences files?](https://stackoverflow.com/questions/396229/wpf-c-where-should-i-be-saving-user-preferences-files)

Navigation In WPF with MVVM:
- [The MVVM pattern – Dependency injection](https://blog.qmatteoq.com/the-mvvm-pattern-dependency-injection/)
- [WPF MVVM navigate views](https://stackoverflow.com/questions/19654295/wpf-mvvm-navigate-views/19654812)
- [Navigating between views in WPF / MVVM](https://www.technical-recipes.com/2018/navigating-between-views-in-wpf-mvvm/)
