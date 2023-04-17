CREATE TABLE persisted_grant (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    key TEXT NOT NULL,
    type TEXT NOT NULL,
    subject_id TEXT NOT NULL,
    session_id TEXT NOT NULL,
    client_id TEXT NOT NULL,
    description TEXT NULL,
    expiry_date TIMESTAMP NULL,
    consumed_date TIMESTAMP NULL,
    data TEXT NOT NULL
);
