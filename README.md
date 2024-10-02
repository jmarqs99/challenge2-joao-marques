## Challange #2

These instructions will help you set up and run the tests in this NUnit project.

### Prerequisites
- .NET SDK (v8.0 or higher)
- NUnit Framework
- NUnit3TestAdapter

### Running the Tests

You can run the tests using the dotnet test command from the project directory. This will execute the API tests and display the results in the terminal.

```bash
dotnet test
```

To generate test results in a specific format, refer to the next section.

### Generating Test Reports

You have multiple options to generate test reports, including XML and HTML formats.

#### HTML 
```bash
dotnet test --logger "html LogFileName=TestResults.html"
```
#### XML 
```bash
dotnet test --logger "nunit;LogFileName=TestResult.xml"
```
