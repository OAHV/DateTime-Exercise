// DateTime Exercise
// Task: Create a "Person" class that describes a person.
// Each person has a name, id, and date of birth (yyyy-MM-dd).
//
// Person(DateTime dt, int id, string name)
// • Program should be take these Information from user until enter “exit”
// o Birthdate information: You can design your code take year,
//   month, and day separately or at the same time with yyyy-MM-dd format)
// o Id
// o Name
// • Create person objects from Person class
// • Create a list and add them to list.
// • Program should print all the list elements OrderBy “date of birth”


// Use Swedish date formats
using System.Globalization;
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("sv-SE");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("sv-SE");
Thread.CurrentThread.CurrentUICulture = new CultureInfo("sv-SE");
Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE");

int id = 1;                                 // First person id is 001 - increment by 1 for each new person
List<Person> people = new List<Person>();   // List of people
DateTime bdate = new DateTime();            // Birth date for input

// Main loop
while (true)
{
    string name = "";       // String for input of name
    string sdate = "";      // String for input of date

    // Initiate
    Console.Clear();        // Clear screen
    displayPeople();        // Display list of people further down to screen
    Console.WriteLine("Input person (quit with 'q')");

    // Ask for person
    Console.Write("Name: ");
    while ( (name = Console.ReadLine()) == ""){
        Console.CursorTop = 1;                              // Row 2
        Console.Write("Empty name. Please try again: ");    // Ask for name again
    }
    if (name == "q") break;                                 // Quit on 'q'

    // Ask for date of birth
    Console.Write("Date of birth (yyyy-mm-dd): ");
    while (sdate == ""){
        sdate = Console.ReadLine();
        if (sdate == "q") break;                            // Quit on 'q'
        try
        {
            bdate = Convert.ToDateTime(sdate);              // Convert string input to DateTime
        }
        catch
        {
            Console.CursorTop = 2;                          // Row 3
            Console.WriteLine(" ".PadRight(60));            // Erase line on screen
            Console.CursorTop = 2;                          // Row 3
            Console.Write("Wrong date format. Please try again: ");
            sdate = "";                                     // Reset string to loop for input
        }
    }
    if (sdate == "q") break;                                // Quit on 'q'

    // Create a new person and add to list
    Person p = new Person(id++, name, bdate);
    people.Add(p);
}

void displayPeople()
{
    // Print list of people sorted by birth date
    Console.CursorTop = 8;                                                  // Print list on row 9 of screen
    people = people.OrderByDescending(pr => pr.BirthDate).ToList();         // Sort descending by birth date
    Console.WriteLine("People\nID\t" + "Name".PadRight(20) + "Birthdate");  // Print header
    if (people.Count == 0) Console.WriteLine("---(emtpy list)---");         // If the list is empty
    foreach (Person p in people) { Console.WriteLine(p); }                  // Print each person on a row
    Console.CursorTop = 0;                                                  // Reset cursor to row 1 of screen (for input)
}

class Person
{
    // Constructor
    public Person(int id, string name, DateTime birthDate)
    {
        Id = id;
        Name = name;
        BirthDate = birthDate;
    }

    public int Id { get; }                      // ID number
    public string Name { get; set; }            // Full name
    public DateTime BirthDate { get; set; }     // Date of birth

    // Make it easy to print each person by just Console.WriteLine(Person)
    public override string ToString()
    {
        // Format is "001   Ole Victor            20/11 1959"
        return $"{Id.ToString("D3")}\t{Name.PadRight(20)}{BirthDate.ToString("d'/'M yyyy")}";
    }
}

// By Ole Victor