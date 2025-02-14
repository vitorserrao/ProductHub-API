# **ProductHub API**

 API para gerenciamento de produtos com autenticação JWT, usando **.NET 8.0**, **Entity Framework Core**, **PostgreSQL**, **AspNetCoreRateLimit** e **Autenticação JWT**.

---

## **Tecnologias Utilizadas**

✅ **.NET 8.0** - Framework principal da aplicação  
✅ **Entity Framework Core** - ORM para interação com o banco de dados  
✅ **PostgreSQL** - Banco de dados relacional  
✅ **AspNetCoreRateLimit** - Controle de limite de requisições  
✅ **Microsoft.AspNetCore.Authentication.JwtBearer** - Autenticação via JWT  
✅ **Microsoft.IdentityModel.Tokens** - Configuração do JWT  
✅ **Moq / xUnit** - Testes automatizados  

---

## **Configuração e Execução do Projeto**

### 🔹 **1. Configurar o Banco de Dados**
No arquivo **`appsettings.json`**, configure a string de conexão do PostgreSQL:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=ProductHub;Username=postgres;Password=123456"
}
```

### 🔹 **2. Aplicar as Migrações do Banco de Dados**
```bash
dotnet ef database update
```

### 🔹 **3. Executar a API**
```bash
dotnet run
```


## **Exemplos de Endpoints**

### **1️⃣ Criar um Produto**
🔹 **Endpoint:** `POST /api/Products/CreateProduct`  
🔹 **Requisição:**
```json
{
  "name": "Produto Teste",
  "description": "Descrição do produto",
  "price": 99.99
}
```
🔹 **Resposta (Sucesso - 200 OK):**
```json
{
  "status": true,
  "message": "Produto criado com sucesso!",
  "data": {
    "id": 1,
    "name": "Produto Teste",
    "description": "Descrição do produto",
    "price": 99.99
  }
}
```

---

### **2️⃣ Deletar um Produto**
🔹 **Endpoint:** `DELETE /api/Products/DeleteProduct/{idProduct}`  
🔹 **Resposta (Sucesso - 200 OK):**
```json
{
  "status": true,
  "message": "Produto deletado com sucesso!",
  "data": []
}
```

---

### **3️⃣ Login**
🔹 **Endpoint:** `POST /api/Users/Login`  
🔹 **Requisição:**
```json
{
  "userName": "admin",
  "passwordHash": "123456"
}
```
🔹 **Resposta (Sucesso - 200 OK):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}
```
🔹 **Resposta (Erro - 400 Bad Request):**
```json
{
  "status": false,
  "message": "Usuário ou senha inválidos!"
}
```

---

## **Testes**
O projeto inclui testes automatizados utilizando **xUnit** e **Moq**.  
Para rodar os testes:

```bash
dotnet test
```

---


## **Autor**
 **Desenvolvido por:** [Vitor Serrão]  


