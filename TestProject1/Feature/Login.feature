Feature: Log in to Advance page 

@positive
Scenario Outline: Successful Login to Advance flow1
	Given i am on Advance login page
	When i click login button
	And i write email <email>
	
	And i press next button on email page
	And i write password <password> 

	And i press next button on password page
	And i press yes button on question page
	Then i can see <helloUser>

	Examples: 
	| email | password | helloUser |
	|  automation.pp@amdaris.com |  10704-observe-MODERN-products-STRAIGHT-69112 | Hi Automation |

	@positive
Scenario Outline: Successful Login to Advance flow2
	Given i am on Advance login page
	When i click login button
	And i write email <email>
	
	And i press next button on email page
	And i write password <password> 

	And i press next button on password page
	And i press no button on question page
	Then i can see <helloUser>

	Examples: 
	| email | password | helloUser |
	|  automation.pp@amdaris.com |  10704-observe-MODERN-products-STRAIGHT-69112 | Hi Automation |

@negative
Scenario Outline: UnSuccessful Login to Advance with invalid email
	Given i am on Advance login page
	When i click login button
	And i write invalid email '<email>'
	And i press next button on email page	
	Then I Should See Error Message '<errorMessage>' on the email page

Examples: 
 | name          | email         | errorMessage                                             |
 | Invalid email | hello @ . com | Enter a valid email address, phone number or Skype name. |
 | Blank email   |               | Enter a valid email address, phone number or Skype name. |

 @negative
Scenario Outline: UnSuccessful Login to Advance with invalid password
	Given i am on Advance login page
	When i click login button
	And i write email <email>
	
	And i press next button on email page
	And i write invalid password '<password>'
	And i press next button on password page
	Then I Should See Error Message on the password page '<errorMessage>' 

Examples: 
 | name           | email                     | password          | errorMessage                                                                              |
 | Invalid passwd | automation.pp@amdaris.com | aaaaaaaaaaaaaa123 | Your account or password is incorrect. If you can't remember your password, reset it now. |
 | Blank passwd   | automation.pp@amdaris.com |                   | Please enter your password.                                                               |