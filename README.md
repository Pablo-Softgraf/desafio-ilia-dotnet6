# desafio-ilia-dotnet6
Controle de ponto API 1.0

## Instalações

1. Visual Studio 2022 ( Community Edition ) link =>  https://visualstudio.microsoft.com/pt-br/vs/community/
2. Dotnet SDK 6.0.404   link => https://dotnet.microsoft.com/pt-br/download/dotnet/6.0
3. MySQL Database => versão usada no projeto "10.4.13-MariaDB"
4. As versões abaixos são suportadas pelo pacote do Pomelo.EntityFrameworkCore.MySql, pacote usado para manipulação do MySQL

        Versões atualmente suportadas:

        MySQL 8.0
        MySQL 5.7
        MariaDB 10.9
        MariaDB 10.8
        MariaDB 10.7
        MariaDB 10.6
        MariaDB 10.5
        MariaDB 10.4
        MariaDB 10.3


## Procedimentos

### Criação e conexão com o banco de dados.

1. Criar um database no <b>MySQL</b> guardando seus valores de conexão como UID e PWD

### Configurações no Projeto

1. Abrir <b>VS2022CE</b> > Novo Projeto > Clonar Repositório > Salvar em alguma pasta de sua preferência.
2. Definir a string de conexão para o database criado no arquivo <b>appsettings.json</b> na seção abaixo :
    "ConnectionStrings": {
        "MySQLConnectionString": "Server=endereco_servidor;DataBase=ilia_ctrl_ponto;Uid=identificacao_usuario;Pwd=senha_usuario"
      },
3. Após o database criado , vamos precisar da versão do database , no nosso caso seria MySQL, essa informação será usada na conexão com o banco de dados, precisamos executar o comando abaixo : 

    <Drive:>\Pasta de instalação do MySQL\bin\MySql --version 
      
    retorno do comando:
    
        mysql  Ver 15.1 Distrib 10.4.13-MariaDB, for Win64 (AMD64), source revision 1b18cddaa23711776537ee98f16529a74ff861c2
    

Como vemos acima , após a palavra <b>Distrib</b>, será mostrada a versão, neste caso seria <b>10.4.13-MariaDB</b> , após isso temos que acessar no projeto através do VS2022CE o arquivo <b>Program.cs</b> nele teremos um trecho de código , logo no inicio após os usings, que nos traz o serviço de conexão ao banco de dados:

    var builder = WebApplication.CreateBuilder(args);
    var connection = builder.Configuration["ConnectionStrings:MySQLConnectionString"];
    builder.Services.AddDbContext<MySQLContext>(option => option.
                        UseMySql(connection,
                                 new MySqlServerVersion("10.4.13-MariaDB"))); <- a versão dever ser inserida no parametro do construtor MySqlServerVersion



## CLI - PowerShell

1. Após a criação do database e clonagem do projeto, vamos abrir o projeto, devemos realizar a execução das migrations no MySQL com os comandos abaixo :

Abra o Powershell (modo administrador) e execute o comando abaixo para atualizar as migrations no banco de dados, sempre na pasta do projeto que contenha o arquivo <b>Desafio-Ilia-PARR.csproj</b>:

    dotnet ef database update
    
   
## Testes

Sugiro que os testes sejam iniciados a partir da rota <b>/v1/batidas</b> , devido as validações que se encontram
na rota <b>/v1/alocacoes</b>. 

###### sempre no formato a seguir :

    {
      "id": 0,
      "dataHora": "2022-12-23T08:00:00"
    }

###### O próximo teste , será inserir na rota <b>/v1/alocacoes</b> alocações no formato do campo tempo exatamente como pedido no Desafio.

    {
      "id": 0,
      "dia": "2022-12-23",
      "tempo": "PT8H1M2S", <- Extrema importância este formato estar correto.
      "nomeProjeto": "ILIA CHALLENGE"
    }

###### No último teste , vamos consumir a partir da rota <b>/v1/folha-de-ponto/{mes}</b> será apresentado apenas o campo mês onde o ano e mês será inserido:

    mes 2022-12




# Obrigado e espero que realize um bom teste !

![Developers rules](https://myoctocat.com/assets/images/base-octocat.svg)
