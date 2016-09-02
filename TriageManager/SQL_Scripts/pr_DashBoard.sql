alter proc pr_DashBoard
(
	@p_type int
)
as
begin

	select * from (
	select top 1 'Last Triage'[Triage], REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date],TriageTopic,Team1Member [Team1 Member],Team2Member [Team2 Member],TA_Member[TA Member],TriageMentor[Triage Mentor],'Submit Poll'[Submit Poll],'Triage Contents'[Triage Contents]
	from (select datediff(day, triagedate, getdate())[day1], triagedate,getdate()[customdate],TriageTopic,Team1Member,Team2Member,TA_Member,TriageMentor from triagecalender) a
	where day1 > 0
	order by 1 )b

	Union

	select top 1 'Upcoming Triage'[Triage],REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date],TriageTopic,Team1Member[Team1 Member],Team2Member [Team2 Member],TA_Member [TA Member],TriageMentor[Triage Mentor],'Submit Poll'[Submit Poll],'Triage Contents'[Triage Contents]
	from (select datediff(day, triagedate, getdate())[day1], triagedate,getdate()[customdate],TriageTopic,Team1Member,Team2Member,TA_Member,TriageMentor from triagecalender) a
	where day1 <= 0

end

--select * from triagecalender
--select * from users
--update triagecalender set TriageMentor = 'kaushalp' where triagecalenderid = 5

insert into users values('puneet.gupta','Puneet','Gupta','puneet.gupta@microsoft.com')
insert into users values('Ravindra.Aditya','Ravindra','Aditya','Ravindra.Aditya@microsoft.com')
insert into users values('rokum','Rohini kumar','Madugula','rokum@microsoft.com')
insert into users values('sanglak','Sandhya Bignenahalli','Lakshmaia','sanglak@microsoft.com')
insert into users values('sadewa','Sanni Kumar','Dewangan','sadewa@microsoft.com')
insert into users values('shsharma','Shiv','Sharma','shsharma@microsoft.com')
insert into users values('Showkat.Lone','Showkat Hassan','Lone','Showkat.Lone@microsoft.com')
insert into users values('tulikac','Tulika','Chaudharie','tulikac@microsoft.com')
insert into users values('v-vabh','Vaishali','Bhatnagar','v-vabh@microsoft.com')
insert into users values('vineev','Vineet','Vashist','vineev@microsoft.com')

--update users set alias = 'showkatl' where alias = 'Showkat.Lone'

