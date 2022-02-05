CREATE TABLE Drivers
(
    id integer,
    firstName CHARACTER VARYING(50),
    lastName CHARACTER VARYING(50),
    country CHARACTER VARYING(50),
    dateOfBirth timestamp,
    placeOfBirth CHARACTER VARYING(50),
    team CHARACTER VARYING(50),
    numberOfPodiums integer,
    firstSeason integer,
    note CHARACTER VARYING(200)
);