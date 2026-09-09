using System;
using System.Collections.Generic;
using System.Text;

namespace FieldsPropertiesDemo
{
    public class Product
    {
        /*
         * ============================================================
         * PUBLIC FIELDS
         * ============================================================
         *
         * A field is a variable that belongs to a class.
         *
         * For example, productName stores the name of a particular
         * Product object.
         *
         * Right now, productName is PUBLIC.
         *
         * public means that code OUTSIDE this class can directly
         * access and change this field.
         *
         * For example, in Program.cs we can write:
         *
         *      laptop.productName = "Dell";
         *
         * This may seem convenient, but public fields can create
         * an important design problem.
         *
         * ------------------------------------------------------------
         * THE PROBLEM WITH PUBLIC FIELDS
         * ------------------------------------------------------------
         *
         * When a field is public, outside code has DIRECT access
         * to the data stored inside the object.
         *
         * There is no checkpoint between the outside code and
         * the field.
         *
         * Think of it like leaving the door to a manager's office
         * completely open and allowing anyone to walk inside and
         * modify the records.
         *
         * We could imagine this:
         *
         *      Program.cs
         *          |
         *          |
         *          | direct access
         *          v
         *      public field
         *
         * There is nothing in between to ask:
         *
         *      "Is this value valid?"
         *
         *      "Should this change be allowed?"
         *
         *      "Does this value follow the rules of our application?"
         *
         * This becomes especially dangerous when the field contains
         * data that must follow certain rules.
         *
         * We will demonstrate this problem with the price.
         */
        public string productName = "";


        /*
         * ============================================================
         * PRIVATE FIELD / BACKING FIELD
         * ============================================================
         *
         * Imagine that we originally created price like this:
         *
         *      public decimal price = 0;
         *
         * Program.cs could then write:
         *
         *      laptop.price = 525m;
         *
         * That looks perfectly fine.
         *
         * BUT Program.cs could ALSO write:
         *
         *      laptop.price = -5000m;
         *
         * C# would accept -5000m as a decimal.
         *
         * Why?
         *
         * Because -5000 is technically a perfectly valid decimal
         * number.
         *
         * However, just because something is a VALID DATA TYPE
         * does NOT necessarily mean that it is VALID DATA for
         * our application.
         *
         * ------------------------------------------------------------
         *
         *              VALID C# DATA
         *                    DOES NOT ALWAYS MEAN
         *              VALID BUSINESS DATA
         *
         * ------------------------------------------------------------
         *
         * For example:
         *
         *      -5000m
         *
         * is a valid decimal.
         *
         * But:
         *
         *      Product Price = -$5,000
         *
         * may not make sense according to the rules of our
         * application.
         *
         * If price were public, the Product object would have
         * no opportunity to stop this change.
         *
         *
         * ------------------------------------------------------------
         * THE SOLUTION: MAKE THE FIELD PRIVATE
         * ------------------------------------------------------------
         *
         * Instead of:
         *
         *      public decimal price;
         *
         * we make the field PRIVATE:
         *
         *      private decimal _price;
         *
         * private means that this field can only be directly
         * accessed from inside the Product class.
         *
         * Therefore, Program.cs CANNOT do this:
         *
         *      laptop._price = -5000m;
         *
         * C# will produce a compile-time error because _price
         * is private.
         *
         * We have now protected the internal data of the object.
         *
         * Think about a bank account.
         *
         * Your bank does not give you direct access to the variable
         * that stores your account balance.
         *
         * You cannot simply say:
         *
         *      balance = 1000000;
         *
         * Instead, the bank provides controlled operations such as:
         *
         *      Deposit
         *      Withdraw
         *      Transfer
         *
         * Those operations can check rules before changing the
         * balance.
         *
         * We want our Product class to work in a similar way.
         *
         * We will protect _price by making it private and then
         * provide CONTROLLED access through a property.
         *
         *
         * ------------------------------------------------------------
         * NAMING CONVENTION
         * ------------------------------------------------------------
         *
         * Notice the underscore before the field name:
         *
         *      _price
         *
         * The underscore is a common C# naming convention for
         * private fields.
         *
         * It also helps us visually distinguish the private field:
         *
         *      _price
         *
         * from the public property:
         *
         *      Price
         */
        private decimal _price = 0;


        /*
         * category is still public for this demonstration.
         *
         * We are intentionally keeping productName and category
         * public so that we can compare PUBLIC FIELDS with a
         * PRIVATE FIELD that is accessed through a PROPERTY.
         *
         * In a better encapsulated design, we would normally
         * protect these pieces of data as well.
         */
        public string category = "";


        /*
         * ============================================================
         * PROPERTY: Price
         * ============================================================
         *
         * We have protected _price by making it private.
         *
         * But this creates another question:
         *
         *      If Program.cs cannot directly access _price,
         *      how can we legitimately read or change the price?
         *
         * The answer is:
         *
         *                  A PROPERTY
         *
         *
         * A property provides CONTROLLED ACCESS to data.
         *
         * Think of the property as a SECURITY GUARD or GATEKEEPER
         * standing between outside code and the private field.
         *
         *
         * WITHOUT ENCAPSULATION:
         *
         *      Program.cs
         *          |
         *          |
         *          v
         *      public price
         *
         *      Direct access!
         *
         *
         * WITH ENCAPSULATION:
         *
         *      Program.cs
         *          |
         *          v
         *      Price Property
         *          |
         *          |  validation
         *          v
         *      private _price
         *
         *
         * Program.cs no longer directly manipulates _price.
         *
         * Instead, it asks the Price property to read or change
         * the value.
         *
         * The property can then decide whether that operation
         * should be allowed.
         */
        public decimal Price
        {
            /*
             * ========================================================
             * GET ACCESSOR
             * ========================================================
             *
             * The get accessor controls what happens when someone
             * READS the property.
             *
             * For example:
             *
             *      Console.WriteLine(laptop.Price);
             *
             * C# sees that we are asking for the value of Price.
             *
             * Therefore, the GET accessor executes.
             *
             * It returns the value stored in our private field.
             *
             *
             *      Program.cs
             *          |
             *          | "What is the Price?"
             *          v
             *      Price.get
             *          |
             *          v
             *      return _price
             *
             *
             * In simple terms:
             *
             *      GET = READ
             */
            get
            {
                return _price;
            }


            /*
             * ========================================================
             * SET ACCESSOR
             * ========================================================
             *
             * The set accessor controls what happens when someone
             * attempts to CHANGE the property.
             *
             * For example:
             *
             *      laptop.Price = 525m;
             *
             * When this statement executes, C# automatically places
             * 525m into a special keyword called:
             *
             *      value
             *
             * Therefore:
             *
             *      laptop.Price = 525m;
             *
             * essentially causes:
             *
             *      value = 525m;
             *
             * inside the setter.
             *
             *
             * In simple terms:
             *
             *      SET = WRITE / CHANGE
             */
            set
            {
                /*
                 * ====================================================
                 * VALIDATION
                 * ====================================================
                 *
                 * This is where the advantage of our property becomes
                 * very clear.
                 *
                 * We can inspect the requested value BEFORE allowing
                 * it to reach the private field.
                 *
                 * Our rule is:
                 *
                 *      Price must be greater than zero.
                 *
                 * Therefore, we ask:
                 *
                 *      Is value > 0?
                 */
                if (value > 0)
                {
                    /*
                     * If the answer is YES, then the value is valid.
                     *
                     * We allow the private field to change.
                     *
                     * Example:
                     *
                     *      laptop.Price = 525m;
                     *
                     * Inside the setter:
                     *
                     *      value = 525m
                     *
                     * Then:
                     *
                     *      525 > 0
                     *
                     * is TRUE.
                     *
                     * Therefore:
                     *
                     *      _price = 525m;
                     */
                    _price = value;
                }

                /*
                 * Notice that we currently do not have an ELSE.
                 *
                 * Therefore, if someone tries:
                 *
                 *      laptop.Price = -500m;
                 *
                 * then:
                 *
                 *      value = -500m
                 *
                 * The condition becomes:
                 *
                 *      -500 > 0
                 *
                 * which is FALSE.
                 *
                 * Therefore:
                 *
                 *      _price = value;
                 *
                 * DOES NOT EXECUTE.
                 *
                 * The invalid change is ignored.
                 *
                 *
                 * Compare the two designs:
                 *
                 *
                 * PUBLIC FIELD:
                 *
                 *      laptop.price = -500m;
                 *
                 *              |
                 *              v
                 *
                 *      price becomes -500
                 *
                 *      No validation!
                 *
                 *
                 * PRIVATE FIELD + PROPERTY:
                 *
                 *      laptop.Price = -500m;
                 *
                 *              |
                 *              v
                 *
                 *          SETTER
                 *
                 *              |
                 *              v
                 *
                 *      Is -500 > 0?
                 *
                 *              |
                 *             NO
                 *              |
                 *              X
                 *
                 *      _price is NOT changed.
                 *
                 *
                 * The Product object is now protecting its own data.
                 */
            }
        }


        /*
         * ============================================================
         * METHOD: DisplayProductInfo()
         * ============================================================
         *
         * Fields and properties generally represent DATA or STATE.
         *
         * Methods generally represent BEHAVIOR — something that
         * an object can do.
         *
         * This method displays information about the Product object.
         */
        public void DisplayProductInfo()
        {
            Console.WriteLine($"Product Name: {productName}");

            /*
             * Notice that we use Price here.
             *
             * Reading Price causes the GET accessor to execute:
             *
             *      get
             *      {
             *          return _price;
             *      }
             *
             * :C tells C# to format the number as currency.
             */
            Console.WriteLine($"Product Price: {Price:C}");

            Console.WriteLine($"Product Category: {category}");
        }


        /*
         * ============================================================
         * BIG IDEA: ENCAPSULATION
         * ============================================================
         *
         * What we have done with _price and Price demonstrates an
         * important Object-Oriented Programming principle called:
         *
         *                  ENCAPSULATION
         *
         * Encapsulation means that an object hides/protects its
         * internal data and controls how outside code interacts
         * with that data.
         *
         *
         * Instead of:
         *
         *      public field
         *
         *      Outside code ----------------> data
         *
         *
         * We have:
         *
         *      private field + public property
         *
         *      Outside code
         *           |
         *           v
         *        Property
         *           |
         *       validation
         *           |
         *           v
         *      private field
         *
         *
         * This allows the CLASS to be responsible for protecting
         * its own valid state.
         *
         * We should not depend on every programmer using Product
         * to remember:
         *
         *      "Don't enter a negative price!"
         *
         * Instead, Product itself should enforce the rule.
         *
         *
         * IMPORTANT:
         *
         * The lesson is NOT simply:
         *
         *      "public is bad and private is good."
         *
         * The deeper lesson is:
         *
         *      Objects should control access to their internal state
         *      and protect themselves from invalid changes.
         *
         * That is one of the major purposes of encapsulation.
         */
    }
}
