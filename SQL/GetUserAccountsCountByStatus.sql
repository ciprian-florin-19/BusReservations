--get how  many users in each age group have accounts
select Status,COUNT(a.UserId) as 'How many'
from dbo.Users u
join dbo.Accounts a on a.UserId=u.Id
group by Status