# Clyvio - VitalPet

Bem-vindo ao repositório da **Clyvio - VitalPet API**, o back-end responsável por gerenciar o ecossistema de saúde e bem-estar animal. 

##  Tecnologias Utilizadas

* **Framework:** .NET 10.0 (ASP.NET Core Web API)
* **Linguagem:** C#
* **ORM:** Entity Framework Core
* **Banco de Dados:** Oracle Database
* **Documentação:** Swagger / OpenAPI

##  Estrutura de Domínio

A API gerencia quatro entidades principais com os seguintes relacionamentos:
* **Tutor:** Possui um ou mais Pets (1:N).
* **Pet:** Pertence a um Tutor e pode ser atendido por um Veterinário.
* **Veterinário:** Pode atender múltiplos Pets e está vinculado a uma Clínica (1:N).
* **Clínica:** Emprega um ou mais Veterinários (1:N).

---

## Como Executar o Projeto Localmente

Siga as instruções abaixo para clonar, configurar e rodar a API na sua máquina local.

### Pré-requisitos
* [.NET 10 SDK](https://dotnet.microsoft.com/download) instalado.
* Banco de Dados Oracle em execução.
* Ferramenta de Migrations do EF Core (`dotnet tool install --global dotnet-ef`).

 1. Clonar o Repositório
 bash
git clone [https://github.com/SEU_USUARIO/VitalPet.git](https://github.com/SEU_USUARIO/VitalPet.git)
cd VitalPet/VitalPet.API
2. Configurar o Banco de Dados (User Secrets)
Por questões de segurança, a string de conexão real não está no arquivo appsettings.json. Configure o seu acesso localmente utilizando o Secret Manager do .NET:
Bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:OracleConnection" "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_ENDERECO:1521/XEPDB1;"
3. Aplicar as Migrations (Criar as Tabelas)
Com o banco de dados em execução, crie a estrutura de tabelas executando:
Bash
dotnet ef database update
4. Rodar a Aplicação
Bash
dotnet run
*Aviso Importante sobre a Interface de Documentação*
Nas versões mais recentes do .NET, a interface gráfica da documentação não abre automaticamente na raiz. Após rodar o comando acima, a aplicação estará escutando na porta indicada no terminal (ex: http://localhost:5172).
Para acessar a interface visual com todos os endpoints, você deve adicionar o caminho /swagger à URL no seu navegador:
 http://localhost:5172/swagger

  Documentação das Rotas (Endpoints)
Abaixo estão as principais rotas disponíveis na API. Todas retornam respostas no formato JSON e utilizam os códigos de status HTTP padrão (200 OK, 201 Created, 204 No Content, 400 Bad Request, 404 Not Found).
  
  Tutores (/api/Tutor)
GET /api/Tutor - Retorna a lista de todos os tutores cadastrados.
GET /api/Tutor/{id} - Retorna um tutor específico pelo ID.
GET /api/Tutor/buscar-por-nome?nome={nome} - Filtra tutores pelo nome.
POST /api/Tutor - Cadastra um novo tutor.
PUT /api/Tutor/{id} - Atualiza os dados de um tutor existente.
DELETE /api/Tutor/{id} - Remove um tutor do sistema.
<img width="1420" height="391" alt="Captura de Tela 2026-05-23 às 15 41 39" src="https://github.com/user-attachments/assets/f6cedf53-c8a3-4b58-b217-39b7dd1f7de3" />


   Pets (/api/Pet)
GET /api/Pet - Retorna a lista de todos os pets (incluindo os dados do tutor responsável).
GET /api/Pet/{id} - Retorna um pet específico pelo ID.
GET /api/Pet/buscar-por-especie?especie={especie} - Filtra pets por espécie (ex: Cachorro, Gato).
POST /api/Pet - Cadastra um novo pet (requer o TutorId).
PUT /api/Pet/{id} - Atualiza os dados de um pet.
DELETE /api/Pet/{id} - Remove um pet do sistema.
<img width="1427" height="383" alt="Captura de Tela 2026-05-23 às 15 41 37" src="https://github.com/user-attachments/assets/491854ac-710f-4e70-bdfa-9121d9f47bb6" />

 Veterinário (/api/Veterinario)
GET /api/Veterinario - Retorna a lista de veterinários.
GET /api/Veterinario/{id} - Retorna um veterinário pelo ID.
POST /api/Veterinario - Cadastra um novo veterinário (pode incluir o ClinicaId).
PUT /api/Veterinario/{id} - Atualiza os dados de um veterinário.
DELETE /api/Veterinario/{id} - Remove um veterinário.
<img width="1430" height="357" alt="Captura de Tela 2026-05-23 às 15 41 49" src="https://github.com/user-attachments/assets/184c876d-4718-4a3c-807f-78d7d6b3a52d" />


Clínica (/api/Clinica)
GET /api/Clinica - Retorna a lista de clínicas veterinárias.
GET /api/Clinica/{id} - Retorna uma clínica pelo ID.
POST /api/Clinica - Cadastra uma nova clínica.
PUT /api/Clinica/{id} - Atualiza os dados de uma clínica.
DELETE /api/Clinica/{id} - Remove uma clínica.
<img width="1421" height="352" alt="Captura de Tela 2026-05-23 às 15 41 32" src="https://github.com/user-attachments/assets/7731d40b-9dcb-4a78-b065-8b9f9d826d6a" />
