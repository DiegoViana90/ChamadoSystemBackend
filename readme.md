# ChamadoSystemBackend

Este é o backend para um sistema de gerenciamento de chamados, desenvolvido em ASP.NET Core 6.0 com PostgreSQL e autenticação JWT.

## Funcionalidades Principais

- Gerenciamento de usuários (registro, login, atualização de perfil)
- Gerenciamento de tickets (criação, listagem, atualização, exclusão)
- Autenticação JWT para proteção de rotas

## Requisitos

- .NET 6.0 SDK ou superior
- PostgreSQL (ou outro banco de dados suportado pelo Entity Framework Core)
- Um editor de código (Visual Studio, Visual Studio Code, Rider, etc.)

## Configuração

1. **Clone o repositório:**

   ```bash
   git clone https://github.com/DiegoViana90/ChamadoSystemBackend.git


2. Configure a string de conexão com o banco de dados:

No arquivo appsettings.json, ajuste a string de conexão para o seu banco de dados PostgreSQL:
   ```bash

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ChamadoSystemDB;Username=seu_usuario;Password=sua_senha"    
  },  
  "JwtSettings": {
    "Secret": "sua_chave_secreta_jwt"  
  }  
}

3.  Instale as dependências:

 Navegue até o diretório do projeto e execute:
 dotnet restore


4. Execute as migrações do banco de dados:

Para criar o esquema do banco de dados, execute as migrações:
dotnet ef database update

5. Execute a aplicação:
dotnet run

Documentação da API
A API é documentada usando Swagger. Após iniciar o servidor, acesse a documentação em:

https://localhost:5001/swagger

Autor
Diego Viana - https://github.com/DiegoViana90
