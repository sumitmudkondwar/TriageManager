alter proc pr_getYourTriages
(
	@p_Alias varchar(100)
)
as
begin

	declare @Team1Name varchar(50)
	declare @Team2Name varchar(50)
	declare @TAMember varchar(50)
	declare @Mentor varchar(50)
	declare @name varchar(50) 
	
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

	fetch next from db_cursor1 into @Team1Name,@Team2Name,@TAMember,@Mentor

	while @@FETCH_STATUS = 0
	begin

		update #temp set [Team1 Member] = (select FirstName + ' ' + LastName from Users where Alias = @Team1Name) where [Team1 Member] = @Team1Name

		update #temp set [Team2 Member] = (select FirstName + ' ' + LastName from Users where Alias = @Team2Name) where [Team2 Member] = @Team2Name

		update #temp set [TA Member] = (select FirstName + ' ' + LastName from Users where Alias = @TAMember) where [TA Member] = @TAMember

		update #temp set [Triage Mentor] = (select FirstName + ' ' + LastName from Users where Alias = @Mentor) where [Triage Mentor] = @Mentor

		fetch next from db_cursor1 into @Team1Name,@Team2Name,@TAMember,@Mentor
	end

	CLOSE db_cursor1   
	DEALLOCATE db_cursor1

	select * from #temp

	drop table #temp

end

go

--pr_getYourTriages 'sumudk@microsoft.com'


