# Gerador de Código Genesis

Ferramenta destinada a gerar código com base em uma estrutura de banco de dados SQL Server, focada em API e utilizando [Entity Framework](https://learn.microsoft.com/pt-br/ef/). GenesisTool é a 'tool' que comunica o usuário com o sistema onde faz todo o papel de CLI, ja a Library é a biblioteca que executa todas as funções e onde fica a arquitetura do codigo em si.



## Genesis

[NuGet Reference](https://www.nuget.org/packages/AspNetCore.Genesis/)



### Installation

#### Starting Project
Você pode utilizar da forma que quiser, contanto que o programa seja em C# a partir de .NET 8.

iniciando um projeto

```bash
> dotnet new webapi
```

Inserindo a tool
```bash
> dotnet add package --global AspNetCore.GenesisTool
```

Inserindo a Biblioteca
```bash
> dotnet add package AspNetCore.Genesis
```
    

## Genesis Tool 

A ferramenta utiliza a palavra 'gns' como palavra reservada para os comandos globais

a estrutura dos commandos se dá pela seguinte:

```bash
> gns {knd} {tool} {args}
``` 

#### Help

Para ver as opções de comandos digite o seguinte comando

```bash
> gns help
```

### Database

#### Add
Para gerar uma estrutura com base no banco de dados, você precisa primeiramente estar na pagina do projeto principal e digitar o seguinte comando:

```bash
> gns database add {database_url}
```

### config

#### proxy-url
Configurar proxy somente pela url direta de proxy no formato "http://username:password@domain:port". Desta forma ele irá configurar automaticamente o nome de usuário, senha e domínio do proxy.

```bash
> gns config proxy-url {url}
```

#### proxy-domain
Configura somente o domínio do proxy onde pode-se alterar o dominio independente do nome de usuário e senha.

```bash
> gns config proxy-domain {domain}
```

#### proxy-credential-username
Configura somente o nome de usuário do proxy.

```bash
> gns config proxy-credential-username {username}
```

#### proxy-credential-password
Configura somente a senha de usuário do proxy.

```bash
> gns config proxy-credential-password {password}
```

Com isso ele gerará a seguinte estrutura para **cada entidade** no banco de dados desejado.

```bash
├─ Core
│    └─ Entity
│        ├─ ClassMap
│        │      └─ EntityClassmap.cs
│        ├─ Repository
│        │      └─ EntityRepository.cs
│        └─ Service
│               └─ EntityService.cs
└─ Domain
     └─ Entity
         ├─ Model
         │    └─ Entity.cs
         ├─ Repositories
         │    └─ IEntityRepository.cs
         └─ Services
              └─ IEntityService.cs
```

### Configuration

#### Proxy Configuration

Para configurar o proxy via comando é necessario digitar os seguintes comandos:

#### Setting Proxy Host
```bash
gns config proxy-adress "http://yourhost.com:8080"
```
ou
```bash
gns config proxy-adress "http://100.100.100.100:8080"
```

#### Setting Proxy Username
```bash
gns config proxy-credential-username "yourUsername"
```
#### Setting Proxy Password
```bash
gns config proxy-credential-password "yourPassword"
```

Se as configurações de proxy não forem feitas o sistema não utilizará o proxy.


## Genesis

Biblioteca que será utilizada como base para a estrutura da API em sí, de forma seguinto o Princípio de Interface Segregation (SOLID) e temos as seguintes interfaces:




- **IRepository.cs**: base de repositorio a qual declaramos quais serão as ações base com o banco

- **IService.cs**: base de serviço onde utilizamos o repositorio.

- **IEntity.cs**: Base de entidade a qual é referente às entidades vindas do banco de dados. Todas as entidades geradas do banco de dados serão herdadas deste tipo.



Temos tambem uma base para Repositorio e Serviços, de forma genérica que inicialmente todos os objetos herdarão as suas respectivas bases. 

- **BaseRepository.cs**: Base de repositorio genérico que implementa *IRepository<T>*, que executa a comuicação com o banco para a tabela de determinada entidade (<T>) que obrigatóriamente herda de IEntity junto com o contexto do banco de dados.

- **BaseService.cs**: Base de serviço genérico que implementa *IService<T>*, onde recebe um *BaseRepository<T>* para qual vai executar seus serviços básicos de cominicação com os repositorios. 

Learn More:
- [Genesis Library Use](https://github.com/NycollasSobolevski/genesis/blob/master/Library/README.md)