select * from users
select * from Poll
--drop table Poll

use triagedb
create table Poll
(
	PollID int identity(1,1) primary key clustered,
	Alias varchar(50),
	IsTriageAttended bit not null,
	TriageLevel int,
	TriageQuality int,
	Presentation int,
	Comments varchar(200),
	Reason varchar(200),
	TriageDate datetime,
)