USE [Clientes]
GO

/****** Object: Table [dbo].[Usuario] Script Date: 09/01/2023 22:01:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Usuario];


GO
CREATE TABLE [dbo].[Usuario] (
    [id_Usuario] INT           IDENTITY (1, 1) NOT NULL,
    [Nome]       VARCHAR (250) NULL,
    [Idade]      INT          not NULL default 0,
    [Senha]      INT           NULL,
    [Email]      VARCHAR (250) NULL,
	[Role]      INT           NOT NULL default 0 
);

drop table Usuario


select * from Usuario

select Nome, Idade, Senha, Email, Role from Usuario where id_Usuario = 1

insert into Usuario (Nome,Idade, Senha,Email)
values ('Luiz',30,456745678, 'Luis@gmail.com');

update Usuario set Idade = 26 ,senha = 987654321, Email = 'caio@hotmail.com' , Role = 1 where id_Usuario = 1;

delete Usuario where id_Usuario = 8;

