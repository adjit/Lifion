using System;
using System.Collections.Generic;

public class CheckSubs
{
    /*  Function doesn't need it's own class    */

	public CheckSubs(Dictionary<int, Subscriber> subscribersAR, List<Invoice> invoices)
	{
        /*  Couple of things here --
         *  
         *  subscribersAR will be a dictionary of subscribers using the Accounts_Receivable_ID
         *  as the key for easy AR access.
         *  
         *  Since the Database will handle account ageing and updating account balances
         *  and amounts due under 30 days and amounts due over 30 days, finding which
         *  subscribers are delinquent is a trivial process of checking which accounts
         *  have balances over 30 days.
         *  
         *  However, lets say it's ok to be over 30 days but under 60 days. The db
         *  doesn't have Over 60 days - you could add that data column in your database
         *  which will be updated by the ageing process and then again this would be a
         *  trivial process. Check if subscribers have amounts due over 60 days.
         *  
         *  For this case, will assume that the over 30 and under 30 variables are
         *  not available and need to check invoices
         * 
         */ 

        DateTime now = DateTime.Now.Date;

        Dictionary<int, List<Invoice>> delinquentSubs = new Dictionary<int, List<Invoice>>();

        for (int i = 0; i < invoices.Count; i++)
        {
            if (now.Subtract(invoices[i].invoiceDate).Days < 60) continue;
            else
            {
                List<Invoice> delinquentInvoices;
                int key = invoices[i].ARID;

                if (!delinquentSubs.TryGetValue(key, out delinquentInvoices))
                {
                    delinquentInvoices = new List<Invoice>();
                    delinquentSubs[key] = delinquentSubs;
                }

                /*  Could choose to notify the delinquent sub here, but what if they have multiple
                 *  invoices outstanding. Could result in multiple messages being sent. Why not just
                 *  collect all delinquent invoices and then send them all at once.                 * 
                 */ 

                delinquentSubs[key].Add(invoices[i]);
            }
        }

        foreach(var item in delinquentSubs)
        {
            subscribersAR[item.Key].notifyDelinquent(item.Value);
        }
	}
}

public class Payment
{
    public DateTime PaymentDate;
    public int PaymentAmount;
}

public class Invoice
{
    public DateTime invoiceDate;
    public int invoiceNumber;
    public int invoiceBalance;
    public int invoiceAmount;
    public int ARID;

    public Invoice(DateTime date, int num, int bal, int amt, int arID)
    {
        invoiceDate = date;
        invoiceNumber = num;
        invoiceBalance = bal;
        invoiceAmount = amt;
        ARID = arID;
    }
}

public class Accounts_Receivable
{
    int Amount_Due_Under_30;
    int Amount_Due_Over_30;
    List<Payment> Payments;

    public Accounts_Receivable(int ARID)
    {
        /*  Query Database for AR data including
         *  payments and load into class variables
         *  Database should take care of Ageing and
         *  updating and amount due
         */
    }
}

public class Contact_Information
{
    public string contact;
    public string address;
    public string city;
    public string state;
    public string zip;
    public string email;
    public string phone;
}

public class Subscriber
{
    /*  Only allow people to get variables
     *  Changes need to be handled by the class
     */

    private string _sub;
    private int _subID;
    private int _ARID;
    private Accounts_Receivable _AR;
    private Contact_Information _CI;

    public string subscriber { get { return _sub; } }
    public int subscriber_ID { get { return _subID; } }
    public int Accounts_Receivable_ID { get { return _ARID; } }
    public Accounts_Receivable AR { get { return _AR; } }
    public Contact_Information CI { get { return _CI; } }
    /*  Contacts, address's etc.
     *  Class will be passed all variables or make
     *  the proper function calls to retrieve the
     *  database information and gather it
     */

    public Subscriber(string sub, int subID, int arID)
    {
        /*  Basic constructor - only set subscriber and ID's  */

        _initialize(sub, subID, arID);
    }

    public Subscriber(bool get_AR, string sub, int subID, int arID)
    {
        /*  Overload Subscriber to load various
         *  items upon initialization. In this case:
         *  
         *  Flag to get AR upon initialization
         *  -   what if we didn't need that data?
         *      pointless to load it in otherwise
         *      
         *  Can add more flags in the future
         */
        _initialize(sub, subID, arID);
        _loadAR();
    }

    public void notifyDelinquent(List<Invoice> invoices)
    {
        /*  Send email / mail subscriber a delinquency notice of cancellation
         *  and delinquent invoices
         */
    }

    public void Load_Accounts_Receivable()
    {
        /* Function to use if you want to load in AR later
         * or refresh
         */

        _loadAR();
    }

    private void _initialize(string sub, int subID, int arID)
    {
        _sub = sub;
        _subID = subID;
        _ARID = arID;
    }

    private void _loadAR()
    {
        _AR = new Accounts_Receivable(_ARID);
    }
}
