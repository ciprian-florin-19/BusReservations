--get how many users of each type exist (regular, student, elderly)
select Status,COUNT(Id) as 'How many'
from dbo.Users
group by Status
order by 'How many' desc