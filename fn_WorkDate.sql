ALTER FUNCTION [dbo].[fn_WorkDate]
(
@BeginDate				datetime,
@EndDate				datetime
)
RETURNS int
BEGIN
	DECLARE 
	@COUNT			int,--工作日
	@WeekCount		int,--除去周六周日的工作日
	@SysCount		int,--串休的工作日
	@Week			int--一周的第几天
	SET @COUNT=0
	
	WHILE (datediff(dd,@BeginDate,@EndDate)>=0)
		begin
			set @WeekCount=0
			set @Week= DATEPART(WEEKDAY,@BeginDate)
			if(@Week=1 or @Week=7)
				BEGIN
					SET @WeekCount=0
				END
			ELSE
				BEGIN
					SET @WeekCount=1
				END
		select @SysCount= max(fday) from  TBProcess_RestDate where datediff(dd,fdate,@BeginDate)=0

          if(@SysCount!=-1)
			begin
				set @WeekCount=@SysCount
			end
			
          set @COUNT=@COUNT +@WeekCount
          SET @BeginDate=DATEADD(DAY,1,@BeginDate)
		end
	Return @COUNT
END


 -- DECLARE @DAY DATE,@COUNT INT
 -- SET @DAY='20150101'
 -- SET @COUNT=0
 -- WHILE @DAY<='20151231'
 -- BEGIN
 -- SET @COUNT=@COUNT+(
 -- CASE DATEPART(WEEKDAY,@DAY) WHEN 1 THEN 0
 --                             WHEN 7 THEN 0
 --                             ELSE 1
 --END )
 --SET @DAY=DATEADD(DAY,1,@DAY)
 --END
 --SELECT @COUNT