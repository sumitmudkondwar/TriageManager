create proc pr_getTriageCalender
(
	@p_Alias varchar(50)
)
as
begin
	
	declare @Team1Member varchar(100)
	declare @Team2Member varchar(100)
	declare @TAMember varchar(100)
	declare @TriageMentor varchar(100)

	declare @Team1Name varchar(100)
	declare @Team2Name varchar(100)
	declare @TAMemberName varchar(100)
	declare @MentorName varchar(100)

	select * into #temp from TriageCalender

	declare C1 cursor for (select Team1Member,Team2Member,TA_Member,TriageMentor from #temp)
	open C1

	fetch next from C1 into @Team1Member,@Team2Member,@TAMember,@TriageMentor

	while @@FETCH_STATUS = 0
	begin
		set @Team1Name = (select FirstName + ' ' + LastName from Users where Alias = @Team1Member)

		if(@Team1Member != '' and @Team1Member is not null and @Team1Name is not null)
			update #temp set Team1Member = @Team1Name where Team1Member = @Team1Member

		set @Team2Name = (select FirstName + ' ' + LastName from Users where Alias = @Team2Member)

		if(@Team2Member != '' and @Team2Member is not null and @Team2Name is not null)
			update #temp set Team2Member = @Team2Name where Team2Member = @Team2Member
	
		set @TAMemberName = (select FirstName + ' ' + LastName from Users where Alias = @TAMember)
	
		if(@TAMember != '' and @TAMember is not null and @TAMemberName is not null)
			update #temp set TA_Member = @TAMemberName where TA_Member = @TAMember
	
		set @MentorName = (select FirstName + ' ' + LastName from Users where Alias = @TriageMentor)
	
		if(@TriageMentor != '' and @TriageMentor is not null and @MentorName is not null)
			update #temp set TriageMentor = @MentorName where TriageMentor = @TriageMentor
		
		fetch next from C1 into @Team1Member,@Team2Member,@TAMember,@TriageMentor
	end

	close C1
	deallocate C1

	select REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date], TriageTopic [Topic], Team1Member [Team 1], Team2Member [Team 2], TA_Member [TA], TriageMentor [Mentor] from #temp

	drop table #temp

end

go

--pr_getTriageCalender ''

