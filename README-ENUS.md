# AwesomeGymAPI
Bootcamp ASP.NET Core - Building a gym management API

---

<h2>:wrench: Features</h2>
<ul>
  <li>Entity Framework</li>
  <li>Swagger</li>
  <li>ASP.NET Core</li>
  <li>In memory database</li>
  <li>MySQL</li>  
  <li>SQL Server</li>  
</ul>

---

<h2>:triangular_flag_on_post:How to run it?</h2>

1- Clone the repository
```
git clone https://github.com/VictorMello1993/AwesomeGymAPI.git
```

2- Open Visual Studio. The dependencies are already installed on the project, no need to have to install everything again. This can be seen through file ```AwesomeGym.API.csproj```

3- Usually the project may have compilation problems due to the dlls generated from the compilation performed previously on another machine. To fix it, execute Clean Solution and rebuild that the error will no longer be reproduced

4- As we already have a migration available on the project to be initialized for a database type (search directory Persistence/Migrations), is need to run the following commands with cmd or Power Sheel:

```
dotnet tool install --global dotnet-ef 
```

```
dotnet ef database update
```
OBS: Remember that on the command line, is need to navigate to the root folder (in this case, is ```AwesomeGym.API``` folder)

However, before running those commands, is need to configure a connection string on the ```appsettings.json``` file filling in the necessary information to connect a database, such as server name (usually is ```localhost```, because we are at the development environment), user name, password, port and database name to be created. Follow the example below:

![Screenshot_3](https://user-images.githubusercontent.com/35710766/97115092-6991b780-16d3-11eb-807c-0644173bf935.png)
<p align="center"><i>MySQL and SQL Server database connections</i></p>



For example, it's decided to connect with MySQL database. In addition to the connection string, is need to check whether the class ```Startup.cs``` is using MySQL connection, as the following line:
![Screenshot_4](https://user-images.githubusercontent.com/35710766/97115263-8da1c880-16d4-11eb-84dc-c84360e20e85.png)

The MySQL connection is realized thanks to the package ```Pomelo.EntityFramework.MySQL``` installed. By default, Entity Framework has a native support for the SQL Server databases, but there are a lots of libraries which allow to configure for others database types.

After following the steps above, Entity Framework will create a database and map the entity classes and their properties automatically in order to generate tables and their columns based on what it is configured on the migration and on the ORM, at DbContext class ```AwesomeGymDbContext.cs```. In this class, each DbSet represents a table, and the configurations are within each Configuration class, that inherits from ```IEntityTypeConfiguration<TipoEntidade>``` interface


![Screenshot_5](https://user-images.githubusercontent.com/35710766/97115800-96e06480-16d7-11eb-8828-4404d87c7019.png)

![Screenshot_6](https://user-images.githubusercontent.com/35710766/97115799-9647ce00-16d7-11eb-870e-b225819080d8.png)
<p align="center"><i>Teacher entity class mapping </i></p>

5- It's done, now just run the project and access through the address ```https://localhost:5001/swagger/index.html```
