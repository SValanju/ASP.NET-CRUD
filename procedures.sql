/*View all data proedure:

create proc viewAllData
as begin
select * from Products
end

*/



/* delete data procedure: 

create proc deleteData
@ID int
as begin
delete from Products where ID=@ID
end

*/


/* view specific data procedure:

create proc viewData
@ID int
as begin
select * from Products where ID=@ID
end



*/