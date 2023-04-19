DO
$departments$
DECLARE
departments text[]:= '{"Mobile Development","HR","Web Development","Accountant","Administration","Supply"}';
dep text;
BEGIN 
   FOREACH dep IN ARRAY departments
        LOOP
	 INSERT INTO
         department (id, create_date, name)
         VALUES (uuid_generate_v4(), CURRENT_TIMESTAMP, dep);
        END LOOP;
END;
$departments$;

DO
$employees$
DECLARE
names text[]:= array['Milo', 'Jack', 'Lucy', 'Carol', 'David', 'Charlotte', 'Steven'];
surnames text[]:= array['Doe', 'Lloyd', 'Nightingale', 'Show', 'Maan', 'Lee', 'Cherkashin'];
name1 text;
surname text;
dep_id uuid;
departments_count int := 6;
BEGIN
        FOREACH name1 IN ARRAY names
        LOOP
            FOREACH surname IN ARRAY surnames
            LOOP
                INSERT INTO 
                employee (id, create_date, name, surname, phone, salary, department_id )
                (select
                    uuid_generate_v4(),
                    CURRENT_TIMESTAMP,
                    name1,
                    surname,
                    null,
                    random_between(5000,300000),
                    department.id FROM department LIMIT 1 OFFSET random_between(0,5));
            END LOOP;
        END LOOP;
END;
$employees$;