using ConceptArchitect.Finance.V2;
using ConceptArchitect.Finance.V3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    public class ATM
    {
        private Bank bank;
        Input keyboard = new Input();
        private int accountNumber;
        //private string password;

        public ATM(Bank bank)
        {
            this.bank = bank;
        }

        public void Boot()
        {
            while (true)
            {
                try
                {
                    accountNumber = keyboard.GetInt("account number? ");

                    if (accountNumber == -1 && keyboard.GetString("password ?") == "NIMDA")
                    {
                        if (_ShowAdminMenu() == false)
                            return;
                    }
                    else
                        _ShowUserMenu();
                }
                catch(InvalidCredentialsException ex)
                {
                    Console.WriteLine(ex+"\tyour session is terminated");
                }
            }
        }

        private bool _ShowAdminMenu()
        {
            while (true)
            {
                int choice = keyboard.GetInt("1. Print List  2. Open Account  3. Credit Interset 99. STOP ATM 0. Exit ?");
                switch (choice)
                {
                    case 1:
                        bank.PrintAccountList();
                        break;
                    case 2:
                        _DoOpenAccount();
                        break;
                    case 3:
                        bank.CreditInterests();
                        break;
                    case 99:
                        return false;
                    case 0:
                        return true;

                    default:
                        Console.WriteLine("Invalid Choice. Retry");
                        break;


                }
            }
        }

        private void _DoOpenAccount()
        {
            String accountType = keyboard.GetString("Account Type?");
            String name = keyboard.GetString("Name?");
            String password = keyboard.GetString("password?");
            int openingBalance = keyboard.GetInt("Amount?");
            var accountNumber = bank.OpenAccount(accountType, name, password, openingBalance);
            _Display("New Account is Ready. Account number is " + accountNumber);

        }

        private void _ShowUserMenu()
        {

            while (true)
            {
                try
                {
                    int choice = keyboard.GetInt("1. Deposit  2. Withdraw 3. Show Balance 4. Transfer 5. Close 0. Exit ?");
                    switch (choice)
                    {
                        case 1:
                            _DoDeposit();
                            break;
                        case 2:
                            _DoWithdraw();
                            break;
                        case 3:
                            _DoShowBalance();
                            break;
                        case 4:
                            _DoTransfer();
                            break;
                        case 5:
                            _DoClose();
                            break;
                        case 0:
                            return;

                        default:
                            Console.WriteLine("Invalid Choice. Retry");
                            break;

                    }
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine("Insufficient Balance in {0}: Total Deficit is {1}", ex.AccountNumber, ex.Deficit);
                }
                catch(InvalidCredentialsException ex)
                {
                    //log the message
                    //throw ex; //this line will be considered as point of origin
                    throw; //retains the original point of origin
                }
                catch (BankingException ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine("Reached Finally");
                }

                //catch (InvalidAccountException ex)
                //{
                //    Console.WriteLine(ex);
                //}
                //catch(InvalidCredentialsException ex)
                //{
                //    Console.WriteLine(ex);
                //}
                //catch(InvalidDenominationException ex)
                //{
                //    Console.WriteLine(ex);
                //}
                //catch(InsufficientBalanceException ex)
                //{
                //    Console.WriteLine("Insufficient Balance in {0}: Total Deficit is {1}",ex.AccountNumber,ex.Deficit);
                //}
            }
        }

        private void _ShowUserMenuV1()
        {

            while (true)
            {
                try
                {
                    int choice = keyboard.GetInt("1. Deposit  2. Withdraw 3. Show Balance 4. Transfer 5. Close 0. Exit ?");
                    switch (choice)
                    {
                        case 1:
                            _DoDeposit();
                            break;
                        case 2:
                            _DoWithdraw();
                            break;
                        case 3:
                            _DoShowBalance();
                            break;
                        case 4:
                            _DoTransfer();
                            break;
                        case 5:
                            _DoClose();
                            break;
                        case 0:
                            return;

                        default:
                            Console.WriteLine("Invalid Choice. Retry");
                            break;

                    }
                }
                catch (InvalidAccountException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (InvalidCredentialsException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (InvalidDenominationException ex)
                {
                    Console.WriteLine(ex);
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine("Insufficient Balance in {0}: Total Deficit is {1}", ex.AccountNumber, ex.Deficit);
                }
            }
        }

        private void _DoClose()
        {
            string password = keyboard.GetString("password?");
            if (keyboard.GetString("TYPE: PLEASE CLOSE MY ACCOUNT") == "PLEASE CLSOE MY ACCOUNT")
            {
                bank.CloseAccount(accountNumber, password);
                _Display("Your account has been closed");

            }

        }

        private void _DoTransfer()
        {
            String password = keyboard.GetString("Password?");
            int amount = keyboard.GetInt("Amount?");
            int to = keyboard.GetInt("to ? ");
            bank.Transfer(accountNumber, password, amount, to);
            _Display("Fund Transferred");
        }

        private void _DoShowBalance()
        {
            string password = keyboard.GetString("Passoword");
            var account = bank.GetAccount(accountNumber, password);
            _Display("Balance is :" + account.Balance);
        }

        private void _DoWithdraw()
        {
            int amount = keyboard.GetInt("Amount?");
            string password = keyboard.GetString("Passoword");
            bank.Withdraw(accountNumber, password, amount);
            _DispenseCash(amount);

        }

        private void _DispenseCash(int amount)
        {
            Console.WriteLine("Please collect your cash :" + amount);
        }

        private void _DoDeposit()
        {
            int amount = keyboard.GetInt("Amount ?");
            bank.Deposit(accountNumber, amount);
            _Display("Amount Deposited");

        }

        private void _Display(string v)
        {
            Console.WriteLine(v);
        }
    }


}
