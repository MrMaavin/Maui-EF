# Maui with Entity Framework

This is an example Project to use Entity Framework within a MAUI App and still be able to use Android.

The example is based on this Video [EntityframeworkCore code first, SQLite for MAUI.](https://youtu.be/i-oiB0KMZrE)

## Add Migrations

To add migration you have to edit the `MauiEF.csproj` file.
1. Comment the following line:
````html
    <!--<TargetFrameworks>net8.0-android;net8.0-ios;net8.0-maccatalyst</TargetFrameworks>-->
````

2. Add the following line:
```html
    <WindowsAppSdkDeploymentManagerInitialize>true</WindowsAppSdkDeploymentManagerInitialize>
```

3. Then you can run the migration in the `DbLibrary` project folder
````shell
    dotnet ef migrations add migrationNameHere
````

To run the application you have to revert the changes in the `MauiEF.csproj` file.