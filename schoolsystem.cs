using System;
using System.Collections.Generic;
using Figgle;
using Spectre.Console;
using ConsoleTables;
namespace project
{
    /*
     salam hocam , oncellikle su 3 libraryi indirmeniz gerek run yapmak icin figgle spectre.console ve consoletable
     nugetlardan indirebiliriniz veya termianal'e bunlari yazabilirsiniz dotnet add package Figgle/Specttre.Console/ConsoleTables(bunda version'u guncel olmali ama)
     */
    class studentortak
    {
        //burda butun studentlarin ortak dersleri ve totalgrade'i ve idleri hesaplaniyor 
        //not 0<=x<=100 arasi olmali yoksa direk 0 yapar notu 
        // id'ler random ataniyor
        private double MATEMATIK;
        private double BIYOLOJI;
        private double FIZIK;
        private double ORTALAMA;
        private long ID;
        
        public double matematik
        {
            get => MATEMATIK;
            set
            {
                if (value<=100 && value >= 0)
                {
                    MATEMATIK = value;
                }
                else
                {
                    MATEMATIK = 0;
                }
            } 
        }

        public double biyoloji
        {
            get => BIYOLOJI;
            set
            {
                 if (value<=100 && value >= 0)
                {
                    BIYOLOJI = value;
                    
                }
                else
                {
                    BIYOLOJI = 0;
                }
                
            }
        }

      

        public double fizik
        {
            get => FIZIK;
            set
            {
                if ( value<=100 && value >= 0)
                {
                    
                    FIZIK=value;
                }
                else
                {
                    FIZIK = 0;
                }
            }
        }
        
        public  virtual double ortalama()
        /*
         burda polymorphisim kullandim cunku farkli fakulteler ve farkli fakulteler olunca farkli dersler de olmak zorunda
         ornek computer enginerin notu hesaplanacagi zaman software dersi var ama electric engineeringde elektrik dersi var
         ikisi farkli dersler aliyor 
         o yuzden virtual yaptim ortak derslere geriye kalan diger derslere override yaptim
         
         */
        {
                    return (matematik+biyoloji+fizik);
        } 
        
        public long id()
        {
            if (ID ==0)
            {
                Random sayi = new Random();
                ID = sayi.Next(100, 999);
            }
            return ID;
        }
        
    }
    class bilgisayarmuhders : studentortak
    {
        private double algoritma;
        private double yazilim;
        public double YAZILIM
        {
            get => yazilim;
            set
            {
                if (value <= 100 && value >= 0)
                {
                    yazilim = value;
                }
                else
                {
                    yazilim = 0;
                }
            }
        }

        public double ALGORITMA
        {
            get => algoritma;
            set
            {
                if (value <= 100 && value >= 0)
                {
                    algoritma = value;
                }
                else
                {
                    algoritma = 0;
                }
            }
        }
        public override double ortalama()
        {
            return (algoritma + yazilim+ matematik + fizik + biyoloji)/5;
        }
            
    }

    class elektrikmuh : studentortak
    {
        public double elektrik;
        public double elektronik;
        
        public double ELEKTRIK
        {
            get => elektrik;
            set
            {
                if (value <= 100 && value >= 0)
                {
                    elektrik = value;
                }
                else
                {
                    elektrik = 0;
                }
            }
        }

        public double ELEKTRONIK
        {
            get => elektronik;
            set
            {
                if (value <= 100 && value >= 0)
                {
                    elektronik = value;
                }
                else
                {
                    elektronik = 0;
                }
            }
        }

        public override double ortalama()
        {
            return (elektronik + elektronik+ matematik + fizik + biyoloji)/5;
        }
    }

    class grafikmuhendisligi : studentortak
    {
        private double grafik;
        private double autocad;
        public double GRAFIK
        {
            get => grafik;
            set
            {
                if (value <= 100 && value >= 0)
                {
                    grafik = value;
                }
                else
                {
                    grafik = 0;
                }
            }
        }

        public double AUTOCAD
        {
            get => autocad;
            set
            {
                if (value <= 100 && value >= 0)
                {
                    autocad = value;
                }
                else
                {
                    autocad = 0;
                }
            }
        }

        public override double ortalama()
        {
            return (grafik + autocad + matematik + fizik + biyoloji)/5;
        }
        
    }

    class school : studentortak
    {
       /*
        burda dictionary kullandim cunku fakulte icin ayri sozluk ve ogrenci icin ayri sozluk acmam gerekiyordu
        hashtable da'kullanabilirdim ama daha yavas ve type-safe degil 
        
        bu yapi sayesinde her fakulte kendi ogrencisini sakliyabiliyor ve her ogrenci kendi notunu sakliyabiliyor
        
        */
        private Dictionary<string, Dictionary<string, studentortak>> ogrenci = new Dictionary<string, Dictionary<string, studentortak>>();
        public void sistemdekiogrenciler(string name, double matematik, double biyoloji, double fizik,
            double yazilim, double algoritma, double autocad, double elektrik, double elektronik, double grafik,
            string fakulte)
        {
            studentortak yeniogrenci;
            //burda.tolower kullandim cunku bir isimi buyuk veya kucuk girdiginde farkli personlar algilamasin
            //ornek emir ve Emir'i ayrirmiyacak tek bir person olarak sayacak
            name = name.ToLower();
            fakulte = fakulte.ToLower();

            if (fakulte == "bilgisayar muhendisligi")
            {
                // eger girilen string value bilgisayar muhendisligi ise bilgisayarmuh classina gidecek ve ogrenci olusturacak
                //ve ortak dersler(matematik,biyoloji,fizik) disinda diger dersleri(algoritma,yazilim(software)) derslerine de not atanacak
               // aynisi elektrik(elektrik eloktronik) ve grafik muhendisligi(grafik,autocad) icinde gecerli  
                var cs = new bilgisayarmuhders();
                cs.matematik = matematik;
                cs.fizik = fizik;
                cs.biyoloji = biyoloji;
                cs.YAZILIM = yazilim;
                cs.ALGORITMA = algoritma;
                yeniogrenci = cs;
            }
            else if (fakulte == "elektrik muhendisligi")
            {
                var es = new elektrikmuh();
                es.matematik = matematik;
                es.fizik = fizik;
                es.biyoloji = biyoloji;
                es.ELEKTRIK = elektrik;
                es.ELEKTRONIK = elektronik;
                yeniogrenci = es;
            }
            else if (fakulte == "grafik muhendisligi")
            {
                var gs = new grafikmuhendisligi();
                gs.matematik = matematik;
                gs.fizik = fizik;
                gs.biyoloji = biyoloji;
                gs.GRAFIK = grafik;
                gs.AUTOCAD = autocad;
                yeniogrenci = gs;
            }
            else
            {
                var ort = new studentortak();
                ort.matematik = matematik;
                ort.fizik = fizik;
                ort.biyoloji = biyoloji;
                yeniogrenci = ort;
            }

            if (!ogrenci.ContainsKey(fakulte))
            {
                ogrenci[fakulte] = new Dictionary<string, studentortak>();
            }

            ogrenci[fakulte][name] = yeniogrenci;
        } 
        
        public void addstudent(string name, string fakulte)
        {
            studentortak student;

            fakulte = fakulte.ToLower();
            name = name.ToLower();
           // contains kullaniyor cunku icerde bilgisayar muhendisligi var mi sorguluyor
           //fakulteyi aliyor ilk basta eger sisteme farkli bir fakulte girilirse soyle dusundum 
           //bir universitenin belirli bolumleri var ornek bilgisaqyar muhendisligi ,gragik muh. etc.
           //ama tip yok diyelim sisteme kaydedecek ama print kisminda gecersiz bolum var yazacak
           
           // yine her bolum 
            if (fakulte.Contains("bilgisayar muhendisligi"))
            {//burdaki amacim yeni ogrenci objectleri olusturup atamak o yuzden cs,es,gs kullandim
                var cs = new bilgisayarmuhders();
                Console.Write("Matematik notu: ");
                cs.matematik = double.Parse(Console.ReadLine());
                Console.Write("Fizik notu: ");
                cs.fizik = double.Parse(Console.ReadLine());
                Console.Write("Biyoloji notu: ");
                cs.biyoloji = double.Parse(Console.ReadLine());
                Console.Write("Algoritma notu: ");
                cs.ALGORITMA = double.Parse(Console.ReadLine());
                Console.Write("Yazılım notu: ");
                cs.YAZILIM = double.Parse(Console.ReadLine());
                student = cs;
            }
            else if (fakulte.Contains("elektrik muhendisligi"))
            {
                var es = new elektrikmuh();
                Console.Write("Matematik notu: ");
                es.matematik = double.Parse(Console.ReadLine());
                Console.Write("Fizik notu: ");
                es.fizik = double.Parse(Console.ReadLine());
                Console.Write("Biyoloji notu: ");
                es.biyoloji = double.Parse(Console.ReadLine());
                Console.Write("Elektrik notu: ");
                es.ELEKTRIK = double.Parse(Console.ReadLine());
                Console.Write("Elektronik notu: ");
                es.ELEKTRONIK = double.Parse(Console.ReadLine());
                student = es;
            }
            else if(fakulte.Contains("grafik muhendisligi"))
            {
                var gs = new grafikmuhendisligi();
                Console.Write("Matematik notu: ");
                gs.matematik = double.Parse(Console.ReadLine());
                Console.Write("Fizik notu: ");
                gs.fizik = double.Parse(Console.ReadLine());
                Console.Write("Biyoloji notu: ");
                gs.biyoloji = double.Parse(Console.ReadLine());
                Console.Write("grafik notu: ");
                gs.GRAFIK = double.Parse(Console.ReadLine());
                Console.Write("autocad notu: ");
                gs.AUTOCAD = double.Parse(Console.ReadLine());
                student = gs;
                
            }
            else
            {
                var ort = new studentortak();
                Console.Write("Matematik notu: ");
                ort.matematik = double.Parse(Console.ReadLine());
                Console.Write("Fizik notu: ");
                ort.fizik = double.Parse(Console.ReadLine());
                Console.Write("Biyoloji notu: ");
                ort.biyoloji = double.Parse(Console.ReadLine());
                student = ort;
            }

            if (!ogrenci.ContainsKey(fakulte))
            {//iste burda bahsettigim sistem kayitli bolum yoksa yeni sozluk acar
                //ve birden fazla bolume ogrenci eklettir
                ogrenci[fakulte] = new Dictionary<string, studentortak>();
            }

            ogrenci[fakulte][name] = student;
            Console.WriteLine($"{name} --- ({fakulte}) eklendi.");
        }
        
        public void printstudents()
        {
            foreach (var fakulte in ogrenci)
            {
                if (fakulte.Key.Contains("bilgisayar muhendisligi"))
                {
                    Console.WriteLine("BILGISAYAR MUHENDISLIGI");
                    // burda consoletable kullandim bir table olusturuyor duzenli ve sirali  gozuksun diye 
                    var ders = new ConsoleTables.ConsoleTable("ad: "," matematik: ", "biyoloji: ", "fizik: ", "algoritma: ", "yazilim: ", "ortalama: ", "id: ");
                    foreach (var studentPair in fakulte.Value)
                    {
                        if (studentPair.Value is bilgisayarmuhders cs)
                        {
                            ders.AddRow(studentPair.Key, cs.matematik, cs.fizik, cs.biyoloji, cs.ALGORITMA, cs.YAZILIM, cs.ortalama(), cs.id());
                        }
                        

                    }
                    ders.Write(Format.Alternative);
                }
                else if (fakulte.Key.Contains("elektrik muhendisligi"))
                {
                    Console.WriteLine("ELEKTRIK MUHENDISLIGI");
                    var ders2 = new ConsoleTables.ConsoleTable("ad:", "matematik: ", "fizik: ", "biyoloji: ", "elektrik:", "elektronik: ", "ortalama: ", "id: ");

                    foreach (var studentPair in fakulte.Value)
                    { 
                        if (studentPair.Value is elektrikmuh es)
                        {
                            ders2.AddRow(studentPair.Key, es.matematik, es.fizik, es.biyoloji, es.elektrik, es.elektronik, es.ortalama(), es.id());
                        }
                    }

                    ders2.Write(Format.Alternative);
                }
                else if (fakulte.Key.Contains("grafik muhendisligi"))
                {
                    Console.WriteLine("GRAFIK MUHENDISLIGI");
                    var ders3 = new ConsoleTables.ConsoleTable("ad", "matematik", "fizik", "biyoloji", "elektrik", "grafik", "aoutocad", "id"); 
                    foreach (var studentPair in fakulte.Value)
                    {
                        if (studentPair.Value is grafikmuhendisligi gs)
                        {
                            ders3.AddRow(studentPair.Key , gs.matematik, gs.fizik, gs.biyoloji, gs.GRAFIK, gs.AUTOCAD, gs.ortalama(), gs.id()); 

                        }
                    }
                    ders3.Write(Format.Alternative);
                }
                else
                {
                    Console.WriteLine("gecersiz bolum var");
                }
                //burda her bolumun en yuksek puan toplamis ogrencilerini gosteriyor
                var enyuksekortlama = fakulte.Value.OrderByDescending(s => s.Value.ortalama()).First();
                Console.WriteLine($"en yüksek ortalama sahip olan kisi:  {enyuksekortlama.Key} --- {enyuksekortlama.Value.ortalama()}"); 
            }
            
        }

        public void deletestudent(string fakulte, string name)
        {
            //burda fakulte ve ogrenci adi alarak ogrenci siliyor
            
            fakulte = fakulte.ToLower();
            name = name.ToLower();
            Console.WriteLine("silinecek ogrenci: ");
            if (ogrenci.ContainsKey(fakulte) && ogrenci[fakulte].ContainsKey(name))
            {
                ogrenci[fakulte].Remove(name);
                Console.WriteLine($"{name} silindi");
            }
            else
            {
                Console.WriteLine($"{name} bulunamadi");
            }
        }

        public void search(string fakulte, string name)
        {
            //ogrenci arama kismi fakulte ve ad'dan buluyor ve notlarini gosteriyor
            //her bolumun farkli dersleri var diye if else kullandim ayirmak icin
            
            
            fakulte = fakulte.ToLower();
            name = name.ToLower();
            Console.WriteLine("aranacak ogrenci: ");
            if (ogrenci.ContainsKey(fakulte) && ogrenci[fakulte].ContainsKey(name))
            {
                studentortak s = ogrenci[fakulte][name];
                Console.WriteLine($"{name}");
                Console.WriteLine($" matematik: {s.matematik}, biyoloji: {s.biyoloji}, fizik: {s.fizik}");

                if (s is bilgisayarmuhders cs)
                {
                    Console.WriteLine($"yazilim:{cs.YAZILIM} algoritma: {cs.ALGORITMA} ");
                }
                else if (s is elektrikmuh es)
                {
                    Console.WriteLine($"elektirk: {es.ELEKTRIK} elektronik: {es.ELEKTRONIK} ");
                }
                else if(s is grafikmuhendisligi gs)
                {
                   Console.WriteLine($"grafik: {gs.GRAFIK} aoutocad: {gs.AUTOCAD} "); 
                }
                Console.WriteLine($"id: {s.id()} ve ortalama: {s.ortalama()}");
            }
            else
            {
                Console.WriteLine($"{name} bulunamadi");
            }
        }

        public void schedule()
        {
         // bu da schedule for teacher
            var dersProgrami = new ConsoleTables.ConsoleTable("Saat", "1. Gün", "2. Gün", "3. Gün", "4. Gün", "5. Gün");

            dersProgrami
                .AddRow("08:30-09:50", "Veri Yapıları - 652.24E", "Siber Güvenlik - 652.24E", "Veri Yapıları - 652.24E",
                    "Veri Yapıları - 652.24E", "Veri Yapıları - 652.24E")
                .AddRow("10:05-11:25", "Algoritma - 653.23E", "", "", "", "Siber Güvenlik - 652.24E")
                .AddRow("11:40-13:00", "", "", "Veri Yapıları - 652.24E", "Software - 652.24E",
                    "Veri Yapıları - 652.24E")
                .AddRow("14:00-15:20", "Temel Bilgisayar - 652.24E", "Algoritma - 652.24E", "Software - 652.24E",
                    "Algoritma - 653.23E", "Software - 652.24E");

            Console.WriteLine("DERS PROGRAMI");
            dersProgrami.Write(Format.Alternative);
            Console.WriteLine();
        }
    }
  

    class Program
        {

            static void Main(string[] args)
            {
                //figgle kutuphanesi ile tittlelar var
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(FiggleFonts.Standard.Render("ADNSU - OKUL - SISTEMI - GIRIS"));
                Thread.Sleep(500);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Blue;
                //systema girmek icin sifre
                Console.WriteLine("sisteme giris icin sifre girin");
                string sifre = "1";
                string girilensifre = " ";
                int haktanima = 3;
                int denemesayisi = 0;
                while (true)
                {

                    girilensifre = Console.ReadLine();
                    if (girilensifre == sifre)
                    {
                        Console.WriteLine("sifre dogru hosgeldiniz");

                        break;
                    }
                    else
                    {
                        denemesayisi++;
                        if (denemesayisi >= haktanima)
                        {
                            Console.WriteLine("sifreyi 3 defa hatali girdiniz bloklandiniz sistemden");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"{haktanima - denemesayisi} hakkin kaldi !");
                        }
                    }
                }

                Console.Clear();

                school ardaguler = new school();

                Console.WriteLine(FiggleFonts.Standard.Render("ADNSU"));
                //kayitli ogrenciler
                ardaguler.sistemdekiogrenciler("hasanali", 92, 90, 100, 90, 100, 0, 0, 0, 0, "bilgisayar muhendisligi");
                ardaguler.sistemdekiogrenciler("m.emir", 98, 97, 93, 89, 87, 0, 0, 0, 0, "bilgisayar muhendisligi");
                ardaguler.sistemdekiogrenciler("orxan", 80, 97, 90, 0, 0, 0, 87, 87, 0, "elektrik muhendisligi");
                ardaguler.sistemdekiogrenciler("aqsin", 87, 83, 91, 0, 0, 98, 0, 0, 78, "grafik muhendisligi"); 
                while (true)
                {
                    //burda spectre.console kullandim menu sistemi yapmak icin ve switch caseden yararlandim
                    
                    var secim = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("[green] menu: [/]")
                        .AddChoices("ogrenci kaydetme", "kayitli ogrenciler", "ogrenci silme", "ogrenci arama",
                            "ders programi", "cikis")); 
                    switch (secim)
                    {

                        case "ogrenci kaydetme":
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(FiggleFonts.Small.Render("ogrenci - ekleme - bolumu"));
                            Thread.Sleep(1000);
                            Console.WriteLine("ogrencinin bolumu:");
                            string fakulte = Console.ReadLine();
                            Console.WriteLine("ogrencinin adi:");
                            string ad = Console.ReadLine();
                            ardaguler.addstudent(ad, fakulte);
                            //altaki satir yukleme ekrani gosteriyor 
                            AnsiConsole.Status().Start("islem yapiliyor...", ctx => { Thread.Sleep(2000); });
                            //buda sisteme kayit saatini gosteriyor
                            AnsiConsole.MarkupLine($"[yellow]KAYDEDILME ZAMANI:[/] {DateTime.Now}");
                            Thread.Sleep(2200);
                            Console.Clear();
                            break;

                        case "kayitli ogrenciler":
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(FiggleFonts.Small.Render("ogrenci - yazdirma - bolumu"));
                            Console.WriteLine("ogrencilerin adi ve notu");
                            AnsiConsole.Status().Start("islem yapiliyor...", ctx => { Thread.Sleep(2000); });
                            ardaguler.printstudents();
                            AnsiConsole.MarkupLine("[yellow] kayitli ogrencilerinin adi ve notu[/]");
                            Thread.Sleep(6000);
                            Console.Clear();
                            break;

                        case "ogrenci silme":
                            Console.WriteLine(FiggleFonts.Standard.Render("ogrenci silme bolumu"));
                            Console.WriteLine("ogrencinin bolumu:");
                            string fakulteSil = Console.ReadLine();
                            Console.WriteLine("silinecek ogrencinin adini girin");
                            string AD = Console.ReadLine();
                            AnsiConsole.Status().Start("islem yapiliyor...", ctx => { Thread.Sleep(2000); });
                            ardaguler.deletestudent(fakulteSil, AD);
                            AnsiConsole.MarkupLine($"[yellow] SILME ZAMANI: [/] {DateTime.Now}");
                            AnsiConsole.MarkupLine("[yellow] ogrenci silindi[/]");
                            Thread.Sleep(2200);
                            Console.Clear();
                            break;

                        case "ogrenci arama":
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(FiggleFonts.Small.Render("ogrenci arama bolumu"));
                            Thread.Sleep(1000);
                            Console.WriteLine("ogrencinin bolumu:");
                            string fakulteAra = Console.ReadLine();
                            Console.WriteLine("ogrencinin adini girin");
                            string ad1 = Console.ReadLine();
                            AnsiConsole.Status().Start("islem yapiliyor...", ctx => { Thread.Sleep(2000); });
                            ardaguler.search(fakulteAra, ad1);
                            AnsiConsole.MarkupLine($"[yellow] aranan ogrenci : [/] {ad1}");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "ders programi":
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(FiggleFonts.Small.Render("ders programi goruntu"));
                            ardaguler.schedule();
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "cikis":
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(FiggleFonts.Small.Render("programdan cikma bolumu"));
                            Console.WriteLine("programdan cikiliyor");
                            AnsiConsole.Status().Start("islem yapiliyor...", ctx => { Thread.Sleep(2000); });
                            AnsiConsole.MarkupLine($"[yellow] CIKIS ZAMANI: [/] {DateTime.Now}");
                            AnsiConsole.MarkupLine("[yellow] sistemden cikildi...[/]");
                            Thread.Sleep(2200);
                            Console.Clear();
                            return;

                        default:

                            break;

                    }

                }

            }

        }
    
    }
