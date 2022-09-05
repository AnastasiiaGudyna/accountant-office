WITH ins1 AS(
    INSERT INTO
        catalog (id, create_date, catalog_name)
    VALUES (uuid_generate_v4(), CURRENT_TIMESTAMP, 'Job Categories')
    RETURNING id AS catalog_id
 )

INSERT INTO 
catalog_values (id, create_date, catalog_id, catalog_value )
(select
    uuid_generate_v4(),
    CURRENT_TIMESTAMP,
    catalog_id,
    'Accountant'
from ins1
UNION 
select
    uuid_generate_v4(),
    CURRENT_TIMESTAMP,
    catalog_id,
    'Software Engineer'
from ins1
UNION 
select
    uuid_generate_v4(),
    CURRENT_TIMESTAMP,
    catalog_id,
    'Administrator'
from ins1
UNION 
select
    uuid_generate_v4(),
    CURRENT_TIMESTAMP,
    catalog_id,
    'Sales Manager'
from ins1
);