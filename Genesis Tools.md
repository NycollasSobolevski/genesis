Genesis Tools

ferramenta que vai usar a biblioteca para gerar codigos C# com base no banco de dados solicitado

commands: 
// Gerar uma nova estrutura com base no banco de dados:
> gns database add "databaseUrl"
	  ^     ^ 	^
	kind | tool | value
example: 
dotnet run database add "Data Source={YourSource}\SQLEXPRESS;Initial Catalog={your catalog};Integrated Security=True;TrustServerCertificate=true"


Genesis Library

biblioteca utilizada pela Tool onde gera o codigo 


--------------------------------------------------------------------------------------------------------------

Rascunho:
comandos

Criando release executavel:
> dotnet pack -c Release -o ./nupkgs

instalando executavel
> dotnet tool install --global --add-source .\nupkgs GenesisTool

