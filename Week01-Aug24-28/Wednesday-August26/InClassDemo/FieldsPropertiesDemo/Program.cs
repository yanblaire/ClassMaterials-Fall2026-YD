
using FieldsPropertiesDemo;


/*
             * Product is our CLASS — our blueprint.
             *
             * laptop is a variable that refers to a Product object.
             *
             * new Product() creates the actual object.
             */

Product laptop = new Product();


/*
 * ========================================================
 * ACCESSING A PUBLIC FIELD
 * ========================================================
 *
 * productName is public.
 *
 * Therefore, Program.cs can directly modify it.
 */
laptop.productName = "Dell";


/*
 * ========================================================
 * ACCESSING A PROPERTY
 * ========================================================
 *
 * Price is a PROPERTY.
 *
 * We are NOT directly accessing the private _price field.
 *
 * In fact, this would NOT work:
 *
 *      laptop._price = 525m;
 *
 * Why?
 *
 * Because _price is PRIVATE.
 *
 * Program.cs does not have permission to directly
 * access it.
 *
 * Instead, we go through the public Price property.
 */
laptop.Price = 525m;


/*
 * What actually happened above?
 *
 *
 *      laptop.Price = 525m;
 *
 *              |
 *              v
 *
 *      Price SET executes
 *
 *              |
 *              v
 *
 *      value becomes 525m
 *
 *              |
 *              v
 *
 *      Is 525 > 0?
 *
 *              |
 *             YES
 *              |
 *              v
 *
 *      _price = 525m
 *
 *
 * Program.cs requested the change.
 *
 * But the Product class decided whether the change
 * was acceptable.
 *
 * That is an important idea in ENCAPSULATION.
 */


/*
 * category is currently public, so Program.cs can
 * directly modify it.
 */
laptop.category = "Computer";


/*
 * Display the information stored in our object.
 */
laptop.DisplayProductInfo();


            /*
             * ========================================================
             * CLASSROOM EXPERIMENT: INVALID PRICE
             * ========================================================
             *
             * After running the program once, uncomment these lines:
             *
             *      laptop.Price = -500m;
             *      laptop.DisplayProductInfo();
             *
             *
             * Ask:
             *
             *      "What do you predict will happen?"
             *
             *
             * The original valid price should remain unchanged.
             *
             * Why?
             *
             * Because the setter checks:
             *
             *      if (value > 0)
             *
             * -500 is NOT greater than zero.
             *
             * Therefore, _price is never changed.
             *
             *
             * Try to contrast this with what would happen if price
             * were simply:
             *
             *      public decimal price;
             *
             * Then this would be allowed:
             *
             *      laptop.price = -500m;
             *
             * There would be no property/setter standing between
             * Program.cs and the field to validate the change.
             */


            /*
             * ========================================================
             * WHY USE DECIMAL FOR PRICE?
             * ========================================================
             *
             * Notice the "m":
             *
             *      525m
             *
             * The m tells C# that this numeric literal should be
             * treated as a decimal.
             *
             * decimal is commonly used when representing monetary
             * values because it provides decimal precision that is
             * appropriate for many financial calculations.
             */


            /*
             * ========================================================
             * FINAL TAKEAWAY
             * ========================================================
             *
             * Compare:
             *
             *      PUBLIC FIELD
             *
             *      Program.cs ----------------------> field
             *
             * Outside code can directly modify the data.
             *
             *
             * Versus:
             *
             *
             *      PRIVATE FIELD + PUBLIC PROPERTY
             *
             *      Program.cs
             *          |
             *          v
             *      Property
             *          |
             *      Validation
             *          |
             *          v
             *      Private Field
             *
             *
             * This gives our object CONTROL over its own data.
             *
             * This is one of the central ideas behind:
             *
             *                  ENCAPSULATION
             */
        