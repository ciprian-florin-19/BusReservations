--get accounts with admin privileges
select Name,Username,Password,PhoneNumber,Email 
from dbo.Accounts
join dbo.Users u on UserId=u.Id
where HasAdminPrivileges=1
