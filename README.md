# shop-api-catalog
Generic product catalog api used by the shopping website

## Setup

#### clone repo 
> git clone https://github.com/sandeepchugh/catalogapi.git

#### install docker
> https://www.docker.com/docker-windows

### Running MySql in container

- open command prompt and navigate to \docker under the local repo
- fix path in docker-compose-mysql.yml. 
> Change the path under "volumes:" to the data folder on your machine. Path is case sensitive and should match the folder case 
>
>  mysql:
>    image: mysql
>    ports:
>      - "3306:3306"
>    restart: always
>    environment:
>       MYSQL_ROOT_PASSWORD: "rootpwd"
>       MYSQL_DATABASE: "catalog"
>       MYSQL_USER: "catalogapiuser"
>       MYSQL_PASSWORD: "catalogapipwd"
>       MYSQL_ALLOW_EMPTY_PASSWORD: "no"
>    volumes:
>      - D:\Dev\shop\mysqldata:/var/lib/mysql

- run the following command to bring up mysql in a container
> docker-compose -f docker-compose-mysql.yml up
- to shut down the container 
> CTRL+C
> 
>  docker-compose -f docker-compose-mysql.yml down

### Setup database 'catalog'

- build solution and run Catalog.Databases.MySql project to setup database
