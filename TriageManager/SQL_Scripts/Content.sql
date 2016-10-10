create table MainContent
(
	MainContentId int identity(1,1) primary key clustered,
	ContentHeading varchar(200),
	ContentDescription varchar(Max),
	ContentGUID varchar(100),
	EmailId varchar(100)
)

go

create table FileNameContent
(
	FileNameContentId int identity(1,1) primary key clustered,
	ContentGUID varchar(100),
	BlobPath varchar(100)
)



