using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Bank
    {

        public List<int> AccountNumber { get; set; }

        public List<int> PinNumber { get; set; }

        public List<int> Balance { get; set; }

        public List<int> Counting { get; set; }

        public int CardInput;

        public void Start()
        {
            var CardIndex = CheckingCard(AccountNumber);

            var PinCheck = PinVerify(PinNumber, CardIndex);





        }

        public void BankingDetails()
        {
            Console.WriteLine("***************** WELCOME TO ATM BANKING-DEVELOPED BY TANVIR *****************\n");

            AccountNumber = new List<int>() { 255, 983, 456, 555 };

            PinNumber = new List<int>() { 7978, 0101, 5050, 111 };

            Balance = new List<int>() { 10000, 40000, 2000, 20000 };

            Counting = new List<int>() {0, 0, 0, 0};
        }


        public int CheckingCard(List<int> AccountNumber)
        {
            Console.Write("Please Enter your Account Number: ");

             CardInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < AccountNumber.Count; i++)
            {
                if (CardInput == AccountNumber[i])
                {
                    int CardNumberIndex = i;

                    return CardNumberIndex;
                }


            }
            Console.WriteLine("Account Number Wrong");
            return CheckingCard(AccountNumber);
        }

        public int PinVerify(List<int> PinNumber, int CardIndex)
        {
            Console.Write("Please Enter your Pin Number: ");

            var PinInput = int.Parse(Console.ReadLine());


            if (PinNumber[CardIndex] == PinInput)
            {
                ChooseTransaction(CardIndex);
            }


            Console.WriteLine("PIN Wrong");
            return CheckingCard(AccountNumber);
        }

        
        public void ChooseTransaction(int CardIndex)
        {
            
            Console.WriteLine("Please Choose Your Transaction: ");

            Console.WriteLine("\t1. Withdraw Money\n\t2. Balance Check\n\t3. Exit");

            Console.Write("Enter Your Choice Now: ");

            var choice = int.Parse(Console.ReadLine());

            // ***************WITHDRW MONEY CODE***********

            if (choice == 1)
            {


                Counting[CardIndex]++;

               

                if (Counting[CardIndex]>3)
                {
                    Console.WriteLine("You tried for 3 times.Try another ");
                    ChooseTransaction(CardIndex);
                    
                }

                else
                {
                    WithDraw(CardIndex, Balance);
                    

                }

                


            }
            else if (choice == 2)
            {
                BalanceCheck(CardIndex);

            }
            else if (choice == 3)
            {
                Exit();

            }
            else
            {
                Console.WriteLine("Sorry Wrong Choice.Try Again");
                ChooseTransaction(CardIndex);
            }
        }

        public void WithDraw(int CardIndex, List<int> Balance)
        {
            Console.Write("Enter Your amount:");

            var withdraw = int.Parse(Console.ReadLine());


            //var Balance1 = Balance[CardIndex];


            var CurrentBalance1 = Balance[CardIndex] - withdraw;

            Balance[CardIndex] = CurrentBalance1;

            if (CurrentBalance1 > 20)
            {


                Console.WriteLine("Success Withdraw. New Balance is: " + CurrentBalance1);

                Console.Write("Do you Want to Quit? Yes OR No: ");

                var quit1 = Console.ReadLine();

                if (quit1 == "yes")
                {
                    Environment.Exit(0);
                }
                else if (quit1 == "no")
                {
                    Console.WriteLine("OK.Try Again From Scratch");
                    ChooseTransaction(CardIndex);
                }
            }


        }

        public void BalanceCheck(int CardIndex)
        {
            Console.WriteLine("Your Balance is: " + Balance[CardIndex]);
            ChooseTransaction(CardIndex);
        }

        public void Exit()
        {
            //Environment.Exit(0);
            Start();
            
            


        }

    }
}
