# ISI-TP-01: Processo ETL - Pentaho

## Descrição
Este repositório contém o trabalho prático I da disciplina **Integração de Sistemas de Informação (ISI)** do curso de Engenharia de Sistemas Informáticos no **Instituto Politécnico do Cávado e do Ave (IPCA)**. O projeto foca na implementação de processos de ETL (Extração, Transformação e Carga) utilizando o **Pentaho Data Integration (PDI)**.

O objetivo do projeto foi extrair dados de um arquivo CSV, transformá-los conforme as necessidades da empresa, validar os dados e carregá-los em uma base de dados MySQL, além de criar um arquivo XML. O projeto também inclui a integração com uma API Web utilizando **ASP.NET Core** para manipular e apresentar os dados.

## Funcionalidades Principais

- **Extração de dados CSV**: Leitura de um arquivo CSV contendo informações de jogos de vídeo entre os anos 2000 e 2015.
- **Transformação de dados**:
  - Incremento de IDs únicos para cada registro.
  - Filtragem e seleção de colunas essenciais.
  - Validação dos dados via XSD.
  - Criptografia e descriptografia dos dados utilizando o algoritmo AES.
- **Carga de dados**: Inserção dos dados processados na base de dados MySQL.
- **Automação de processos**: Unificação dos processos em um job automatizado que verifica a integridade dos dados e envia alertas via e-mail.
- **Integração com API Web**: Exposição dos dados através de uma API criada em ASP.NET Core, com endpoints para consulta de vendas de consoles de videogame.

## Tecnologias Utilizadas

- **Pentaho Data Integration (PDI)**: Software de ETL utilizado para o processamento dos dados.
- **MySQL**: Banco de dados relacional onde os dados processados são armazenados.
- **ASP.NET Core MVC**: Framework utilizado para desenvolver a API e o front-end.
- **C#**: Linguagem de programação usada para criar a API e o sistema MVC.
- **AES (Advanced Encryption Standard)**: Algoritmo de criptografia simétrica usado para proteger os dados.
- **SMTP**: Utilizado para o envio de notificações por e-mail ao final do processo de ETL.

## Estrutura do Projeto

- **ETL/Jobs**: Contém o fluxo de transformações e jobs criados no Pentaho para converter os dados CSV em XML e MySQL.
- **API**: Código fonte da API Web desenvolvida em ASP.NET Core, que permite consultar os dados transformados.
- **Front-end**: Aplicação web criada para exibir os dados de vendas de consoles de videogame.

## Como Executar

### Requisitos

- [Pentaho Data Integration](https://sourceforge.net/projects/pentaho/)
- [MySQL](https://www.mysql.com/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Passos

1. Clone o repositório:
   ```bash
   git clone https://github.com/Skunkzenn/ISI-TP-01.git

### 2. Configure o banco de dados MySQL e atualize as strings de conexão no projeto.

### 3. Importe o job e transformações no Pentaho para processar o arquivo CSV.

4. Execute a API com o seguinte comando na raiz do projeto ASP.NET Core:
   ```bash
   dotnet run

### 5. Acesse a aplicação web para visualizar os dados transformados no navegador.

### Demonstração
Assista à demonstração do projeto através do vídeo explicativo.
