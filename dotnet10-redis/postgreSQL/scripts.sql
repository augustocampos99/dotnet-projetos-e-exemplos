create table contatos (
	id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL,
	telefone VARCHAR(50) NOT NULL
);
