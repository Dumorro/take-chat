# take-chat

## implamentação do teste técnico

### Comandos para utilização da sala de bate papo: 
- **/t** + texto para enviar uma mensagem
- **/d** + apelido para enviar uma mensagem direta pública.
- **/r** + apelido para enviar uma mensagem direta privada.
- **/s** para sair da sala

Obs.: os comandos **/t** , **/r** e **/s** podem ser utilizados em conjunto para mensagens diretas.

### Build
em: ~\src\Take.BatePapo.Servidor
**dotnet build**

### Testes
**Build**
em: ~\src\Take.BatePapo.Servidor\Take.BatePapo.TestesDeUnidade
**dotnet test**

### Iniciar aplicação
em: ~\src\Take.BatePapo.Servidor\Take.BatePapo.WebApp
**dotnet run**

Acessar a aplicação em *http://localhost:36454*


### Disclamer

O projeto foi implentando tentando se utilizar das boas práticas de SOLID.

O desenho da arquitetura se basea em arquitetura Hexagonal/Port&Adpters.

Devido ao pouco tempo livre para implementação, testes de unidade estão com uma cobertura de código pequena.

Para testes da aplicação, é interessante a implementação de testes E2E utilizando Cypress.
