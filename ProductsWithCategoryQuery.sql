SELECT Products.Name AS ProductName, Categories.Name AS CategoryName FROM Products LEFT JOIN ProductCategories ON ProductCategories.ProductId = Products.Id
LEFT JOIN Categories ON ProductCategories.CategoryId = Categories.Id
ORDER BY ProductName