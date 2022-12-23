# desafio-ilia-dotnet6
Controle de ponto API 1.0

Instruções 
--------------------------------------------------------------------------
Instalações

1. Visual Studio 2022 ( Community Edition ) link =>  https://visualstudio.microsoft.com/pt-br/vs/community/
2. Dotnet SDK 6.0.404   link => https://dotnet.microsoft.com/pt-br/download/dotnet/6.0
3. MySQL Database => versão usada no projeto "10.4.13-MariaDB".


Procedimentos

Criação e conexão com o banco de dados.

1. Criar um database no <b>MySQL</b> guardando seus valores de conexão como UID e PWD


Criação e configurações no Projeto

1. Abrir <b>VS2022CE</b> > Novo Projeto > Clonar Repositório > Salvar em alguma pasta
2. Definir a string de conexão para o database criado no arquivo <b>appsettings.json</b> na seção abaixo :

<b>"ConnectionStrings": {
    "MySQLConnectionString": "Server=endereco_servidor;DataBase=ilia_ctrl_ponto;Uid=identificacao_usuario;Pwd=senha_usuario"
  },</b>


CLI - PowerShell

1. Após a criação do database devemos realizar a execução das migrations no MySQL com os comandos abaixo :

Execute o comando abaixo para atualizar as migrations no banco de dados:

    dotnet ef database update
    
    
    
Obrigado , e realize um bom teste !


















 


