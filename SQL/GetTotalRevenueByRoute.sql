--get total revenue from route
select Name,Start,Destination,SUM(FinalSeatPrice) as 'Total revenue'
from dbo.Buses,dbo.Reservations,dbo.DrivenRoutes
group by Name,Start,Destination