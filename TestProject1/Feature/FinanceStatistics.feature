
Feature: Finance Page, Statistics category

Background: Loging In and going to the Finance page, Statistics category
    Given i am Logged in and i am on Finance page on Statistics category

@AddActuals	
Scenario Outline: Add Actuals on Statistic page
	When i click Add Actual button
	And i choose year '<year>' and '<month>' month 
	And i write average <average rate>
	And i write revenue <revenue>
	And i click Save button
	Then i sould see confirmation popup with <popUptext>

	Examples: 
	| year | month | average rate | revenue | popUptext                               |
	| 2026 | MAY   | 15           | 1       | Actuals have successfully been created. |
	| 2026 | OCT   | 12.3         | 13.6    | Actuals have successfully been created. |
	| 2026 | NOV   | 0000000      | -23     | Actuals have successfully been created. |
	
@EditActuals
Scenario Outline: Edit a specific Actuals on Statistic page
	When i click Edit button on existing actuals item '<info>' <id>
	And i choose year '<year>' and '<month>' month 
	And i write average <average rate>
	And i write revenue <revenue>
	And i click Save button
	Then i sould see confirmation popup with <popUptext>

	Examples:
	| info     | id | year | month | average rate | revenue | popUptext                               |
	| Mar 2019 | 1  | 2020 | MAY   | 13           | 2       | Actuals have successfully been updated. |


@DeleteActuals
Scenario Outline: Delete a specific Actuals on Statistic page flow1
	When i click Delete button on existing actuals item '<info>' <id>
	And i click yes button on '<question>' window 
	Then i sould see confirmation popup with <popUptext>

	Examples:
	| info     | id | question                                          | popUptext                               |
	| May 2026 | 8  | Are you sure you want to delete this information? | Actuals have successfully been deleted. |

@DeleteActuals
Scenario Outline: Delete a specific Actuals on Statistic page flow2
	When i click Delete button on existing actuals item '<info>' <id>
	And i click no button on '<question>' window 
	Then i sould see the specific '<info>' Actuals on Statistic page

	Examples:
	| info     | id | question                                          |
	| Jan 2020 | 1  | Are you sure you want to delete this information? |

@AddActualsWithInvalidData
Scenario Outline: UnSuccessful Add Actuals on Statistic page
	When i click Add Actual button
	And i choose year '<year>' and '<month>' month 
	And i write average <average rate>
	And i write revenue <revenue>
	Then i sould see error message '<errorMessage>'

Examples: 
 | test                    | year | month | average rate | revenue | errorMessage                     |
 | Average Invalid format  | 2026 | OCT   | 15,4         | 1       | Invalid format                   |
 | Average Invalid format  | 2026 | OCT   | aSd          | 1       | Invalid format                   |
 | Average Negative number | 2026 | OCT   | -20          | 1       | Average value cannot be negative |
 | Average Empty field     | 2026 | OCT   |              | 1       | This field is required           |
 | Revenue Invalid format  | 2026 | OCT   | 15.4         | 1,5     | Invalid format                   |
 | Revenue Invalid format  | 2026 | OCT   | 15.4         | @-!     | Invalid format                   |
 
 