namespace CinemaExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            repeatTenTimes();
            Console.WriteLine();
            Console.WriteLine("Please enter in a sentence"); 
            string answer = Console.ReadLine(); 
            string something = getThirdWordInSentence(answer); 
            Console.WriteLine(something);
            */
            // För default värdet, ommanönskar att justera den är det möjligt att utföra detta här
            string message = "Wrong input, option do not exist";
            do
            {
                Console.WriteLine("Welcome dear user, you are currently within the" +
                    " program. Please type in a option. \n" +
                    "0: you wish to exit the program: " +
                    "\n1 or 2: You wish to visit the cinema, If you are by yourself press \"1\":\n" +
                    "If you are with a retenue press \"2\":" +
                    "\n3: Type a message and get it repeated 10 times: " +
                    "\n4: Type in a sentence with at least three words" +
                    " and receive the third word with in sentence: ");
                //recieving input from user  

                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        int age = PromptingUserAndConvertToInt();
                        int cost = YouthOrPensionere(age);
                        Console.WriteLine($"The cost is {cost}");
                        break;
                    case "2":
                        TotalCostForRetenue();
                        break;

                    case "3":
                        RepeatTenTimes();
                        break;
                    case "4":
                        Console.WriteLine("Type in a sentence: ");
                        string sentence = Console.ReadLine();
                        string answer = GetThirdWordInSentence(sentence);
                        Console.WriteLine(answer);
                        break;
                    default:
                        Console.WriteLine(message);
                        break;
                }
            } while (true);

        }
        public static int YouthOrPensionere(int age)
        {
            int youthPrice = 80;
            int pensionerePrice = 90;
            int standardPrice = 120;
            if (age <= 20)
            {
                Console.WriteLine("Price or cost for young adults and children"
                    + $" are: {youthPrice} kr");
                return youthPrice;
            }
            else if (age >= 64)
            {
                Console.WriteLine("Price for our beloved and honoured seniors are: "
                    + $"{pensionerePrice} kr");
                return pensionerePrice;
            }
            else {
                Console.WriteLine($"The price is {standardPrice} for our " 
                    + "most despised section of society ");
                return standardPrice;
            }
        } 
        //The totalcost of the retenue
        public static void TotalCostForRetenue()
        {
            int sizeOfGroup = PromptingUserForSizeOfRetenue();
            int costOfGroup = TotalCostForGroup(sizeOfGroup);
            Console.WriteLine($"\nFinally, total cost for everyoneare {costOfGroup}"); 
            Console.WriteLine("The size of the group is, {0}", sizeOfGroup);
        }
        //Begära ett ålder av änvändaren för att omvandla svaret till int och spotta ut den
        public static int PromptingUserAndConvertToInt()
        {
            Console.WriteLine("Please enter your age: ");
            string age = Console.ReadLine();
            return int.Parse(age);
        } 
        public static int PromptingUserForSizeOfRetenue()
        {
            int sizeOfRetenue = 0;
            bool condition = true;
            do
            {
                Console.WriteLine("Please provide us with a number that mirrors the size " +
                " of everyone wishing to devour content from the cinema ? ");
                try
                {
                    sizeOfRetenue = int.Parse(Console.ReadLine());
                    condition = false;
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message + "\n So please dear user "
                        + "you have managed, remarkably so, to render my patience " +
                        " into the snow in skåne, meaning into non existence."
                        + "For the love of God, type in a number!");
                }
            } while (condition);
            
            return sizeOfRetenue;
        }
        /*En metod som ansvarar för att räkna totalkostnaden för hela 
         * gruppen utifrån deltagarnas ålder 
         */ 
        public static int TotalCostForGroup(int sizeOfGroup)
        {
            int index = 1;
            int TotalCost = 0; 
            while (index <= sizeOfGroup )
            {
                int age = PromptingUserAndConvertToInt();
                int cost = YouthOrPensionere(age);
                TotalCost += cost;
                index++;
            }
            return TotalCost;
        }
        //En metod vars primära funktion är att emmulera en papegoja, återupprepa budskap
        public static void RepeatTenTimes()
        {
            Console.Write("Type in a message you want to be repeated: ");
            string message = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(message + ", ");
            }
            Console.WriteLine();
        }
        /*En metod som enbart är intresserad av det tredje ordet av
         * en mening jag så möddosamt konstruerat
         */
        public static string GetThirdWordInSentence(string input)
        {
            string answer = "";
            string lastly = "";
            //metod ta bort extra blank spaces 

            string[] anArray = input.Split(" ");
            int length = anArray.Length;
            Console.WriteLine(length);
            bool iterate = true;
            do {
                try
                {
                    answer = anArray[2];
                    lastly = $"The answer is: {answer}"; 
                    iterate = false;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine("You must type in three word, Please try again "); 
                    iterate = false; //Kan inte kalla på GetThirdWordInSentence(input);, inuti metoden därför iterate = false, vill ej loopa i all evighet
                }
            } while (iterate);
            return lastly;
        }
    }
}