// IHR NAME
// IHRE KLASSE

/// <summary>
/// SAS Konsoleneingabe
/// Arbeitsauftrag 2 - Aufgabe 1
/// Fehleingabe
/// </summary>


Aufgabe_1.Aufgabe1();

public static class Aufgabe_1
{
    public static (string, string, short, double, bool) Aufgabe1()
    {
        string vorname = "";
        string nachname = "";
        short alter = 0;
        double groesse = 0;
        bool erste_ps=false;

        Console.WriteLine("Persönliche Daten");

        try
        {

            Console.WriteLine("Geben Sie Ihren Vornamen ein:");
            vorname = Console.ReadLine();
            Console.WriteLine("Geben Sie Ihren Nachnamen ein:");
            nachname = Console.ReadLine();

            Console.WriteLine("Wie alt sind Sie?:");
            alter = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Wie groß sind Sie?:");
            groesse = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ist C# Ihre erste Programmiersprache?(true/false):");
            erste_ps = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"{"Vorname:",-10}{vorname}");
            Console.WriteLine($"{"Nachname:",-10}{nachname}");
            Console.WriteLine($"{"Alter:",-10}{alter}");
            Console.WriteLine($"{"Größe:",-10}{groesse}");
            Console.WriteLine($"{"ProgErf:",-10}{erste_ps}");
        }
        catch (Exception)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Falsche Eingabe!");
        }
        return (vorname, nachname, alter, groesse, erste_ps);

    }
}
