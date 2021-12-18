# condomanager
CRUD Api

Para executar, clone o repositório crie um arquivo .env em /ConodManager e adicione uma SECRET_KEY à ele.
Atenção: O sistema utiliza sistema próprio de login bem simples apenas para ter alguma autenticação, a estrutura é simples e foi feito pensando em ser facilmente integrado com um sistema de login externo existente.

## Endpoints
A documentação completa está no swagger: https://localhost:7287/swagger/index.html (somente em ambiente de desenvolvimento).
Todos os endpoints, exceto na rota /User, precisam de autenticação Bearer Token, faça o login em ~/v1/api/User/login e utilize o token presente na resposta como seu Bearer Token em todas as requisições.
## Modelos
### Condo
Padrões de telefone aceitos pela api:
(XX) XXXXX-XXXX
(XX) XXXX-XXXX
XX XXXXX-XXXX
XX XXXX-XXXX
XXXXX-XXXX
XXXX-XXXX