CD\
CD\Projects\TourManagement\Scripts

IF NOT EXIST C:\Publish\ mkdir C:\Publish\
IF NOT EXIST C:\Publish\TourManagement\ mkdir C:\Publish\TourManagement\
del /S /F /Q C:\Publish\TourManagement

dotnet publish ..\TourManagement.API\TourManagement.API.csproj -f netcoreapp2.0 -c Development --output "c:\Publish\TourManagement"
