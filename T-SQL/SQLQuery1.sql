use Northwind;

select 
* 
from dbo.Products;



SELECT 
p.ProductName, p.UnitPrice, p.UnitsInStock
from dbo.Products p
where p.UnitPrice < 50
order by p.UnitPrice ASC, p.UnitsInStock DESC
-- ilk where calisti ve buldu uyanlari
-- sonra p.UnitPrice siraladi
-- daha sonra da ayni UnitPrice'a uyanlara UnitsInStock sarti uygulandi


SELECT
   c.CustomerID, 	c.CompanyName, c.Address, c.City, c.Country
FROM Customers c
WHERE c.Country LIKE 'A%'
-- sozel karsilastirma operatoru : LIKE
-- A ile baslayanlari siralamak icin yuzde ifadesi kullanildi

SELECT
   c.CustomerID, c.CompanyName, c.Address, c.City, c.Country
FROM Customers c
WHERE c.Country LIKE '%A'

SELECT 
   e.FirstName, e.LastName, e.Title,  YEAR(GETDATE())- YEAR(e.BirthDate) as Age
FROM Employees e
Order by Age
-- YEAR( GETDATE() ) diyerek bu yili aldik
-- e.BirthDate'in ise sadece yilini aldik
-- as Age diyerek kolon oluşturduk 

SELECT LOWER('BÜYÜK')
SELECT UPPER('küçük')


SELECT 
   e.FirstName + ' ' + UPPER( e.LastName) FullName, e.Title,  YEAR(GETDATE())- YEAR(e.BirthDate) as Age
FROM Employees e
Order by Age, FullName 


SELECT 
 OrderID, CustomerID, Freight, OrderDate
FROM Orders
WHERE OrderDate BETWEEN '1996-07-04' AND '1996-08-01'

SELECT 
 *
FROM Customers 
WHERE CompanyName BETWEEN 'A' AND 'E'
--baslangıc degerini dahil edip bitis degerini dahil etmez


--Almanya'daki veya Italyadaki müşterilerim kim?
SELECT 
   CustomerID, CompanyName, ContactName, Address, City, Country
FROM Customers
WHERE Country = 'Germany' OR Country='Italy' OR Country = 'UK'
Order by Country
--
SELECT 
   CustomerID, CompanyName, ContactName, Address, City, Country
FROM Customers
WHERE Country IN ('Germany','Spain','UK','Italy','France')
Order by Country
-- in ile içindekileri sorgulayabiliriz


-- Fax numarası olmayan müşterilerimi bulun:
SELECT 
  CompanyName, Country, Fax
FROM Customers
WHERE Fax is NULL

-- Satış yaptığımız ülkeler:
SELECT 
  DISTINCT Country
FROM Customers

--Aggregate Functions:,

-- 10248 İD'Lİ siparişte ne kadar ödendi?
SELECT 
   SUM(UnitPrice * (1-Discount) * Quantity) 
FROM [Order Details] WHERE OrderID = 10248

-- UK'da kaç adet müşterim var?
select count(*) as TotalCustomerCount from Customers where country = 'UK'

--MAX, MIN, AVG, 
--Group By:
--SELECT Renk, Count(Pantolon) FROM Gardrop
--GROUP BY Renk
--
-- Hangi ülkede kaç adet müşterim var?
SELECT
    Country, Count(CustomerID) TotalCustomers
FROM Customers
GROUP BY Country
ORDER BY TotalCustomers desc

-- 5'den fazla müşterim olan ülkeler
SELECT
    Country, Count(CustomerID) TotalCustomers
FROM Customers
GROUP BY Country
HAVING Count(CustomerID) >= 5
ORDER BY TotalCustomers desc


-- Hangi Siparişte ne kadar ödendi?
SELECT 
   OrderId,  '$'+CAST(ROUND(SUM(UnitPrice * (1-Discount) * Quantity), 0) AS nvarchar(5))
FROM [Order Details]
GROUP BY OrderID


-- 1000 DOLARDAN Fazla olan siparişler
SELECT 
   OrderId,  '$'+CAST(ROUND(SUM(UnitPrice * (1-Discount) * Quantity), 0) AS nvarchar(5))
FROM [Order Details]
GROUP BY OrderID
HAVING ROUND(SUM(UnitPrice * (1-Discount) * Quantity),0) > 1000 



--1000 dolardan fazla tutan siparişler toplamı ne kadar?

SELECT
    SUM(UnitPrice * (1-Discount) * Quantity)
FROM [Order Details]
HAVING SUM(UnitPrice * (1-Discount) * Quantity)>1000


-- Hangi Siparişte ne kadar ödendi?
SELECT TOP 5 OrderId,  ROUND(SUM(UnitPrice * (1-Discount) * Quantity), 2) as Total
FROM [Order Details]
GROUP BY OrderID
ORDER BY Total Desc 

