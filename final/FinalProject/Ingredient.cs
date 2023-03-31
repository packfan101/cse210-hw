public class Ingredient {
// Variables    
    private string _name;
    private string _quantity;
    private string _unitOfMeasure;

// Constructors
    public Ingredient(string name, string quantity, string unitOfMeasure){
        _name = name;
        _quantity = quantity;
        _unitOfMeasure = unitOfMeasure;
    }

    public Ingredient(){
        SetName();        
        SetQuantity();
        SetUnitOfMeasure();
    }

// Behaviors
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

    public string GetQuantity(){
        return _quantity;
    }
    
    public string GetUnitOfMeasure(){
        return _unitOfMeasure;
    }
}