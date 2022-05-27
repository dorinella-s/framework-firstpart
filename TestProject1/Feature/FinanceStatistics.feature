Feature: FinanceStatistics
@positive
Scenario: Acces Finance Statistics page
	Given i am logged into Advance
	And i am on Advance home page
	When i click Finance button
	Then i should see 'Statistics' tab


	
Scenario Outline: Add Actuals on Statistic page
	Given i am logged into Advance
	And i am on Advance home page
	When i click Finance button
	And i click Statistics tab
	And i click Add Actual button
	And i choose year and month
	And i write average <average rate>
	And i write revenue <revenue>
	And i click Save button
	Then i sould see confirmation popup with <popUptext>

	Examples: 
	| average rate | revenue | popUptext                               |
	| 12           | 1       | Actuals have successfully been created. |
