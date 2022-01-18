use pubs

-- 1) Select all the author's details
SELECT * FROM authors

-- 2) Print all the author's full name
SELECT CONCAT(au_fname,' ', au_lname) 'Author Full Name' FROM authors
ORDER BY 1

-- 3) Print the average price , total price of all the titles
SELECT AVG(price) 'Average Price', SUM(price) 'Total Price' FROM titles

-- 4) Print the average price of a titles published by '0736'
SELECT pub_id 'Publisher ID', AVG(price) 'Average Price' FROM titles
WHERE pub_id = '0736'
GROUP BY pub_id

-- 5) Print the titles which have advance min of 3200 and maximum of 5000
SELECT title 'Title', advance 'Advance'FROM titles
WHERE advance > 3200 AND advance < 5000

-- 6) Print the titles which are of type 'psychology' or 'mod_cook'
SELECT title 'Title', type 'Type' FROM titles
WHERE type = 'psychology' OR type = 'mod_cook'

-- 7) Print all titles published before '1991-06-09 00:00:00.000'
SELECT title 'Title', pubdate 'Publish Date' FROM titles
WHERE pubdate < '1991-06-09 00:00:00.000'

-- 8) Select all the authors from 'CA'
SELECT * FROM authors
WHERE state = 'CA'

-- 9) Print the average price of titles in every type
SELECT type 'Type', AVG(price) 'Average Price' FROM titles
GROUP BY type

-- 10) Print the sum of price of all the books pulished by every publisher
SELECT pub_id 'Publisher ID', SUM(price) 'Total Price' FROM titles
GROUP BY pub_id

-- 11) Print the first published title in every type --edit just the type and first pub date
SELECT type 'Type', MIN(pubdate) 'Published Date' FROM titles
GROUP BY type

-- 12) Calculate the total royalty for every publisher
SELECT P.pub_id 'Publisher ID', SUM(royalty) 'Total Royalty' 
FROM titles T RIGHT OUTER JOIN publishers P
ON T.pub_id = P.pub_id
GROUP BY P.pub_id

-- 13) Print the titles sorted by published date
SELECT title 'Title', pubdate 'Publised Date' FROM titles
ORDER BY pubdate

-- 14) Print the titles sorted by publisher then by price
SELECT title 'Title', pub_id 'Publisher ID', price 'Price' FROM titles
ORDER BY pub_id, price

-- 15) Print the books published by authors from 'CA'
SELECT DISTINCT T.title 'Title' 
FROM titles T JOIN titleauthor TA
ON T.title_id =  TA.title_id
JOIN authors A ON A.au_id = TA.au_id
WHERE state = 'CA'
ORDER BY 1

-- 16) Print the author name of books which have royalty more than the average royalty of all the titles
SELECT CONCAT(A.au_fname, ' ', A.au_lname) 'Author Full Name' 
FROM titles T JOIN titleauthor TA
ON T.title_id =  TA.title_id
JOIN authors A ON A.au_id = TA.au_id
WHERE royalty > (SELECT AVG(royalty) FROM titles)
ORDER BY 1

-- 17) Print all the city and the number of pulishers in it, only if the city has more than one publisher
SELECT city 'City', COUNT(DISTINCT pub_id) 'No. of Publisher' FROM publishers
GROUP BY city
HAVING COUNT(DISTINCT pub_id) > 1 
--no result

-- 18) Print the total number of orders for every title
SELECT title_id 'Title ID', COUNT(title_id) 'Total number of orders' FROM sales
GROUP BY title_id

-- 19) Print the total number of titles in every order
SELECT ord_num 'Order No.', COUNT(title_id) 'Total Titles' FROM sales
GROUP BY ord_num

-- 20) Print the order date and the title name
SELECT T.title 'Title Name', S.ord_date 'Order Date' 
FROM sales S JOIN titles T
ON S.title_id = T.title_id
ORDER BY 2

-- 21) Print all the title names and publisher names
SELECT T.title 'Title Name', P.pub_name 'Publisher Name' 
FROM titles T JOIN publishers P
ON T.pub_id = P.pub_id

-- 22) print all the publisher names(even if they have not published) and the title names that they have published
SELECT P.pub_name 'Publisher Name', T.title 'Title Name'
FROM titles T RIGHT OUTER JOIN publishers P
ON T.pub_id = P.pub_id

-- 23) print the title id and the numebr of authors contributing to it
SELECT title_id 'Title ID', COUNT(DISTINCT au_id) 'No. of Author' FROM titleauthor
GROUP BY title_id
ORDER BY 1

-- 24) Print the title name and the author name
SELECT T.title 'Title Name', CONCAT(A.au_fname, ' ', A.au_lname) 'Author Name'
FROM titles T JOIN titleauthor TA
ON T.title_id = TA.title_id
JOIN authors A ON A.au_id = TA.au_id
ORDER BY T.title

-- 25) print the title name, author name and the publisher name
SELECT T.title 'Title Name', CONCAT(A.au_fname, ' ', A.au_lname) 'Author Name', P.pub_name 'Publisher Name' 
FROM authors A JOIN titleauthor TA
ON A.au_id = TA.au_id
JOIN titles T ON T.title_id = TA.title_id
JOIN publishers P ON P.pub_id = T.pub_id
ORDER BY 1

-- 26) print the title name, author name, publisher name, orderid, order date, quantity ordered and the total price
SELECT T.title 'Title Name', CONCAT(A.au_fname, ' ', A.au_lname) 'Author Name', P.pub_name 'Publisher Name',
S.ord_num 'Order ID', S.ord_date 'Order Date', S.qty 'Quanitity Ordered', S.qty*T.price 'Total Price'
FROM authors A JOIN titleauthor TA
ON A.au_id = TA.au_id
JOIN titles T ON T.title_id = TA.title_id
JOIN publishers P ON P.pub_id = T.pub_id
JOIN sales S ON S.title_id = T.title_id
ORDER BY 1

-- 27) given a title name print the stores in which it was sold
SELECT T.title 'Title Name', SR.stor_name 'Store Name'
FROM titles T JOIN sales SS
ON T.title_id = SS.title_id
JOIN stores SR ON SR.stor_id = SS.stor_id
WHERE title = 'But Is It User Friendly?'

-- 28) Select the stores who have taken more than 2 orders
SELECT stor_id 'Store ID', COUNT(stor_id) 'Total Order'
FROM sales
GROUP BY stor_id
HAVING COUNT(stor_id) > 2

-- 29) Select all the titles and print the first order date (titles that have not be ordered should also be present)
SELECT T.title_id 'Title ID', MIN(S.ord_date)
FROM titles T LEFT OUTER JOIN sales S
ON T.title_id = S.title_id
GROUP BY T.title_id

-- 30) select all the data from the orders and the authors table
SELECT * FROM sales, authors






