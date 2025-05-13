
# Sistema Bancário

## Descrição

O **Sistema Bancário** é uma aplicação backend para gerenciar usuários, carteiras digitais e transações financeiras, com funcionalidades como registro de usuário, saldo de conta, transferência de saldo entre usuários e histórico de transferências.

O sistema foi desenvolvido com as melhores práticas em arquitetura de software, como DDD (Domain-Driven Design) e SOLID. A aplicação é construída em C# usando o framework .NET e o banco de dados PostgreSQL.

## Funcionalidades

### 1. **Registro de Usuário**

- O sistema permite o cadastro de novos usuários com informações como nome, e-mail e senha.
- O e-mail é utilizado como identificador único para o login.

### 2. **Login de Usuário**

- Usuários registrados podem realizar login para acessar suas contas e realizar operações financeiras.
- O login é feito via e-mail e senha.

### 3. **Carteira Digital**

- Cada usuário tem uma carteira digital associada.
- A carteira pode ser consultada para verificar o saldo atual.

### 4. **Transferência de Saldo**

- Os usuários podem realizar transferências entre suas carteiras e as carteiras de outros usuários.
- A transferência pode ser feita com base no e-mail do destinatário.
- O sistema verifica se o usuário tem saldo suficiente para realizar a transferência.

### 5. **Histórico de Transferências**

- O sistema mantém um histórico de todas as transferências realizadas, tanto como remetente quanto como destinatário.
- É possível consultar o histórico de transferências de um usuário em um determinado período.

### 6. **Exceções e Validações**

- O sistema possui validações para garantir que as operações sejam realizadas corretamente:
  - Não é permitido transferir saldo para si mesmo.
  - Não é permitido transferir um valor maior do que o saldo disponível.
  - Exceções são lançadas para erros como usuário não encontrado ou saldo insuficiente.

## Tecnologias Utilizadas

- **Backend**: C# (.NET 8)
- **Banco de Dados**: PostgreSQL
- **ORM**: Entity Framework Core
- **Mapeamento de Objetos**: AutoMapper
- **Autenticação e Autorização**: JWT Tokens
- **Arquitetura**: DDD (Domain-Driven Design), SOLID
- **Testes**: xUnit (Testes Unitários)

## Como Rodar o Projeto

### Pré-requisitos

Antes de rodar o projeto, certifique-se de ter as seguintes ferramentas instaladas:

- .NET 8 SDK
- PostgreSQL (ou Docker para rodar o PostgreSQL em contêiner)
- Editor de código (Visual Studio, VS Code, etc.)

### Passo 1: Clonar o Repositório

Clone o repositório para sua máquina local:

```bash
git clone https://github.com/seu-usuario/SistemaBancario.git
cd SistemaBancario
```

### Passo 2: Configuração do Banco de Dados

Crie uma base de dados no PostgreSQL chamada `SistemaBancario` ou edite a string de conexão no arquivo `appsettings.json` para corresponder à sua configuração de banco de dados:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=SistemaBancario;Username=seu_usuario;Password=sua_senha"
}
```

### Passo 3: Executar Migrations

Execute as migrations para criar o banco de dados e as tabelas necessárias:

```bash
dotnet ef database update --project SistemaBancario.Infrastructure --startup-project SistemaBancario.API
```

### Passo 4: Rodar o Projeto

Execute a aplicação:

```bash
dotnet run --project SistemaBancario.API
```

A API estará disponível em `http://localhost:5000` (ou conforme configurado).

## Endpoints da API

### **POST /api/users/register**

- **Descrição**: Cadastra um novo usuário no sistema.
- **Body**:
  ```json
  {
    "email": "user@example.com",
    "name": "John Doe",
    "password": "senha123"
  }
  ```
  
### **POST /api/users/login**

- **Descrição**: Realiza o login de um usuário e retorna um token JWT.
- **Body**:
  ```json
  {
    "email": "user@example.com",
    "password": "senha123"
  }
  ```

### **GET /api/wallet/{userId}**

- **Descrição**: Retorna o saldo da carteira do usuário.
- **Resposta**:
  ```json
  {
    "balance": 100.0
  }
  ```

### **POST /api/transfers**

- **Descrição**: Realiza uma transferência entre usuários.
- **Body**:
  ```json
  {
    "receiverEmail": "receiver@example.com",
    "amount": 50.0
  }
  ```

### **GET /api/transfers/{userId}?startDate={startDate}&endDate={endDate}**

- **Descrição**: Retorna o histórico de transferências de um usuário em um período específico.
- **Parâmetros**:
  - `startDate` (opcional) - Data inicial para filtrar as transferências.
  - `endDate` (opcional) - Data final para filtrar as transferências.

## Estrutura de Diretórios

A estrutura do projeto é organizada da seguinte maneira:

```
├── SistemaBancario.sln
├── src/
│   ├── SistemaBancario.API         # API e controllers
│   ├── SistemaBancario.Application # Lógica de negócios
│   ├── SistemaBancario.Domain      # Entidades e repositórios
│   ├── SistemaBancario.Infrastructure # Acesso a dados (EF Core, Migrations)
│   ├── SistemaBancario.Communication # Requests e Responses
```

## Contribuindo

Se você deseja contribuir para o projeto, siga estas etapas:

1. Faça um fork do repositório.
2. Crie uma branch para suas alterações (`git checkout -b feature/nova-funcionalidade`).
3. Faça as alterações necessárias e adicione testes para garantir a funcionalidade.
4. Realize o commit das suas alterações (`git commit -am 'Adiciona nova funcionalidade'`).
5. Envie a branch para o repositório (`git push origin feature/nova-funcionalidade`).
6. Crie um pull request.

## Licença

Este projeto é licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

### Ajustes Futuros

- Melhorias na segurança do sistema com autenticação via OAuth.
- Adicionar funcionalidades de notificações (por exemplo, e-mails ou SMS para transferências).
- Implementar testes de carga e performance.
