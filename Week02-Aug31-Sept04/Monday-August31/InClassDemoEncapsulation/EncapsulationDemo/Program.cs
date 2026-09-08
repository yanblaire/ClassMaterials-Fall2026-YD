/*
 * ================================================================
 * CREATE A PRODUCT PRICE MANAGER OBJECT
 * ================================================================
 *
 * Here we create an object from our ProductPriceManager class.
 *
 * The constructor requires:
 *
 *      1. A product category
 *      2. The number of products
 *
 * We provide:
 *
 *      "Drinks"
 *      5
 *
 * Therefore:
 *
 *      category = "Drinks"
 *      numberOfproducts = 5
 *
 *
 * Inside the constructor, an array containing 5 decimal elements
 * will be created.
 *
 *
 *          _prices
 *
 *      INDEX       INITIAL VALUE
 *      -----       -------------
 *        0              0
 *        1              0
 *        2              0
 *        3              0
 *        4              0
 */
using EncapsulationDemo;

ProductPriceManager priceManager1 =
    new ProductPriceManager("Drinks", 5);


/*
 * ================================================================
 * SETTING PRICES
 * ================================================================
 *
 * Notice something VERY important.
 *
 * Program.cs does NOT have direct access to:
 *
 *      _prices
 *
 * because _prices is PRIVATE.
 *
 * Therefore, we cannot write:
 *
 *      priceManager1._prices[3] = 5m;
 *
 * That is intentional.
 *
 * Instead, ProductPriceManager provides the SetPrice() method.
 *
 * SetPrice() becomes our controlled doorway into the array.
 *
 *
 *      Program.cs
 *          |
 *          | SetPrice(3, 5m)
 *          v
 *      +--------------------+
 *      |     SetPrice()     |
 *      |                    |
 *      | Check index        |
 *      | Check price        |
 *      +---------+----------+
 *                |
 *                v
 *          private _prices
 *
 *
 * This means ProductPriceManager remains responsible for
 * protecting its own data.
 */


/*
 * Store $5 at index 3.
 *
 *      index = 3
 *      price = 5m
 *
 * SetPrice checks:
 *
 *      Is 3 a valid index? YES
 *
 *      Is 5 negative? NO
 *
 * Therefore:
 *
 *      _prices[3] = 5m;
 */
priceManager1.SetPrice(3, 5m);


/*
 * Store $15 at index 2.
 */
priceManager1.SetPrice(2, 15m);


/*
 * Store $50 at index 0.
 */
priceManager1.SetPrice(0, 50m);


/*
 * Store $8 at index 1.
 */
priceManager1.SetPrice(1, 8m);


/*
 * Store $85.50 at index 4.
 *
 * Notice the m suffix.
 *
 * m tells C# that this number should be treated as a decimal.
 *
 * decimal is commonly used for monetary values.
 */
priceManager1.SetPrice(4, 85.5m);


/*
 * At this point, our private array conceptually contains:
 *
 *
 *      INDEX       PRICE
 *      -----       ------
 *        0         $50.00
 *        1          $8.00
 *        2         $15.00
 *        3          $5.00
 *        4         $85.50
 *
 *
 * Notice that Program.cs never directly manipulated the array.
 *
 * All changes went through SetPrice().
 */


/*
 * ================================================================
 * DISPLAY ALL PRICES
 * ================================================================
 *
 * DisplayPrices() uses a for loop to move through the private
 * _prices array and display every element.
 */
priceManager1.DisplayPrices();


/*
 * ================================================================
 * PRIVATE SETTER DEMONSTRATION
 * ================================================================
 *
 * ProductCategory has:
 *
 *      public get
 *      private set
 *
 * Therefore, Program.cs is allowed to READ ProductCategory.
 *
 * For example:
 *
 *      Console.WriteLine(priceManager1.ProductCategory);
 *
 * would be allowed.
 *
 *
 * However, Program.cs is NOT allowed to change it:
 *
 *      priceManager1.ProductCategory = "Electronics";
 *
 * Uncomment the statement below and Visual Studio should show
 * an error.
 *
 * Why?
 *
 * Because the setter is PRIVATE.
 *
 *
 *          ProductCategory
 *
 *      +-----------------------+
 *      |                       |
 *      | public GET            | <---- Program.cs can READ
 *      |                       |
 *      | private SET           | <---- Program.cs cannot WRITE
 *      |                       |
 *      +-----------------------+
 *
 *
 * This gives our class additional control over its state.
 */

//priceManager1.ProductCategory = "Electronics";


/*
 * ================================================================
 * OPTIONAL CLASSROOM TEST #1: INVALID PRICE
 * ================================================================
 *
 * Ask students:
 *
 *      "What do you think will happen?"
 *
 *
 * Uncomment:
 *
 *      priceManager1.SetPrice(2, -500m);
 *
 *
 * SetPrice receives:
 *
 *      index = 2
 *      price = -500
 *
 * Index 2 is valid.
 *
 * But:
 *
 *      -500 < 0
 *
 * is true.
 *
 * Therefore the method displays:
 *
 *      Price cannot be negative!
 *
 * and executes:
 *
 *      return;
 *
 * The array is NOT modified.
 */

//priceManager1.SetPrice(2, -500m);


/*
 * ================================================================
 * OPTIONAL CLASSROOM TEST #2: INVALID INDEX
 * ================================================================
 *
 * Our array contains five elements:
 *
 *      0  1  2  3  4
 *
 * Therefore index 10 does NOT exist.
 *
 * Uncomment:
 *
 *      priceManager1.SetPrice(10, 100m);
 *
 *
 * The method checks:
 *
 *      index >= NumberOfProducts
 *
 * which becomes:
 *
 *      10 >= 5
 *
 * TRUE.
 *
 * Therefore it displays:
 *
 *      Invalid Index!
 *
 * and exits the method using return.
 */

//priceManager1.SetPrice(10, 100m);


/*
 * ================================================================
 * FINAL TAKEAWAY
 * ================================================================
 *
 * The important idea is NOT simply:
 *
 *      "Make fields private because public is bad."
 *
 * The deeper idea is that an object should CONTROL and PROTECT
 * its own internal state.
 *
 *
 * Instead of:
 *
 *      Program.cs ---------------------> public array
 *
 *
 * We have:
 *
 *      Program.cs
 *          |
 *          v
 *      Public Method
 *          |
 *      Validation
 *          |
 *          v
 *      Private Array
 *
 *
 * This is a fundamental idea in Object-Oriented Programming:
 *
 *                      ENCAPSULATION
 */