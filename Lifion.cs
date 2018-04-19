using System;

public class Class1
{
    public class Payment
    {
        DateTime PaymentDate;
        int PaymentAmount;
    }

    public class Accounts_Receivable
    {
        int Accounts_Receivable_ID;
        int Amount_Under_30;
        int Amount_Over_30;
        List<Payment> Payments;
    }

    public class Subscribers
    {
        string Subscriber;
        int Subscriber_ID;
        Accounts_Receivable AR;
        /*  Contacts, address's etc.
         * 
         */

        public Subscribers() { }
    }

	public Class1()
	{


        DateTime now = DateTime.Now.Date;



        if(invoices[i].invoiceDate < )
	}
}
