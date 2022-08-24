--get the average price for a route depending on company
select Name as 'Company Name',Start,Destination,AVG(SeatPrice) as 'Average Seat Price'
from dbo.Buses,dbo.DrivenRoutes
group by Name,Start,Destination
order by 'Average Seat Price' 