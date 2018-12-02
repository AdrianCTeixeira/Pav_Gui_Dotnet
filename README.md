# Criação de um serviço para consulta de Altcoins

## Descrição
Criação de um sistema para listagem de altcoins e cotação(BTC) de uma altcoin a preferência do usuário.

### Requisitos

-   A entrada devem conter as siglas padronizadas da moeda que o usuário deseja converter.
-   Interface Web e Desktop
-   Obter via API a lista de altcoins.
-   API: [https://bittrex.com/api/v1.1/public/getcurrencies](https://bittrex.com/api/v1.1/public/getcurrencies "https://bittrex.com/api/v1.1/public/getcurrencies
    CTRL+Click to follow link")
-   Obter via API a cotação de uma altcoin.
-   API: [https://bittrex.com/api/v1.1/public/getmarkethistory?market=BTC-DOGE](https://bittrex.com/api/v1.1/public/getmarkethistory?market=BTC-DOGE "https://bittrex.com/api/v1.1/public/getmarkethistory?market=BTC-DOGE
    CTRL+Click to follow link")
-   Separação do Core para Interface.
-   Testes e correção.


### Entradas

São esses os parâmetros que a interface irá aceitar: 

- No método ListarPorId(): abreviação da altcoin
- No método Listar: não possui entrada.

### Interfaces

-   MVC
-   Form

### Passos:

-   Criação da Solution com as interfaces e o core
-	Mapeamento da API com NewtonSoft
-   Conexão com o banco de dados local no core
-   Métodos públicos para consulta
-   Criação de interfaces para consumir o Core com foco no back-end
-   Visual mais amigável e otimização
-   Correção dos Bugs


### Mudanças e features novas.

- Nova api: https://coinmarketcap.com/pt-br/api/
- Banco de dados: https://github.com/AdrianCTeixeira/Pav_Gui_Dotnet/blob/Core/Interface/api.bak
- MVC ficará em segundo plano. O foco do projeto será apenas em WinForm.
- Uma nova Model, que vai carregar 3 apis em uma.
- Nova coluna no BD servindo como token com expiracao de 20 minutos para realizar nova consulta a web, para menos consulta web e maior desempenho/velocidade nas consultas de listas.
- Funçoes do form:
    - Acessar api e salvar no banco de dados
    - Acessar banco de dados e obter lista
    - ..[em desenvolvimento ]..
