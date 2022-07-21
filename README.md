# InicioIntelitrader

- Este repositório contém toda a aplicação do CRUD de usuário funcionando em Docker containers. 
- Para executá-la, clone esse repositório e utilize o docker compose para subir os containers.  
- Para executar os testes:
    1. Levante os container do banco e da API com o docker compose;
    2. Acesse o código da API;
    3. Abra a pasta "Contexts";
    4. Acesse a classe de contexto "IntelitraderContext.cs";
    5. Vá até a linha 27;
    6. Na string de conexão, substitua a "Data Source=sqldata" por Data Source=localhost,1450";
    7. Após alterar a string de conexão, a linha 27 ficará assim:
          
          optionsBuilder.UseSqlServer("Data Source=localhost,1450; initial catalog=INTELITRADER; user Id=SA; pwd=senai@132;");
          
    8. Com a string de conexão alterada, os contaneirs online e o visual studio aberto, clique na opção "teste" no menu superior e então em "Executar todos os testes";
    9. Aguarde e então todos os testes serão realizados.
