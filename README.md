# AwesomeGymAPI
Bootcamp ASP.NET Core - Construindo uma API para gerenciamento de academias de ginástica

---

<h2>:wrench: Recursos</h2>
<ul>
  <li>Entity Framework</li>
  <li>Swagger</li>
  <li>ASP.NET Core</li>
  <li>Banco de dados em memória</li>
  <li>MySQL</li>  
  <li>SQL Server</li>  
</ul>

---

<h2>:triangular_flag_on_post:Como executar?</h2>

1- Clone o repositório
```
git clone https://github.com/VictorMello1993/AwesomeGymAPI.git
```

2- Abra o Visual Studio. As dependências já estão instaladas no projeto, sem a necessidade de ter que instalar tudo novamente. Isso pode ser visto através do arquivo ```AwesomeGym.API.csproj```

3- Normalmente o projeto pode apresentar problemas de compilação devido às dlls geradas da compilação realizada anteriormente em outra máquina. Para isso, execute Clean Solution e recompile que o erro não será mais reproduzido.

4- Como já temos uma migration disponível no projeto a ser inicializado para um tipo de banco de dados (vide pasta Persistence/Migrations), é preciso executar os seguintes comandos via cmd ou Power Sheel:

```
dotnet tool install --global dotnet-ef 
```

```
dotnet ef database update
```
OBS: Lembrando que na linha de comando, é preciso navegar até a pasta raíz da aplicação (no caso, é a pasta ```AwesomeGym.API```)

No entanto, antes executar estes comandos, é preciso configurar a connection string no arquivo ```appsettings.json``` colocando as informações necessárias para conexão de um banco de dados, como nome do servidor (geralmente é ```localhost```, pois se trata do ambiente de desenvolvimento), nome do usuário, senha, porta e o nome do banco a ser criado. Segue o exemplo abaixo:

![Screenshot_3](https://user-images.githubusercontent.com/35710766/97115092-6991b780-16d3-11eb-807c-0644173bf935.png)
<p align="center"><i>Conexões de banco de dados MySQL e SQL Server</i></p>




Por exemplo, optou-se por conectar com o banco MySQL. Além da connection string, é preciso verificar que na classe ```Startup.cs``` esteja usando banco de dados MySQL, conforme a linha abaixo:

![Screenshot_4](https://user-images.githubusercontent.com/35710766/97115263-8da1c880-16d4-11eb-84dc-c84360e20e85.png)

A conexão com MySQL é realizada graças ao pacote ```Pomelo.EntityFramework.MySQL``` instalado. Por padrão, o Entity Framework possui suporte nativo para bancos do SQL Server, mas existem várias bibliotecas que permitem configuração para outros tipos de bancos de dados.

Após esses procedimentos, o Entity Framework irá automaticamente criar a base e mapear as classes de entidades e suas propriedades para gerar tabelas e suas respectivas colunas de acordo com o que foi configurado na migration e na ORM, na classe DbContext ```AwesomeGymDbContext.cs```. Nessa classe, Cada DbSet representa uma tabela, e as configurações estão dentro de cada classe Configuration, que herda da interface ```IEntityTypeConfiguration<TipoEntidade>```

![Screenshot_5](https://user-images.githubusercontent.com/35710766/97115800-96e06480-16d7-11eb-8828-4404d87c7019.png)


![Screenshot_6](https://user-images.githubusercontent.com/35710766/97115799-9647ce00-16d7-11eb-870e-b225819080d8.png)
<p align="center"><i>Mapeamento da classe de entidade Professor</i></p>

5- Pronto, agora é só executar o projeto e acessar através do endereço
```https://localhost:5001/swagger/index.html```

---
<h2>Versões do README</h2>
<a href="/README-ENUS.md">Inglês</a> | <a href="/README.md">Português</a> 
