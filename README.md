# condomanager
CRUD Api

Atenção: O sistema utiliza sistema próprio de login bem simples apenas para ter alguma autenticação, a estrutura é simples e foi feito pensando em ser facilmente integrado com um sistema de login externo existente.

## Endpoints
A documentação completa está no swagger: https://localhost:7287/swagger/index.html (somente em ambiente de desenvolvimento).
Todos os endpoints, exceto na rota /User, precisam de autenticação Bearer Token, faça o login em ~/v1/api/User/login e utilize o token presente na resposta como seu Bearer Token em todas as requisições.
## Modelos
### Condo
Padrões de telefone aceitos pela api:
<br>(XX) XXXXX-XXXX
<br>(XX) XXXX-XXXX
<br>XX XXXXX-XXXX
<br>XX XXXX-XXXX
<br>XXXXX-XXXX
<br>XXXX-XXXX

# Rodando a aplicação
<br>Clone o repositório para uma pasta local
<br>Para executar, clone o repositório crie um arquivo .env em /CondoManager e adicione uma SECRET_KEY à ele.
<br>acesse a pasta /CondoManager e execute os comandos abaixo:
<br># monta o projeto e confirma que está compilando
<br>$ dotnet build
<br> # sobe os containers com o banco de dados
<br>$ docker-compose up -d
<br> # aplica a migração do banco com base no código
<br>$ dotnet ef migrations add initial
<br> # sobe as migrações para o banco
<br>$ dotnet ef database update
<br> # faz a api funcionar
<br>$ dotnet run
<br>
<br>Agora é só utilizar o swagger ou uma ferramenta como Insomnia ou Postman para executar as requisições
<br>Se as configurações iniciais forem mantidas o banco de dados pode ser acessado via http://localhost:5050/ (login e senha presentes no arquivo docker-compose.yml). Para acesso à api vide sessão Endpoints neste documento