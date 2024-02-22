# Read Me

## Instructions

### How to deploy ASP.NET Core MVC IIS
1. Install the .NET Core Hosting Bundle
2. Install the .NET Core SDK
3. Restart IIS with iisreset

### Internet Information Services (IIS) Manager
- Edit Application Pool
- Name: **mvc**
- .NET CLR version: **No Managed Code**
- Managed pipeline mode: **Integrated**
- [/]Start application pool immediately

### Sites > mvc
- Bindings...
- Edit Site Binding
- Type: **http**
- IP address: **All Unassigned (*)**
- Port: **82**
- Host name: **(*)**

### web.config
Add below codes to your web.config
```
<aspNetCore processPath="dotnet" arguments=".\mvc.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess">
	<environmentVariables>
		<environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
	</environmentVariables>
</aspNetCore>
```
