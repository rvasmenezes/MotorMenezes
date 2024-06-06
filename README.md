# MotorMenezes
Sistema para aluguél de motos

#Instalação

1 - Instale o docker na maquina

2 - Abra o power shell e naveque e navegue até a pasta raiz do projeto onde se encontra o arquivo docker-compose.yml
	-> execute o comando "docker-compose up"
	-> Este comando irá iniciar o RabbitMQ (Mensageria), PostgreSQL(Banco de dados) e Serilog Seq (Sistema para logs)

3 - O sistema foi desenvolvido em Code First, então será necessário abrir o projeto e no visual Studio.
	-> Localize a opção de "Package Manager Console" e execute o comando "Update-Database" (O migration irá criar todas as tabelas e campos necessários)

4 - Faça download do PgAdmin, acesse o banco de dados criado em localhost, porta 5433

5 - Crie os registros de domínio (Tipo de CNH, Planos, e Roles)
	-> Roles
		insert into "AspNetRoles" ("Id", "Name", "NormalizedName") values ('959364b1-f0fe-11ed-8b31-0242ac140004', 'Admin', 'ADMIN');
		insert into "AspNetRoles" ("Id", "Name", "NormalizedName") values ('d2017b50-84c1-45ed-ba00-9d4cf56bb998', 'Motorcyclist', 'MOTORCYCLIST');
	
	-> Tipo CNH
		INSERT INTO public."CNHType"("Description") VALUES ('A');
		INSERT INTO public."CNHType"("Description") VALUES ('B');
		INSERT INTO public."CNHType"("Description") VALUES ('AB');
	
	-> Planos		
		INSERT INTO public."Plan"("Day", "CostPerDay", "PercentageFine") VALUES (7, 30, 20);
		INSERT INTO public."Plan"("Day", "CostPerDay", "PercentageFine") VALUES (15, 28, 40);
		INSERT INTO public."Plan"("Day", "CostPerDay", "PercentageFine") VALUES (30, 22, 0);
		INSERT INTO public."Plan"("Day", "CostPerDay", "PercentageFine") VALUES (45, 20, 0);
		INSERT INTO public."Plan"("Day", "CostPerDay", "PercentageFine") VALUES (50, 18, 0);

6 - É necessário criar o usuário Admin com comando SQL direto no banco. A senha é "Admin@123"
	-> 
		INSERT INTO public."AspNetUsers"(
			"Id", 
			"Name", 
			"BirthDate", 
			"RegisterDate", 
			"CNPJ", 
			"CNHNumber", 
			"CNHTypeId", 
			"UserName", 
			"NormalizedUserName", 
			"Email", 
			"NormalizedEmail", 
			"EmailConfirmed", 
			"PasswordHash", 
			"SecurityStamp", 
			"ConcurrencyStamp", 
			"PhoneNumber", 
			"PhoneNumberConfirmed", 
			"TwoFactorEnabled", 
			"LockoutEnd", 
			"LockoutEnabled", 
			"AccessFailedCount", 
			"PossuiImagem"
		) VALUES (
			'fa132a88-b684-459f-8f9c-45a2d5d8c577', 
			'Admin', 
			null, 
			'2024-06-04', 
			null, 
			null, 
			null, 
			'admin@gmail.com', 
			'ADMIN@GMAIL.COM',
			'admin@gmail.com', 
			'ADMIN@GMAIL.COM', 
			true, 
			'AQAAAAIAAYagAAAAECje3n729c1P0PCY3gHBvpbVsRMfAsWobJymt6qeB05Quub/77QhhcXi2FUtXZBqaw==', 
			'GX6GZ3R4YSMAAXH4P7RWB6OOENJ5VWMZ',
			'9055ab97-a263-4914-bbc5-03192c987486', 
			null, 
			false, 
			false, 
			null, 
			true, 
			0, 
			false
		);

	INSERT INTO public."AspNetUserRoles"("UserId", "RoleId") VALUES ('fa132a88-b684-459f-8f9c-45a2d5d8c577', '959364b1-f0fe-11ed-8b31-0242ac140004');

7 - Altere o appsettings.json no nó "AWS" (Iremos utilizar o bucket S3 da AWS para fazer upload da CNH dos motoristas)

	"AWS": {
	  "S3AccessKeyId": "{AccessKeyId}",
	  "S3AccessKeySecret": "{AccessKeySecret}",
	  "S3BucketExterno": "{Seu_bucket}",
	  "S3UploadPahCNH": "MotoAluguel/CNH",
	  "S3BucketRegionEndpoint": "{Região_bucket}"
	}

8 - Inicialize o sistema


