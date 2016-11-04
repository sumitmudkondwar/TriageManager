create table TriageCalender
(
	TriageCalenderID int identity(1,1) primary key clustered,
	TriageDate date,
	TriageTopic varchar(500),
	Team1Member varchar(50),
	Team2Member varchar(50),
	TA_Member varchar(50),
	TriageMentor varchar(50),
	IsTriageCompleted bit,
)

go

insert into TriageCalender values('24-aug-2016', 'BYOD & App Service Certificate', '', '', 'kaushalp', 'kaushalp', 0)
insert into TriageCalender values('31-aug-2016', 'Website Availability & Performance', '', '', 'puneetg', 'puneetg', 0)
insert into TriageCalender values('7-sep-2016', 'BYOD / App Service Certificate / SSL / Custom domains / Extensions / KUDU / Traffic Manager / Backups / Clone / Auto-Heal', 'amagar', 'v-prasec', '', 'kaushalp', 0)
insert into TriageCalender values('14-sep-2016', 'VNET / Hybrid Connection', 'dabhan', 'v-vabh', '', 'showkatl', 0)
insert into TriageCalender values('21-sep-2016', 'Deployment', 'midixit', 'sumudk', '', 'Kaushal', 0)
insert into TriageCalender values('28-sep-2016', 'VNET', '', '', 'showkatl', 'showkatl', 0)
insert into TriageCalender values('5-oct-2016', 'ASE', 'prpand', 'dixitaro', '', 'hkrish', 0)
insert into TriageCalender values('12-oct-2016', 'Mobile Apps', 'kechaw', 'amtripat', '', 'puneetg', 0)
insert into TriageCalender values('19-oct-2016', 'Scaling / Auto-Scaling/ Slots / Alerts / App Settings', 'sanglak', 'v-goven', '', 'showkatl', 0)
insert into TriageCalender values('26-oct-2016', 'ASE', '', '', 'hkrish', 'hkrish', 0)
insert into TriageCalender values('2-nov-2016', 'Linux Basics', 'vinku', '', '', 'hkrish', 0)
insert into TriageCalender values('9-nov-2016', 'Easy Auth and AAD related', 'anilpras', '', '', 'puneetg', 0)
insert into TriageCalender values('16-nov-2016', 'Easy Auth and AAD related', '', '', 'puneetg', 'puneetg', 0)
insert into TriageCalender values('23-nov-2016', 'Web Jobs (SDK) & Functions', 'vineev', 'kakushwa', '', 'tulikac', 0)
insert into TriageCalender values('30-nov-2016', 'Logic & API apps', 'madhbh', 'raadity', '', 'tulikac', 0)
insert into TriageCalender values('7-dec-2016', 'Azure Powershell / API / SDK / ARM templates', 'rokum', 'akashkh', '', 'showkatl', 0)
insert into TriageCalender values('14-dec-2016', 'Azure Functions', '', '', 'tulikac', 'tulikac', 0)


select TriageDate, TriageTopic, Team1Member, Team2Member, TA_Member, TriageMentor from TriageCalender

select REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/') from TriageCalender

--truncate table TriageCalender