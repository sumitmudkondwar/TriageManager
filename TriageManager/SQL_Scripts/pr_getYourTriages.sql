alter proc pr_getYourTriages
(
	@p_Alias varchar(100)
)
as
begin

	declare @Team1Member varchar(50)
	declare @Team2Member varchar(50)
	declare @TAMember varchar(50)
	declare @Mentor varchar(50)
	declare @name varchar(50) 

	declare @Team1Name varchar(100)
	declare @Team2Name varchar(100)
	declare @TAMemberName varchar(100)
	declare @MentorName varchar(100)
	
	select @name = alias from users	where emailid = @p_Alias 
	
	select	REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date], 
			TriageTopic [Triage Topic], 
			Team1Member [Team1 Member], 
			Team2Member [Team2 Member], 
			TA_Member [TA Member], 
			TriageMentor[Triage Mentor]
	into #temp
	from triagecalender 
	where team1member = @name or team2member = @name or ta_member = @name or triagementor = @name

	DECLARE db_cursor1 CURSOR FOR (select [Team1 Member],[Team2 Member],[TA Member],[Triage Mentor] from #temp)
	open db_cursor1

	fetch next from db_cursor1 into @Team1Member,@Team2Member,@TAMember,@Mentor
	
	while @@FETCH_STATUS = 0
	begin

		set @Team1Name = (select FirstName + ' ' + LastName from Users where Alias = @Team1Member)

		if(@Team1Member != '' and @Team1Member is not null and @Team1Name is not null)
			update #temp set [Team1 Member] = @Team1Name where [Team1 Member] = @Team1Member

		set @Team2Name = (select FirstName + ' ' + LastName from Users where Alias = @Team2Member)

		if(@Team2Member != '' and @Team2Member is not null and @Team2Name is not null)
			update #temp set [Team2 Member] = @Team2Name where [Team2 Member] = @Team2Member
	
		set @TAMemberName = (select FirstName + ' ' + LastName from Users where Alias = @TAMember)
	
		if(@TAMember != '' and @TAMember is not null and @TAMemberName is not null)
			update #temp set TA_Member = @TAMemberName where TA_Member = @TAMember
	
		set @MentorName = (select FirstName + ' ' + LastName from Users where Alias = @Mentor)
	
		if(@Mentor != '' and @Mentor is not null and @MentorName is not null)
			update #temp set [Triage Mentor] = @MentorName where [Triage Mentor] = @Mentor

		fetch next from db_cursor1 into @Team1Member,@Team2Member,@TAMember,@Mentor
	end

	CLOSE db_cursor1   
	DEALLOCATE db_cursor1

	select * from #temp

	drop table #temp

end

go

--pr_getYourTriages 'sumudk@microsoft.com'


