Feature: Login
	Log in to Advance page 

@positive
Scenario Outline: Login to Advace positive flow
	Given i am on Advance login page
	When i click login button
	And i write email <email>
	
	And i press next button on email page
	And i write password <password> 

	And i press next button on password page
	And i press next button on question page
	Then i can see <helloUser>

	Examples: 
	| email | password | helloUser |
	|  automation.pp@amdaris.com |  10704-observe-MODERN-products-STRAIGHT-69112 | Hi Automation |
