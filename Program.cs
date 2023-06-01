//var pizza = new Pizza();
//Console.WriteLine(pizza.number);
//Console.WriteLine(pizza.date);
//Console.WriteLine(pizza.ingredient);
//pizza.AddIngredient(new Cheddar());
//pizza.AddIngredient(new Mozzarella());
//pizza.AddIngredient(new TomatoSause());

//Console.WriteLine(pizza.ToString());

//var ingredient = new Ingredient(1);
//ingredient.PublicField = 10;

//Console.WriteLine("Variable of type Cheddar");
//Cheddar chedar = new Cheddar(); 
//Console.WriteLine(chedar.Name);
//Console.WriteLine();
//Console.WriteLine("Variable of type Ingredient");
//Ingredient ingredient = new Cheddar();
//Console.WriteLine(ingredient.Name);

//chedar.PublicField = 20;

//Console.WriteLine("Value in igredient: " + ingredient.PublicField);
//Console.WriteLine("Value in igredient: " + chedar.PublicField);
//Console.WriteLine(chedar.PublicMethod());
//Console.WriteLine(chedar.PrivateMethod());
//Console.WriteLine(chedar.ProtectedMethod());

//var ingredients = new List<Ingredient>
//{
//    new Cheddar(),
//    new Mozzarella(),
//    new TomatoSause()
//};

//Console.WriteLine();
//foreach (var ingredient in ingredients)
//{
//    Console.WriteLine(ingredient.Name);
//}

//var cheddar = new Cheddar(1, 4);

//Console.WriteLine(cheddar);
//Console.WriteLine(new TomatoSause());
//Console.WriteLine(cheddar);

//Ingredient ingredient = new Cheddar(2, 12);

//using System.Threading.Channels;

//Ingredient ingredient = GenerateRandomIngredient();
//Console.WriteLine("Ingredient is" + ingredient);
//Cheddar cheddar = ingredient as Cheddar;
//if (cheddar is not null)
//{
//    Console.WriteLine(cheddar.Name);
//}

//else
//{
//    Console.WriteLine("Conversion failed");
//}
//if (randomIngredient is Cheddar)
//{
//    Cheddar cheddar = (Cheddar)randomIngredient;
//    Console.WriteLine("cheddar object: " + cheddar);
//}

//Console.WriteLine("Random ingredirnt is" + randomIngredient);
//Cheddar chedar = (Cheddar)randomIngredient;

//var cheddar = new Cheddar(2, 12);
//var tomatoSause = new TomatoSause(1);
//cheddar.Prepare();
//tomatoSause.Prepare();

//var ingredients = new List<Ingredient>
//{
//    new Cheddar(2,10),
//    new Mozzarella(2),
//    new TomatoSause(1),
//};

//foreach (var ingredient in ingredients)
//{
//    ingredient.Prepare();
//}

//var pizza = RandomPizzaGenerator.Generate(3);

var multilineText = @"aaa
bbb
ccc
ddd";

Console.WriteLine("Count of lines is " + CountLines(multilineText));

Console.ReadKey();

int CountLines(string input) => input.Split(Environment.NewLine).Length;

public static class RandomPizzaGenerator
{

    public static Pizza Generate(int hoqManyIngredients)
    {
        var pizza = new Pizza();
        for (int i = 0; i < hoqManyIngredients; i++)
        {
            var randomIngredient = GenerateRandomIngredient();
            pizza.AddIngredient(randomIngredient);
        }

        return pizza;
    }

    private static Ingredient GenerateRandomIngredient()
    {
        var random = new Random();
        var number = random.Next(1, 4);
        if (number == 1) { return new Cheddar(2, 12); }
        if (number == 2) { return new TomatoSause(1); }
        else return new Mozzarella(2);
    }
}

public class Pizza
{
    public int number;
    public DateTime date;
    public Ingredient ingredient;

    private List<Ingredient> _ingredients = new List<Ingredient>();

    public void AddIngredient(Ingredient ingredient) => _ingredients.Add(ingredient);

    public override string ToString() => $"This is a pizza with  {string.Join(", ", _ingredients)}";
}

public abstract class Ingredient
{
    public Ingredient(int priceIfExtraTopping)
    {
        Console.WriteLine("CONSRUCTOR FROM THE INGREDIENT CLASS");
        PriceIfExtraTopping = priceIfExtraTopping;
    }

    public int PriceIfExtraTopping { get; }

    public override string ToString() => Name;

    public virtual string Name { get; } = "Some ingredient";

    public abstract void Prepare();

    public int PublicField;

    public string PublicMethod() => "This method PUBLIC in the Ingredient class.";

    protected string ProtectedMethod() => "This method PROTECTED in the Ingredient class.";

    private string PrivateMethod() => "This method PRIVATE in the Ingredient class.";
}

public abstract class Cheese : Ingredient
{
    public Cheese(int priceIfExtraTopping) : base(priceIfExtraTopping)
    {
    }
}
public class Cheddar : Ingredient
{
    public Cheddar(int priceIfExtraTopping, int agedForMonth) : base(priceIfExtraTopping)
    {
        AgedForMonth = agedForMonth;
        Console.WriteLine("Constructor from the Cheddar class");
    }
    public override string Name => $"{base.Name}, more specifically, a Cheddar cheese aged for {AgedForMonth} month";
    public int AgedForMonth { get; }

    public override void Prepare() => Console.WriteLine("Grate anf spinkle over pizza.");

    public void UseMethodsFromBaseClass()
    {
        Console.WriteLine(PublicMethod());
        Console.WriteLine(ProtectedMethod());
        //Console.WriteLine(PrivateMethod());
    }
}

public class ItalianFoodItem
{

}

public class Mozzarella : Cheese
{
    public Mozzarella(int priceIfExtraTopping) : base(priceIfExtraTopping)
    {
    }

    public override string Name => "Mozzarella";
    public int IsLight { get; }

    public override void Prepare() => Console.WriteLine("Slice thinly and plase on top of the pizza.");
}

public class TomatoSause : Ingredient
{
    public TomatoSause(int priceIfExtraTopping) : base(priceIfExtraTopping)
    {
    }

    public override string Name => "Tomato sause";
    public int TomatosIn100Grams { get; }

    public override void Prepare() => Console.WriteLine("Cook tomatos with basil, garlic and salt. Spread on pizza.");
}