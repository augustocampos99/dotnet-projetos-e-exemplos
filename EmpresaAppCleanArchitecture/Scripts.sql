create table funcionarios (
	id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
	cpf varchar(11) NOT NULL,
	nome varchar(100) NOT NULL,
	departamento_id UUID NOT NULL,
	cargo_id UUID NOT NULL,
	status varchar(20) NOT NULL,
	"data_criacao" TIMESTAMP NOT NULL,
	"data_atualizacao" TIMESTAMP NOT NULL,
	constraint funcionarios_key_cpf unique (cpf)
);

create table departamentos (
	id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
	nome varchar(50) NOT NULL
);

create table cargos (
	id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
	nome varchar(50) NOT NULL
);

