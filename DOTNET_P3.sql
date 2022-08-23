create schema DOTNET_P3;

create table DOTNET_P3.users(
	userId int identity,
	zipcode_fk int not null foreign key references DOTNET_P3.zipcode(zipcodeId),
	city_fk int not null foreign key references DOTNET_P3.city(cityId),
	state_fk int not null foreign key references DOTNET_P3.state(stateId),	
	username varchar(30) unique,
	password varchar(30) not null,
	email varchar (45) not null,
	shippingAddress varchar (45) not null,
	role varchar(8) not null check (role in ('Guest', 'User', 'Admin')) default 'User'
	);
	
create table DOTNET_P3.orders(
	orderId int identity,
	product_fk int not null foreign key references DOTNET_P3.product(productId),
	orderDetails_fk int not null foreign key references DOTNET_P3.orderDetails(orderDetailsId),
	user_fk int not null foreign key references DOTNET_P3.users(userId),
	zipcode_fk int not null foreign key references DOTNET_P3.zipcode(zipcodeId),
	city_fk int not null foreign key references DOTNET_P3.city(cityId),
	state_fk int not null foreign key references DOTNET_P3.state(stateId),		
	orderDetails varchar(45),
	orderTime datetime not null
	)

create table DOTNET_P3.city(
	cityId int identity,
	state_fk int not null foreign key reference DOTNET_P3.state(stateId),	
	cityName varchar(45) not null
	)

create table DOTNET_P3.state(
	stateId int identity,
	stateName varchar(20) not null
	)	
	
create table DOTNET_P3.zipcode(
	zipcodeId int identity,
	city_fk int not null foreign key references DOTNET_P3.city(cityId),
	zipCode int not null
	)
	
create table DOTNET_P3.orderDetails(
	
	)

create table DOTNET_P3.category(
	
	)
	
create table DOTNET_P3.product(
	
	)
	
create table DOTNET_P3.productOptions(
	
	)