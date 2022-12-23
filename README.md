# desafio-ilia-dotnet6
Controle de ponto API 1.0

Instruçoes 
--------------------------------------------------------------------------


Instalações

1. Visual Studio 2022 ( Community Edition ) link =>  https://visualstudio.microsoft.com/pt-br/vs/community/
2. MySQL Database => versão usada no projeto "10.4.13-MariaDB".


Procedimentos

Criação e conexão com o banco de dados.

1. Criar um database no <b>MySQL</b> guardando seus valores de conexão como UID e PWD


Criação e configurações no Projeto

1. Abrir <b>VS2022CE</b> > Novo Projeto > Clonar Repositório > Salvar em alguma pasta
2. Definir a string de conexão para o database criado no arquivo <b>appsettings.json</b> na seção ConnectionStrings

{
<b>"ConnectionStrings": {
    "MySQLConnectionString": "Server=endereco_servidor;DataBase=nome_database_criado;Uid=identificacao_usuario;Pwd=senha_usuario"
  },</b>
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

 


