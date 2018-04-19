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
        int Amount_Under_30;
        int Amount_Over_30;
        List<Payment> Payments;

        public Accounts_Receivable(int ARID)
    }

    public class Subscriber
    {
        /*  Only allow people to get variables
         *  Changes need to be handled by the class
         */

        private string _sub;
        private string _subID;
        private string _ARID;
        private Accounts_Receivable _AR;
        
        public string subscriber            { get { return _sub; } }
        public int subscriber_ID            { get { return _subID; } }
        public int Accounts_Receivable_ID   { get { return _ARID; } }
        public Accounts_Receivable AR       { get { return _AR; } }
        /*  Contacts, address's etc.
         *  Class will have functions to query the
         *  database and gather all of the information
         */

        public Subscriber() {
            /*  Basic constructor - only set subscriber and ID's  */
        }
        public Subscriber(bool get_AR) {
            /*  Overload Subscriber to load various
             *  items upon initialization. In this case:
             *  
             *  Flag to get AR upon initialization
             *  -   what if we didn't need that data?
             *      pointless to load it in otherwise
             *      
             *  Can add more flags in the future
             */
            _loadAR();
        }

        public void Load_Accounts_Receivable()
        {
            _loadAR();
        }

        private void _loadAR()
        {
            _AR = new Accounts_Receivable(_ARID);
        }
    }

	public Class1()
	{

        DateTime now = DateTime.Now.Date;
        
        if(invoices[i].invoiceDate < )
	}
}
