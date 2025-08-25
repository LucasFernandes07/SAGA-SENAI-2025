# 📝 TarefasApp

Bem-vindo ao **TarefasApp**! 🚀

Um aplicativo web moderno e eficiente para gerenciar suas tarefas diárias, desenvolvido com ASP.NET Core MVC, Entity Framework Core (MySQL) e visual inovador com Bootstrap. Organize, crie, edite, conclua e exclua tarefas de forma prática e estilosa!

## ✨ Funcionalidades

- 📋 Listagem de tarefas com visual moderno
- ➕ Criação de novas tarefas
- ✏️ Edição de tarefas existentes
- ✅ Marcação de tarefas como concluídas (com botão interativo)
- ❌ Exclusão de tarefas com confirmação
- 🔍 Filtro e busca por título
- 🌙 Modo escuro
- 📱 Layout responsivo para celular/tablet
- 🎨 Interface com emotes, cores suaves e feedback visual

## 🖥️ Tecnologias Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- MySQL (via Pomelo)
- Bootstrap 5
- HTML5, CSS3 customizado
- jQuery (para interações)

## 🚦 Como Executar o Projeto

1. **Pré-requisitos:**
   - [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
   - MySQL Server rodando e banco criado (`tarefasapp`)

2. **Configure a conexão:**
   - Edite o arquivo `appsettings.json` com os dados do seu MySQL:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=tarefasapp;user=arthur;password=121212;"
     }
     ```

3. **Restaure os pacotes:**
   ```bash
   dotnet restore
   ```

4. **Aplique as migrações e crie o banco de dados:**
   ```bash
   dotnet ef database update
   ```

5. **Execute o projeto:**
   ```bash
   dotnet run
   ```

6. **Acesse no navegador:**
   [http://localhost:5000/Tarefas](http://localhost:5000/Tarefas)

## 📂 Estrutura Principal

- `Controllers/` - Lógica de controle das rotas e ações
- `Models/` - Modelos de dados (Tarefa)
- `Views/` - Páginas de interface (Razor)
- `Data/` - Contexto do banco de dados
- `wwwroot/` - Arquivos estáticos (CSS, JS, Bootstrap)

## 🗄️ Diagrama da Tabela MySQL

```
+-----------+--------------+-----------+-----------------------------+
|   Campo   |    Tipo      |  Chave    |         Observação          |
+-----------+--------------+-----------+-----------------------------+
| Id        | INT          | PK        | Auto incremento             |
| Titulo    | VARCHAR(255) |           | Não nulo                    |
| Descricao | VARCHAR(255) |           | Não nulo                    |
| Concluida | TINYINT(1)   |           | Não nulo (0 = não, 1 = sim) |
+-----------+--------------+-----------+-----------------------------+
```

## 🖼️ Telas

- **Lista de Tarefas:** Visualize, filtre e busque tarefas
- **Criar Tarefa:** Adicione uma nova tarefa
- **Editar Tarefa:** Altere informações de uma tarefa existente
- **Excluir Tarefa:** Remova tarefas com confirmação
- **Modo Escuro:** Ative para uma experiência confortável à noite

## 💡 Extras

- Filtro e busca instantânea por título
- Modo escuro com alternância
- Feedback visual para ações (alertas, cores, emotes)
- Layout 100% responsivo
- Botão de concluir estilizado e funcional

---

Feito por Arthur Gomes
