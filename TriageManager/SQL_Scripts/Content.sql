create table MainContent
(
	MainContentId int identity(1,1) primary key clustered,
	SmeTopicsId int,
	ContentLevel  int,
	ContentDescription varchar(Max),
	ContentGUID varchar(100),
	EmailId varchar(100),
	ContentURL varchar(500)
)

go

create table FileNameContent
(
	FileNameContentId int identity(1,1) primary key clustered,
	ContentGUID varchar(100),
	BlobPath varchar(100)
)



