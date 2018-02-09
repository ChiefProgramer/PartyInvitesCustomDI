/* Use this file to initialize the MySql db locally for PartyInvitesCustom app
/* it includes some seed data to get the app running
*/

/* START: make sure db connection info matches the connection info in the project
*/

/* To create the user and grant all permissions on the deb if it doesnt already exist */

CREATE USER IF NOT EXISTS 'partyinvitesuser'@'localhost' IDENTIFIED BY 'K:Qe?&DnE^/8^6t+';
#GRANT ALL PRIVILIGES ON PartyInvites.* TO 'partyinvitesuser'@'localhost' WITH GRANT OPTION;
GRANT ALL ON PartyInvites.* TO 'partyinvitesuser'@'localhost' WITH GRANT OPTION;

/* To create the db if it doesn't already exist */

CREATE DATABASE IF NOT EXISTS PartyInvitesDb;

/* END: make sure db connection info matches the connection info in the project
*/

/* Create the table and stick in some seed data if it's not already there
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

INSERT INTO InvitationResponses (Name, Email, Phone, WillAttend) VALUES
	('Paris Hilton', 'parishilton@gmail.com', '555-555-5555', true),
    ('John Mcafee', 'johnmcafee@gmail.com', '555-555-5555', true),
    ('George W Bush', 'w@gmail.com', '555-555-5555', false),
    ('Bill Clinton', 'bill@gmail.com', '555-555-5555', true);
    





