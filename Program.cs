using ConsoleApp13;

Bank bank = new Bank();
var parent = bank.CreateDir();
bank.CreateGrades(parent);
bank.CreateUsers(parent);