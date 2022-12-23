# desafio-ilia-dotnet6
Controle de ponto API 1.0

Instruções 
--------------------------------------------------------------------------
<b>Instalações</b>

1. Visual Studio 2022 ( Community Edition ) link =>  https://visualstudio.microsoft.com/pt-br/vs/community/
2. Dotnet SDK 6.0.404   link => https://dotnet.microsoft.com/pt-br/download/dotnet/6.0
3. MySQL Database => versão usada no projeto "10.4.13-MariaDB".


<b>Procedimentos</b>

Criação e conexão com o banco de dados.

1. Criar um database no <b>MySQL</b> guardando seus valores de conexão como UID e PWD

Criação e configurações no Projeto

1. Abrir <b>VS2022CE</b> > Novo Projeto > Clonar Repositório > Salvar em alguma pasta de sua preferência.
2. Definir a string de conexão para o database criado no arquivo <b>appsettings.json</b> na seção abaixo :
    "ConnectionStrings": {
        "MySQLConnectionString": "Server=endereco_servidor;DataBase=ilia_ctrl_ponto;Uid=identificacao_usuario;Pwd=senha_usuario"
      },


<b>CLI - PowerShell</b>

1. Após a criação do database devemos realizar a execução das migrations no MySQL com os comandos abaixo :

Execute o comando abaixo para atualizar as migrations no banco de dados, sempre na pasta do projeto que contenha o arquivo <b>Desafio-Ilia-PARR.csproj</b>:

    dotnet ef database update
    
    
<b>Testes</b>

Sugiro que os testes sejam iniciados a partir da rota <b>/v1/batidas</b> , devido as validações que se encontram
na rota <b>/v1/alocacoes</b>. 

sempre no formato a seguir :

    {
      "id": 0,
      "dataHora": "2022-12-23T08:00:00"
    }

O próximo teste , será inserir na rota <b>/v1/alocacoes</b> alocações no formato do campo tempo exatamente como pedido no Desafio.

    {
      "id": 0,
      "dia": "2022-12-23",
      "tempo": "PT8H1M2S",
      "nomeProjeto": "ILIA CHALLENGE"
    }

No último teste , vamos consumir a partir da rota <b>/v1/folha-de-ponto/{mes}</b> será apresentado apenas o campo mês 
onde o ano e mês será inserido:

    mes 2022-12




<b>Obrigado e espero que realize um bom teste !</b>


















 


