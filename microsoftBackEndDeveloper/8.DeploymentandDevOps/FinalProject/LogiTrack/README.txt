PROJETO LOGITRACK - SISTEMA DE GERENCIAMENTO DE PEDIDOS

DESCRIÇÃO GERAL:
O LogiTrack é um sistema completo de gerenciamento de pedidos e inventário desenvolvido em ASP.NET Core Web API. O sistema permite que usuários autenticados gerenciem itens de inventário e criem pedidos de forma segura e eficiente.

PRINCIPAIS FUNCIONALIDADES:

1. AUTENTICAÇÃO E AUTORIZAÇÃO:
   - Registro de novos usuários
   - Login com geração de tokens JWT
   - Sistema de roles (Manager e User)
   - Controle de acesso baseado em roles

2. GERENCIAMENTO DE INVENTÁRIO:
   - Listagem de todos os itens de inventário
   - Adição de novos itens (apenas para Managers)
   - Remoção de itens (apenas para Managers)
   - Cache em memória para otimização de performance

3. GERENCIAMENTO DE PEDIDOS:
   - Criação de pedidos com múltiplos itens
   - Listagem de pedidos do usuário autenticado
   - Visualização detalhada de pedidos individuais
   - Remoção de pedidos (apenas para Managers)
   - Isolamento de dados por usuário

4. OTIMIZAÇÕES DE PERFORMANCE:
   - Cache em memória com expiração deslizante
   - Consultas otimizadas com AsNoTracking()
   - Operações assíncronas para melhor responsividade

TECNOLOGIAS UTILIZADAS:
- ASP.NET Core 8.0 (Web API)
- Entity Framework Core com SQLite
- ASP.NET Identity para autenticação
- JWT Bearer Tokens
- In-Memory Caching
- Swagger/OpenAPI para documentação
- C# 12 com recursos modernos

ESTRUTURA DO PROJETO:

Controllers/
├── AuthController.cs      - Gerenciamento de autenticação
├── InventoryController.cs - Operações de inventário
└── OrderController.cs     - Operações de pedidos

Models/
├── ApplicationUser.cs     - Modelo de usuário
├── InventoryItem.cs       - Modelo de item de inventário
└── Order.cs              - Modelo de pedido

Outros arquivos:
├── Program.cs            - Configuração da aplicação
├── LogiTrackContext.cs   - Contexto do banco de dados
└── appsettings.json      - Configurações da aplicação

SEGURANÇA IMPLEMENTADA:
- Autenticação JWT com expiração de 30 minutos
- Autorização baseada em roles
- Validação de entrada de dados
- Isolamento de dados por usuário
- Senhas hashadas com ASP.NET Identity

COMO USAR:

1. CONFIGURAÇÃO INICIAL:
   - O sistema cria automaticamente as tabelas do banco na primeira execução
   - Usuários de teste são criados: "manager" e "user" (senha: Password123!)

2. AUTENTICAÇÃO:
   - POST /api/auth/register - Registrar novo usuário
   - POST /api/auth/login - Fazer login e obter token JWT
   - Incluir token no header: Authorization: Bearer {token}

3. ENDPOINTS DISPONÍVEIS:
   - GET /api/inventory - Listar itens de inventário
   - POST /api/inventory - Adicionar item (Manager)
   - DELETE /api/inventory/{id} - Remover item (Manager)
   - GET /api/orders - Listar pedidos do usuário
   - GET /api/orders/{id} - Obter pedido específico
   - POST /api/orders - Criar novo pedido
   - DELETE /api/orders/{id} - Remover pedido (Manager)

4. DOCUMENTAÇÃO:
   - Acesse http://localhost:5134/swagger para documentação interativa

CARACTERÍSTICAS TÉCNICAS:
- Arquitetura RESTful
- Operações CRUD completas
- Tratamento de erros adequado
- Validação de dados
- Documentação automática
- Testável via Swagger UI

OBJETIVO DO PROJETO:
Este projeto demonstra a implementação de uma API web moderna e segura, abrangendo conceitos avançados como autenticação, autorização, otimização de performance e boas práticas de desenvolvimento em ASP.NET Core.