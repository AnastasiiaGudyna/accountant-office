WITH ins1 AS(
    INSERT INTO
        department (id, create_date, name)
    VALUES (uuid_generate_v4(), CURRENT_TIMESTAMP, 'Mobile Development')
    RETURNING id AS department_id
 )

INSERT INTO 
employee (id, create_date, name, surname, phone, salary, department_id )
(select
    uuid_generate_v4(),
    CURRENT_TIMESTAMP,
    'James',
    'Forret',
    null,
    120000,
    department_id
from ins1
UNION 
select
    uuid_generate_v4(),
    CURRENT_TIMESTAMP,
    'Caren',
    'Floid',
    null,
    100000,
    department_id
from ins1);