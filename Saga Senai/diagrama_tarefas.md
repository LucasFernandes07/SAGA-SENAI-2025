```mermaid
erDiagram
    Tarefas {
        INT Id PK "Auto incremento, chave primária"
        VARCHAR Titulo "Título da tarefa"
        VARCHAR Descricao "Descrição da tarefa"
        TINYINT Concluida "0 = pendente, 1 = concluída"
    }
```

---

**Descrição dos campos:**
- `Id`: Identificador único da tarefa (auto incremento, chave primária)
- `Titulo`: Título da tarefa
- `Descricao`: Descrição da tarefa
- `Concluida`: Status (0 = pendente, 1 = concluída)
