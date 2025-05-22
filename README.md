
# Integrantes:

- Alexsandro Macedo: RM557068
- Leonardo Faria Salazar: RM557484
- Guilherme Felipe da Silva Souza: RM558282


# API Mottu - Gerenciamento de Motos

API RESTful desenvolvida em .NET 8 para gerenciamento de motos, estações, usuários e históricos de movimentações. Utiliza Oracle como banco de dados, com arquitetura organizada em camadas (Domain, Infrastructure, Application, Presentation). A solução consiste em implementar um sistema que vai utilizar de estações no galpão da Mottu, esse sistema será controlar para liberar/devolver uma moto, similar ao sistema de aluguel de bicicletas, dessa forma conseguiremos ter um mapeamento do pátio. Para melhor contexto segue abaixo imagens de como funcionará o nosso sistema.

![image](https://github.com/user-attachments/assets/8b992276-597c-4d3e-bd48-4719801ec19c)
![image](https://github.com/user-attachments/assets/9718ec2f-9c85-4e70-81c4-94363cbb6b65)
![image](https://github.com/user-attachments/assets/bf81452e-15d7-49f8-bf7e-7024dfaa0651)
![image](https://github.com/user-attachments/assets/854f1f1c-4747-430a-aa19-0cab331c853b)
![image](https://github.com/user-attachments/assets/f4de5c04-41fc-4dc0-9261-0edf04ff4306)


---

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core (com Oracle)  
- Swagger / OpenAPI para documentação e testes  
- Swashbuckle.AspNetCore (Swagger UI)  
- C# 10  
- Oracle Database  

---

## Estrutura do Projeto

- **Domain**: Entidades do domínio e interfaces de repositórios  
- **Infrastructure**: Implementação dos repositórios e configuração do contexto EF Core  
- **Application**: Serviços de aplicação com regras de negócio e interfaces para a API  
- **Presentation**: Controllers REST para comunicação HTTP e documentação Swagger  

---

## Entidades Principais

- `UsuarioEntity` — representa os usuários do sistema  
- `MotoEntity` — representa as motos cadastradas  
- `EstacaoEntity` — representa as estações/filiais onde as motos ficam armazenadas  
- `HistoricoMotoEntity` — histórico de ações (liberação, devolução) das motos  

---

## Endpoints Principais

### Usuários  
- GET `/api/usuario` — lista todos os usuários  
- GET `/api/usuario/{id}` — obtém usuário por ID  
- POST `/api/usuario` — cadastra novo usuário  
- PUT `/api/usuario/{id}` — atualiza usuário existente  
- DELETE `/api/usuario/{id}` — remove usuário  

### Motos  
- GET `/api/moto` — lista todas as motos  
- GET `/api/moto/{id}` — obtém moto por ID  
- POST `/api/moto` — cadastra nova moto  
- PUT `/api/moto/{id}` — atualiza moto existente  
- DELETE `/api/moto/{id}` — remove moto  

### Estações  
- GET `/api/estacao` — lista todas as estações  
- GET `/api/estacao/{id}` — obtém estação por ID  
- POST `/api/estacao` — cadastra nova estação  
- PUT `/api/estacao/{id}` — atualiza estação existente  
- DELETE `/api/estacao/{id}` — remove estação  

### Histórico de Motos  
- GET `/api/historicomoto` — lista todos os históricos  
- GET `/api/historicomoto/{id}` — obtém histórico por ID  
- POST `/api/historicomoto` — cadastra novo histórico  
- PUT `/api/historicomoto/{id}` — atualiza histórico existente  
- DELETE `/api/historicomoto/{id}` — remove histórico  

---

## Como Rodar

1. **Configure a string de conexão no `appsettings.json`**

```json
{
  "ConnectionStrings": {
    "Oracle": "User Id=seu_usuario;Password=sua_senha;Data Source=seu_host:porta/servico"
  }
}
```

2. **Execute as migrations para criar as tabelas no banco Oracle**

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

3. **Execute a API**

```bash
dotnet run
```

4. **Acesse o Swagger UI**

Abra no navegador:

```
https://localhost:<porta>/swagger
```

---

## Swagger UI

A API está documentada com Swagger e você pode testar todos os endpoints pela interface web do Swagger.

---

## Pacotes NuGet Importantes

- Microsoft.EntityFrameworkCore  
- Microsoft.EntityFrameworkCore.Oracle  
- Swashbuckle.AspNetCore  
- Swashbuckle.AspNetCore.Annotations  

---
