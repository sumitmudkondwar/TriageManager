alter proc get_TriageDate
(
	@p_type bit
)
as
begin

	if(@p_type = 'true')
	begin
		select top 1 REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date]
		from (select datediff(day, triagedate, getdate())[day1], triagedate,getdate()[customdate] from triagecalender) a
		where day1 > 0
		order by 1 
	end
	else
	begin
		select top 1 REPLACE(CONVERT(VARCHAR(11),TriageDate,106), ' ','/')[Triage Date]
		from (select datediff(day, triagedate, getdate())[day1], triagedate,getdate()[customdate] from triagecalender) a
		where day1 <= 0
	end

end

go

get_TriageDate 'true'



