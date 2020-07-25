;WITH t1 AS
(
	select 
			CONVERT(date, TransactionDate) as [start_day],
			PersonId,
			name,
			family,
			SUM(price) as [_sum]
		from
			_Orders
		inner join 
			_Persions on 
					_Persions.id=_Orders.PersonId
		group by 
				CONVERT(date, TransactionDate),
				PersonId,
				name,
				family
)
SELECT 
	t1.PersonId,
	t1.name			as [Name],
	t1.family		as [Family],
	t1.start_day	as [StartDate] ,
	t3.start_day	as [EndDate],
	t1._sum			as [Sum],
	sum(t2.[_sum])  as Total
	
FROM 
	t1
	inner join t1 as t2  on (t1.start_day>=t2.start_day and t1.PersonId=t2.PersonId) 
	left join t1 as t3 on (t1.start_day<t3.start_day and t1.PersonId=t3.PersonId) 

		group by 
		t1.start_day , t1.PersonId,t1.name ,t1.family,t1._sum,t3.start_day
		order by t1.PersonId
		