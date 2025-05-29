# Sistema de Gerenciamento de Reservas de Carros

**Disciplina:** Tópicos Especiais de Sistemas  
**Data:** 29/05/2025  
**Grupo:** Matheus de Araujo Amaral, Luan Curtz, Caio Somacal, Arthur Flamino

---

## 1. Objetivo do Projeto

O objetivo deste projeto é desenvolver uma API RESTful utilizando ASP.NET Core, Entity Framework Core e SQLite, voltada para o gerenciamento de reservas de veículos. A aplicação permite o controle do cadastro de carros, clientes e o processo completo de reserva. O sistema foi desenvolvido com foco em contextos operacionais onde é necessário controlar a disponibilidade de veículos, garantir integridade nos agendamentos e facilitar a consulta e manutenção de registros por parte de usuários e administradores.

---

## 2. Estrutura da Solução

### 2.1 Modelagem de Dados

A modelagem da aplicação baseia-se em três entidades principais: **Carro**, **Cliente** e **Reserva**. Cada uma dessas entidades foi estruturada com atributos essenciais ao processo de reserva:

- **Carro**: modelo, marca, ano, placa, status  
- **Cliente**: nome, e-mail, telefone  
- **Reserva**: relação entre carro e cliente, data de início, data de fim, status da reserva

As classes foram implementadas na camada de domínio e utilizadas como base para a criação da estrutura de banco de dados via Entity Framework Core.

### 2.2 Integração da API com a Solução

A API foi implementada como ponto central de acesso para operações CRUD (Create, Read, Update, Delete). Cada rota da aplicação representa uma funcionalidade específica como cadastro de cliente, consulta de carros ou cancelamento de reservas. A comunicação entre o cliente (ex: frontend, Postman) e a base de dados se dá de maneira segura, performática e estruturada.

---

## 3. Endpoints da API

| Entidade | Método  | Rota                        | Descrição                            |
|----------|---------|-----------------------------|--------------------------------------|
| Carro    | GET     | /api/carros                 | Lista todos os carros                |
| Carro    | GET     | /api/carros/{id}            | Retorna um carro por ID              |
| Carro    | POST    | /api/carros                 | Cadastra um novo carro               |
| Carro    | PUT     | /api/carros/{id}            | Atualiza os dados de um carro        |
| Carro    | DELETE  | /api/carros/{id}            | Exclui um carro                      |
| Cliente  | GET     | /api/clientes               | Lista todos os clientes              |
| Cliente  | GET     | /api/clientes/{id}          | Retorna um cliente por ID            |
| Cliente  | POST    | /api/clientes               | Cadastra um novo cliente             |
| Cliente  | DELETE  | /api/clientes/{id}          | Remove um cliente                    |
| Reserva  | GET     | /api/reservas               | Lista todas as reservas              |
| Reserva  | GET     | /api/reservas/{id}          | Retorna uma reserva por ID           |
| Reserva  | POST    | /api/reservas               | Cria uma nova reserva                |
| Reserva  | DELETE  | /api/reservas/{id}          | Cancela uma reserva existente        |

**Regras de negócio adicionais:**

- Reservas só podem ser feitas para carros com status **"Disponível"**.  
- Cancelamento de reservas atualiza o status do carro para **"Disponível"**.

---

## 4. Organização do Código

A estrutura do projeto segue uma abordagem modular e organizada por funcionalidades:

```
├── Models/
│   ├── Carro.cs
│   ├── Cliente.cs
│   └── Reserva.cs
├── Data/
│   ├── ApplicationDbContext.cs
│   └── DbInitializer.cs
├── Routes/
│   ├── Carros/
│   │   ├── CarrosDeleteRoute.cs
│   │   ├── CarrosGetRoute.cs
│   │   └── CarrosPostRoute.cs
│   ├── Clientes/
│   │   ├── ClientesDeleteRoute.cs
│   │   ├── ClientesGetRoute.cs
│   │   └── ClientesPostRoute.cs
│   └── Reservas/
│       ├── ReservasDeleteRoute.cs
│       ├── ReservasGetRoute.cs
│       └── ReservasPostRoute.cs
├── Program.cs
```

Essa divisão por entidades dentro de `Routes/` facilita a manutenção e escalabilidade do código.

---

## 5. Execução da Aplicação

### Pré-requisitos

- .NET 6 SDK  
- EF Core CLI (opcional):  
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Passos para rodar

```bash
dotnet restore                 # Restaurar pacotes
dotnet ef database update     # Criar ou atualizar o banco de dados
dotnet run                    # Executar a aplicação
```

A API estará disponível em: [http://localhost:5000](http://localhost:5000)

---

## 6. Conclusão

A API de Reserva de Carros foi desenvolvida com foco acadêmico e estrutural, utilizando boas práticas de desenvolvimento web com .NET. A organização modular, a lógica de reserva e a modelagem das entidades oferecem uma base sólida para evolução do projeto, como adição de autenticação, relatórios ou funcionalidades avançadas.
