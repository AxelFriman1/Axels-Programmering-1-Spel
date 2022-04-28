using System;
using System.Collections.Generic;

namespace Texas_Hold_em
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerMoney = 500; //Startsumman för hur mycket pengar spelaren har
            int botMoney = 500;    //Startsumman för hur mycket pengar dator 1 har
            int bot2Money = 500;   //Startsumman för hur mycket pengar dator 2 har

            int round = 1;         //En variabel som håller koll på vilken runda i spelet man är
            int sleepTime = 2000;  //Hur länge spelet ska vänta på att skriva ut nästa rad av kod
            

            int dealer = 1;                //En variabel som kollar vem som delar ut kort
            int bigBlind = 10;             //En int som innehåller stora startkostnaden för att vara med i spelet
            int maxBigBlind = 75;          //En int som innehåller ett tal som berättar om hur stort värde big blind kan anta
            int smallBlind = bigBlind / 2; //En int som innehåller lilla startkostaden för att vara med i spelet

            List<string> botNames = new List<string>() { "Pillow", "Kelly", "Belle", "Haley", "Miley", "Stella", "Lexie", "Aurora", "Luna", "Stormy", "Hope", "Sky", "Mary Jane", "Ellie", "Legendary", "Happy", "Bellatrix", "Chloe", "Melanie", "Lex", "Zion", "Jason", "Leevi", "Lexus", "Spencer", "Kingston", "Lionel", "Zackarias", "Lucky", "Dimond", "Dion", "Logan", "Sebastian" }; //En lista som innehåller namn till datorn
            string botName = "";
            string bot2Name = "";
            botName = randomizeBotName(botNames, botName, bot2Name);  //Slumpar namnet på dator 1
            bot2Name = randomizeBotName(botNames, bot2Name, botName); //Slumpar namnet på dator 2
          
            Console.WriteLine("Hej och välkommen till ett spel av Texas Hold'em!");
            System.Threading.Thread.Sleep(sleepTime);
            Console.WriteLine($"Du spelar mot {botName} och {bot2Name}");
            System.Threading.Thread.Sleep(sleepTime);
            
            while (playerMoney > 0 && botMoney > 0 || playerMoney > 0 && bot2Money > 0) //Spelar spelet medans två av spelarna har mer än 0 pengar
            {
                string[] playerCards = new string[2]; //En array som ska innehålla spelarens kort
                string[] botCards = new string[2];    //En array som ska innehålla dator 1:s kort
                string[] bot2Cards = new string[2];   //En array som ska innehålla dator 2:s kort
                string[] deckCards = { "", "", "", "", ""};   //En array som ska innehålla korten som ligger på bordet

                int playerBet = 0; //En int som innehåller hur mycket pengar spelaren har bettat under rundan
                int botBet = 0;    //En int som innehåller hur mycket dator 1 har bettat under rundan
                int bot2Bet = 0;   //En int som innehåller hur mycket dator 2 har bettat under rundan
                int bettedMoney = 0;    //En int som innehåller den totala summan bettade pengar

                int betRound = 0;

                string[] playerCardValue = new string[2];   //En lista där första platsen ska innehålla spelarens värde i tal och andra platsen spelarens värde i text
                string[] botCardValue = new string[2];
                string[] bot2CardValue = new string[2];

                bool playerActive = true; //Kollar ifall spelaren fortfarande är med i spelet
                bool botActive = true;    //Kollar ifall dator 1 fortfarande är med i spelet
                bool bot2Active = true;   //Kollar ifall dator 2 fortfarande är med i spelet

                List<string> cards = new List<string>() {"Spader 2", "Spader 3", "Spader 4", "Spader 5", "Spader 6", "Spader 7", "Spader 8", "Spader 9", "Spader 10", "Spader Knekt", "Spader Dam", "Spader Kung", "Spader Ess",
                "Klöver 2", "Klöver 3", "Klöver 4", "Klöver 5", "Klöver 6", "Klöver 7", "Klöver 8", "Klöver 9", "Klöver 10", "Klöver Knekt", "Klöver Dam","Klöver Kung","Klöver Ess",
                "Hjärter 2", "Hjärter 3", "Hjärter 4", "Hjärter 5", "Hjärter 6", "Hjärter 7", "Hjärter 8", "Hjärter 9", "Hjärter 10", "Hjärter Knekt", "Hjärter Dam", "Hjärter Kung", "Hjärter Ess",
                "Ruter 2", "Ruter 3", "Ruter 4", "Ruter 5", "Ruter 6", "Ruter 7", "Ruter 8", "Ruter 9", "Ruter 10", "Ruter Knekt", "Ruter Dam", "Ruter Kung", "Ruter Ess" }; //En lista som innehåller alla 52 kort

                playerCards = drawCards(cards, playerCards); ///Drar kort åt spelaren
                
                if (botMoney != 0)                       
                {                                           
                    botCards = drawCards(cards, botCards);  //Drar kort åt dator 1 sålänge den har mer än 0 pengar
                }
                if (bot2Money != 0)
                {
                    bot2Cards = drawCards(cards, bot2Cards); //Drar kort åt dator 2 sålänge den har mer än 0 pengar
                }
                deckCards = drawDeck(cards, deckCards); //Drar kort åt bordet
                
                Console.WriteLine($"Runda: {round}");  //Skriver ut rundan                                  
                
                if(dealer == 1) //Om dealer är 1 så delar dator 2 ut kort, spelaren är small blind och dator 1 är big blind
                {
                    Console.WriteLine($"{bot2Name} delar ut kort till varje spelare");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine($"Du får korten: {playerCards[0]} och {playerCards[1]}");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine($"{bot2Name} lägger ut korten på bordet");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}");
                    System.Threading.Thread.Sleep(sleepTime);

                    playerBet += smallBlind;                                               //Lägger till startsumman small blind i spelarens totalt bettade pengar
                    Console.WriteLine($"Du är small blind och har bettat {playerBet} kr");
                    System.Threading.Thread.Sleep(sleepTime);
                    botBet += bigBlind;                                                    //Lägger till startsumman big blind i dator 1:s totalt bettade pengar
                    Console.WriteLine($"{botName} är big blind och har bettat {botBet} kr");
                    System.Threading.Thread.Sleep(sleepTime);

                    while (betRound < 2)   
                    {
                        Random rnd = new Random();

                        int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                        if (betRound == 0)  //Om det är bettingrunda 0 så får alla spelarna lägga in sin bett
                        {
                            playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                            Console.WriteLine($"Du har bettat {playerBet} kr");
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));

                            botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                            Console.WriteLine($"{botName} har bettat {botBet} kr");

                            bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                            Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                            System.Threading.Thread.Sleep(sleepTime);
                        }

                        if (betRound == 1 && playerBet != minBet)   //Ifall det är bettingrunda 1 och spelaren inte lagt in tillräckligt för att vara med i nästa runda får spelaren en chans att göra det
                        {
                            playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                            if (playerBet < minBet)
                            {
                                playerActive = false;
                            }
                        }
                        if (betRound == 1 && botBet != minBet)  //Ifall det är bettingrunda 1 och dator 1 inte lagt in tillräckligt för att vara med i nästa runda får spelaren en chans att göra det
                        {
                            botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                            if(botBet == minBet)
                            {
                                Console.WriteLine($"{botName} lägger in {botBet}");
                                System.Threading.Thread.Sleep(sleepTime);
                            }
                            else
                            {
                                botActive = false;
                                Console.WriteLine($"{botName} har gett upp");
                                System.Threading.Thread.Sleep(sleepTime);
                            }
                        }
                        if (betRound == 1 && bot2Bet != minBet) //Om dator 2 inte lagt in tillräckligt åker han ut för rundan
                        {
                            bot2Active = false;
                            Console.WriteLine($"{bot2Name} har gett upp");
                            System.Threading.Thread.Sleep(sleepTime);
                        }

                        betRound += 1;
                    }

                    if (playerActive == true && botActive == true && bot2Active == false) //Om dator 2 har åkt ut
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound); //Lägger in ett nytt kort på bordet
                        Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                        System.Threading.Thread.Sleep(sleepTime);
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");

                        while(betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                            if (betRound == 2) //Om det är bettingrunda 2 får båda spelarna en chans att lägga in sin bett
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, botBet);

                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, botBet);
                                Console.WriteLine($"{botName} har bettat {botBet} kr");
                            }

                            if (betRound == 3 && playerBet != minBet) //Om spelaren inte lagt in lika mycket som dator 1 får spelaren en chans att göra det
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                if (playerBet < minBet)
                                {
                                    playerActive = false;
                                }
                            }
                            if (betRound == 3 && botBet != minBet) //Om dator 1 inte lagt in lika mycket som spelaren så åker datorn ut
                            {
                                botActive = false;
                                Console.WriteLine($"{botName} har gett upp");
                            }
                            
                            betRound += 1;
                        }
                        if(playerActive == true && botActive == true) //Om båda spelarna är kvar
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound); //Lägger in ett nytt kort på bordet
                            Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                                if (betRound == 4) //Om det är bettingrunda 4 får båda spelarna lägga in sin bett
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, botBet);

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, botBet);
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");
                                }
                                if (betRound == 5 && playerBet != minBet) //Om det är bettingrunda 5 och spelaren inte lagt in lika mycket som dator 1 får spelaren en chans att göra det
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    if (playerBet < minBet)
                                    {
                                        playerActive = false;
                                    }
                                }
                                if (betRound == 5 && botBet != minBet) //Om dator 1 inte lagt in lika mycket som spelaren så åker dator 1 ut för rundan
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }

                                betRound += 1;
                            }
                        }
                    }
                    else if(playerActive == true && bot2Active == true && botActive == false) //Om dator 1 har åkt ut
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound); //Drar ett nytt kort till bordet
                        Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                            if (betRound == 2) //Om det är bettingrunda 2 får båda spelarna en chans att lägga in sin bett
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, bot2Bet);

                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(playerBet, bot2Bet);
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                            }

                            if (betRound == 3 && playerBet != minBet) //Om spelaren inte lagt in lika mycket som dator 2 får spelaren en chans att göra det
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                if (playerBet < minBet)
                                {
                                    playerActive = false;
                                }
                            }
                            if (betRound == 3 && bot2Bet != minBet) //Om dator 1 inte lagt in lika mycket som spelaren åker dator 2 ut för rundan
                            {
                                bot2Active = false;
                                Console.WriteLine($"{bot2Name} har gett upp");
                            }
                            
                            betRound += 1;
                        }
                        if (playerActive == true && bot2Active == true) //Om båda spelarna är kvar i spelet
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound); //Drar ett nytt kort till bordet
                            Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4) //Om det är bettingrunda 4 får båda spelarna lägga in sin bett
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, bot2Bet);

                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                                }
                                if (betRound == 5 && playerBet != minBet) //Om det är bettingrunda 5 och spelaren inte bettat lika mycket som dator 2 får spelaren en chans att göra det
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    if (playerBet < minBet)
                                    {
                                        playerActive = false;
                                    }
                                }
                                if (betRound == 5 && bot2Bet != minBet) //Om dator 2 inte lagt in tillräckligt för att vara med så åker dator 2 ut för rundan
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }

                                betRound += 1;
                            }
                        }

                    }
                    else if(botActive == true && bot2Active == true && playerActive == false) //Om spelaren har åkt ut
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound); //Drar ett nytt kort till bordet
                        Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(botBet, bot2Bet); //Kollar vem som har bettat mest
                            if (betRound == 2) //Om det är bettingrunda 2 får båda spelarna en chans att lägga in sin bett
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{botName} har bettat {botBet} kr");

                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(botBet, bot2Bet);
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                            }


                            if (betRound == 3 && botBet != minBet) //Om det är bettingrunda 3 och dator 1 inte lagt in lika mycket som dator 2 får dator 1 en chans att göra det
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                if(botBet == minBet)
                                {
                                    Console.WriteLine($"{botName} lägger in {botBet} kr");
                                }
                                else
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                            }
                            if (betRound == 3 && bot2Bet != minBet) //Om dator 2 inte lagt in lika mycket som dator 1 åker dator 2 ut för rundan
                            {
                                bot2Active = false;
                                Console.WriteLine($"{bot2Name} har gett upp");
                            }
                            
                            betRound += 1;
                        }
                        if (botActive == true && bot2Active == true) //Om båda spelarna är kvar
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound); //Drar ett nytt kort till bordet
                            Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while(betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4) //Om det är bettingrunda 4 får båda spelarna en chans att lägga in sin bett
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");

                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(botBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                                }

                                if (betRound == 5 && botBet != minBet) //Om det är bettingrunda 5 och dator 1 inte lagt in lika mycket som dator 2 får dator 1 en chans att göra det
                                {

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    if(botBet == minBet)
                                    {
                                        Console.WriteLine($"{botName} lägger in {botBet} kr");
                                    }
                                    else
                                    {
                                        botActive = false;
                                        Console.WriteLine($"{botName} har gett upp");
                                    }

                                }
                                if (betRound == 5 && bot2Bet != minBet) //Om dator 2 inte lagt in lika mycket som dator 1 så åker dator 2 ut för rundan
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }
                                betRound += 1;
                            }
                        }
                    }
                    else if(playerActive == true && botActive == true && bot2Active == true) //Om alla spelarna är kvar
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound); //Drar ett nytt kort till bordet
                        Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                            if (betRound == 2) //Om det är bettingrunda två får alla spelarna lägga in sin bett
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));

                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{botName} har bettat {botBet} kr");

                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                            }

                            if (betRound == 3 && playerBet != minBet) //Om det är bettingrunda 3 och spelaren inte lagt in tillräckligt för att vara med i nästa runda får spelaren en chans att göra det
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                if (playerBet < minBet)
                                {
                                    playerActive = false;
                                }
                            }
                            if (betRound == 3 && botBet != minBet) //Om det är bettingrunda 3 och dator 1 inte lagt in tillräckligt för att vara med i nästa runda får dator 1 en chans att göra det
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                if(botBet == minBet)
                                {
                                    Console.WriteLine($"{botName} lägger in {botBet} kr");
                                }
                                else
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                            }
                            if (betRound == 3 && bot2Bet != minBet) //Om dator 2 inte lagt in tillräckligt för att vara med i nästa runda så åker dator 2 ut för rundan
                            {
                                bot2Active = false;
                                Console.WriteLine($"{bot2Name} har gett upp");
                            }
                               
                            
                            betRound += 1;
                        }
                        if(playerActive == true && botActive == true && bot2Active == false) //Om dator 2 har åkt ut
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound); //Drar ett nytt kort till bordet
                            Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                                if (betRound == 4) //Om det är bettingrunda 4 får båda spelarna en chans att lägga sin bett
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, botBet);

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, botBet);
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");
                                }

                                if (betRound == 5 && playerBet != minBet) //Om det är bettingrunda 5 och spelaren inte lagt in lika mycket som dator 1 får spelaren en chans att göra det
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    if (playerBet < minBet)
                                    {
                                        playerActive = false;
                                    }
                                }
                                if (betRound == 5 && botBet != minBet) //Om dator 1 inte lagt in lika mycket som spelaren så åker dator 1 ut för rundan
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }

                                betRound += 1;
                            }
                        }
                        else if(playerActive == true && bot2Active == true && botActive == false) //Om dator 1 har åkt ut
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound); //Drar ett nytt kort till bordet
                            Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4) //Om det är bettingrunda 4 får båda spelarna lägga in sin bett
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, bot2Bet);

                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                                }

                                if (betRound == 5 && playerBet != minBet) //Om spelaren inte lagt in lika mycket som dator 2 får spelaren en chans att göra det
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    if (playerBet < minBet)
                                    {
                                        playerActive = false;
                                    }
                                }
                                if (betRound == 5 && bot2Bet != minBet) //Om dator 2 inte lagt in lika mycket som spelaren så åker dator 2 ut för rundan
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }

                                betRound += 1;
                            }
                        }
                        else if(botActive == true && bot2Active == true && playerActive == false) //Om spelaren har åkt ut
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound); //Lägger in ett till kort på bordet
                            Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(botBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4) //Om det är bettingrunda 4 får båda spelarna en chans att lägga in sin bett
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");

                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(botBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                                }

                                if (betRound == 5 && botBet != minBet) //Om det är bettingrunda 5 och dator 1 inte lagt in lika mycket som dator 2 får dator 1 en chans att göra det
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    if(botBet == minBet)
                                    {
                                        Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                    }
                                    else
                                    {
                                        botActive = false;
                                        Console.WriteLine($"{botName} har gett upp");
                                    }
                                }
                                if (betRound == 5 && bot2Bet != minBet) //Om dator 2 inte lagt in lika mycket som dator 1 åker dator 2 ut för rundan
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }

                                betRound += 1;
                            }
                        }
                        else if (botActive == true && bot2Active == true && playerActive == true) //Om alla spelarna är kvar
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"{bot2Name} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                                if (betRound == 4) //Om det är bettingrunda 4 får alla spelarna en chans att lägga in sin bett
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");

                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                                }

                                if (betRound == 5 && playerBet != minBet) //Om spelaren inte lagt in tillräckligt för att vara med i nästa runda får spelaren en chans att göra det
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    if (playerBet < minBet)
                                    {
                                        playerActive = false;
                                    }
                                }
                                if (betRound == 5 && botBet != minBet) //Om dator 1 inte lagt in tillräckligt för att vara med i nästa runda får dator 1 en chans att göra det
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    if(botBet == minBet)
                                    {
                                        Console.WriteLine($"{botName} lägger in {botBet} kr");
                                    }
                                    else
                                    {
                                        botActive = false;
                                        Console.WriteLine($"{botName} har gett upp");
                                    }
                                }
                                if (betRound == 5 && bot2Bet != minBet) //Om dator 2 inte lagt in tillräckligt för att vara med i nästa runda åker dator 2 ut för rundan
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }


                                betRound += 1;
                            }
                        }
                    }
                }
                else if (dealer == 2) //Om dealer är 2 så delar spelaren ut kort, dator 1 är small blind och dator 2 är big blind
                {
                    Console.WriteLine("Du delar ut kort till varje spelare");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine($"Du får korten: {playerCards[0]} och {playerCards[1]}");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine("Du lägger ut korten på bordet");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}");
                    System.Threading.Thread.Sleep(sleepTime);

                    botBet += smallBlind;                                                   //Lägger till startsumman small blind i dator 1:s totalt bettade pengar
                    Console.WriteLine($"{botName} är small blind och har bettat {botBet} kr");
                    bot2Bet += bigBlind;                                                    //Lägger till startsumman big blind i dator 2:s totalt bettade pengar
                    Console.WriteLine($"{bot2Name} är big blind och har bettat {bot2Bet} kr");

                    while (betRound < 2)
                    {
                        Random rnd = new Random();

                        int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                        if (betRound == 0)
                        {
                            botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);        //Dator 1 lägger in sin bett
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));                                            //Minimum bettet uppdateras
                            Console.WriteLine($"{botName} har bettat {botBet} kr");                                                 

                            bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);   //Dator 2 lägger in sin bett
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));                                            //Minimum bettet uppdateras
                            Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                            playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                            Console.WriteLine($"Du har bettat {playerBet} kr");
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                        }

                        if (betRound == 1 && botBet != minBet)      //Ifall det är bettrunda 1 och dator 1 inte lagt in tillräckligt för att vara med i nästa runda får datorn en chans att göra det
                        {
                            botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                            if (botBet == minBet)
                            {
                                Console.WriteLine($"{botName} lägger in {botBet}");
                            }
                            else
                            {
                                botActive = false;
                                Console.WriteLine($"{botName} har gett upp");
                            }
                        }
                        if (betRound == 1 && bot2Bet != minBet)
                        {
                            bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                            if (bot2Bet == minBet)
                            {
                                Console.WriteLine($"{bot2Name} lägger in {bot2Bet}");
                            }
                            else
                            {
                                bot2Active = false;
                                Console.WriteLine($"{bot2Name} har gett upp");
                            }
                        }
                        if (betRound == 1 && playerBet != minBet)      //Ifall det är bettrunda 1 och spelaren inte lagt in tillräckligt för att vara med i nästa runda så åker spelaren ut ur rundan
                        {
                            playerActive = false;
                        }

                        betRound += 1;
                    }
                    if (playerActive == true && botActive == true && bot2Active == false)
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound);
                        Console.WriteLine("Du lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                            if (betRound == 2)
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, botBet);
                                Console.WriteLine($"{botName} har bettat {botBet} kr");

                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, botBet);

                               
                            }

                            if (betRound == 3 && botBet != minBet)
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                if(botBet == minBet)
                                {
                                    Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                }
                                else
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                            }
                            if (betRound == 3 && playerBet != minBet)
                            {
                                playerActive = false;
                            }
                            
                            betRound += 1;
                        }
                        if(playerActive == true && botActive == true)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine("Du lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, botBet);
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");

                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, botBet);
                                }

                                if (betRound == 5 && botBet != minBet)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    if(botBet == minBet)
                                    {
                                        Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                    }
                                    else
                                    {
                                        botActive = false;
                                        Console.WriteLine($"{botName} har gett upp");
                                    }
                                }
                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerActive = false;
                                }

                                betRound += 1;
                            }
                        }
                    }
                    else if (playerActive == true && bot2Active == true && botActive == false)
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound);
                        Console.WriteLine("Du lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                            if (betRound == 2)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(playerBet, bot2Bet);
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, bot2Bet);
                            }

                            if (betRound == 3 && bot2Bet != minBet)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                if(bot2Bet == minBet)
                                {
                                    Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                }
                                else
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }
                            }
                            if (betRound == 3 && playerBet != minBet)
                            {
                                playerActive = false;
                            }
                            
                            betRound += 1;
                        }
                        if(playerActive == true && bot2Active == true)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine("Du lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, bot2Bet);
                                }

                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    if (bot2Bet == minBet)
                                    {
                                        Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                    }
                                    else
                                    {
                                        bot2Active = false;
                                        Console.WriteLine($"{bot2Name} har gett upp");
                                    }
                                }
                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerActive = false;
                                }

                                betRound += 1;
                            }
                        }
                    }
                    else if (botActive == true && bot2Active == true && playerActive == false)
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound);
                        Console.WriteLine("Du lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(botBet, bot2Bet); //Kollar vem som har bettat mest
                            if (betRound == 2)
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{botName} har bettat {botBet} kr");

                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(botBet, bot2Bet);
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                            }

                            if (betRound == 3 && botBet != minBet)
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                if(botBet == minBet)
                                {
                                    Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                }
                                else
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                            }
                            if (bot2Bet != minBet)
                            {
                                bot2Active = false;
                                Console.WriteLine($"{bot2Name} har gett upp");
                            }
                            
                            betRound += 1;
                        }
                        if(botActive == true && bot2Active == true)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine("Du lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(botBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");

                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(botBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                                }

                                if (betRound == 5 && botBet != minBet)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    if(botBet == minBet)
                                    {
                                        Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                    }
                                    if (botBet < minBet)
                                    {
                                        botActive = false;
                                        Console.WriteLine($"{botName} har gett upp");
                                    }
                                }
                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }
                                
                                betRound += 1;
                            }
                        }
                    }
                    else if (playerActive == true && botActive == true && bot2Active == true)
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound);
                        Console.WriteLine($"Du lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                            if (betRound == 2)
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{botName} har bettat {botBet} kr");

                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                            }

                            if (betRound == 3 && botBet != minBet)
                            {
                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                if(botBet == minBet)
                                {
                                    Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                }
                                else
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                            }
                            if (betRound == 3 && bot2Bet != minBet)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                if(bot2Bet == minBet)
                                {
                                    Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                }
                                else
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }
                            }
                            if (betRound == 3 && playerBet != minBet)
                            {
                                playerActive = false;
                            }
                            
                            betRound += 1;
                        }
                        if(playerActive == true && botActive == true && bot2Active == false)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"Du lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, botBet);
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");

                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, botBet);
                                }

                                if (betRound == 5 && botBet != minBet)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    if(botBet == minBet)
                                    {
                                        Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                    }
                                    else
                                    {
                                        botActive = false;
                                        Console.WriteLine($"{botName} har gett upp");
                                    }
                                }
                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerActive = false;
                                }

                                betRound += 1;
                            }

                        }
                        else if(playerActive == true && bot2Active == true && botActive == false)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"Du lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, bot2Bet);
                                }

                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    if(bot2Bet == minBet)
                                    {
                                        Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                    }
                                    else
                                    {
                                        bot2Active = false;
                                        Console.WriteLine($"{bot2Name} har gett upp");
                                    }
                                }
                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerActive = false;
                                }

                                betRound += 1;
                            }
                        }
                        else if(botActive == true && bot2Active == true && playerActive == false)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine("Du lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(botBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");

                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(botBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");
                                }

                                if (betRound == 5 && botBet != minBet)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    if(botBet == minBet)
                                    {
                                        Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                    }
                                    else
                                    {
                                        botActive = false;
                                        Console.WriteLine($"{botName} har gett upp");
                                    }
                                }
                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }

                                betRound += 1;
                            }
                        }
                        else if(playerActive == true && botActive == true && bot2Active == true)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"Du lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");

                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                }

                                if (betRound == 5 && botBet != minBet)
                                {
                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    if(botBet == minBet)
                                    {
                                        Console.WriteLine($"{botName} har lagt in {botBet} kr");
                                    }
                                    else
                                    {
                                        botActive = false;
                                        Console.WriteLine($"{botName} har gett upp");
                                    }
                                }
                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    if(bot2Bet == minBet)
                                    {
                                        Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                    }
                                    else
                                    {
                                        bot2Active = false;
                                        Console.WriteLine($"{bot2Name} har gett upp");
                                    }
                                }
                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerActive = false;
                                }

                                betRound += 1;
                            }
                        }
                    }
                }
                else //Om inget av det stämmer så delar dator 1 ut kort, dator 2 är small blind och spelaren är big blind
                {
                    Console.WriteLine($"{botName} delar ut kort till varje spelare");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine($"Du får korten: {playerCards[0]} och {playerCards[1]}");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine($"{botName} lägger ut korten på bordet");
                    System.Threading.Thread.Sleep(sleepTime);
                    Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}");
                    System.Threading.Thread.Sleep(sleepTime);

                    bot2Bet += smallBlind;                                                   //Lägger till startsumman small blind i dator 2:s totalt bettade pengar
                    Console.WriteLine($"{bot2Name} är small blind och har bettat {bot2Bet} kr");
                    playerBet += bigBlind;                                                   //Lägger till startsumman small blind i spelarens totalt bettade pengar
                    Console.WriteLine($"Du är big blind och har bettat {playerBet} kr");

                    while (betRound < 2)
                    {
                        Random rnd = new Random();

                        int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                        if (betRound == 0)
                        {
                            bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                            Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                            playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                            Console.WriteLine($"Du har bettat {playerBet} kr");
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));

                            botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                            minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                            Console.WriteLine($"{botName} har bettat {botBet} kr");
                        }

                       
                        if (betRound == 1 && bot2Bet != minBet)
                        {
                            bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                            if (bot2Bet == minBet)
                            {
                                Console.WriteLine($"{bot2Name} lägger in {bot2Bet}");
                            }
                            else
                            {
                                bot2Active = false;
                                Console.WriteLine($"{bot2Name} har gett upp");
                            }
                        }
                        if (betRound == 1 && playerBet != minBet)
                        {
                            playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                            Console.WriteLine($"{botName} lägger in {botBet}");
                            if (playerBet < minBet)
                            {
                                playerActive = false;
                                Console.WriteLine("Du har gett upp");
                            }
                        }
                        if (betRound == 1 && botBet != minBet)
                        {
                            botActive = false;
                            Console.WriteLine($"{botName} har gett upp");
                        }
                        betRound += 1;
                    }
                    if (playerActive == true && botActive == true && bot2Active == false)
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound);
                        Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                            if (betRound == 2)
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, botBet);

                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, botBet);
                                Console.WriteLine($"{botName} har bettat {botBet} kr");
                            }

                            if (betRound == 3 && playerBet != minBet)
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                if (playerBet < minBet)
                                {
                                    playerActive = false;
                                }
                            }
                            if (betRound == 3 && botBet != minBet)
                            {
                                botActive = false;
                                Console.WriteLine($"{botName} har gett upp");
                            }
                            betRound += 1;
                        }
                        if(playerActive == true && botActive == true)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, botBet);

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, botBet);
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");
                                }

                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    if (playerBet < minBet)
                                    {
                                        playerActive = false;
                                    }
                                }
                                if (betRound == 5 && botBet != minBet)
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                            }
                            betRound += 1;
                        }
                    }
                    else if (playerActive == true && bot2Active == true && botActive == false)
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound);
                        Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                            if (betRound == 2)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(playerBet, bot2Bet);
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, bot2Bet);
                            }
                            
                            if (betRound == 3 && bot2Bet != minBet)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                if(bot2Bet == minBet)
                                {
                                    Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                }
                                else
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }
                            }
                            if (betRound == 3 && playerBet != minBet)
                            {
                                playerActive = false;
                            }
                            
                            betRound += 1;
                        }
                        if(playerActive == true && bot2Active == true)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, bot2Bet);
                                }

                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    if (bot2Bet == minBet)
                                    {
                                        Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                    }
                                    else
                                    {
                                        bot2Active = false;
                                        Console.WriteLine($"{bot2Name} har gett upp");
                                    }
                                }
                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerActive = false;
                                }

                                betRound += 1;
                            }
                        }
                    }
                    else if (botActive == true && bot2Active == true && playerActive == false)
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound);
                        Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(botBet, bot2Bet); //Kollar vem som har bettat mest
                            if (betRound == 2)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(botBet, bot2Bet);
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{botName} har bettat {botBet} kr");
                            }

                            if (betRound == 3 && bot2Bet != minBet)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                if(bot2Bet == minBet)
                                {
                                    Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                }
                                else
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }
                            }
                            if (betRound == 3 && botBet != minBet)
                            {
                                botActive = false;
                                Console.WriteLine($"{botName} har gett upp");
                            }
                            betRound += 1;
                        }
                        if(botActive == true && bot2Active == true)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(botBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(botBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");
                                }

                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    if (bot2Bet == minBet)
                                    {
                                        Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                    }
                                    else
                                    {
                                        bot2Active = false;
                                        Console.WriteLine($"{bot2Name} har gett upp");
                                    }
                                }
                                if (betRound == 5 && botBet != minBet)
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                                betRound += 1;
                            }
                        }
                    }
                    else if (playerActive == true && botActive == true && bot2Active == true)
                    {
                        deckCards = newDeckCard(cards, deckCards, betRound);
                        Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                        Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}");
                        while (betRound < 4)
                        {
                            int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                            if (betRound == 2)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                Console.WriteLine($"Du har bettat {playerBet} kr");
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));

                                botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                Console.WriteLine($"{botName} har bettat {botBet} kr");
                            }

                            if (betRound == 3 && bot2Bet != minBet)
                            {
                                bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                if(bot2Bet == minBet)
                                {
                                    Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                }
                                else
                                {
                                    bot2Active = false;
                                    Console.WriteLine($"{bot2Name} har gett upp");
                                }
                            }
                            if (betRound == 3 && playerBet != minBet)
                            {
                                playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                if (playerBet < minBet)
                                {
                                    playerActive = false;
                                }
                            }
                            if (betRound == 3 && botBet != minBet)
                            {
                                botActive = false;
                                Console.WriteLine($"{botName} har gett upp");
                            }
                            
                            betRound += 1;
                        }
                        if(playerActive == true && botActive == true && bot2Active == false)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, botBet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, botBet);

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, botBet);
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");
                                }

                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    if (playerBet < minBet)
                                    {
                                        playerActive = false;
                                    }
                                }
                                if (betRound == 5 && botBet != minBet)
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                            }
                            betRound += 1;
                        }
                        else if(playerActive == true && bot2Active == true && botActive == false)
                        {

                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, bot2Bet);
                                }

                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    if (bot2Bet == minBet)
                                    {
                                        Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                    }
                                    else
                                    {
                                        bot2Active = false;
                                        Console.WriteLine($"{bot2Name} har gett upp");
                                    }
                                }
                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerActive = false;
                                }

                                betRound += 1;
                            }
                        }
                        else if(botActive == true && bot2Active == true && playerActive == false)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(botBet, bot2Bet); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(botBet, bot2Bet);
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");
                                }

                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    if (bot2Bet == minBet)
                                    {
                                        Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                    }
                                    else
                                    {
                                        bot2Active = false;
                                        Console.WriteLine($"{bot2Name} har gett upp");
                                    }
                                }
                                if (betRound == 5 && botBet != minBet)
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                                betRound += 1;
                            }
                        }
                        else if(playerActive == true && botActive == true && bot2Active == true)
                        {
                            deckCards = newDeckCard(cards, deckCards, betRound);
                            Console.WriteLine($"{botName} lägger ut ett nytt kort på bordet");
                            Console.WriteLine($"{deckCards[0]}, {deckCards[1]}, {deckCards[2]}, {deckCards[3]}, {deckCards[4]}");
                            while (betRound < 6)
                            {
                                int minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet)); //Kollar vem som har bettat mest
                                if (betRound == 4)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{bot2Name} har bettat {bot2Bet} kr");

                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    Console.WriteLine($"Du har bettat {playerBet} kr");
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));

                                    botBet = botBetMoney(botCards, deckCards, betRound, botCardValue, botMoney, botBet, minBet);
                                    minBet = Math.Max(playerBet, Math.Max(botBet, bot2Bet));
                                    Console.WriteLine($"{botName} har bettat {botBet} kr");
                                }

                                if (betRound == 5 && bot2Bet != minBet)
                                {
                                    bot2Bet = botBetMoney(bot2Cards, deckCards, betRound, bot2CardValue, bot2Money, bot2Bet, minBet);
                                    if (bot2Bet == minBet)
                                    {
                                        Console.WriteLine($"{bot2Name} har lagt in {bot2Bet} kr");
                                    }
                                    else
                                    {
                                        bot2Active = false;
                                        Console.WriteLine($"{bot2Name} har gett upp");
                                    }
                                }
                                if (betRound == 5 && playerBet != minBet)
                                {
                                    playerBet = playerBetMoney(playerBet, playerMoney, minBet, botName, botMoney, botBet, bot2Name, bot2Money, bot2Bet, betRound);
                                    if (playerBet < minBet)
                                    {
                                        playerActive = false;
                                    }
                                }
                                if (betRound == 5 && botBet != minBet)
                                {
                                    botActive = false;
                                    Console.WriteLine($"{botName} har gett upp");
                                }
                                betRound += 1;
                            }
                        }
                    }

                    if (bigBlind < maxBigBlind)
                    {
                        bigBlind += 5;              //Big blind ökar med 5
                        smallBlind = bigBlind / 2;  //Small blind blir hälften av big blind
                        Console.WriteLine($"Big blind ökar nu med 5 kr, big blind är nu mera {bigBlind} kr och small blind är nu {smallBlind} kr");
                        
                    }

                    
                    dealer = 0;  //dealer blir 0 och cykeln om vem som delar ut kort börjar om
                }

                if(betRound == 6) //Om bettingrunda 6 har nåtts så kollas alla spelarnas kort
                {
                    playerCardValue = checkCards(playerCards, deckCards, betRound, playerCardValue);
                    botCardValue = checkCards(botCards, deckCards, betRound, botCardValue);
                    bot2CardValue = checkCards(bot2Cards, deckCards, betRound, bot2CardValue);
                }
               
                bettedMoney = playerBet + botBet + bot2Bet;
                if(playerActive == true && botActive == false && bot2Active == false && betRound < 6) //Om spelaren är den enda kvar i slutet av rundan
                {
                    Console.WriteLine($"{botName} och {bot2Name} har lagt sig och du vinner {bettedMoney} kr");
                    playerMoney += bettedMoney; //Du får den totala summan bettade pengar
                    //Alla spelarna blir av med de pengarna de har bettat
                    playerMoney -= playerBet;
                    botMoney -= botBet;
                    bot2Money -= bot2Bet;
                }
                else if(botActive == true && playerActive == false && bot2Active == false && betRound < 6) //Om dator 1 är den enda kvar i slutet av rundan
                {
                    Console.WriteLine($"Du och {bot2Name} har lagt sig och {botName} vinner {bettedMoney} kr");
                    botMoney += bettedMoney; //Dator 1 får totala summan bettade pengar
                    //Alla spelarna blir av med de pengar de har bettat
                    botMoney -= botBet;
                    playerMoney -= playerBet;
                    bot2Money -= bot2Bet;
                }
                else if(bot2Active == true && playerActive == false && botActive == false && betRound < 6) //Om dator 2 är den enda kvar i slutet av rundan
                {
                    Console.WriteLine($"Du och {botName} har lagt sig och {bot2Name} vinner {bettedMoney} kr");
                    bot2Money += bettedMoney; //Dator 2 får totala summan bettade pengar
                    //Alla spelarna blir av med de pengar de har bettat
                    bot2Money -= bot2Bet;
                    playerMoney -= playerBet;
                    botMoney -= botBet;
                }
                else if(betRound == 6 && Int32.Parse(playerCardValue[0]) > Int32.Parse(botCardValue[0]) && Int32.Parse(playerCardValue[0]) > Int32.Parse(bot2CardValue[0]) && playerActive == true) //Om spelaren har högst hand
                {
                    Console.WriteLine($"Din högsta hand är {playerCardValue[1]}, {botName}s största hand är {botCardValue[1]} och {bot2Name}s största hand är {bot2CardValue[1]}");
                    Console.WriteLine($"Du har högst hand och vinner {bettedMoney} kr");
                    playerMoney += bettedMoney; //Spelaren får den totala summan bettade pengar
                    //Alla spelarna blir av med de pengar de har bettat
                    playerMoney -= playerBet;
                    botMoney -= botBet;
                    bot2Money -= bot2Bet;
                }
                else if (betRound == 6 && Int32.Parse(botCardValue[0]) > Int32.Parse(playerCardValue[0]) && Int32.Parse(botCardValue[0]) > Int32.Parse(bot2CardValue[0]) && botActive == true) //Om dator 1 har högst hand
                {
                    Console.WriteLine($"Din högsta hand är {playerCardValue[1]}, {botName}s största hand är {botCardValue[1]} och {bot2Name}s största hand är {bot2CardValue[1]}");
                    Console.WriteLine($"{botName} har högst hand och vinner {bettedMoney} kr");
                    botMoney += bettedMoney; //Dator 1 får den totala summan bettade pengar
                    //Alla spelarna blir av med de pengar de har bettat
                    botMoney -= botBet;
                    playerMoney -= playerBet;
                    bot2Money -= bot2Bet;
                }
                else if (betRound == 6 && Int32.Parse(bot2CardValue[0]) > Int32.Parse(playerCardValue[0]) && Int32.Parse(bot2CardValue[0]) > Int32.Parse(botCardValue[0]) && bot2Active == true) //Om dator 2 har högst hand
                {
                    Console.WriteLine($"Din högsta hand är {playerCardValue[1]}, {botName}s största hand är {botCardValue[1]} och {bot2Name}s största hand är {bot2CardValue[1]}");
                    Console.WriteLine($"{bot2Name} har högst hand och vinner {bettedMoney} kr");
                    bot2Money += bettedMoney; //Dator 2 får den totala summan bettade pengar
                    //Alla spelarna blir av med de pengar de har bettat
                    bot2Money -= bot2Bet;
                    playerMoney -= playerBet;
                    botMoney -= botBet;
                }
                else if(betRound == 6 && Int32.Parse(botCardValue[0]) == Int32.Parse(playerCardValue[0]) && playerActive == true && botActive == true) //Om du och dator 1 har samma värde på eran hand
                {
                    Console.WriteLine($"Din högsta hand är {playerCardValue[1]}, {botName}s största hand är {botCardValue[1]} och {bot2Name}s största hand är {bot2CardValue[1]}");
                    Console.WriteLine($"Du och {botName} har lika bra kort och får dela på {bettedMoney} kr");
                    playerMoney += bettedMoney / 2; //Spelaren får hälften av den totala summan bettade pengar
                    botMoney += bettedMoney / 2; //Dator 1 får hälften av den totala summan bettade pengar
                    //Alla spelarna blir av med de pengar de har bettat
                    bot2Money -= bot2Bet;
                    playerMoney -= playerBet;
                    botMoney -= botBet;
                }
                else if (betRound == 6 && Int32.Parse(bot2CardValue[0]) == Int32.Parse(playerCardValue[0]) && playerActive == true && bot2Active == true) //Om du och dator 2 har samma värde på eran hand
                {
                    Console.WriteLine($"Din högsta hand är {playerCardValue[1]}, {botName}s största hand är {botCardValue[1]} och {bot2Name}s största hand är {bot2CardValue[1]}");
                    Console.WriteLine($"Du och {bot2Name} har lika bra kort och får dela på {bettedMoney} kr");
                    playerMoney += bettedMoney / 2; //Spelaren får hälften av den totala summan bettade pengar
                    bot2Money += bettedMoney / 2; //Dator 2 får hälften av den totala summan bettade pengar
                    //Alla spelarna blir av med de pengar de har bettat
                    bot2Money -= bot2Bet;
                    playerMoney -= playerBet;
                    botMoney -= botBet;
                }
                else if (betRound == 6 && Int32.Parse(botCardValue[0]) == Int32.Parse(bot2CardValue[0]) && botActive == true && bot2Active == true) //Om dator 1 och dator 2 har samma värde på eran hand
                {
                    Console.WriteLine($"Din högsta hand är {playerCardValue[1]}, {botName}s största hand är {botCardValue[1]} och {bot2Name}s största hand är {bot2CardValue[1]}");
                    Console.WriteLine($"{bot2Name} och {botName} har lika bra kort och får dela på {bettedMoney} kr");
                    botMoney += bettedMoney / 2; //Dator 1 får hälften av den totala summan bettade pengar
                    bot2Money += bettedMoney / 2; //Dator 2 får hälften av den totala summan bettade pengar
                    //Alla spelarna blir av med de pengar de har bettat
                    bot2Money -= bot2Bet;
                    playerMoney -= playerBet;
                    botMoney -= botBet;
                }

                round += 1; //Ökar rundan med 1
                dealer += 1; //Dealer ökar med 1

                Console.ReadLine();
                Console.Clear(); 
            }
            System.Threading.Thread.Sleep(sleepTime);
            Console.WriteLine($"{botName} och {bot2Name} har slut på pengar, grattis du vann!");

        }

        static string randomizeBotName(List<string> botNames, string assignedName, string name) //En funktion som ger ett slumpmässigt namn till datorn
        {
            Random rd = new Random();   
            assignedName = botNames[rd.Next(0, botNames.Count)]; //Slumpar ett namn från listan
            botNames.Remove(assignedName); //Tar bort namnet ur listan som datorn fick
            return assignedName;
        }

        static string[] drawCards(List<string> cards,  string[] playerCards) //En funktion som ger ut 2 kort till spelarna
        {
            Random rd = new Random();
            for (int j = 0; j < playerCards.Length; j++)
            {
                playerCards[j] = cards[rd.Next(0, cards.Count)]; //Ger ett slumpmässigt kort 
                cards.Remove(playerCards[j]);                    //Tar bort det slumpmässiga kort man fick ur listan
            }

           return playerCards; //Returnerar arrayen "playerCards" med 2 kort
        }

        static string[] drawDeck(List<string> cards, string[] deckCards) //En funktion som ger ut 3 kort på bordet
        {
            
            Random rd = new Random();
            for (int i = 0; i < 3; i++)
            {
                deckCards[i] = cards[rd.Next(0, cards.Count)]; //Ger ett slumpmässigt kort 
                cards.Remove(deckCards[i]);                    //Tar bort det slumpmässiga kort man fick ur listan
            }
            
            return deckCards; //Returnerar arrayen "deckCards" med 3 kort
        }

        static string[] newDeckCard(List<string> cards, string[] deckCards, int betRound) //En funktion som ger ut ett nytt kort på bordet
        {
            
            Random rd = new Random();
            if (betRound == 2) //Om bettrundan är 2 så läggs ett kort till på plats 3 i listan
            {
                deckCards[3] = cards[rd.Next(0, cards.Count)];
                cards.Remove(deckCards[3]);
            }
            else if(betRound == 4) //Om betturdan är 4 så läggs ett kort till på plats 4 i listan
            {
                deckCards[4] = cards[rd.Next(0, cards.Count)];
                cards.Remove(deckCards[4]);
            }
            return deckCards;
        }

        static int playerBetMoney(int playerBet, int playerMoney, int minBet, string botName, int botMoney, int botBet, string bot2Name, int bot2Money, int bot2Bet, int betRound) //En funktion som styr spelarens bett
        {
            int tempBet = playerBet; //En temporär int för spelarens bett

            //Spelarnas nuvarande pengar de har kvar
            int playerCurrentMoney = playerMoney - playerBet;
            int botCurrentMoney = botMoney - botBet;
            int bot2CurrentMoney = bot2Money - bot2Bet;

            int minimumToAdd = minBet - playerBet;
            if (betRound == 0 || betRound == 2 ||  betRound == 4) //Om bettrundan är 0, 2 eller 4 så skrivs en text ut
            {
                Console.WriteLine($"Du har {playerCurrentMoney} kr kvar, {botName} har {botCurrentMoney} kr kvar, {bot2Name} har {bot2CurrentMoney} kr kvar");
                if (tempBet == minBet)
                {
                    Console.WriteLine($"Du har lagt in {tempBet} kr, högsta betten är {minBet} kr, vill du höja, eller lägga in {minBet - tempBet} kr?"); //Om man har högsta betten så skrivs en text ut
                }
                else if (betRound == 0 || betRound == 2 || betRound == 4)
                {
                    Console.WriteLine($"Du har lagt in {tempBet} kr, högsta betten är {minBet} kr, vill du höja, lägga dig (0kr) eller lägga in {minimumToAdd} kr?"); //Om man inte har högsta betten skrivs en annan text ut
                }
               
                try
                {
                    tempBet += int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Du får bara använda dig av heltal och inga bokstäver!");
                    tempBet += int.Parse(Console.ReadLine());
                }

                while (tempBet < minBet && tempBet > playerBet || tempBet > playerMoney)
                {
                    Console.WriteLine($"Ditt bett är inkorrekt, du får inte lägga in mer än {playerCurrentMoney} kr, mindre än {minimumToAdd} kr och större än 0 kr");
                    tempBet = playerBet;
                    tempBet += int.Parse(Console.ReadLine());
                }
            }
            else if(betRound == 1 || betRound == 3 ||  betRound == 5) //Om bettrundan är 1, 3 eller 5 så skrivs en annan text ut
            {
                Console.WriteLine($"Du har inte lagt in tillräckligt för att vara med, du måste lägga in {minimumToAdd} kr eller lägga dig (0kr)");
                try
                {
                    tempBet += int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Du får bara använda dig av heltal och inga bokstäver!");
                    tempBet += int.Parse(Console.ReadLine());
                }
                while (tempBet < minBet && tempBet > playerBet || tempBet > playerMoney || tempBet > minBet)
                {
                    Console.WriteLine($"Ditt bett är inkorrekt, du måste lägga in {minimumToAdd} kr eller lägga dig (0kr)");
                    tempBet = playerBet;
                    tempBet += int.Parse(Console.ReadLine());
                }
            }
            //Lägger till det temporära bettet in i spelarens bett och returnerar det värdet
            playerBet = tempBet;
            return playerBet;
        }
        
        static int botBetMoney(string[] playerCards, string[] deckCards, int betRound, string[] cardValue, int botMoney, int botBet, int minBet) //En funktion som ger ut ett värde på vad datorn ska betta
        {
            Random rnd = new Random();
            cardValue = checkCards(playerCards, deckCards, betRound, cardValue);
            int tempCardValue = Int32.Parse(cardValue[0]);
            int botCurrentMoney = botMoney - botBet;
           
            int round0MaxBet = botCurrentMoney / 6;    //Hur mycket datorn mest kan höja runda 0
            int round0Bet = rnd.Next(0, round0MaxBet); //Hur mycket datorn ska höja runda 0

            int round2MaxBet = botCurrentMoney / 4;    //Hur mycket datorn mest ska höja runda 2
            int round2Bet = rnd.Next(0, round2MaxBet); //Hur mycket datorn ska höja runda 2

            int round4MaxBet = botCurrentMoney / 2;    //Hur mycket datorn mest ska höja runda 2
            int round4Bet = rnd.Next(0, round4MaxBet); //Hur mycket datorn ska höja runda 2

            if (betRound == 0)
            {
                if (tempCardValue == 338 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)                                  //Om spelaren har en royal straight flush
                {
                    botBet = minBet + round0Bet;
                }
                else if (tempCardValue >= 302 && tempCardValue <= 337 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)     //Om spelaren har en straight flush
                {
                    botBet = minBet + round0Bet;
                }
                else if(tempCardValue >= 234 && tempCardValue <= 282 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)      //Om spelaren har ett fyrtal
                {
                    botBet = minBet + round0Bet;
                }
                else if(tempCardValue >= 170 && tempCardValue <= 226 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)      //Om spelaren har en kåk
                {
                    botBet = minBet + round0Bet;
                }
                else if(tempCardValue == 158 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)                              //Om spelaren har färg
                {
                    botBet = minBet + round0Bet;
                }
                else if(tempCardValue >= 117 && tempCardValue <= 157 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)      //Om spelaren har stege
                {
                    botBet = minBet + round0Bet;
                }
                else if(tempCardValue >= 61 && tempCardValue <= 97 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)        //Om spelaren har triss
                {
                    botBet = minBet + round0Bet;
                }
                else if(tempCardValue >= 33 && tempCardValue <= 55 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)        //Om spelaren har två par
                {
                    botBet = minBet + round0Bet / 2;
                }
                else if(tempCardValue >= 16 && tempCardValue <= 28 && minBet + round0Bet < botCurrentMoney && rnd.Next(3) == 2)        //Om spelaren har par
                {
                    botBet = minBet + round0Bet / 2;
                }
                else if(tempCardValue > 12 && botBet < minBet)                                                            //Om spelaren har ett kortvärde som är större än 14 går datorn med
                {
                    botBet = minBet;
                }
                else if(rnd.Next(3) == 2 && botBet < minBet)         //Om spelaren inte har något bättre än kortvärdet 14 så slumpas det ifall datorn ska lägga in minsta möjliga betten eller inte
                {
                    botBet = minBet;
                }
            }
            else if(betRound == 1 || betRound == 3 || betRound == 5)
            {
                if(rnd.Next(4) == 1 && minBet < botCurrentMoney)
                {
                    botBet = minBet;
                }
                
            }
            else if(betRound == 2)
            {
                
                if (tempCardValue == 338 && minBet + round2Bet! < botCurrentMoney)                                                  //Om spelaren har en royal straight flush
                {
                    botBet = minBet + round2Bet;
                }
                else if (tempCardValue >= 302 && tempCardValue <= 337 && minBet + round2Bet < botCurrentMoney)                     //Om spelaren har en straight flush
                {
                    botBet = minBet + round2Bet;
                }
                else if (tempCardValue >= 234 && tempCardValue <= 282 && minBet + round2Bet < botCurrentMoney)                      //Om spelaren har ett fyrtal
                {
                    botBet = minBet + round2Bet;
                }
                else if (tempCardValue >= 170 && tempCardValue <= 226 && minBet + round2Bet < botCurrentMoney)                      //Om spelaren har en kåk
                {
                    botBet = minBet + round2Bet;
                }
                else if (tempCardValue == 158 && minBet + round2Bet < botCurrentMoney)                                              //Om spelaren har färg
                {
                    botBet = minBet + round2Bet;
                }
                else if (tempCardValue >= 117 && tempCardValue <= 157 && minBet + round2Bet < botCurrentMoney)                      //Om spelaren har stege
                {
                    botBet = minBet + round2Bet;
                }
                else if (tempCardValue >= 61 && tempCardValue <= 97 && minBet + round2Bet < botCurrentMoney)    //Om spelaren har triss
                {
                    botBet = minBet + round2Bet;
                }
                else if (tempCardValue >= 33 && tempCardValue <= 55 && minBet + round2Bet < botCurrentMoney)    //Om spelaren har två par
                {
                    botBet = minBet + round2Bet / 2;
                }
                else if (tempCardValue >= 16 && tempCardValue <= 28 && minBet + round2Bet < botCurrentMoney)    //Om spelaren har par
                {
                    botBet = minBet + round2Bet / 2;
                }
                else if (tempCardValue > 14 && minBet < botCurrentMoney)                                                            //Om spelaren har ett kortvärde som är större än 14 går datorn med
                {
                    botBet = minBet;
                }
                else if (rnd.Next(2) == 0 && minBet < botCurrentMoney)                                   //Om spelaren inte har något bättre än kortvärdet 14 så slumpas det ifall datorn ska lägga in minsta möjliga betten eller inte
                {
                    botBet = minBet;
                }
            }
            else if(betRound == 4)
            {
                if (tempCardValue == 338 && minBet + round4Bet! < botCurrentMoney)                                                  //Om spelaren har en royal straight flush
                {
                    botBet = minBet + round4Bet;
                }
                else if (tempCardValue >= 302 && tempCardValue <= 337 && minBet + round4Bet < botCurrentMoney)                     //Om spelaren har en straight flush
                {
                    botBet = minBet + round4Bet;
                }
                else if (tempCardValue >= 234 && tempCardValue <= 282 && minBet + round4Bet < botCurrentMoney)                      //Om spelaren har ett fyrtal
                {
                    botBet = minBet + round4Bet;
                }
                else if (tempCardValue >= 170 && tempCardValue <= 226 && minBet + round4Bet < botCurrentMoney)                      //Om spelaren har en kåk
                {
                    botBet = minBet + round4Bet;
                }
                else if (tempCardValue == 158 && minBet + round4Bet < botCurrentMoney)                                              //Om spelaren har färg
                {
                    botBet = minBet + round4Bet;
                }
                else if (tempCardValue >= 117 && tempCardValue <= 157 && minBet + round4Bet < botCurrentMoney)                      //Om spelaren har stege
                {
                    botBet = minBet + round4Bet;
                }
                else if (tempCardValue >= 61 && tempCardValue <= 97 && minBet + round4Bet < botCurrentMoney)    //Om spelaren har triss
                {
                    botBet = minBet + round4Bet;
                }
                else if (tempCardValue >= 33 && tempCardValue <= 55 && minBet + round4Bet < botCurrentMoney)    //Om spelaren har två par
                {
                    botBet = minBet + round4Bet / 2;
                }
                else if (tempCardValue >= 16 && tempCardValue <= 28 && minBet + round4Bet / 2 < botCurrentMoney)    //Om spelaren har par
                {
                    botBet = minBet + round4Bet / 2;
                }
                else if (tempCardValue > 14 && minBet < botCurrentMoney)            //Om spelaren har ett kortvärde som är större än 14 går datorn med
                {
                    botBet = minBet;
                }
                else if (rnd.Next(3) == 0 && minBet < botCurrentMoney)           //Om spelaren inte har något bättre än kortvärdet 14 så slumpas det ifall datorn ska lägga in minsta möjliga betten eller inte
                {
                    botBet = minBet;
                }
            }
            return botBet;
        }

        static string[] checkCards(string[] playerCards, string[] deckCards, int betRound, string[] cardValue) //En funktion som ger tillbaks ett värde på spelarens hand i både nummer och text
        {
            int tempCardValue = 0;  //En temporär int för värdet på spelarens kort 

            string[] cardLetters = { "knekt", "dam", "kung", "ess" }; 
            int[] cardLetterValues = { 11, 12, 13, 14 };                //En lista som innehåller värdena för "Knekt", "Dam", "Kung", och "Ess"
            int[] cardNumberValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };    //En lista som innehåller värdena för de 10 första korten
            string[] cardColors = { "spader", "ruter", "hjärter", "klöver" };
            

            for (int i = 0; i < deckCards.Length - 2; i++)
            {
                for (int a = 0; a < deckCards.Length - 2; a++)
                {
                    for (int w = 0; w < deckCards.Length - 2; w++)
                    {
                        for (int j = 0; j < playerCards.Length; j++)
                        {
                            for (int t = 0; t < playerCards.Length; t++)
                            {
                                for (int o = 0; o < cardColors.Length; o++)
                                {

                                    for (int g = 0; g < cardNumberValues.Length; g++)
                                    {
                                        for (int f = 0; f < cardNumberValues.Length; f++)
                                        {
                                            //Kollar vilket nummer spelarens kort har och de nummer de högsta kortet har de poängen får spelaren - (Högsta kortvärde)
                                            if (playerCards[j].Contains(cardNumberValues[g].ToString()) == true && tempCardValue < cardNumberValues[g])
                                            {
                                                tempCardValue = cardNumberValues[g];
                                                cardValue[1] = cardNumberValues[g].ToString();
                                            }

                                            //Kollar ifall det finns en kombination med din hand och bordet där du har 2 likadana kort - (Par)
                                            if (playerCards[j].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && tempCardValue < (cardNumberValues[g] + cardLetterValues[3]) || playerCards[t].Contains(cardNumberValues[g].ToString()) == true && playerCards[j].Contains(cardNumberValues[g].ToString()) == true && tempCardValue < (cardNumberValues[g] + cardLetterValues[3]) && playerCards[t] != playerCards[j])
                                            {
                                                tempCardValue = cardNumberValues[g] + cardLetterValues[3];
                                                cardValue[1] = "par i " + cardNumberValues[g].ToString();
                                            }

                                            //Kollar ifall det finns en kombination med bordet där man har två stycken par i 2-10 - (Två Par i 2- 10)
                                            if (playerCards[j].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].Contains(cardNumberValues[f].ToString()) == true && deckCards[a].Contains(cardNumberValues[f].ToString()) == true && tempCardValue < (cardNumberValues[g] + cardNumberValues[f] + 28) && playerCards[t] != playerCards[j] && deckCards[i] != deckCards[a] || playerCards[j].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[f].ToString()) == true && deckCards[a].Contains(cardNumberValues[f].ToString()) == true && tempCardValue < (cardNumberValues[g] + cardNumberValues[f] + 28) && playerCards[t] != playerCards[j] && deckCards[i] != deckCards[a])
                                            {
                                                tempCardValue = cardNumberValues[g] + cardNumberValues[f] + 28;
                                                cardValue[1] = "par i " + cardNumberValues[g].ToString() + " och par i " + cardNumberValues[f].ToString();
                                            }

                                            //Kollar ifall man har stege där båda ens kort(2-9) är lägst i stegen och alla kort på bordet är högst i stegen
                                            if (playerCards[j].Substring(playerCards[j].Length - 1) == cardNumberValues[g].ToString() && playerCards[t].Substring(playerCards[t].Length - 1) == cardNumberValues[g + 1].ToString() && deckCards[i].Substring(deckCards[i].Length - 1) == cardNumberValues[g + 2].ToString() && deckCards[a].Substring(deckCards[a].Length - 1) == cardNumberValues[g + 3].ToString() && deckCards[w].Substring(deckCards[w].Length - 1) == cardNumberValues[g + 4].ToString() && tempCardValue < (cardNumberValues[g] + cardNumberValues[g + 1] + cardNumberValues[g + 2] + cardNumberValues[g + 3] + cardNumberValues[g + 4] + 97))
                                            {
                                                tempCardValue = cardNumberValues[g] + cardNumberValues[g + 1] + cardNumberValues[g + 2] + cardNumberValues[g + 3] + cardNumberValues[g + 4] + 97;
                                                cardValue[1] = "stege med " + cardNumberValues[g].ToString() + ", " + cardNumberValues[g + 1].ToString() + ", " + cardNumberValues[g + 2].ToString() + ", " + cardNumberValues[g + 3].ToString() + ", " + cardNumberValues[g + 4].ToString();
                                            }

                                            //Kollar ifall båda ens kort och alla 3 kort på bordet har samma färg - (Färg)
                                            if (playerCards[j].ToUpper().Contains(cardColors[o].ToUpper()) == true && playerCards[t].ToUpper().Contains(cardColors[o].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardColors[o].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardColors[o].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardColors[o].ToUpper()) == true && playerCards[j] != playerCards[t] && deckCards[i] != deckCards[a] && deckCards[i] != deckCards[w] && deckCards[a] != deckCards[w] && tempCardValue < 158)
                                            {
                                                tempCardValue = 158;
                                                cardValue[1] = "färg i " + cardColors[o];
                                            }

                                            //Kollar ifall det finns en kombination med bordet där du har ett par av något (2-10) och en triss av någonting (2-10) - (Kåk)
                                            if (playerCards[0].Contains(cardNumberValues[g].ToString()) == true && playerCards[1].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[f].ToString()) == true && deckCards[a].Contains(cardNumberValues[f].ToString()) == true && deckCards[w].Contains(cardNumberValues[f].ToString()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardNumberValues[g] * 2  + cardNumberValues[f] * 3 + 158) || playerCards[j].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].Contains(cardNumberValues[f].ToString()) == true && deckCards[a].Contains(cardNumberValues[f].ToString()) == true && deckCards[w].Contains(cardNumberValues[f].ToString()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardNumberValues[g] * 2 + cardNumberValues[f] * 3 + 158) || deckCards[w].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].Contains(cardNumberValues[f].ToString()) == true && deckCards[a].Contains(cardNumberValues[f].ToString()) == true && playerCards[j].Contains(cardNumberValues[f].ToString()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && playerCards[t] != playerCards[j] && tempCardValue < (cardNumberValues[g] * 2 + cardNumberValues[f] * 3 + 158)) 
                                            { 
                                                tempCardValue = cardNumberValues[g] * 2 + cardNumberValues[f] * 3 + 158;
                                                cardValue[1] = "kåk med 2st " + cardNumberValues[g].ToString() + ":or, " + "och 3st " + cardNumberValues[f] + ":or";
                                            }

                                            //Kollar ifall man i kombination med bordet har 4 likadana kort(2-10) - (Fyrtal)
                                            if(playerCards[0].Contains(cardNumberValues[g].ToString()) == true && playerCards[1].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && deckCards[w].Contains(cardNumberValues[g].ToString()) == true && deckCards[i] != deckCards[w] && tempCardValue < (cardNumberValues[g] * 4 + 226))
                                            {
                                                tempCardValue = cardNumberValues[g] * 4 + 226;
                                                cardValue[1] = "fyrtal i " + cardNumberValues[g];
                                            }

                                            for (int h = 0; h < cardLetters.Length; h++)
                                            {

                                                for (int l = 0; l < cardLetters.Length; l++)
                                                {
                                                    //Kollar ifall det finns en kombination med korten på borden och handen där tre har samma värde (Knekt-Ess) - (Triss i Knekt - Ess)
                                                    if (playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardLetters[h].ToUpper()) && tempCardValue < (cardLetterValues[h] * 3 + 55) && deckCards[i] != deckCards[a] || playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[t].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardLetters[h].ToUpper()) && tempCardValue < (cardLetterValues[h] * 3 + 55) && playerCards[j] != playerCards[t])
                                                    {
                                                        tempCardValue = cardLetterValues[h] * 3 + 55;
                                                        cardValue[1] = "triss i " + cardLetters[h];
                                                    }

                                                    //Kollar ifall en av ens kort (2-10) matchar med två av korten (2-10) på bordet - (Triss i 2-10)
                                                    if (playerCards[j].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && deckCards[a].Contains(cardNumberValues[g].ToString()) == true && tempCardValue < (cardNumberValues[g] * 3 + 55) && deckCards[i] != deckCards[a] || playerCards[j].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].Contains(cardNumberValues[g].ToString()) == true && deckCards[a].Contains(cardNumberValues[g].ToString()) == true && tempCardValue < (cardNumberValues[g] * 3 + 55) && playerCards[j] != playerCards[t])
                                                    {
                                                        tempCardValue = cardNumberValues[g] * 3 + 55;
                                                        cardValue[1] = "triss i " + cardNumberValues[g].ToString();
                                                    }

                                                    //Kollar ifall det finns en kombination med bordet där du har ett par av något (Knekt-Ess) och en triss av någonting (Knekt-Ess) - (Kåk)
                                                    if (playerCards[0].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[1].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardLetterValues[h] * 2 + cardLetterValues[l] * 3 + 158) || playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[t].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardLetterValues[h] * 2 + cardLetterValues[l] * 3 + 158) || deckCards[w].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[t].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardLetters[l].ToUpper()) == true && playerCards[j].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardLetterValues[h] * 2 + cardLetterValues[l] * 3 + 158))
                                                    {
                                                        tempCardValue = cardLetterValues[h] * 2 + cardLetterValues[l] * 3 + 158;
                                                        cardValue[1] = "kåk med 2st " + cardLetters[h] + " och 3st " + cardLetters[l];
                                                    }

                                                    //Kollar ifall det finns en kombination med bordet där du har ett par av något (2-10) och en triss av någonting (Knekt-Ess) - (Kåk)
                                                    if (playerCards[0].Contains(cardNumberValues[g].ToString()) == true && playerCards[1].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardNumberValues[g] * 2 + cardLetterValues[l] * 3 + 158) || playerCards[j].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardNumberValues[g] * 2 + cardLetterValues[l] * 3 + 158) || deckCards[w].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[a].ToUpper().Contains(cardLetters[l].ToUpper()) == true && playerCards[j].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardNumberValues[g] * 2 + cardLetterValues[l] * 3 + 158))
                                                    {
                                                        tempCardValue = cardNumberValues[g] * 2 + cardLetterValues[l] * 3 + 158;
                                                        cardValue[1] = "kåk med 2st " + cardNumberValues[g].ToString() + ":or" + " och 3st " + cardLetters[l];
                                                    }

                                                    //Kollar ifall det finns en kombination med bordet där du har ett par av något (Knekt-Ess) och en triss av någonting (2-10) - (Kåk)
                                                    if (playerCards[0].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[1].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].Contains(cardNumberValues[f].ToString()) == true && deckCards[a].Contains(cardNumberValues[f].ToString()) == true && deckCards[w].Contains(cardNumberValues[f].ToString()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardLetterValues[h] * 2 + cardNumberValues[f] * 3 + 158) || playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[h]) == true && playerCards[t].Contains(cardNumberValues[f].ToString()) == true && deckCards[a].Contains(cardNumberValues[f].ToString()) == true && deckCards[w].Contains(cardNumberValues[f].ToString()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && tempCardValue < (cardLetterValues[h] * 2 + cardNumberValues[f] * 3 + 158) || deckCards[w].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[t].Contains(cardNumberValues[f].ToString()) == true && deckCards[a].Contains(cardNumberValues[f].ToString()) == true && playerCards[j].Contains(cardNumberValues[f].ToString()) == true && deckCards[i] != deckCards[w] && deckCards[i] != deckCards[a] && deckCards[w] != deckCards[a] && playerCards[t] != playerCards[j] && tempCardValue < (cardLetterValues[h] * 2 + cardNumberValues[f] * 3 + 158))
                                                    {
                                                        tempCardValue = cardLetterValues[h] * 2 + cardNumberValues[f] * 3 + 158;
                                                        cardValue[1] = "kåk med 2st " + cardLetters[h].ToString() + " och 3st " + cardNumberValues[f] + ":or";
                                                    }

                                                    //Kollar ifall det finns en kombination med bordet där alla kort (Knekt - Ess) är lika - (Fyrtal)
                                                    if (playerCards[0].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[1].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i] != deckCards[w] && tempCardValue < (cardLetterValues[h] * 4 + 226))
                                                    {
                                                        tempCardValue = cardLetterValues[h] * 4 + 226;
                                                        cardValue[1] = "fyrtal i " + cardLetters[h];
                                                    }

                                                    //Denna if-sats kollar ifall någon av spelarens kort är en Knekt, Dam, Kung eller Ess och om de är det får de sitt motsvarande värde - (Högsta kortvärde)
                                                    if (playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && tempCardValue < cardLetterValues[h])
                                                    {
                                                        tempCardValue = cardLetterValues[h];
                                                        cardValue[1] = cardLetters[h];
                                                    }

                                                    //Denna if-sats kollar om det finns en kombination med bordet där två kort är samma - (Par)
                                                    if (playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[h].ToUpper()) == true && tempCardValue < cardLetterValues[h] + cardLetterValues[3] || playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[t].ToUpper().Contains(cardLetters[h].ToUpper()) == true && tempCardValue < cardLetterValues[h] + cardLetterValues[3] && playerCards[j] != playerCards[t])
                                                    {
                                                        tempCardValue = cardLetterValues[h] + cardLetterValues[3];
                                                        cardValue[1] = "par i " + cardLetters[h];
                                                    }

                                                    //Denna if-sats kollar om det finns en kombination med bordet och handen där man har två par i (Knekt - Ess) - (Två Par i Knekt - Ess)
                                                    if (playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[t].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[l].ToUpper()) == true && tempCardValue < (cardLetterValues[h] + cardLetterValues[l] + 28) && playerCards[j] != playerCards[t] || playerCards[j].ToUpper().Contains(cardLetters[h].ToUpper()) == true && playerCards[t].ToUpper().Contains(cardLetters[h].ToUpper()) == true && deckCards[i].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[l].ToUpper()) == true && tempCardValue < (cardLetterValues[h] + cardLetterValues[l] + 28) && playerCards[j] != playerCards[t] && deckCards[i] != deckCards[w])
                                                    {
                                                        tempCardValue = cardLetterValues[h] + cardLetterValues[l] + 28;
                                                        cardValue[1] = "par i " + cardLetters[h] + " och par i " + cardLetters[l];
                                                    }

                                                    //Kollar ifall det finns en kombination med korten på bordet och handen där man har par i 2-10 och ett par i knekt-ess - (Två par)
                                                    if (playerCards[j].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[l].ToUpper()) == true && tempCardValue < (cardNumberValues[g] + cardLetterValues[l] + 28) && playerCards[j] != playerCards[t] || playerCards[j].Contains(cardNumberValues[g].ToString()) == true && playerCards[t].Contains(cardNumberValues[g].ToString()) == true && deckCards[i].ToUpper().Contains(cardLetters[l].ToUpper()) == true && deckCards[w].ToUpper().Contains(cardLetters[l].ToUpper()) == true && tempCardValue < (cardNumberValues[g] + cardLetterValues[l] + 28) && playerCards[j] != playerCards[t] && deckCards[i] != deckCards[w])
                                                    {
                                                        tempCardValue = cardNumberValues[g] + cardLetterValues[l] + 28;
                                                        cardValue[1] = "par i " + cardNumberValues[g].ToString() + " och par i " + cardLetters[l];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            cardValue[0] = tempCardValue.ToString(); //Lägger in den temporära int:en för spelarens värde på handen
            return cardValue;
        }

    }
}
