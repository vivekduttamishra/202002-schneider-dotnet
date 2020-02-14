
class TransactionException : BankingException{

	List<BankingException> errors=new List<BankingException> ();

}


public void Transfer(int from, string password, double amount, int to){

	TransactionException errors=new TransactionException();
	BankAccount src=null;
	BankAccount trgt=null;
	try{
		src=GetAccount(	from);
	}catch(Exception ex){
		errors.Add(ex);
	}

	try{
		trg=GetAccount(	from);
	}catch(Exception ex){
		errors.Add(ex);
	}

	try{
		src.Withdraw(amount,password);
	}catch(Exception ex){
		errors.Add(ex);
	}

	try{
		trgt.Deposit(amount);
	}catch(Exception ex){
		errors.Add(ex);
	}

	if(errors.errors.Size>0)
		throw errors;

}