////////////////////Resept Data/////////////////////////
List<string> reseptisim = new List<string>();
List<string> reseptterkib = new List<string>();
List<string> reseptaddim = new List<string>();

string isimdata = "reseptisimdata.txt";
string terkibdata = "resepttarifdata.txt";
string addimdata = "reseptaddimdata.txt";


if (File.Exists(isimdata) && File.Exists(terkibdata) && File.Exists(addimdata))
{
    string[] isimlerim = File.ReadAllLines(isimdata);
    string[] tariflerim = File.ReadAllLines(terkibdata);
    string[] addimlarim = File.ReadAllLines(addimdata);

    for (int i = 0; i < isimlerim.Length; i++)
    {
        reseptisim.Add(isimlerim[i]);
        reseptterkib.Add(tariflerim[i]);
        reseptaddim.Add(addimlarim[i]);

    }
}

/////////////////////SYSTEMS//////////////////////////

void reseptbaxmaq()
{
    Console.WriteLine("-------RESEPTLER-------");
    if (reseptterkib.Count == 0)
    {
        Console.WriteLine("Resept yoxdur!");
    }
    else
    {
        Console.WriteLine("ID - AD - TERKİB - ADDIMLAR");
        Console.WriteLine("---------------------------");
        for (int i = 0; i < reseptterkib.Count; i++)
        {
            string isimindex = reseptisim[i];
            string terkibindex = reseptterkib[i];
            string reseptindex = reseptaddim[i];

            Console.WriteLine($"{i + 1}-{isimindex} ---> {terkibindex} ---> {reseptindex}");
            Console.WriteLine("---------------------------");
        }
    }
}

void reseptelaveet()
{
    Console.WriteLine("-------RESEPT ELAVE ET------");
    Console.Write("Resept adı: ");
    string ad = Console.ReadLine();
    Console.Write("Terkibi : ");
    string terkib = Console.ReadLine();
    Console.Write("Resepti hazirlama addimlari: ");
    string addimlar = Console.ReadLine();

    reseptisim.Add(ad);
    reseptterkib.Add(terkib);
    reseptaddim.Add(addimlar);
    yazdirfunksiya();
}

void reseptsil()
{
    reseptbaxmaq();
    Console.WriteLine("Hansı resepti silmek isteyirsiniz?(Geri qayitmaq ID:0)");
    int silid = 0;
    string silindex = "";
    while (true)
    {
        Console.Write("ID: ");
        silindex = Console.ReadLine();
        if (!int.TryParse(silindex, out silid) || silid > reseptisim.Count)
        {
            Console.WriteLine("Tekrar yoxlayin.");
        }
        else
        {
            break;
        }
    }
    silid = Convert.ToInt32(silindex);
    if (silid == 0)
    {
        return;
    }
    reseptisim.RemoveAt(silid - 1);
    reseptterkib.RemoveAt(silid - 1);
    reseptaddim.RemoveAt(silid - 1);
    yazdirfunksiya();
    reseptbaxmaq();
}

void reseptaxtar()
{
    Console.WriteLine("-----RESEPT AXTARIŞ-----");
    Console.Write("Axtardığınız resept adı: ");
    string ad = Console.ReadLine().ToLower();
    bool tapildi = false;

    for (int i = 0; i < reseptisim.Count; i++)
    {
        if (reseptisim[i].ToLower().Contains(ad))
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Ad: {reseptisim[i]}");
            Console.WriteLine($"Terkib: {reseptterkib[i]}");
            Console.WriteLine($"Addımlar: {reseptaddim[i]}");
            Console.WriteLine("---------------------------");
            tapildi = true;
        }
    }
    if (!tapildi)
    {
        Console.WriteLine("Axtardiginiz adda resept yoxdur!");
    }
}

void yazdirfunksiya()
{
    File.WriteAllLines(isimdata, reseptisim);
    File.WriteAllLines(terkibdata, reseptterkib);
    File.WriteAllLines(addimdata, reseptaddim);
}

////////////////MENU///////////////////////////
do
{
    Console.WriteLine("------MENU------");
    Console.WriteLine("1-Reseptlere Bax \n2-Ada Göre Axtarış \n3-Resept Daxil Et \n4-Resept Sil \n5-Cıxış");
    int id = 0;
    while (true)
    {
        Console.Write("ID: ");
        string index = Console.ReadLine();
        if (!int.TryParse(index, out id) || id > 4 || id < 1)
        {
            Console.WriteLine("Tekrar Yoxlayın.");
        }
        else
        {
            break;
        }
    }
    if (id == 1)
    {
        reseptbaxmaq();
    }
    else if (id == 2)
    {
        reseptaxtar();
    }
    else if (id == 3)
    {
        reseptelaveet();
    }
    else if (id == 4)
    {
        reseptsil();
    }
    else if (id == 5)
    {
        break;
    }

} while (true);