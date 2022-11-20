ScanEventExercise

#Assumptions:

- Scan Event API endpoint returns the event data from json file from ( \\Data\\scanevents.json). For testing purpose I have added 3 events in scanevents.json 
- Application uses required configuration for WorkerService i.e (ScanEventServiceUrl) and Seq from appsettings.json

#Improvements:

- For exercise purpose, I am fetching scan event data from .json file which can be moved to EF/database .
- This application is currently using unit tests for tesing differnt modules. In Future, integration tests can be added to test the different components like web api calls, database operations
- Currently application follows monolithic architecture which can be useful when working in small team and application is simple. But in future, in case of evolving, expansion of functionality it will be difficult to maintain the current application hence the project can be converted into microservice architecture.
- Also, to handle the scenario of calling same scan events from multiple worker application, we can configure worker services to receive messages published from different providers like RabbitMQ SQS etc.

#Deliverable:

- ScanEventExercise is .net core web API project with hosted service to run backgroud tasks.
- Run ScanEventExercise application using IIS Express and ScanEventsWorker worker service will run in the background to fetch ScanEvents data from web PI
- SEQ service should be running locally for viewing event logs from browser.  SEQ service can be installed locally using this link (https://datalust.co/Download) and access using http://localhost:5341 to view logs/events.
- If needed, missing NuGet packages can be downloaded or updated online.
