--get company seat price range across all routes
select Name as 'Company Name',
MIN(SeatPrice) as 'Smallest Seat Price',
MAX(SeatPrice) as 'Biggest Seat Price'
from dbo.Buses,dbo.DrivenRoutes
group by Name
order by AVG(SeatPrice)