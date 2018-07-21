CD\
CD\Projects\TourManagement\Scripts

IF NOT EXIST C:\Publish\ mkdir C:\Publish\
IF NOT EXIST C:\Publish\TourManagementIdp\ mkdir C:\Publish\TourManagementIdp\
del /S /F /Q C:\Publish\TourManagementIdp

dotnet publish ..\Marvin.IDP\Marvin.IDP.csproj -f netcoreapp2.0 -c Development --output "c:\Publish\TourManagementIdp"
