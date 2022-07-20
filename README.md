> # Xeynergy_CRUDAPP

> ## Steps to setup the API

- Clone the repository.
- Open the `CRUDAPI` project in visual studio.
- Add connection to the sql server from `Server Explora`.
  <br/>
  &emsp; Add Server - View -> Sever Explora -> Server
  <br/>
  &emsp; Add Data Connection - View -> Server Explora -> Data Connection
  <br/>
- Replace the connection string in the `CRUDAPIDBContext.cs` file with your own connection string.
  &emsp;
- Open the `NuGet Package Manager Console`.
  <br/>
  &emsp; Tools -> NuGet Package Manager -> Package Manager Console
- Run `dotnet ef migrations add --project .\CRUDAPI.DataAccess`.
- Run `dotnet ef database update --project .\CRUDAPI.DataAccess`.
- Then run the `CRUDAPI`.

---

<br/>

> ## Steps to setup the web app

- Open the `CRUDAPPWEB` in the `Visual Studio Code`.
- Open the termial and run `npm i` command.
- Run the `ng s -o` command.
