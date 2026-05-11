-- =========================================
-- USERS
-- =========================================
CREATE TABLE users (
    id BIGSERIAL PRIMARY KEY,
    cpf VARCHAR(11) NOT NULL UNIQUE,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255),
    phone VARCHAR(15),
    birth_date DATE NOT NULL,
    address VARCHAR(255),
    monthly_income NUMERIC(15,2) DEFAULT 0,
    password VARCHAR(255),
    status VARCHAR(20) NOT NULL DEFAULT 'ACTIVE',
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

ALTER SEQUENCE users_id_seq RESTART WITH 1000;


-- =========================================
-- AGENCIES
-- =========================================
CREATE TABLE agencies (
    id BIGSERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    address VARCHAR(255),
    status VARCHAR(20) NOT NULL DEFAULT 'ACTIVE',
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

ALTER SEQUENCE agencies_id_seq RESTART WITH 1000;


-- =========================================
-- ACCOUNTS
-- =========================================
CREATE TABLE accounts (
    id BIGSERIAL PRIMARY KEY,
    user_id BIGINT NOT NULL,
    agency_id BIGINT NOT NULL,
    account_type VARCHAR(50) NOT NULL,
    balance NUMERIC(15,2) NOT NULL DEFAULT 0,
    status VARCHAR(20) NOT NULL DEFAULT 'ACTIVE',
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_accounts_users
        FOREIGN KEY (user_id)
        REFERENCES users(id),

    CONSTRAINT fk_accounts_agencies
        FOREIGN KEY (agency_id)
        REFERENCES agencies(id)
);

ALTER SEQUENCE accounts_id_seq RESTART WITH 1000;


-- =========================================
-- ACCOUNT TRANSACTIONS
-- =========================================
CREATE TABLE account_transactions (
    id BIGSERIAL PRIMARY KEY,
    user_id BIGINT NOT NULL,
    source_account_id BIGINT NOT NULL,
    destination_account_id BIGINT,
    transaction_amount NUMERIC(15,2) NOT NULL,
    transaction_type VARCHAR(50) NOT NULL,
    description TEXT,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,

    CONSTRAINT fk_transactions_users
        FOREIGN KEY (user_id)
        REFERENCES users(id),

    CONSTRAINT fk_transactions_source_account
        FOREIGN KEY (source_account_id)
        REFERENCES accounts(id),

    CONSTRAINT fk_transactions_destination_account
        FOREIGN KEY (destination_account_id)
        REFERENCES accounts(id)
);

ALTER SEQUENCE account_transactions_id_seq RESTART WITH 1000;