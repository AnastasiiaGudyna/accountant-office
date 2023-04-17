CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE registered_user (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    password_hash TEXT NOT NULL,
    email TEXT NOT NULL,
    first_name TEXT NOT NULL,
    last_name TEXT NOT NULL,
    phone TEXT NULL
);