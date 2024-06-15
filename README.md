# Sistema para aluguél de motos

# Instalação (É necessário ter o Docker instalado)

1 - Abra o power shell;

2 - Naveque e navegue até a pasta raiz do projeto onde se encontra o arquivo docker-compose.yml;
	
3 - Execute o comando "docker-compose up"


# Docker compose será responsável por:

1 - Instalar o Message Broker RabbitMQ na porta 15672 (http://localhost:15672);

2 - Instalar o banco de dados Postgres na porta 5432;

3 - Instalar o sistema para logs Serilog Seq na porta 5342 (http://localhost:5342);

4 - Instalar o LocalStack e AWS CLI para simular o Bucket S3 da AWS;

5 - Rodar os scripts do arquivo init.sql;


# Uso

1 - Acesse o sistema pelo endereço "http://localhost:5532"

2 - Faça login com o usuário "admin@gmail.com" e senha "Admin@123" (Registra motos e visualiza reservas) 

3 - Ao cadastrar um usuário na tela de cadastro, poderá realizar reservas
