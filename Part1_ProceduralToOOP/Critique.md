# Critique – Procedural Order System

## 1. Global State

The original program stores customers, products, and orders in global arrays and uses global counters.

For example:

* `customerIds`
* `customerNames`
* `customerEmails`
* `productIds`
* `productNames`
* `orderIds`
* `orderIsPaid`

This makes the program difficult to maintain because data is separated across multiple arrays.

### OOP Improvement

The refactored version groups related data into classes:

* `Customer`
* `Product`
* `Order`
* `OrderLine`
* `OrderSystem`

Each object represents a real entity in the system.

---

## 2. Data and Behavior Are Separated

In the procedural version, data is stored in global arrays while functions operate on that data.

For example, `addCustomer()` modifies several customer arrays at the same time.

### OOP Improvement

The OOP version combines data and related behavior.

For example, `Product` contains its stock and provides the `ReduceStock()` method to safely modify it.

`Order` contains its order lines and provides methods such as:

* `AddLine()`
* `MarkAsPaid()`
* `CalculateTotal()`

---

## 3. Weak Encapsulation

The original program allows global data to be accessed directly by many functions.

This increases the risk of invalid state.

For example, stock can be modified directly through the global `productStock` array.

### OOP Improvement

The refactored version uses encapsulation.

For example:

```csharp
public int Stock { get; private set; }
```

Other parts of the program can read the stock, but they cannot directly change it.

Stock changes through the controlled `ReduceStock()` method.

---

## 4. Parallel Arrays

The original program uses multiple arrays to represent one customer or product.

For example:

```text
customerIds[]
customerNames[]
customerEmails[]
customerCities[]
customerIsVip[]
```

The same index must always refer to the same customer.

This makes the code harder to understand and maintain.

### OOP Improvement

Each customer is represented by one `Customer` object:

```text
Customer
├── Id
├── Name
├── Email
├── City
└── IsVip
```

The same idea is applied to products and orders.

---

## 5. Fixed Array Limits

The procedural version uses constants such as:

```text
MAX_CUSTOMERS = 50
MAX_PRODUCTS = 50
MAX_ORDERS = 100
```

This limits the amount of data that can be stored.

### OOP Improvement

The refactored version uses `List<T>` collections for customers, products, and orders.

The system still keeps business limits where required, but the data structure is more flexible and easier to manage.

---

## 6. Responsibility

In the procedural version, many functions operate on shared global state.

This makes responsibilities less clear.

### OOP Improvement

Responsibilities are divided between classes.

* `Customer` represents customer information.
* `Product` manages product information and stock.
* `OrderLine` represents a product and quantity inside an order.
* `Order` manages order state, lines, payment, and total calculation.
* `OrderSystem` manages the collections and coordinates operations.

This makes the design easier to understand, test, and extend.

---

## 7. Conclusion

The original program works, but its procedural design relies heavily on global state, parallel arrays, and functions that directly manipulate shared data.

The OOP refactoring improves the design by using classes, objects, encapsulation, properties, methods, and collections.

The new design keeps related data and behavior together and makes the system easier to maintain and extend.
