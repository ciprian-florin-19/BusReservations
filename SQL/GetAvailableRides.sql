--get available rides for given date and route
select Name as 'Bus Company', Start, Destination, SeatPrice
from dbo.Buses as b,dbo.DrivenRoutes as dr
where b.Capacity> 
(select COUNT(s.DrivenRouteId) from dbo.Seats
join dbo.Seats s on s.DrivenRouteId=dr.Id)
--(select count(Id) 
-- from dbo.Seats as s
-- where s.DrivenRouteId=dr.Id) 
 and
 dr.Start='pitesti' 
 and 
 dr.Destination='sibiu'
 and
 cast(
 (select DepartureDate
 from dbo.TimeTables as tt
 where tt.Id=dr.TimeTableId)
 as DATE)='2022-05-12'
 order by dr.SeatPrice
