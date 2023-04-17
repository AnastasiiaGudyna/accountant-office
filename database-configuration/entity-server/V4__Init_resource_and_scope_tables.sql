CREATE TABLE api_scope (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    enabled BOOLEAN NOT NULL,
    name TEXT NOT NULL,
    display_name TEXT NULL,
    description TEXT NULL,
    required BOOLEAN NOT NULL,
    emphasize BOOLEAN NOT NULL,
    show_in_discovery_document BOOLEAN NOT NULL,
    updated TIMESTAMP NULL,
    last_accessed TIMESTAMP NULL,
    non_editable BOOLEAN NOT NULL
);

CREATE TABLE api_resource (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    enabled BOOLEAN NOT NULL,
    name TEXT NOT NULL,
    display_name TEXT NULL,
    description TEXT NULL,
    allowed_access_token_signing_algorithms TEXT NULL,
    require_resource_indicator BOOLEAN NOT NULL,
    show_in_discovery_document BOOLEAN NOT NULL,
    updated TIMESTAMP NULL,
    last_accessed TIMESTAMP NULL,
    non_editable BOOLEAN NOT NULL
);
