# Assessment
Clienttele Assesment

 LibraryManagementSystem & CustomerManagementSystem

This repository contains two separate .NET projects:

LibraryManagementSystem — manages books, authors, and related library operations.

CustomerManagementSystem — manages customer records and related services.

Both projects use Microsoft SQL Server databases.

Databases
Project	Database Name	Database Type
LibraryManagementSystem	LibraryDB	SQL Server Database
CustomerManagementSystem	CustomerDB	SQL Server Database

Prerequisites

Before running the projects, make sure you have the following installed:

Visual Studio 2022 or later

.NET 6.0 SDK (or your project’s target framework)

Microsoft SQL Server (Express, Developer, or full edition)

SQL Server Management Studio (SSMS)

	Step 1: Attach the Databases

Open SQL Server Management Studio (SSMS).

Connect to your SQL Server instance.

Right-click on Databases → Attach...

Browse to and select the provided database files:

CustomerDB.mdf

LibraryDB.mdf

Confirm and click OK.

Verify both databases appear in your Databases list.

	Step 2: Update the Connection Strings

After attaching the databases,  Web.config (for .NET Framework) with your SQL Server instance name.
 

LibraryManagementSystem
<connectionStrings>
   <add name="LibraryDBEntities" connectionString="metadata=res://*/LMSModel.csdl|res://*/LMSModel.ssdl|res://*/LMSModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DBServerName;initial catalog=LibraryDB;integrated security=True;encrypt=False;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />

</connectionStrings>

CustomerManagementSystem



	Replace ServerName with your actual SQL Server name.


Example for Web.config (if .NET Framework)
<connectionStrings>
    <add name="CustomerDBEntities" connectionString="metadata=res://*/CustomerEntity.csdl|res://*/CustomerEntity.ssdl|res://*/CustomerEntity.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ServerName;initial catalog=CustomerDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />

</connectionStrings>

	Step 3: Build and Run the Applications

Open each project (LibraryManagementSystem.sln or CustomerManagementSystem.sln) in Visual Studio.

Restore NuGet packages (Tools → NuGet Package Manager → Restore Packages).

Build the solution (Ctrl + Shift + B).

Run the application (Ctrl + F5).
