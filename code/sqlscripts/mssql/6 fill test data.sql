INSERT INTO Cities(id, name) VALUES
(1, 'Moscow'),
(2, 'Saint-Peterburg'),
(3, 'Yaroslavl')

INSERT INTO Streets(id, name, city_id) VALUES
(1, 'Puskin st', 1),
(2, 'Lomonosov st', 1),
(3, 'Lenin st', 2),
(4, 'Lermontov st', 2),
(5, 'Chkalova st', 3)

INSERT INTO Houses(id, number, street_id) VALUES
(1, '1', 1),
(2, '2', 1),
(3, '1', 2),
(4, '1', 3),
(5, '2', 3),
(6, '1', 4),
(7, '2', 4),
(8, '1', 5)

INSERT INTO Apartments(id, area, house_id) VALUES
(1, 20.50, 1),
(2, 18.90, 2),
(3, 15.05, 3),
(4, 18.10, 4),
(5, 13.45, 5),
(6, 10.50, 6),
(7, 20.60, 7),
(8, 30.60, 8)
