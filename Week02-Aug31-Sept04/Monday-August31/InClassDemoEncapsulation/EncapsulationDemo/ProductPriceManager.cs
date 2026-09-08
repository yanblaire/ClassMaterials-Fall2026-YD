using System;
using System.Collections.Generic;
using System.Text;

namespace EncapsulationDemo
{

    /*
     * ================================================================
     * PRODUCT PRICE MANAGER
     * ================================================================
     *
     * This class represents an object whose responsibility is to
     * manage the prices of a group of products in a particular
     * product category.
     *
     * For example, we could create:
     *
     *      ProductPriceManager drinks
     *
     * and allow that object to manage:
     *
     *      Drinks
     *      ----------------
     *      Product 0   $50
     *      Product 1   $8
     *      Product 2   $15
     *      Product 3   $5
     *      Product 4   $85.50
     *
     *
     * This example demonstrates several important OOP concepts:
     *
     *      1. Private fields
     *      2. Encapsulation
     *      3. Properties
     *      4. Private setters
     *      5. Constructors
     *      6. Arrays
     *      7. Methods
     *      8. Validation
     *      9. Protecting an object's internal state
     */
    public class ProductPriceManager
    {
        /*
         * ============================================================
         * FIELDS
         * ============================================================
         *
         * Fields are variables that belong to a class/object.
         *
         * These fields represent information that each
         * ProductPriceManager object needs to remember.
         *
         * Notice something VERY important:
         *
         *              ALL OF THESE FIELDS ARE PRIVATE.
         *
         * This is intentional.
         *
         * We do NOT want code outside this class to have unrestricted
         * access to the internal data of the object.
         */


        /*
         * ------------------------------------------------------------
         * PRIVATE FIELD: _productCategory
         * ------------------------------------------------------------
         *
         * This field stores the category being managed.
         *
         * Examples:
         *
         *      "Drinks"
         *      "Electronics"
         *      "Furniture"
         *      "Books"
         *
         * Why don't we write:
         *
         *      public string productCategory;
         *
         * ?
         *
         * Because a public field would allow outside code to directly
         * modify the value.
         *
         * For example:
         *
         *      priceManager1.productCategory = "";
         *
         * or:
         *
         *      priceManager1.productCategory = "     ";
         *
         * Those values may violate the rules of our application.
         *
         * By making the field PRIVATE, outside code cannot directly
         * modify it.
         *
         * Instead, access will be controlled through the
         * ProductCategory property below.
         *
         * The underscore is a common C# naming convention for
         * private fields.
         */
        private string _productCategory;


        /*
         * ------------------------------------------------------------
         * PRIVATE ARRAY FIELD: _prices
         * ------------------------------------------------------------
         *
         * This field is especially important.
         *
         * _prices is an ARRAY of decimal values.
         *
         * It will store multiple product prices.
         *
         * For example, if we create an array with 5 elements:
         *
         *      _prices = new decimal[5];
         *
         * we can imagine the array like this:
         *
         *      INDEX       VALUE
         *      -----       -----
         *        0          0
         *        1          0
         *        2          0
         *        3          0
         *        4          0
         *
         *
         * WHY IS THE ARRAY PRIVATE?
         * ------------------------------------------------------------
         *
         * Suppose we made the array public:
         *
         *      public decimal[] prices;
         *
         * Outside code could then potentially do:
         *
         *      priceManager1.prices[0] = -5000m;
         *
         * This would completely bypass our validation.
         *
         * The class would lose control over its own data.
         *
         *
         * PUBLIC ARRAY:
         *
         *      Program.cs
         *          |
         *          | direct access
         *          v
         *      prices[0] = -5000
         *
         * There is no checkpoint.
         *
         *
         * PRIVATE ARRAY:
         *
         *      Program.cs
         *          |
         *          v
         *      SetPrice(...)
         *          |
         *          v
         *      Validate index
         *          |
         *          v
         *      Validate price
         *          |
         *          v
         *      private _prices[index]
         *
         *
         * This is ENCAPSULATION.
         *
         * The array is internal data belonging to this object.
         *
         * Outside code should ASK the object to modify the array
         * through a controlled method rather than directly reaching
         * into the array and changing it.
         */
        private decimal[] _prices;


        /*
         * ------------------------------------------------------------
         * PRIVATE FIELD: _numberOfProducts
         * ------------------------------------------------------------
         *
         * This field stores the number of products.
         *
         * The NumberOfProducts property below controls access to
         * this information.
         */
        private int _numberOfProducts;


        /*
         * ============================================================
         * PROPERTIES
         * ============================================================
         *
         * Properties provide controlled access to information
         * associated with an object.
         *
         * Think of a property as a controlled doorway.
         *
         *
         *      Outside Code
         *           |
         *           v
         *       Property
         *       /      \
         *     get      set
         *       \      /
         *           |
         *           v
         *      Private Data
         */


        /*
         * ------------------------------------------------------------
         * PROPERTY: ProductCategory
         * ------------------------------------------------------------
         *
         * This property provides controlled access to:
         *
         *      _productCategory
         */
        public string ProductCategory
        {
            /*
             * GET
             * --------------------------------------------------------
             *
             * get controls READING.
             *
             * Outside code can write:
             *
             *      Console.WriteLine(priceManager1.ProductCategory);
             *
             * When ProductCategory is read, this code executes.
             */
            get
            {
                return _productCategory;
            }


            /*
             * PRIVATE SET
             * --------------------------------------------------------
             *
             * Notice something important:
             *
             *      private set
             *
             * instead of simply:
             *
             *      set
             *
             *
             * This means the property can be READ from outside
             * the class, but it cannot be CHANGED directly from
             * outside the class.
             *
             * Therefore:
             *
             *      Console.WriteLine(priceManager1.ProductCategory);
             *
             * is allowed.
             *
             * But:
             *
             *      priceManager1.ProductCategory = "Electronics";
             *
             * is NOT allowed from Program.cs.
             *
             *
             * Why might we want this?
             *
             * Because in this design, the category is established
             * when the object is created.
             *
             * We don't want arbitrary outside code changing it later.
             *
             * Think of this as:
             *
             *      PUBLIC GET  = Everyone may LOOK.
             *
             *      PRIVATE SET = Only this class may CHANGE it.
             */
            private set
            {
                /*
                 * VALIDATION
                 * ----------------------------------------------------
                 *
                 * String.IsNullOrWhiteSpace(value)
                 *
                 * checks whether the supplied string is:
                 *
                 *      null
                 *
                 *      ""
                 *
                 * or something containing only spaces such as:
                 *
                 *      "     "
                 *
                 *
                 * The ! means NOT.
                 *
                 * Therefore:
                 *
                 *      !String.IsNullOrWhiteSpace(value)
                 *
                 * essentially means:
                 *
                 *      "The value contains a meaningful string."
                 */
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _productCategory = value;
                }
                else
                {
                    /*
                     * If the category is invalid, we throw an
                     * ArgumentException.
                     *
                     * This prevents us from creating a manager
                     * with an invalid category.
                     */
                    throw new ArgumentException(
                        "Product Category cannot be empty!"
                    );
                }
            }
        }


        /*
         * ------------------------------------------------------------
         * PROPERTY: NumberOfProducts
         * ------------------------------------------------------------
         *
         * This property represents how many products are being
         * managed.
         */
        public int NumberOfProducts
        {
            /*
             * GET
             * --------------------------------------------------------
             *
             * Here, the getter returns:
             *
             *      _prices.Length
             *
             * Length tells us how many elements exist in the array.
             *
             * For example:
             *
             *      decimal[] prices = new decimal[5];
             *
             *      prices.Length
             *
             * returns:
             *
             *      5
             */
            get
            {
                return _prices.Length;
            }


            /*
             * SET
             * --------------------------------------------------------
             *
             * The setter checks that the requested number of
             * products is greater than zero.
             *
             * We do not want:
             *
             *      -5 products
             *
             * because a negative number of products does not
             * logically make sense.
             */
            set
            {
                if (value > 0)
                {
                    _numberOfProducts = value;
                }
            }
        }


        /*
         * ============================================================
         * CONSTRUCTOR
         * ============================================================
         *
         * A constructor runs when a new object is created.
         *
         * Its job is usually to place the new object into a useful
         * initial state.
         *
         * Our constructor requires two pieces of information:
         *
         *      1. category
         *      2. numberOfproducts
         *
         *
         * Therefore, when someone creates this object, they must
         * provide those values.
         *
         * Example:
         *
         *      new ProductPriceManager("Drinks", 5);
         *
         *
         * Here:
         *
         *      category = "Drinks"
         *
         *      numberOfproducts = 5
         */
        public ProductPriceManager(
            string category,
            int numberOfproducts)
        {
            /*
             * Instead of directly writing:
             *
             *      _productCategory = category;
             *
             * we go through our ProductCategory property.
             *
             * Why?
             *
             * Because the property contains our validation.
             *
             * Therefore:
             *
             *      ProductCategory = category;
             *
             * calls the setter.
             *
             *
             * Example:
             *
             *      category = "Drinks"
             *
             *              |
             *              v
             *
             *      ProductCategory setter
             *
             *              |
             *              v
             *
             *      Is it null/empty/whitespace?
             *
             *              |
             *             NO
             *              |
             *              v
             *
             *      _productCategory = "Drinks"
             */
            ProductCategory = category;


            /*
             * We also send the requested number of products
             * through the NumberOfProducts property.
             */
            NumberOfProducts = numberOfproducts;


            /*
             * --------------------------------------------------------
             * CREATING THE ARRAY
             * --------------------------------------------------------
             *
             * Now we create an array large enough to store one price
             * for every product.
             *
             * If:
             *
             *      numberOfproducts = 5
             *
             * then:
             *
             *      new decimal[numberOfproducts]
             *
             * becomes:
             *
             *      new decimal[5]
             *
             *
             * The array contains FIVE positions:
             *
             *      Index:    0    1    2    3    4
             *               +----+----+----+----+----+
             *      Price:   | 0  | 0  | 0  | 0  | 0  |
             *               +----+----+----+----+----+
             *
             *
             * IMPORTANT:
             *
             * Array indexes begin at ZERO.
             *
             * Therefore an array containing 5 elements has indexes:
             *
             *      0, 1, 2, 3, 4
             *
             * NOT:
             *
             *      1, 2, 3, 4, 5
             */
            _prices = new decimal[numberOfproducts];
        }


        /*
         * ============================================================
         * METHOD: SetPrice
         * ============================================================
         *
         * This method allows outside code to REQUEST that a price
         * be placed into our private array.
         *
         * Notice the wording:
         *
         *      REQUEST
         *
         * Program.cs does not directly modify _prices.
         *
         * Instead, it calls:
         *
         *      SetPrice(index, price)
         *
         *
         * The method receives:
         *
         *      index
         *
         *          Which array position should be changed?
         *
         *      price
         *
         *          What price should be stored?
         *
         *
         * Before changing the array, the method validates BOTH.
         */
        public void SetPrice(int index, decimal price)
        {
            /*
             * --------------------------------------------------------
             * VALIDATION #1: CHECK THE INDEX
             * --------------------------------------------------------
             *
             * Before using an array index, we must make sure that
             * the index actually exists.
             *
             * Suppose our array has 5 elements:
             *
             *      0    1    2    3    4
             *
             * Valid indexes are therefore:
             *
             *      0 through 4
             *
             *
             * This condition checks TWO invalid situations:
             *
             *      index < 0
             *
             * OR
             *
             *      index >= NumberOfProducts
             *
             *
             * || means OR.
             *
             *
             * If index is -1:
             *
             *      -1 < 0
             *
             * is true.
             *
             *
             * If index is 5 and there are only 5 products:
             *
             *      5 >= 5
             *
             * is true.
             *
             *
             * Therefore both:
             *
             *      -1
             *
             * and
             *
             *      5
             *
             * are invalid indexes for an array of length 5.
             */
            if (index < 0 || index >= NumberOfProducts)
            {
                Console.WriteLine("Invalid Index!");


                /*
                 * RETURN
                 * ----------------------------------------------------
                 *
                 * return immediately exits this method.
                 *
                 * This is extremely important.
                 *
                 * Once we discover that the index is invalid,
                 * there is no reason to continue.
                 *
                 * Without return, the program could eventually try:
                 *
                 *      _prices[index] = price;
                 *
                 * using an invalid index.
                 *
                 * So we stop the method here.
                 */
                return;
            }


            /*
             * --------------------------------------------------------
             * VALIDATION #2: CHECK THE PRICE
             * --------------------------------------------------------
             *
             * The index is valid at this point.
             *
             * Now we check the price.
             *
             * Our business rule says:
             *
             *      Prices cannot be negative.
             *
             * Therefore:
             */
            if (price < 0)
            {
                Console.WriteLine("Price cannot be negative!");


                /*
                 * Again, return stops the method.
                 *
                 * The invalid price never reaches our private array.
                 */
                return;
            }


            /*
             * --------------------------------------------------------
             * STORE THE PRICE
             * --------------------------------------------------------
             *
             * If execution reaches this line, we know:
             *
             *      1. The index is valid.
             *
             *      2. The price is valid.
             *
             * Therefore, it is now safe to modify the array.
             */
            _prices[index] = price;


            /*
             * This method demonstrates encapsulation very nicely.
             *
             *
             * Program.cs says:
             *
             *      "Please store this price."
             *
             *              |
             *              v
             *
             *          SetPrice()
             *
             *              |
             *              v
             *
             *      Is index valid?
             *
             *              |
             *             YES
             *              |
             *              v
             *
             *      Is price valid?
             *
             *              |
             *             YES
             *              |
             *              v
             *
             *      _prices[index] = price
             *
             *
             * The CLASS controls its own data.
             */
        }


        /*
         * ============================================================
         * METHOD: DisplayPrices
         * ============================================================
         *
         * This method displays every price currently stored in
         * the array.
         */
        public void DisplayPrices()
        {
            /*
             * We use a FOR LOOP because we want to visit every
             * position in the array.
             *
             *
             *      int i = 0
             *
             * Start at index 0.
             *
             *
             *      i < NumberOfProducts
             *
             * Continue while i is a valid position.
             *
             *
             *      i++
             *
             * Move to the next index after each iteration.
             */
            for (int i = 0; i < NumberOfProducts; i++)
            {
                /*
                 * i represents the current index.
                 *
                 * _prices[i] retrieves the price stored at that
                 * position.
                 *
                 * :C formats the decimal as currency.
                 *
                 * \t inserts a tab between the index and price.
                 */
                Console.WriteLine($"{i}\t{_prices[i]:C}");
            }
        }


        /*
         * ============================================================
         * ENCAPSULATION SUMMARY
         * ============================================================
         *
         * The important design idea in this class is that our data
         * is PRIVATE:
         *
         *      private string _productCategory;
         *      private decimal[] _prices;
         *      private int _numberOfProducts;
         *
         *
         * Outside code cannot simply reach inside and change these
         * fields however it wants.
         *
         *
         * BAD DESIGN WITH PUBLIC DATA:
         *
         *      Program.cs
         *          |
         *          |
         *          +----------> prices[0] = -5000
         *
         * No validation.
         *
         *
         * ENCAPSULATED DESIGN:
         *
         *      Program.cs
         *          |
         *          |
         *          v
         *      SetPrice()
         *          |
         *          +---- Check index
         *          |
         *          +---- Check price
         *          |
         *          v
         *      private _prices
         *
         *
         * The private field/array stores the data.
         *
         * The public property or method provides controlled access.
         *
         * The class enforces the rules.
         *
         * That is the central idea of ENCAPSULATION:
         *
         *      Protect an object's internal state and provide
         *      controlled ways of interacting with that state.
         */
    }


}
