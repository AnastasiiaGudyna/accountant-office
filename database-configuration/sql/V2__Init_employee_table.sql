CREATE TABLE employee (
    id UUID PRIMARY KEY,
    create_date TIMESTAMP NOT NULL,
    name TEXT NOT NULL,
    surname TEXT NOT NULL,
    phone TEXT NULL,
    salary numeric,
    department_id UUID,
    CONSTRAINT fk_department FOREIGN KEY(department_id) REFERENCES department(id)
);