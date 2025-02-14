# ** ProductHub API **

API web ASP.NET Core para gerenciamento de produtos com autenticação JWT, usando **.NET 8.0**, **Entity Framework Core**, **PostgreSQL**, **AspNetCoreRateLimit** e **Autenticação JWT**.

---

## **Tecnologias Utilizadas**
✅ **.NET 8.0** - Framework principal da aplicação  
✅ **ASP.NET Core** - Desenvolvimento de APIs web  
✅ **Entity Framework Core** - ORM para interação com o banco de dados  
✅ **PostgreSQL** - Banco de dados relacional  
✅ **AspNetCoreRateLimit** - Controle de limite de requisições  
✅ **Microsoft.AspNetCore.Authentication.JwtBearer** - Autenticação via JWT  
✅ **Microsoft.IdentityModel.Tokens** - Configuração do JWT  
✅ **Moq / xUnit** - Testes automatizados  

---

## ** Configuração e Execução do Projeto **

### 🔹 **1. Configurar o Banco de Dados**
No arquivo **`appsettings.json`**, configure a string de conexão do PostgreSQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=ProductHub;Username=postgres;Password=admin"
}
```

### 🔹 **2. Aplicar as Migrações do Banco de Dados **
```bash
dotnet ef database update
```

### 🔹 **3. Executar a API**
```bash
dotnet run
```

---

# ** Exemplos de Endpoints**

## ** Produtos**

### **1️⃣ Obter todos os produtos **
🔹 **GET /api/Products/GetAllProducts**  
🔹 **Resposta:**
```json
{
  "status": true,
  "message": "Produtos listados com sucesso!",
  "data": [
    {
      "id": 1,
      "name": "Produto Teste",
      "description": "Descrição do produto",
      "price": 99.99
    }
  ]
}
```

---

### **2️⃣ Obter um produto por ID**
🔹 **GET /api/Products/GetProductById/{idProduct}**  
🔹 **Resposta (200 OK):**
```json
{
  "status": true,
  "message": "Produto encontrado!",
  "data": {
    "id": 1,
    "name": "Produto Teste",
    "description": "Descrição do produto",
    "price": 99.99
  }
}
```

🔹 **Resposta (404 Not Found):**
```json
{
  "status": false,
  "message": "Produto não encontrado!"
}
```

---

### **3️⃣ Criar um produto**
🔹 **POST /api/Products/CreateProduct**  
🔹 **Requisição:**
```json
{
  "name": "Produto Novo",
  "description": "Descrição do novo produto",
  "price": 149.90
}
```

🔹 **Resposta (201 Created):**
```json
{
  "status": true,
  "message": "Produto criado com sucesso!",
  "data": {
    "id": 3,
    "name": "Produto Novo",
    "description": "Descrição do novo produto",
    "price": 149.90
  }
}
```

🔹 **Resposta (400 Bad Request):**
```json
{
  "status": false,
  "message": "O nome do produto é obrigatório!"
}
```

---

## ** Usuários e Autenticação**

### **4️⃣ Criar um usuário**
🔹 **POST /api/Users/CreateUser**  
🔹 **Requisição:**
```json
{
  "userName": "admin",
  "passwordHash": "123456"
}
```

🔹 **Resposta (201 Created):**
```json
{
  "status": true,
  "message": "Usuário criado com sucesso!",
  "data": {
    "id": 1,
    "userName": "admin"
  }
}
```

🔹 **Resposta (400 Bad Request):**
```json
{
  "status": false,
  "message": "Usuário já existe!"
}
```

---

### **5️⃣ Login **
🔹 **POST /api/Users/Login**  
🔹 **Requisição:**
```json
{
  "userName": "admin",
  "passwordHash": "123456"
}
```

🔹 **Resposta (200 OK):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}
```

🔹 **Resposta (400 Bad Request):**
```json
{
  "status": false,
  "message": "Usuário ou senha inválidos!"
}
```

---

## **Testes Automatizados**
O projeto inclui testes automatizados utilizando **xUnit** e **Moq**.  
Para rodar os testes:

```bash
dotnet test
```

---

## ** Autor **
 **Desenvolvido por:** Vitor Serrão

