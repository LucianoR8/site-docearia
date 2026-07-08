create table categorias (
  id_categoria INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
  nome_categoria VARCHAR(100) UNIQUE NOT NULL,
  criado_em TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
  atualizado_em TIMESTAMP WITH TIME ZONE
);

create table configuracoes (
  id_configuracao INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
  nome_loja varchar(100) NOT NULL,
  facebook TEXT,
  instagram TEXT,
  endereco TEXT NOT NULL,
  abre_as TIME NOT NULL,
  fecha_as TIME NOT NULL,
  telefone VARCHAR(20) NOT NULL,
  whatsapp VARCHAR(20),
  email VARCHAR(100),
  icone_url TEXT,
  logo_url TEXT,
  banner_url TEXT,
  criado_em TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
  atualizado_em TIMESTAMP WITH TIME ZONE,
  quantidade_maxima_destaques SMALLINT DEFAULT 9
);

CREATE TABLE produtos (
    id_produto INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nome_produto VARCHAR(100) NOT NULL,
    descricao_produto TEXT,
    imagem_url TEXT,
    prazo_entrega VARCHAR(100) NOT NULL,
    slug VARCHAR(100) UNIQUE,
    criado_em TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    atualizado_em TIMESTAMP WITH TIME ZONE,
    ativo BOOLEAN DEFAULT TRUE,
    destaque BOOLEAN DEFAULT FALSE,
    preco NUMERIC(10, 2) NOT NULL,
    categoria_id INT NOT NULL,

    CONSTRAINT fk_categoria
        FOREIGN KEY (categoria_id) 
        REFERENCES categorias(id_categoria)
);
