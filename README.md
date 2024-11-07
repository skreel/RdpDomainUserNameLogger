Welcome to the RdpDomainUserNameLogger wiki!

This is a simple Http Moudle that plugs into the IIS pipeline, extracts the user name from the post data and then appends the user name to the IIS logs.

This allows you to use [IPBan](https://github.com/DigitalRuby/IPBan) or similar to block IPs based on usernames.

Install by 
1. compiling the project and getting the RdpDomainUserNameLogger.dll
2. Place RdpDomainUserNameLogger.dll in the C:\Windows\Web\RDWeb\Pages\Bin directory
3. Hook the http module into the iis request pipeline by modifying C:\Windows\Web\RDWeb\Pages\Web.config

>  add **\<add name="RdpDomainUserNameLogger" type="RdpDomainUserNameLogger.PostLoggerHttpModule, RdpDomainUserNameLogger" />**
>  to the modules section

>   \<system.webServer>\
>     \<modules runAllManagedModulesForAllRequests="true">\
>       \<remove name="FormsAuthentication" />\
>       \<add name="RDWAFormsAuthenticationModule" type="Microsoft.TerminalServices.Publishing.Portal.FormAuthentication.TSDomainFormsAuthentication" />\
>       **\<add name="RdpDomainUserNameLogger" type="RdpDomainUserNameLogger.PostLoggerHttpModule, RdpDomainUserNameLogger" />**\
>     \</modules>
