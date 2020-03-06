create database webapi;
create table customer (
	id int not null auto_increment,
    customer_name varchar(100) not null,
    age int not null,
    gender ENUM("Male", "Female", "Another") not null
);