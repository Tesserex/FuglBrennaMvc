use FuglBrenna;

create table [Shires] (
	[ShireId] int not null primary key identity (1,1),
	[Name] varchar(50) not null
);
go

create table [Members] (
	[MemberId] int not null primary key identity (1,1),
	[ShireId] int null foreign key references [Shires](ShireId),
	[FirstName] varchar(50) not null,
	[LastName] varchar(50) not null,
	[FightingName] varchar(50) not null,
);
go