--get how many buses with more than 5 seats run on a route
select Name as 'Company Name',Capacity,Start,Destination,count(Buses.Id) as 'How many'
from dbo.Buses,dbo.DrivenRoutes
where Capacity>5
group by Name,Capacity,Start,Destination
order by Capacity desc