Feature: RepeatingInvoice

#---------------------------- Basic Flows ------------------------------

@BVT
@Sales
Scenario: Basic Flow - Page Load Verification
	Given I login to the system
	When I navigate to Repeating Invoice Page
	Then I should see Repeating Invoice page with correct content

@BVT
@Sales
Scenario: Basic Flow - Successful Repeating Invoice
	Given I'm on Repeating Invoice Page
	When I place a successfull Repeating Invoice
	Then I should see the confirmation message

#---------------------------- Exception Flows ------------------------------

@Exception
@SmokePack
@Sales
Scenario Outline: Exception Flow - Repeating invoice without an Item
	Given I'm on Repeating Invoice Page
	When I place a Repeating Invoice without '<MissingItem>'
	Then I should see the '<ErrorMessage>' message

Examples: 
| MissingItem  | ErrorMessage                                           |
| DueDate      | Due Date cannot be empty                               |
| ActionStatus | Please select how you wish this invoice to be treated. |
| InvoiceTo    | Invoice to cannot be empty.                            |
| Item         | Description cannot be empty.                           |
