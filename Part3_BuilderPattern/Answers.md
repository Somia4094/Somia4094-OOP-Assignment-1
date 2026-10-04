# Task 3.1 — Why Are 20-Parameter Constructors a Problem?

## 1. Why is a single 20-parameter constructor a problem in practice?

A constructor with around 20 parameters is difficult to read and maintain. At the call site, it is hard to know what each argument represents, especially when several parameters have the same type, such as multiple strings or decimal amounts.

This increases the risk of passing values in the wrong order without getting a compile-time error. For example, two decimal values such as SubTotal and TaxAmount could accidentally be swapped, or two string values representing different address fields could be passed in the wrong order.

It also becomes harder to maintain when a new optional property is added. The constructor must be changed, and existing calls may need to be updated, making the code more difficult to understand and maintain.

## 2. Is this purely a "constructor is too long" problem?

No. There is also a deeper design issue.

The class contains several groups of related information, such as billing address, shipping address, and order/payment information. Putting all of these loosely related properties into one class increases its complexity and gives one class too many responsibilities.

A better design is to group related data into smaller components and use composition. This makes the design easier to understand, validate, reuse, and maintain.

# Task 3.3 — Why Is the Composed Builder Better?

The composed version is better because it separates the responsibilities of constructing the different parts of the invoice.

## Single Responsibility

`AddressBuilder` is responsible only for creating and validating an address.

`OrderBuilder` is responsible only for creating and validating order and payment information.

The main invoice builder is responsible for combining these parts into the final invoice.

This keeps each builder focused on one responsibility.

## Independent Validation

`AddressBuilder` can validate the address fields by itself. For example, it can make sure that required fields such as street, city, and zip code are provided.

The parent invoice object does not need to know the individual validation rules for every address field.

## Reuse

The same `AddressBuilder` can be used for both the billing address and the shipping address.

Without this approach, the construction and validation logic for billing and shipping addresses could be duplicated, which would make future changes harder and increase the chance of inconsistent behavior.

## Readability at the Call Site

The composed builder makes the construction process easier to understand because the data is organized according to its purpose.

Instead of passing many unrelated values to one large builder, the caller can clearly see separate sections for:

* Billing address
* Shipping address
* Order and payment information

This makes the code more readable and easier to maintain.
