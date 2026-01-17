Functional Requirements
These are the core features the system must perform to meet the user's needs. Based on the challenge, here are the key ones:

Add New Products: The system must allow users to input a product name, price (as a decimal), and initial stock quantity (as an integer). It should validate inputs (e.g., price > 0, quantity >= 0) and store the product uniquely (e.g., by name or ID).

Update Stock Levels: Users must be able to increase or decrease stock for existing products (e.g., for sales or restocking). This includes selecting a product, specifying the change amount, and ensuring stock doesn't go negative.

View All Products: The system must display a list of all products, including their name, price, and current stock quantity. If no products exist, it should show a clear message.

Remove Products: Users must be able to delete a product from the inventory by selecting it (e.g., by name). This should confirm the action to prevent accidental deletions.

User Interface (Console-Based): The application must run in a console/terminal, presenting a menu for users to choose actions (e.g., numbered options like "1. Add Product"). It should handle invalid inputs gracefully (e.g., non-numeric entries) and loop until the user chooses to exit.

Data Persistence: Products and their data must be stored temporarily during the session (e.g., in memory using a list or dictionary). For simplicity, no database is required yet—focus on in-memory storage.


Non-Functional Requirements
These describe how the system should perform, rather than what it does. For a small console app like this:

Usability: The interface must be simple and intuitive, with clear prompts and error messages in English. Response time for actions should be near-instant (under 1 second).

Reliability: The app should not crash on invalid inputs (e.g., handle exceptions for parsing numbers). It must maintain data integrity (e.g., no duplicate products by name).

Performance: Handle at least 100 products without noticeable slowdowns, as this is a small-scale system.

Portability: Must run on Windows (your OS), using .NET (likely .NET 6+ or .NET Core for C# console apps). No external dependencies beyond standard libraries.

Security: Basic input validation to prevent issues like negative prices, but no advanced security (e.g., no user authentication) since it's a local console app.

Maintainability: Code should be well-structured (e.g., using classes for Product and InventoryManager) for easy future updates.


Project Objectives
These are the specific, measurable results you aim to achieve by the end of the project. They align with the challenge and help guide development:

Deliver a Working Console App: Create a fully functional C# console application that implements all functional requirements, allowing users to manage inventory interactively.

Demonstrate Core C# Concepts: Use this project to practice object-oriented programming (e.g., classes, methods), data structures (e.g., List or Dictionary), input/output handling, and basic error handling.

Achieve 100% Feature Completeness: Ensure all required features (add, update, view, remove) work correctly, with at least 5 test products added and manipulated during a demo run.

Produce Clean, Readable Code: Write code that's easy to understand and modify, with comments explaining key sections, and no build errors or warnings.

Complete Within Scope: Finish the project as a standalone console app without over-engineering (e.g., no GUI or database integration unless specified later).