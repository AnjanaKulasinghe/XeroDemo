
Tools and technologies used

	•	VS2015-Community Edition
	•	SpecFlow + NUnit
	•	NuGet Package Manager
	•	Selenium Webdriver
	•	ClosedXML


Prerequisites

	•	VS with NuGet Extension
	•	Chrome browser
	•	ReSharper (optional)


Setup Instructions

	1.	Open ‘XeroDemo.sln’ solution
	2.	Restore Nuget Packages (RC the solution  Restore NuGet Packages
	3.	Build the solution
	4.	Open ReSharper unit test panel (ReSharper menu --> Windows --> Unit Tests)
	5.	Create a unit test session.
	6.	Execute tests.


Project Structure

	•	DataFiles: System configuration text files are located here.
	•	Pages: All page objects are located here.
	•	Specs: All specflow feature files are located here.
	•	Steps: All specflow step definitions are located here.
	•	Utilities: All helper classes/utility classes are located here.
	•	app.config: Application configuration file.
	•	chromedriver.exe: Selenium chrome binary.
	•	package.config: NuGet package details.
