# Read Me

## Instructions

### Internet Information Services (IIS) Manager
_ Edit Application Pool
_ Name: mvc
_ .NET CLR version: No Managed Code
_ Managed pipeline mode: Integrated
_ -[x]Start application pool immediately

### Sites > mvc
_ Bindings...
_ Edit Site Binding
_ Type: http
_ IP address: All Unassigned (*)
_ Port: 82
_ Host name: *

### web.config
> <aspNetCore processPath="dotnet" arguments=".\mvc.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess">
			<environmentVariables>
				<environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
			</environmentVariables>
		</aspNetCore>
