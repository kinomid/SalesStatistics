declare @RawSalesData table (Channel NVARCHAR(50), ProductId NVARCHAR(50), CustomerId NVARCHAR(50), ShipDate DATE, Amount NUMERIC(28, 12))

insert @RawSalesData values ('Channel1', 'Product1', 'Customer1' , '2018-03-01', 1), ('Channel1', 'Product2', 'Customer1' , '2018-04-01', 2), ('Channel2', 'Product2', 'Customer1' , '2018-04-01', 4),
 ('Channel3', 'Product2', 'Customer2' , '2018-04-01', 4), ('Channel4', 'Product2', 'Customer2' , '2018-05-01', 5), ('Channel5', 'Product3', 'Customer3' , '2018-04-01', 5)  

 --исходные данные
select * from @RawSalesData

; with SumAmount as
(select Channel, CustomerId
,sum (Amount) sumam   
from @RawSalesData 
group by Channel, CustomerId)

--обновляем для клиента канал сбыта на канал с максимальным объемом для этого клиента 
update rsd
set rsd.Channel = sa.Channel 
from @RawSalesData rsd
join (select Channel, Customerid, sumam  
,row_number() over (partition by customerid order by sumam desc) rn
from SumAmount) sa on rsd.CustomerId = sa.CustomerId and sa.rn = 1

--данные после изменения
select * from @RawSalesData




 
