#Read Me

##Instructions

###Internet Information Services (IIS) Manager
_Edit Application Pool
_Name: mvc
_.NET CLR version: No Managed Code
_Managed pipeline mode: Integrated
_/Start application pool immediately

###Sites > mvc
_Bindings...
_Edit Site Binding
_Type: http
_IP address: All Unassigned (*)
_Port: 82
_Host name: *

###web.config
><aspNetCore processPath="dotnet" arguments=".\mvc.dll" stdoutLogEnabled="false" stdoutLogFile=".\logs\stdout" hostingModel="inprocess">
			<environmentVariables>
				<environmentVariable name="ASPNETCORE_ENVIRONMENT" value="Development" />
			</environmentVariables>
		</aspNetCore>
