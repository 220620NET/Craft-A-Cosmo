create schema DOTNET_P3;

create table DOTNET_P3.users(
	userId int identity primary key,
	username varchar(30) unique,
	password varchar(30) not null,
	email varchar (45) not null,
	role varchar(8) not null check (role in ('Guest', 'User', 'Admin')) default 'User'
	);
	
create table DOTNET_P3.orders(
	orderId int identity primary key,
	productId_fk int not null foreign key references DOTNET_P3.product(productId),
	orderDetailsId_fk int not null foreign key references DOTNET_P3.orderDetails(orderDetailsId),
	userId_fk int not null foreign key references DOTNET_P3.users(userId),		
	orderTime datetime not null
	);

create table DOTNET_P3.city(
	cityId int identity primary key,
	stateId_fk int not null foreign key references DOTNET_P3.state(stateId),	
	cityName varchar(45) not null
	);

create table DOTNET_P3.state(
	stateId int identity primary key,
	stateName varchar(20) not null
	);	
	
create table DOTNET_P3.zipcode(
	zipcodeId int identity primary key,
	cityId_fk int not null foreign key references DOTNET_P3.city(cityId),
	zipCode int not null
	);
	
create table DOTNET_P3.orderDetails(
	orderDetailsId int identity primary key,
	billingAddress_fk int not null foreign key references DOTNET_P3.billingAddress(billingAddressId),
	shippingAddress_fk int not null foreign key references DOTNET_P3.shippingAddress(shippingAddressId),
	orderTime datetime not null,
	shippingNote varchar(50),
	quantity int not null
	);

create table DOTNET_P3.productOptions(
	productOptionsId int identity primary key,
	colorVariant varchar(45),
	sizeVariant varchar(45),
	soundVariant varchar(45)
	);

create table DOTNET_P3.category(
	categoryId int identity primary key,
	categoryName varchar(45)
	);
	
create table DOTNET_P3.product(
	productId int identity primary key,
	categoryId_fk int not null foreign key references DOTNET_P3.category(categoryId),
	productOptionsId_fk int not null foreign key references DOTNET_P3.productOptions(productOptionsId),
	price money not null,
	description varchar(255),
	productName varchar(45),
	productCol varchar(45),
	productImage varchar(45),
	listed tinyint
	);

create table DOTNET_P3.billingAddress(
	billingAddressId int identity primary key,
	buildingNum int,
	streetName varchar,
	apartmentNum int,
	zipcode_fk int not null foreign key references DOTNET_P3.zipcode(zipcodeId),
	city_fk int not null foreign key references DOTNET_P3.city(cityId),
	state_fk int not null foreign key references DOTNET_P3.state(stateId)
	);

create table DOTNET_P3.shippingAddress(

	shippingAddressId int identity primary key,
	buildingNum int,
	streetName varchar,
	apartmentNum int,
	zipcode_fk int not null foreign key references DOTNET_P3.zipcode(zipcodeId),
	city_fk int not null foreign key references DOTNET_P3.city(cityId),
	state_fk int not null foreign key references DOTNET_P3.state(stateId)
	);	
	
drop table DOTNET_P3.shippingAddress;