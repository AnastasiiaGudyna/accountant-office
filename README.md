# Accountant Office

Accountant Office is an application for Accounting. It provides information about Departments, Employes and their salary.

## Installation

Make sure that you have docker installed on your PC.

Create file .env in root.
In .env file fill in

`POSTGRES_USER`

`POSTGRES_PASSWORD`

`POSTGRES_DB`

with data you will use for database creation. This are variables which are used in docker-compose.yaml for db creation and comunication api with db.

Then in the root directory use command
```bash
docker compose up -d
```
The frontend will be available at http://localhost:80/ as soon as docker launches necessary container.

The backend can be found at http://localhost:5011/swagger/index.html

# ToDo

* Different user roles
* Admin Page with new user creation, catalogs management
* Separate service with report generation