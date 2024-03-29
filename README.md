# Accountant Office

## Overview

Accountant Office is an application for Accounting. It provides information about Departments, Employes and their salary.

The application uses three services to run:
- Accountant Office Api - based on .Net 7 API consisted of interaction with departments, employes and catalogs using PostgreSQL database
- Identity Server - for developing of this server was used [Duende](https://docs.duendesoftware.com/identityserver/v6) library
- Accountant Office Frontend - Angular based frontend application

## Installation

Make sure that you have docker installed on your PC.

Create file .env in root.
In .env file fill in
| var                    | description | note |
| ----                   | ----                                                            | ---- |
| `ACCOUNTANT_DB_USER`        | accountant office api database user                                                   |↓     |
| `ACCOUNTANT_DB_PASSWORD`    | accountant office api database user password                                          |This variables will be used in docker-compose.yaml for accountant office db creation and comunication api with db.     |
| `ACCOUNTANT_DB`          | accountant office api database name                                                   |↑     |
| `IDENTITY_DB_USER`        | identity server database user                                                   |↓     |
| `IDENTITY_DB_PASSWORD`    | identity server database user password                                          |This variables will be used in docker-compose.yaml for identity server db creation and comunication server with db.     |
| `IDENTITY_DB`          | identity server database name                                                   |↑     |
| `CERTIFICATE_PASSWORD` | this password the same as was used when https cert was created  |      |

Then in the root directory use the next commands:

```bash
docker compose build
```

```bash
docker compose up -d
```
The frontend will be available at http://localhost:80/ as soon as docker launches necessary container.

The backend API can be found at http://localhost:5010/swagger/index.html or https://localhost:5011/swagger/index.html

Also it is possible to operate Identity Server on http://localhost:5000/. You can use `example@example.com/Admin` as `login/password` as it is the user created for Identity Server during the first launch.
At this time Identity Server supports only login and refresh tokens and has some data stored in the db instead of memory (Users, Signin Keys and Tokens).

### Note

The Identity Server uses self-signed development certificates for hosting pre-built images over localhost. The instructions are similar to using production certificates. The certificate generated by dotnet dev-certs is for use with localhost only and should not be used in an environment like Kubernetes. To support HTTPS within a Kubernetes cluster, use the tools provided by Manage TLS Certificates in a Cluster to setup TLS within pods.

## Additional info

For created PRs this repository uses GitHub Actions that checks that all solutions within can be built without any errors and that all tests pass.

## Useful links

For applying certificates was used [Hosting ASP.NET Core images with Docker Compose over HTTPS](https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https?view=aspnetcore-7.0)

For configuring Identity Server was used [Duende docs](https://docs.duendesoftware.com/identityserver/v6/quickstarts/)

For frontend part for Auth was used [oidc-client-ts library](https://authts.github.io/oidc-client-ts/index.html)

# To Do:

* Change CORS Policies in services
* Remove exposed DB ports
* Make persistant DBs
* Add different user roles
* Create Admin Page with new user creation, scopes, roles management catalogs management
* Create service with report generation