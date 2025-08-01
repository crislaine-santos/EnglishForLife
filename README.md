# English For Life API

API de Gerenciamento de cadastro de Alunos em turmas.

## 📋 Requisitos e Funcionalidades

A API foi desenvolvida para atender aos seguintes requisitos:

### Modelo de Dados

* **Aluno**:
    * `Id`
    * `Nome`
    * `CPF`
    * `E-mail`
    * `Id Turma`
* **Turma**:
    * `Id`
    * `Nome`
    * `Nivel`

### Endpoints 

* **CRUD de Aluno**:
    * `Cadastro`
    * `Edição`
    * `Listagem`
    * `Exclusão`
* **CRUD de Turma**:
    * `Cadastro`
    * `Listagem`
    * `Listagem de alunos de determinada turma`
    * `Exclusão`

### Regras de Negócio

* **Restrição de CPF**: Não é permitido cadastrar alunos com um CPF já existente.
* **Matrícula Obrigatória**: No cadastro do aluno, é obrigatório associá-lo a uma turma existente.
* **Limite de Alunos por Turma**: Cada turma possui um número máximo de 5 alunos. Não é possível matricular novos alunos após esse limite ser atingido.
* **Restrição de Exclusão**: Uma turma não pode ser excluída se ela possuir alunos matriculados.

 ### Autenticação e Autorização

Foi implementado um sistema de segurança para a API

* **ASP.NET Core Identity**: Para o gerenciamento de usuários, incluindo registro, login e roles.
* **JSON Web Token (JWT)**: Para a geração de tokens de acesso seguros, que permitem a autorização em endpoints protegidos.

## 🚀 Tecnologias Utilizadas

* **ASP.NET Core**: Framework principal para a construção da API.
* **Entity Framework Core**: Utilizado para o acesso a dados com a abordagem **Code First Mapping**.
* **SQL Server**: Banco de dados utilizado para persistência das informações.
* **Swagger/OpenAPI**: Ferramenta para visualização, interação e teste dos endpoints da API.

