
//using HW5_Real_Dictionary___Dictionary_File;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

string pathJson = "C:\\Users\\marketa.zemlova\\Visual Studio 2023\\C sharp 2\\HW5_Real_Dictionary_&_Dictionary_File\\DictionaryJson.json";
bool isOver = false;

// nacti input jako string z JSON souboru 
string input = File.ReadAllText(pathJson);
Dictionary<string, string> realDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(input);

while (!isOver)
{
    //Menu
    Console.WriteLine("Menu:\n" +
        "0 - Konec\n" +
        "1 - Vypiš slovník do konzole\n" +
        "2 - Přidej hodnotu do slovníku\n" +
        "3 - Vymaž hodnotu ze slovníku\n" +
        "4 - Ulož slovník do souboru\n" +
        "5 - Načti slovník ze souboru");
    int.TryParse(Console.ReadLine(), out int choosenNumber);

    switch (choosenNumber)
    {
        //End
        case 0:
            isOver = true;
            break;
       //Dictionary to console
        case 1:
            foreach (KeyValuePair<string, string> statementValue in realDictionary)
            {
                Console.WriteLine($"{statementValue.Key} : {statementValue.Value}");
            }
            break;
        //Add dictionary key pair
        case 2:
            Console.WriteLine("Napiš anglický výraz:");
            string addKey = Console.ReadLine();
            Console.WriteLine("Napiš význam:");
            string addValue = Console.ReadLine();
            if ((addKey != null) && (addValue != null)){ 
                realDictionary.Add(addKey, addValue);
            }
            break;
        //Remove key pair
        case 3:
            Console.WriteLine("Napiš anglický výraz pro vymazání:");
            string removeKey = Console.ReadLine();
            realDictionary.Remove(removeKey);
            break;


        // Zapis do souboru pomoci JSON
        // uloz string output do souboru
        case 4:
            string output = JsonConvert.SerializeObject(realDictionary);
            File.WriteAllText(pathJson, output);
            break;

        // opetovne nacteni ze souboru JSON
        // nacti output jako string ze souboru a vypis na konzoli
        case 5:
            //input = File.ReadAllText(pathJson);
            realDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(input);
            
            

            break;
    }

    //Console.ReadLine();
}