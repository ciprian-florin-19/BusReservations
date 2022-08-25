begin try
	begin transaction

	insert into dbo.Buses(Id,Name,Capacity) 
	values('05d171ab-d74a-47a9-9d18-e6f47e3cbef7','Vasile Transports',22)
	insert into dbo.Users(Id,Name,PhoneNumber,Email,Status) 
	values('b5138469-2986-4e89-8b07-b3e260190351','Ion Vasile','0712345678','ivasile@gmail.com',0)
	insert into dbo.DrivenRoutes(Id,Start,Destination,SeatPrice,TimeTableId)
	values ('b756eb27-4d42-4c1c-9ed5-24e138d23255','Pitesti','Sibiu',60,'7DAFCCF5-BE53-4341-8E12-5FB450BB5B42')
	delete from dbo.Reservations where Id='101B02B4-A9E4-4294-9BBC-26920E227300' 
	delete from dbo.Accounts where Id='EC2951F9-A848-4EE4-AB89-7F3DF5CEA3D6'
	delete from dbo.DrivenRoutes where Id='Fail transaction on purpose'
	commit transaction
end try

begin catch
	select ERROR_MESSAGE() as ErrorMessage;
	rollback transaction
end catch