alter proc pr_InsertPoll
(
	@p_IsTriageAttended bit,
	@p_Alias varchar(50),
	@p_TriageLevel int,
	@p_TriageQuality int,
	@p_Presentation int,
	@p_Comments varchar(200),
	@p_Reason varchar(200),
	@p_TriageDate datetime
)
as
begin

	if(@p_IsTriageAttended = 'true')
		insert into Poll values(@p_Alias, @p_IsTriageAttended, @p_TriageLevel, @p_TriageQuality, @p_Presentation, @p_Comments, null, @p_TriageDate)
	else
		insert into Poll values(@p_Alias, @p_IsTriageAttended, null, null, null, null, @p_Reason, @p_TriageDate)

end

go

--exec pr_InsertPoll
--@p_IsTriageAttended = 'false',
--@p_Alias = 'test',
--@p_TriageLevel = 1,
--@p_TriageQuality = 1,
--@p_Comments = 'good',
--@p_Reason = 'asdf'

--go

select * from poll

delete from poll