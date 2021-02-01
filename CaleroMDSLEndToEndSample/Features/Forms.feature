Feature: Forms
	The scenarios below are designed to see how interact with forms using Selenium WebDriver

Scenario: Filling in a Form
	Given that I am viewing the Input Form Demo page
	Then I should be able to complete all the fields on the form and submit it
	 | Fields                 | Values                    |
	 | First Name             | Usha                      |
	 | Last Name              | Shivaram                  |
	 | E-Mail                 | usha@email.com            |
	 | Phone #                | (845)555-1212             |
	 | Address                | 12,Yarling Court          |
	 | City                   | Birmingham                |
	 | State                  | Alabama                   |
	 | Zip Code               | 35242                     |
	 | Website or domain name | https://www.google.co.uk/ |
	 | Do you have hosting?   | Yes                       |
	 | Project Description    | Automation Project        |
	 And I click on Send button


