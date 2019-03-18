use master
go

drop database modelo
go

create database modelo
go

use modelo
go

create table ContaCorrente(
	ID int identity primary key,
	Numero varchar(200)
)
go

create table Lancamento(
	ID int identity primary key,
	IDContaOrigem int,
	IDContaDestino int,
	Valor numeric(12,2)
)
go