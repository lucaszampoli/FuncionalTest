# Instruções

Este repositório contém informações para permitir que o mongodb seja executado em um contêiner para desenvolvimento local.
As informações abaixo extraem uma imagem do mongodb do Docker Hub; 

### Cria nova imagem mongo 

```docker pull mongo```

### Criar caminho para armazenar dados

```mkdir -p $(pwd)/Documentos/Projetos/data/db```

Note: $(pwd) é um script de shell para mostrar a pasta atual. Altere para o seu próprio local.

```docker run --name mongodb -d -p 27017:27017 -v $(pwd)/Documentos/Projetos/data/db:/data/db mongo```

Este comando executará o seu mongo em um contêiner, usando o sistema de arquivos local para armazenar dados.

```docker logs -f mongodb```

Este comando manterá uma janela aberta para ver todos os logs em sua instância local do mongo. Útil para ver o que está acontecendo.

### Execute o contêiner mongodb para permitir que o aplicativo o conecte

```docker run -it --link mongodb:mongodb --rm mongo sh -c 'exec mongo "$MONGODB_PORT_27017_TCP_ADDR:$MONGODB_PORT_27017_TCP_PORT"'```

Este comando iniciará um terminal para navegar através de sua instância do mongodb, verificando dados etc.

### Inserir alguns dados para teste de aplicação
```use funcionalDb;```

```db.product.insert({"ProductName": "Dipirona","Industry": "Generico","Price": 54.93,"Quantity": 100});```

```db.product.find().pretty();```

Você deverá ver o objeto inserido após o comando db.product.find (). Pretty (). Agora seu banco de dados mongodb está pronto e pronto.

# Sessão avançada

### Remova todos os contêineres em execução (somente se você precisar redefinir todos os contêineres):

```docker stop $(docker ps -aq)```

```docker rm $(docker ps -aq)```

### Remova a imagem da janela de encaixe (você não precisa fazer isso, apenas se necessário !!!)

```docker rmi ImageID```

### Precisamos nos conectar ao nosso contêiner mongodb para executar alguns comandos mongo:

### Iniciar um novo processo bash no contêiner em execução

```docker exec -it mongodb bash```

### Para Harbor

Caso você precise fazer o download de uma imagem Harbor (e deseja renomear a imagem para um nome conhecido, como "mongo")

```docker run --name mongodb mongo:4.0.4```

### Uso da aplicação 

### Iniciar a aplicação no Visual Studio

você precisa verificar se o banco mongo está rodando e se foi criado o mesmo com o nome "funcionalDb".

### Endpoints

https://localhost:8001/api/product => Criar novo produto.

https://localhost:8001/api/product=> Lista os produtos.

https://localhost:8001/api/product/id => Busca de produto.

https://localhost:8001/api/product/id => Atualiza produto.

https://localhost:8001/api/product/id => Deleta produto.

### Você pode importar o arquivo "Funcional.postman_collection.json" que esta na raiz do projeto para o POSTMAN para realizar os testes.


