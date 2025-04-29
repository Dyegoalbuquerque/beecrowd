# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The following test must be delivered within 5 calendar days from the date this document is received.**

- The code must be versioned in a public **GitHub** repository, and the link must be sent for evaluation upon completion.
- Upload this template to your repository and start working from it.
- Ensure all requirements are addressed by reading the instructions thoroughly.
- Documentation and overall organization will be considered during the evaluation.

---

## Use Case
**You are a developer on the DeveloperStore team. The goal is to implement API prototypes for managing sales records.**

The project follows `DDD` (Domain-Driven Design) principles. To reference entities from other domains, we utilize the **External Identities** pattern with entity description denormalization.

You will develop an API (complete CRUD) to manage sales records. The API must provide the following functionalities:

- Sale number
- Date of the sale
- Customer information
- Total sale amount (including applied taxes)
- Branch where the sale occurred
- Products
- Quantities
- Unit prices
- Tax value applied
- Total amount for each item
- Sale status: Cancelled or Not Cancelled

### Bonus Features (Optional)
It is not mandatory, but implementing code to publish events would be a plus:
- **SaleCreated**
- **SaleCancelled**
- **ProductCreated**

The events do not need to be published to a **Message Broker**. Logging them in the application is sufficient if you decide to implement this.

---

## Business Rules
The following business rules define tax application and quantity-based limitations for sales:

1. **Tax Tiers**:
   - Purchases **below 4 identical items** have **no tax**.
   - Purchases **from 4 to 9 identical items** apply **IVA TAX (10%)**.
   - Purchases **from 10 to 20 identical items** apply **SPECIAL IVA TAX (20%)**.
   - It is **not allowed** to sell more than 20 identical items.

---

## Overview
This section provides a high-level overview of the project and assesses key skills for developer candidates.

[See Overview](/.doc/overview.md)

---

## Configuration Project
This section includes links to the detailed documentation for configuration of project:
- [Configuration project](/.doc/configuration-project.md)

---

## Tech Stack
This section highlights the key technologies used in the project, including backend, testing, frontend, and database components.

[See Tech Stack](/.doc/tech-stack.md)

---

## Frameworks
This section outlines the frameworks and libraries utilized to enhance development productivity and maintainability.

[See Frameworks](/.doc/frameworks.md)

---

## Mandatory Endpoints
The following endpoints must be implemented with the specified names and paths:

| HTTP Method | Path             | Description                                    |
|-------------|------------------|------------------------------------------------|
| `GET`       | `/products`      | List products.                                 |
| `POST`      | `/products`      | Create a new product.                          |
| `GET`       | `/sales`         | List sales.                                    |
| `POST`      | `/sales`         | Create a new sale with applied tax rules.      |
| `PATCH`    | `/sales/{id}`    | Cancel a sale based on its ID.                 |

- **Base URL**: `http://ocelot-gateway:7777/`

### Standardized Response Format
All API responses should follow this structure:
```json
{
  "data": [{}],
  "status": "success",
  "message": "Operation completed successfully."
}
