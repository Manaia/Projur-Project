# Projur

Esse projeto consiste em um CRUD, o back-end foi escrito em .NET Core 2.2 utilizando o ORM Entity Framework configurado para o SQL Server e o front-end escrito em Angular.

## Instalação

### Verificar as tecnologias na sua máquina

Primeiro é necesário verificar se sua máquina contém o .NET Core e o Node.js instalado.

```sh

// versão node
node -v

// versão .NET Core
dotnet --version

```

Se não tiver sido instalado, clique no [Node.js](https://nodejs.org/) ou [.Net Core](https://dotnet.microsoft.com/download) para ser redirecionado.


Tendo instalado o Node.js na máquina, é necessário verificar se o angular CLI está instalado na máquina.

```sh

// versão Angular CLI
ng --version

```

Se não estiver instalado, clique no [Angular CLI] (https://cli.angular.io/) para ser redirecionado.

## Iniciando o front-end

É necessário entrar na pasta Projur-App.

```sh

// entrar na pasta
cd Projur-App/

```

Em seguida realizar os seguintes comandos.

```sh

// instalar todas as dependências presentes no arquivo package.json
npm install

// compilar o projeto
ng build

// iniciar a aplicação
ng serve -o

```

## Iniciando o back-end

É necessário estar na pasta raiz e realizar os seguintes comandos.

```sh

// compilar o projeto e suas dependências
dotnet restore

// iniciar a aplicação
dotnet run watch --project Projur.Api/

```