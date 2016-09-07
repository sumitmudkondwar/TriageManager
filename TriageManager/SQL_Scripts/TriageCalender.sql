create table TriageCalender
(
	TriageCalenderID int identity(1,1) primary key clustered,
	TriageDate date,
	TriageTopic varchar(500),
	Team1Member varchar(50),
	Team2Member varchar(50),
	TA_Member varchar(50),
	TriageMentor varchar(50),
)

go

insert into TriageCalender values('24-aug-2016', 'BYOD & App Service Certificate', '', '', 'kaushalp', 'kaushalp')
insert into TriageCalender values('31-aug-2016', 'Website Availability & Performance', '', '', 'puneetg', 'puneetg')
insert into TriageCalender values('7-sep-2016', 'BYOD / App Service Certificate / SSL / Custom domains / Extensions / KUDU / Traffic Manager / Backups / Clone / Auto-Heal', 'amagar', 'v-prasec', '', 'kaushalp')
insert into TriageCalender values('14-sep-2016', 'VNET / Hybrid Connection', 'dabhan', 'v-vabh', '', 'showkatl')
insert into TriageCalender values('21-sep-2016', 'Deployment', 'midixit', 'sumudk', '', 'Kaushal')
insert into TriageCalender values('28-sep-2016', 'VNET', '', '', 'showkatl', 'showkatl')
insert into TriageCalender values('5-oct-2016', 'ASE', 'prpand', 'dixitaro', '', 'hkrish')
insert into TriageCalender values('12-oct-2016', 'Mobile Apps', 'kechaw', 'amtripat', '', 'puneetg')
insert into TriageCalender values('19-oct-2016', 'Scaling / Auto-Scaling/ Slots / Alerts / App Settings', 'sanglak', 'v-goven', '', 'showkatl')
insert into TriageCalender values('26-oct-2016', 'ASE', '', '', 'hkrish', 'hkrish')
insert into TriageCalender values('2-nov-2016', 'Linux Basics', 'vinku', '', '', 'hkrish')
insert into TriageCalender values('9-nov-2016', 'Easy Auth and AAD related', 'anilpras', '', '', 'puneetg')
insert into TriageCalender values('16-nov-2016', 'Easy Auth and AAD related', '', '', 'puneetg', 'puneetg')
insert into TriageCalender values('23-nov-2016', 'Web Jobs (SDK) & Functions', 'vineev', 'kakushwa', '', 'tulikac')
insert into TriageCalender values('30-nov-2016', 'Logic & API apps', 'madhbh', 'raadity', '', 'tulikac')
insert into TriageCalender values('7-dec-2016', 'Azure Powershell / API / SDK / ARM templates', 'rokum', 'akashkh', '', 'showkatl')
insert into TriageCalender values('14-dec-2016', 'Azure Functions', '', '', 'tulikac', 'tulikac')


select TriageDate, TriageTopic, Team1Member, Team2Member, TA_Member, TriageMentor from TriageCalender

select REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/') from TriageCalender

--truncate table TriageCalender