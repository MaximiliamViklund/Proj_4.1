using System.Reflection.Metadata;

Menu();
Console.ReadLine();

static void Menu(){
    string resp;
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("a) Play");
    Console.WriteLine("b) Read rules");
    Console.WriteLine("c) Quit");
    resp=Console.ReadLine().ToLower();

    if(resp=="a"){
        Console.Clear();
        Play();
    }
    else if(resp=="c"){
        Console.Clear();
    }
    else if(resp=="b"){
        Console.Clear();
        Rules();
    }
    else{
        Console.Clear();
        Console.WriteLine("Not a valid response");
        Console.ReadLine();
        Console.Clear();
        Menu();
    }
}

static void Rules(){
    Console.WriteLine("First, you choose a character");
    Console.WriteLine("Each character has different modifiers for damage and accuracy");
    Console.WriteLine("They also have different hp and armor");
    Console.WriteLine("When making an attack you roll a number between 1 and 20 to determine your accuracy");
    Console.WriteLine("Then your accuracy modifier adds to the number you roll, if your combined score exceeds your opponents armor you hit");
    Console.WriteLine("If you hit you then determine your damage");
    Console.WriteLine("You again roll a random number, this time between 1 and 12, and add your damage modifier");
    Console.WriteLine("First one to hit 0 hp loses");
    Console.WriteLine("Good luck!");
    Console.ReadLine();
    Console.Clear();
    Menu();
}

static void Play(){
    string resp;
    int f1hp=0;
    int f2hp=0;
    int dmg1=0;
    int dmg2=0;
    int acc1=0;
    int acc2=0;
    int ac1=0;
    int ac2=0;
    int dice=0;
    Random generator = new Random();
    int cha;

    Console.WriteLine("Choose your character");
    Console.WriteLine("a) Character 1");
    Console.WriteLine("Hp: 45");
    Console.WriteLine("Armor: 16");
    Console.WriteLine("Acc: +2");
    Console.WriteLine("Dmg: +2");

    Console.WriteLine("b) Character 2");
    Console.WriteLine("Hp: 25");
    Console.WriteLine("Armor: 13");
    Console.WriteLine("Acc: +3");
    Console.WriteLine("Dmg: +5");

    Console.WriteLine("c) Character 3");
    Console.WriteLine("Hp: 30");
    Console.WriteLine("Armor: 12");
    Console.WriteLine("Acc: +6");
    Console.WriteLine("Dmg: +3");
    resp=Console.ReadLine().ToLower();

    if(resp=="a"){
        f1hp=45;
        ac1=16;
        acc1=2;
        dmg1=2;
        Console.WriteLine("You choose Character 1");
    }
    else if(resp=="b"){
        f1hp=25;
        ac1=13;
        acc1=3;
        dmg1=5;
        Console.WriteLine("You choose Character 2");
    }
    else if(resp=="c"){
        f1hp=30;
        ac1=12;
        acc1=6;
        dmg1=3;
        Console.WriteLine("You choose Character 3");
    }
    else{
        Console.WriteLine("Not a valid response");
        Play();
    }
    cha = generator.Next(1,4);

   if(cha==1){
        f2hp=45;
        ac2=16;
        acc2=2;
        dmg2=2;
        Console.WriteLine("Your opponent choose Character 1");
    }
    else if(cha==2){
        f2hp=25;
        ac2=13;
        acc2=3;
        dmg2=5;
        Console.WriteLine("Your opponent choose Character 2");
    }
    else if(cha==3){
        f2hp=30;
        ac2=12;
        acc2=6;
        dmg2=3;
        Console.WriteLine("Your opponent choose Character 3");
    }
    Console.ReadLine();
    Console.Clear();

    Console.WriteLine("Let's get ready!!");
    while(f2hp>0&&f1hp>0){
        Console.WriteLine("Press ENTER to attack");
        Console.ReadLine();
        dice=generator.Next(1,21);
        if(dice+acc1>=ac2){
            Console.WriteLine("You hit!");
            Console.WriteLine("Press ENTER to do damage");
            Console.ReadLine();
            dice=generator.Next(1,13);
           int dmg=dice+dmg1;
            f2hp-=dmg;
            Console.WriteLine("You did "+dmg+" damage");
            if(f2hp<0){
                f2hp=0;
            }
            Console.WriteLine("Enemy has "+f2hp+" health left");
            Console.ReadLine();
        }
        else{
            Console.WriteLine("You missed...");
        }
        Console.WriteLine("Your enemy attacks!");
        dice=generator.Next(1,21);
        if(dice+acc2>=ac1){
            Console.WriteLine("They hit.");
            dice=generator.Next(1,13);
            f1hp-=dice+dmg2;
            if(f1hp<0){
                f1hp=0;
            }
            Console.WriteLine("You have "+f1hp+" health left");
            Console.ReadLine();
        }
        else{
            Console.WriteLine("They missed!");
        }
    }
    if(f1hp<=0&&f2hp<=0){
        Console.WriteLine("It's a tie!!");
        Console.WriteLine("Atleast you didn't die.");
        Console.ReadLine();
        Console.Clear();
        Menu();
    }
    else if(f1hp<=0){
        Console.WriteLine("You lost...");
        Console.WriteLine("Better luck next time.");
        Console.ReadLine();
        Console.Clear();
        Menu();
    }
    else if(f2hp<=0){
        Console.WriteLine("You won!!");
        Console.WriteLine("Good job!!");
        Console.ReadLine();
        Console.Clear();
        Menu();
    }
   
}