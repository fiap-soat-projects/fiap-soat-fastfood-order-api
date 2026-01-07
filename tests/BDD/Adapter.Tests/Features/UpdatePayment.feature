Feature: Update Payment

@tagUpdateValid
Scenario: Update payment with valid request
        Given an order id "order-pay-1"
        And a payment request with method "Pix" and status "Authorized"
        When I update the payment
        Then the use case should be called once
  
@tagUpdateInvalidStatus
Scenario: Update payment with invalid payment status
    Given an order id "order-pay-2"
    And a payment request with method "Pix" and status "InvalidStatus"
    When I update the payment
    Then an InvalidPaymentStatusException should be thrown
    And the use case should not be called

@tagUpdateInvalidMethod
Scenario: Update payment with invalid payment method
    Given an order id "order-pay-3"
    And a payment request with method "InvalidMethod" and status "Authorized"
    When I update the payment
    Then an InvalidPaymentMethodException should be thrown
    And the use case should not be called


