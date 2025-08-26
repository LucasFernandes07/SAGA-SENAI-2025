# ald_controls

Este projeto é um sistema web para controle de EPIs e colaboradores, desenvolvido em ASP.NET Core MVC.

## Sobre o sistema
O ald_controls permite:
- Cadastro e gerenciamento de colaboradores
- Cadastro e gerenciamento de EPIs (Equipamentos de Proteção Individual)
- Registro de uso de EPIs pelos colaboradores
- Controle de pontos por registro de uso
- Ranking dos colaboradores
- Controle de acesso por perfil (administrador e colaborador)
- Autenticação e gerenciamento de conta via ASP.NET Identity

## Tecnologias utilizadas
- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Identity (autenticação, roles)
- Bootstrap (layout responsivo)
- Razor Pages para área de identidade
- SQL Server (banco de dados)

## Como funciona
- Administradores podem cadastrar, editar e excluir colaboradores e EPIs, além de editar descrições e gerenciar registros.
- Colaboradores podem visualizar EPIs, registros e ranking, mas não podem editar ou excluir dados.
- Cada registro de uso de EPI soma 10 pontos ao colaborador.
- O sistema possui páginas de login, registro, gerenciamento de conta e autenticação em dois fatores, todas traduzidas para português.

## Como rodar
1. Instale o .NET SDK 8.0 ou superior
2. Configure a string de conexão do banco de dados em `appsettings.json`

### Restaure os pacotes
```powershell
dotnet restore
```

### Aplique as migrações e crie o banco de dados
```powershell
dotnet ef database update
```

### Execute o projeto
```powershell
dotnet run
```

5. Acesse o site em `http://localhost:5000` (ou porta configurada)

## Observações
- O usuário administrador é criado automaticamente no seed do sistema.
- Apenas administradores podem editar descrições de EPIs e gerenciar dados.
- O layout e todas as páginas principais estão em português.

---
Desenvolvido para controle de EPIs e colaboradores SENAI 2025.
