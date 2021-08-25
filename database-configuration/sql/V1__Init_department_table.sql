CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE department (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    name TEXT NOT NULL
);