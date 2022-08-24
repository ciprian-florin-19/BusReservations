--get how many seats of each type were reserved for a route
select Type,Start,Destination,COUNT(Type) as 'How many'
from dbo.Seats as s
join dbo.DrivenRoutes dr on s.DrivenRouteId=dr.Id
group by Type,Start,Destination
order by Type