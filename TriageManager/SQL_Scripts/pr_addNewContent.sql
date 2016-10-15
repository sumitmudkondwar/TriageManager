alter proc pr_addNewContent
(
	@p_SmeTopicsId int,
	@p_ContentLevel int,
	@p_ContentDescription varchar(Max),
	@p_EmailId varchar(100),
	@p_FileNameList varchar(Max)
)
as 
begin

	declare @GUID varchar(100) = newid();
	declare @FileName varchar(100)

	insert into MainContent values(@p_SmeTopicsId,@p_ContentLevel,@p_ContentDescription,@GUID,@p_EmailId)

	declare C1 cursor for (SELECT value FROM STRING_SPLIT(@p_FileNameList, '|') WHERE RTRIM(value) <> '')
	
	open C1 

	fetch next from C1 into @FileName

	while @@FETCH_STATUS = 0
	begin
		insert into FileNameContent values (@GUID, @FileName)
		fetch next from C1 into @FileName
	end

	close C1
	deallocate C1

end

go


exec pr_addNewContent
@p_SmeTopicsId = 1,
@p_ContentLevel = 100,
@p_ContentDescription = 'asffg',
@p_EmailId = 'sumit@micro.com',
@p_FileNameList = 'a|b|c'
