public class Ingredient {
    private string _name;
    private string _quantity;
    private string _unitOfMeasure;

    public Ingredient(){
        SetName();        
        SetQuantity();
        SetUnitOfMeasure();
    }

    public string GetIngredient(){
        return $"{_quantity} {_unitOfMeasure} {_name}";
    }

    public void SetName(){
        Console.WriteLine("What is the name of the ingredient? ");
        _name = Console.ReadLine();
    }
    
    public void SetQuantity(){
        Console.WriteLine("How much would you like to add to the recipe? (Enter the number or fraction) ");
        _quantity = Console.ReadLine();   
    }

    public void SetUnitOfMeasure(){
        Console.WriteLine("Please enter the unit of measure. (cup/tsp/tbsp/etc.) ");
        _unitOfMeasure = Console.ReadLine();
    }

    public string GetName(){
        return _name;
    }
}