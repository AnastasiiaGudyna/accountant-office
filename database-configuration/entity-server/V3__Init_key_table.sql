CREATE TABLE key (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    use TEXT NOT NULL,
    version INTEGER NOT NULL,
    algorithm TEXT NOT NULL,
    data TEXT NOT NULL,
    data_protected BOOLEAN NOT NULL,
    is_x509_certificate BOOLEAN NOT NULL
);