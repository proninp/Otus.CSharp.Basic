select c.ID CustomerID
       , c.FirstName
       , c.LastName
       , p.ID ProductID
       , o.Quantity ProductQuantity
       , p.Price ProductPrice
from Orders o
join Customers c on o.CustomerID = c.ID
join Products p on o.ProductID = p.ID
where o.ID = 1 and c.Age > 30;