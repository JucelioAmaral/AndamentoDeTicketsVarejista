
# Desafio – Implementação Back end

Api Restful feita em .Net SDK 5.0.406, em camadas, usando Dapper para persistencia e acesso ao banco de dados,
Swagger para documentação da Api e SQLServer como SGBD.


## Pré requisitos
 
1. [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/)

## Como baixar o código

git clone https://github.com/JucelioAmaral/AndamentoDeTicketsVarejista.git

## Como configurar a api(Backend)?

1. Abrir a Visual Code ou Studio;
2. Configurar o arquivo "appsettings.json" com a connectionString, apontando para o banco SQL server;
3. Instalar o pacote do sql server: "Install-Package Microsoft.EntityFrameworkCore.SqlServer";
4. Instalar o pacote Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 3.1.5, seguindo o item 5 abaixo porém, alterar o "Default project" para "TesteHavan.Tests"
5. Abrir o Package Manager Console, alterar o "Default project" (que fica na parte superior do console) para o Class Library que encontra-se os arquivos de persistência para "TesteHavan.Infraestructure"
6. Executar o comando: Add-Migration InitialCreate;
7. Executar o comando: Update-Database;
8. Executar a api (TesteHavan).

**API roda na porta 5001 e pode ser testada pelo link: https://localhost:5001/swagger/index.html**

