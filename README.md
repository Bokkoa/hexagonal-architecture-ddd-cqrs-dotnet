# C# Language Training

This is a courses compilation that im doing  while im study.
The original concepts, authors or ideas gonna be pointed in the next source list:

- Arquitetura Hexagonal com DDD Tático em C# / Uai Bora Tech

you can check it here -> [https://www.udemy.com/course/arquitetura-hexagonal-com-ddd-tatico-em-c/](https://www.udemy.com/course/arquitetura-hexagonal-com-ddd-tatico-em-c/)


## Aggregations

* Account
	* Commands:
		* Create account
		* Add Address
		* Register Transaction
	* Queries:
		* Consult balance
		* List transactions

* Budget
	* Commands:
		* Register Budget
		* Add Category
		* Update total limit
	* Queries:
		* Get total expenses
		* List categories
		* Get expenses by category