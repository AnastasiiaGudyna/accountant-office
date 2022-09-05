CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE catalog (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    catalog_name TEXT NOT NULL
);

CREATE TABLE catalog_values (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    catalog_id UUID,
    catalog_value TEXT NOT NULL,
    CONSTRAINT fk_catalog FOREIGN KEY(catalog_id) REFERENCES catalog(id)
);

CREATE TABLE catalog_relation (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    catalog_value_parent UUID,
    catalog_child UUID,
    CONSTRAINT fk_catalog_values FOREIGN KEY(catalog_value_parent) REFERENCES catalog_values(id),
    CONSTRAINT fk_catalog_child FOREIGN KEY(catalog_child) REFERENCES catalog(id)
);