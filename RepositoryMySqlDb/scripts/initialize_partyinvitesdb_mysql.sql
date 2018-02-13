/* Use this file to initialize the MySql db locally for PartyInvitesCustom app, since it's creating a user and a db you'll have to run it
/* from a user that has all privileges on your system, usually 'root' unless you have set up a different one on top of that
/* it should create the user 'partyinvitesuser', create the db 'partyinvitesdb', create the table 'invitationresponses' and then
/* insert some dummy data to test with. 
*/

/* START: make sure db connection info matches the connection info in the project
*/

/* To create the user and grant all permissions on the db if it doesnt already exist */

CREATE USER IF NOT EXISTS 'partyinvitesuser'@'localhost' IDENTIFIED BY 'Password1234!';
GRANT ALL ON partyinvitesdb.* TO 'partyinvitesuser'@'localhost' WITH GRANT OPTION;

/* To create the db if it doesn't already exist */

CREATE DATABASE IF NOT EXISTS partyinvitesdb;

/* Create invitationresponses table if it doesn't already exist
*/
USE PartyInvitesDb;

DROP TABLE IF EXISTS InvitationResponses;
CREATE TABLE IF NOT EXISTS InvitationResponses
(
		id INT UNSIGNED NOT NULL AUTO_INCREMENT,
		Name VARCHAR(50) NOT NULL,
        Email VARCHAR(100) NOT NULL,
        Phone VARCHAR(12) NOT NULL,
        WillAttend Boolean NOT NULL,
        PRIMARY KEY (id) 
)ENGINE=InnoDB;

/* insert some dummy data to test with
*/
INSERT INTO InvitationResponses (Name, Email, Phone, WillAttend) VALUES
	('Paris Hilton', 'parishilton@gmail.com', '555-555-5555', true),
    ('John Mcafee', 'johnmcafee@gmail.com', '555-555-5555', true),
    ('George W Bush', 'w@gmail.com', '555-555-5555', false),
    ('Bill Clinton', 'bill@gmail.com', '555-555-5555', true);
    





