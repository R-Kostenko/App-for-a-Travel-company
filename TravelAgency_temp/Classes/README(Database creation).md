# Database creation
This README is created to help users with creating a database on their devices. Here is the **query code** to create the database and tables in it.
## Microsoft SQL Server Management Studio 18 Installation
If you **do not have MSS installed** I will leave you with a link to a short and informative [**video**](https://youtu.be/iaUXjTL_F9U) on how to install this utility.
## Query to create database and tables
I'll add the query code here.
**Code**:
```
create database DataTrevApp

use DataTrevApp

create table register(
	id_user int identity(1,1) not null primary key,
	user_last_name nvarchar(50) not null,
	user_first_name nvarchar(50) not null,
	user_middle_name nvarchar(50) not null,
	user_gender nvarchar(7) not null,
	user_password nvarchar(256) not null,
	user_email nvarchar(50) not null,
	user_phone_number nchar(13) not null,
	is_admin bit default 0
)

create table tours(
	id_tour int identity(1,1) not null primary key,
	tour_name nvarchar(256) not null,
	tour_description nvarchar(max) not null,
	tour_start_date date not null,
	tour_end_date date not null,
	tour_price int not null,
	tour_max_count_users int default 2
)

create table orders (
    id_order int identity(1, 1) not null primary key,
	id_user int not null,
	id_tour int not null,
    order_date date not null,
	foreign key (id_user) references dbo.register(id_user) on delete cascade on update cascade,
	foreign key (id_tour) references dbo.tours(id_tour) on delete cascade on update cascade
)
```
**FIRST OF ALL** To create a database, execute the first line: `create database DataTrevApp`.
Only after executing the first line you can execute the other lines (if they are not executed on the first try - try again :smile:)

## Next step
Congratulations, you're about to finish deploying the program. To continue, please follow this link to the latest [**README**](TravelAgency_temp/Classes/README(Deployment).md).
