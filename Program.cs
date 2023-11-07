
using System.Text;

string path = "C:\\Users\\marketa.zemlova\\Visual Studio 2023\\C sharp 2\\HW5_Real_Dictionary_&_Dictionary_File\\Dictionary.txt";
bool isOver = false;

Dictionary<string, string> realDictionary = new Dictionary<string, string>() {
    {"palmy","1 - vzkvétající, prosperující\t2 - palmový, plný palem" },
    {"parallelogram","rovnoběžník (v geometrii)" },
    {"paperhanging", "tapetování"},
    {"paper tiger","politická loutka (zdánlivě mocná osoba)" },
    {"dibber","sázecí kolík, udělat díru sázaecím kolíkem" },
    {"devil","1 - the Devil - ďábel, Satan > Go to the devil. Jdi k čertu.\t2 - démon, zlý duch, čert\t3 - (expr.) poor devil - chudák, nešťastník / You lucky devil! Ty máš, ale štěstí. Ty jsi klikař!\t4 - better the devil you know(than the devil you don't know) Lepší čelit zlu, které znáš.  " },
    {"snowdrift","sněhová závěj" },
    {"rubbishy","bídný, mizerný, prachšpatný" },
    {"lout","hulvát, nevychovanec, klacek" },
    {"eager","1 - (celý) nedočkavý\t2 - eager to do sth - dychtivý po čem, nedočkavý, nažhavený na co; He was eager to do it. Byl celý žhavý to dělat." },
    {"window shade","roleta" },
    {"winset","zubr" },
    {"abrasion","1 - odřenina, oděrka (na těle)\t2 - odření, odírání, broušení\t3 - geol. abraze obrušování " }
};
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
        //Store dictionary to file

        // Vymyslet efektivní způsob zápisu do douboru! - pole o 2 prvcích? 
        case 4:
            StringBuilder builderDictionary = new StringBuilder();
            foreach (KeyValuePair<string, string> statementValue in realDictionary) 
            { 
                builderDictionary.AppendLine($"{{{statementValue.Key}}},{{{statementValue.Value}}}");

            }
            File.WriteAllText(path, builderDictionary.ToString());
            break;
    }

    //Console.ReadLine();
}