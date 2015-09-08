DirtRallyWebTelemetry
=====================
Console application that listens on port 20777 to capture telemetry data from Codemasters racing games.

Exposes a web frontend on port 8080 to show the telemtry data.

Large parts of the listening side are based on the project [F1Speed](https://github.com/robgray/F1Speed), so credits for this go to that project.

Development
-----------

Tools:
* Visual Studio 2013 with Web Essentials (there is a free [Community edition](https://www.visualstudio.com/products/free-developer-offers-vs.aspx) available)
* [Node JS](https://nodejs.org/)

Run ```npm install --dev``` in the WebFrontend project to set everything up

Usage
-----

Start the application DirtRallyConsoleListener.exe, and open a browser that points to http://localhost:8080/ on the same machine,
or if you want to connect from another device http://{your-computers-ip}:8080/

Add an inbound rule in your firewall for port 8080.

Either run the application as Administrator, or before the first run,
open a command line window with admin privileges, and enter
```netsh http add urlacl url=http://+:8080/ user={your windows user name}```