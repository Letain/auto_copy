create database my_winform_demo;

use my_winform_demo;
create table copy_history(
 `history_id` int not null auto_increment primary key,
 `file_address` varchar(256) not null,
 `record_datetime` datetime not null
)

select * from copy_history;