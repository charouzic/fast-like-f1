INSERT INTO Drivers VALUES
                           -- UGLY HARDCODED VALUES
           (3,'Daniel','Ricardo','Australia','01/07/1989'::date,'Perth, Australia','McLaren',32,2012,'The Honey Badger'),
           (44,'Lewis','Hamilton','United Kingdom','01/07/1985'::date,'Stevenage, England','Mercedes',182,2007,'Still I Rise'),
           (63,'George','Russell','United Kingdom','02/15/1998'::date,'King,s Lynn, England','Mercedes',1,2019,'If in doubt, go flat out'),
           (33,'Max','Verstappen','Netherlands','09/30/1997'::date,'Hasselt, Belgium','Red Bull Racing',60,2014,'Max by name, max by nature'),
           (11,'Sergio','Perez','Mexico','01/26/1990'::date,'Guadalajara, Mexico','Red Bull Racing',15,2011,'Fighter with a gentle touch'),
           (16,'Charles','Leclerc','Monaco','10/16/1997'::date,'Monte Carlo, Monaco','Ferrari',13,2016,'Meditarian on the mission'),
           (55,'Carlos','Sainz','Spain','09/01/1994'::date,'Madrid, Spain','Ferrari',6,2015,'Matador from madrid'),
           (4,'Lando','Norris','United Kingdom','11/13/1999'::date,'Bristol, England','McLaren',5,2019,'May the downforce be with us'),
           (31,'Esteban','Ocon','France','09/17/1996'::date,'Evereux, Normandy','Alpine',2,2017,'The boy with sacrifice'),
           (14,'Fernando','Alonso','Spain','07/29/1981'::date,'Oviedo, Spain','Alpine',98,2001,'9/10 in evertyhing'),
           (10,'Pierre','Gasly','France','02/07/1996'::date,'Rouen, France','AlphaTauri',3,2017,'Rollercoaster guy'),
           (22,'Yuki','Tsunoda','Japan','05/11/2000'::date,'Sagamihara, Japan','AlphaTauri',0,2021,'Could he be the first Japanese to win F1?'),
           (18,'Lance','Stroll','Canada','10/29/1998'::date,'Montreal, Canada','Aston Martin',3,2017,'The kid comming from money'),
           (5,'Sebastian','Vettel','Germany','07/03/1987'::date,'Heppenheim, Germany','Aston Martin',122,2006,'The one flirting with reporters'),
           (23,'Alexander','Albon','Thailand','03/23/1996'::date,'London, England','Williams',2,2019,'First word in italian'),
           (6,'Nicholas','Latifi','Canada','06/29/1995'::date,'Montreal, Canada','Williams',0,2020,'Started racing at the age 13 which is pretty late'),
           (77,'Valtteri','Bottas','Finland','08/28/1989'::date,'Nastola, Finland','Alfa Romeo',67,2013,'Learned the craft on icy finish roads'),
           (24,'Guanyu','Zhou','China','05/30/1999'::date,'Shanghai, China','Alfa Romeo',0,2022,'Feels like first chineese F1 driver'),
           (47,'Mick','Schumacher','Germany','03/23/1999'::date,'Vufflens-le-Chateau, Switzerland','Haas F1 Team',0,2021,'Son of the famous driver'),
           (9,'Nikita','Mazepin','Russia','03/02/1999'::date,'Moscow, Russia','Haas F1 Team',0,2021,'He can barely finish one lap')
                           
-- cannot copy as the application does not have the rights (probably) ==> TO BE FIXED
--COPY Drivers(id, firstName, lastName, country, dateOfBirth, placeOfBirth, team, numberOfPodiums, firstSeason, note)
--    FROM 'Users/viki/Desktop/projects_programming/fast-like-f1/src/data/drivers.csv'
--    DELIMITER ','
--    CSV HEADER;