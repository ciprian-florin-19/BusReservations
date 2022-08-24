--get user reservations
--get how many times he travelled on a route
--order in descending order

select Name,Start,Destination,Type,SeatNumber,FinalSeatPrice,
COUNT(dbo.Seats.Id) as 'times travelled' 
from dbo.Users,dbo.Reservations,dbo.DrivenRoutes,dbo.Seats,dbo.TimeTables
group by Name,Start,Destination,Type,SeatNumber,FinalSeatPrice
order by 'times travelled' desc
